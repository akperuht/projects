/**
 * AkiTimingSystem 
 * @version 2.3.0
 * @author Aki Ruhtinas
 * Versio 2.0 julkaistu 17.7.2016
 * 
 * Versio 2.1.0, julkaistu 19.8.2016
 *     -Tehty yhdellä laserilla ajanoton käynnitys sekä lopetus (moodi a)
 * Päivitys 2.1.2, julkaistu 22.8.2016
 *     -muokattu ajan näyttämistä
 *     
 * Versio 2.2.0, julkaistu 25.8.2016
 *    -lisätty hyppykorkeuden määrittäminen
 * Päivitys 2.2.1, julkaistu 29.8.2016
 *    -lisätty 3cm korjausmoodi hyppykorkeuteen
 * Versio 2.3.0, julkaistu 27.11.2016
 *    -lisätty USB-datankeräys
 * Versio 2.3.1, julkaistu 3.1.2017
 *    -muutettu äänirajaa 0.15 -> 0.30
 * HUOM! kehitysversio
 */
#include <Key.h>
#include <Keypad.h>

#include <Wire.h>
#include <LiquidCrystal_I2C.h>

// Alustetaan naytto
LiquidCrystal_I2C lcd(0x3F,2,1,0,4,5,6,7,3, POSITIVE);
// Alustetaan muuttujat
const int mikrofoniPinni = 0;
const int valoPinni1=1;
const int valoPinni2=2;
const int punLEDPinni=10;
const int vihLEDPinni=11;
const double VALI_MATKA=12.25; //Välimatka senttimetreinä 

//antureiden rajat
const int LIGHT_TRESHOLD=0.15;
const int SOUND_TRESHOLD=0.15;

int aanenVoimakkuus;
int valonVoimakkuus=1000;
int valonVoimakkuus2;
int aaniRaja=600;
int valoRaja=1000;
int valoRaja2=1000;
char moodi;

//Alustetaan nappaimisto
const byte RIVIT = 4; 
const byte KOLUMNIT = 4; 
// Maaritetaan nappaimiston merkit
char keys[RIVIT][KOLUMNIT] = {
  {'e','f','g','h'},
  {'a','b','c','d'},
  {'5','6','7','8'},
  {'1','2','3','4'}
};
// Maaritetaan mihin pinneihin kytketaan
byte riviPinni[RIVIT] = { 2, 3, 4, 5 };
byte colPinni[KOLUMNIT] = { 6, 7, 8 ,9}; 

// Luodaan nappaimisto
Keypad nappaimisto = Keypad( makeKeymap(keys), riviPinni, colPinni, RIVIT, KOLUMNIT );

bool tila=false; // Jos false niin laskuri ei ole kaynnissa
bool looppi=false; // Jos false niin loop() ei ole viela aloittanut
unsigned long aloitusAika=0;
unsigned long lopetusAika=0;

/**
 * Tehdään alustukset
 */
void setup()
{
  pinMode(mikrofoniPinni, INPUT);
  pinMode(valoPinni1, INPUT);
  lcd.begin (16,2);
  
  //Alustetaan LED:it
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  digitalWrite(punLEDPinni,HIGH);

  lcd.clear();
  lcd.setBacklight(HIGH);
  lcd.setCursor(0,0);
  lcd.print("AkiTimingSystem");
  lcd.setCursor(0,1);
  lcd.print("    v2.3.1");
  delay(3000);

  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("Copyright");
  lcd.setCursor(0,1);
  lcd.print("Aki Ruhtinas");
  delay(3000);
  
  //Kalibroidaan sensorit vallitsevan valon ja äänen mukaan
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("Kalibroidaan ");
  lcd.setCursor(0,1);
  lcd.print("sensoreita...");
  delay(1800);
  aaniRaja=analogRead(mikrofoniPinni)+0.30*analogRead(mikrofoniPinni);// raja 125%
  valoRaja=analogRead(valoPinni1)-0.50*analogRead(valoPinni1);//raja 75%
  valoRaja2=analogRead(valoPinni2)-0.15*analogRead(valoPinni2);//raja 75%
  delay(200);

  lcd.clear();
}
/**
 * looppia toistetaan koko ohjelman käynnissäoloajan
 * jos looppi on false niin määritetään moodia ja jos looppi on true niin toistetaan valittua moodia
 */
void loop()
{
  switch(looppi){
    case false:
    MaaritaMoodi();
    break;
  
    case true:
    break;
  } 
  switch(moodi){
      case '1':
      AaniValo();
      break;

      case '2':
      AaniAani();
      break;

      case '3':
      NappiNappi();
      break;

      case '4':
      ValoValo();
      break;

      case '5':
      looppi=false;
      break;

      case '6':
      looppi=false;
      break;

      case '7':
      looppi=false;
      break;

      case '8':
      kalibroi();
      break;

      case 'a':
      Valo();
      break;

      case 'b':
      HyppyKorkeus();
      break;

      case 'c':
      HyppyKorkeus3CM();
      break;

      case 'd':
      sarjaLiikenne(true, 1, 1000);  //viive mikrosekunneissa
      break;

      case 'e':
      sarjaLiikenne(false, 1, 1002);
      break;

      case 'f':
      sarjaLiikenne(false, 2, 965);
      break;

      case 'g':
      sarjaLiikenneNopea(1);
      break;

      case 'h':
      sarjaLiikenneNopea(2);
      break;
      
  }
}
/**
 * Moodi 1
 * Äänirajan ylitys käynnistää ajanoton ja laserin katkeaminen lopettaa ajanoton
 */
void AaniValo(){
 
      switch (tila){      
      case false: 
      aanenVoimakkuus = analogRead(mikrofoniPinni);
      if(aanenVoimakkuus>aaniRaja){
      Aloitus();
      lcd.clear(); 
      }
      break;
      
      case true:
      valonVoimakkuus = analogRead(valoPinni1);
      if(valonVoimakkuus<valoRaja){
      LopetusMs();
      }
      break;   
    }
    naytaAika();
}

/**
 * Moodi 2
 * Äänirajan ylitys käynnistää ajanoton ja lopettaa ajanoton
 */
void AaniAani(){
    aanenVoimakkuus = analogRead(mikrofoniPinni);

    if(aanenVoimakkuus>aaniRaja){
      
      switch (tila){  
      case false:
      Aloitus();
      lcd.clear(); 
      delay(100);
      break;
      
      case true:
      LopetusMs();
      break;
      
      }
    }
    else{
        naytaAika();
    }
}

/**
 * Moodi 3
 * Näppäin 5 käynnistää ja pysäyttää ajanoton
 */
void NappiNappi(){
  char key = nappaimisto.getKey();
  if(key=='5'){
    switch(tila){
      case false:
      Aloitus();
      break;
      
      case true:
      LopetusMs();
      break;
  }
  }
  else{
    naytaAika();
  }
}

/**
 * Valoanturi 1 aloittaa ajanoton ja valoanturi 2 katkaisee ajanoton
 */
void ValoValo(){
      switch (tila){      
      case false: 
      valonVoimakkuus = analogRead(valoPinni1);
      if(valonVoimakkuus<valoRaja){
      aloitusAika=micros();
      tila=true;
      }
      break;
      
      case true:
      valonVoimakkuus2 = analogRead(valoPinni2);
      if(valonVoimakkuus2<valoRaja2){
      //if(valonVoimakkuus2>1){
      lopetusAika=micros();
      LopetusUs();
      }
      break;   
    }
}

/**
 * Anturi 1 aloittaa ja katkaisee ajanoton
 */
void Valo(){
    valonVoimakkuus = analogRead(valoPinni1);

    if(valonVoimakkuus<valoRaja){
      
      switch (tila){  
      case false:
      Aloitus();
      lcd.clear(); 
      delay(500);
      break;
      
      case true:
      LopetusMs();
      break;
      
      }
    }
    else{
        naytaAika();
    };
}

/**
 * Lasketaan kevennyshypyn korkeus
 */
 void HyppyKorkeus(){
  int valoNyt = analogRead(valoPinni1);
  if(valoNyt>=valoRaja&&valonVoimakkuus<valoRaja){
    aloitusAika=millis();
    tila=true;
    digitalWrite(punLEDPinni,LOW);
    digitalWrite(vihLEDPinni,HIGH);
  }
  if(valoNyt<=valoRaja&&valonVoimakkuus>valoRaja){
    lopetusAika=millis();
    tila=false;
    lcd.clear();
    unsigned long aika = lopetusAika-aloitusAika;
    double korkeus=LaskeKorkeus(aika);
    lcd.setCursor(2,0);
    lcd.print("Hypyn korkeus");
    lcd.setCursor(4,1);
    lcd.print(korkeus,3);
    lcd.print(" cm");
    
    digitalWrite(punLEDPinni,HIGH);
    digitalWrite(vihLEDPinni,LOW);
  }
 valonVoimakkuus=valoNyt;
 }

 /**
 * Lasketaan kevennyshypyn korkeus
 * Laser-säde on keskimäärin 29mm lattiasta
 */
 void HyppyKorkeus3CM(){
  int valoNyt = analogRead(valoPinni1);
  if(valoNyt>=valoRaja&&valonVoimakkuus<valoRaja){
    aloitusAika=millis();
    tila=true;
    digitalWrite(punLEDPinni,LOW);
    digitalWrite(vihLEDPinni,HIGH);
  }
  if(valoNyt<=valoRaja&&valonVoimakkuus>valoRaja){
    lopetusAika=millis();
    tila=false;
    lcd.clear();
    unsigned long aika = lopetusAika-aloitusAika;
    double korkeus=LaskeKorkeus(aika);
    double korjattu=korkeus+2.9;
    lcd.setCursor(2,0);
    lcd.print("Hypyn korkeus");
    lcd.setCursor(4,1);
    lcd.print(korjattu,3);
    lcd.print(" cm");
    
    digitalWrite(punLEDPinni,HIGH);
    digitalWrite(vihLEDPinni,LOW);
  }
 valonVoimakkuus=valoNyt;
 }
 
/**
 * Aloitetaan ajanotto millisekunneissa
 */
void Aloitus(){
    aloitusAika=millis();
    tila=true;
    digitalWrite(punLEDPinni,LOW);
    digitalWrite(vihLEDPinni,HIGH);
}

/**
 * Lopetetaan ajanotto, näytetään aika sekunteina ja haistellaan milloin halutaan aloittaa uudestaan
 */
void LopetusMs(){
    lopetusAika=millis();
    tila=false;
    lcd.clear();
    unsigned long aika = lopetusAika-aloitusAika;
    double aikaSekunteina=msSekunneiksi(aika);
    lcd.setCursor(5,0);
    lcd.print("Aika");
    lcd.setCursor(4,1);
      if(aika<60000){
         lcd.setCursor(5,1);
         lcd.print(aikaSekunteina,3);
         lcd.print(" s");
      }
      else{
          lcd.setCursor(4,1);
          int minuutit=aika/60000;
          double sekunnit=aikaSekunteina-60*minuutit;
          lcd.print(minuutit);
          lcd.print(":");
          if(sekunnit<10){
            lcd.print("0");
            lcd.print(sekunnit,3);
          }
          else lcd.print(sekunnit,3);
          }
    digitalWrite(punLEDPinni,HIGH);
    digitalWrite(vihLEDPinni,LOW);
    
    while(true){
     char nollataanko = nappaimisto.getKey();
     // Aloitetaan uusi ajanotto
     if(nollataanko=='6'){
      break;
     }
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      looppi=false;
      break;
     }
    }
    lcd.clear();
}
/**
 * Lopetetaan ajanotto, näytetään aika sekunteina ja haistellaan milloin halutaan aloittaa uudestaan
 */
void LopetusUs(){
    tila=false;
    lcd.clear();
    unsigned long aika = lopetusAika-aloitusAika;
    lcd.setCursor(5,0);
    lcd.print("Aika");
    lcd.setCursor(0,1);
    lcd.print(aika);
    lcd.print(" us");
    
    while(true){
     char nollataanko = nappaimisto.getKey();
     // Aloitetaan uusi ajanotto
     if(nollataanko=='6'){
      NaytaNopeus(aika);
      break;
     }
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      looppi=false;
      break;
     }
    }
    lcd.clear();
}

/**
 * Muuntaa millisekunnit sekunneiksi
 */
double msSekunneiksi(unsigned long aika){
  double aikaSekunteina=aika/1000.0;
  return aikaSekunteina;
}

/** 
* Laskee nopeuden annetusta ajasta 
*@param aika mikrosekunteina 
*@return palauttaa nopeuden m/s 
*/ 
double laskeNopeusMS(unsigned long aika){ 
     double nopeus=(0.01*VALI_MATKA)/(0.000001*aika); 
return nopeus; 

}
/** 
* Laskee nopeuden annetusta ajasta 
*@param aika mikrosekunteina 
*@return palauttaa nopeuden km/h 
*/ 
double laskeNopeusKMH(unsigned long aika){ 
return laskeNopeusMS(aika)*3.6; 
}
/**
 * Näyttää kulunutta aikaa tietyn ajan välein
 */
void naytaAika(){
   const int VALI_AIKA=170;
        unsigned long aikanyt=millis();
        if(aikanyt%VALI_AIKA==0){
          if(!tila){
              lcd.setCursor(5,0);
              lcd.print("Aloita");
              }
              
          else{
                lcd.setCursor(4,0);
                lcd.print("Aloitettu");
                lcd.setCursor(5,1);
                unsigned long aikaamennyt=aikanyt-aloitusAika;
                double aikaSekunteinaNyt=msSekunneiksi(aikaamennyt);
                if(aikaamennyt<60000){
                  lcd.setCursor(5,1);
                  lcd.print(aikaSekunteinaNyt,1);
                }
                else{
                  lcd.setCursor(5,1);
                  int minuutit=aikaamennyt/60000;
                  double sekunnit=aikaSekunteinaNyt-60*minuutit;
                  lcd.print(minuutit);
                  lcd.print(":");
                  lcd.print(sekunnit,1);
                }
           }
        }
}

/**
 * Määrittää mikä moodi on päällä
 */
void MaaritaMoodi(){
   // Maaritetaan moodi
  lcd.setCursor(0,0);
  lcd.print("Valitse moodi ");
  char key = nappaimisto.getKey();
  if(key){
    moodi=key;
    lcd.setCursor(0,1);
    lcd.print("moodi");
    lcd.setCursor(7,1);
    lcd.print(key);  
    delay(2000);
    //Aloitetaan...
    lcd.clear();
    lcd.setCursor(5,0);
    lcd.print("Aloita");
    looppi=true;
  }
}
/** 
* Kalibroi sensorit haluttaessa 
*/ 
void kalibroi(){
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("Kalibroidaan ");
  lcd.setCursor(0,1);
  lcd.print("sensoreita...");
  delay(500); 
  int valoNyt=analogRead(valoPinni1);
  int valoNyt2=analogRead(valoPinni1);
  int aaniNyt=analogRead(mikrofoniPinni); 
  valoRaja=valoNyt*(1-LIGHT_TRESHOLD);
  valoRaja2=valoNyt2*(1-LIGHT_TRESHOLD); 
  aaniRaja=aaniNyt*(1+SOUND_TRESHOLD);
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("Kalibroitu ");
  while(true){
     char nollataanko = nappaimisto.getKey();
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      moodi='7';
      lcd.clear();
      break;
     }
    }
  }

/**
 * Haistattaa paskan
 */
void haistaPaska(){
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("Haista paska");
  lcd.setCursor(0,1);
  lcd.print(" Mika");
  while(true){
     char nollataanko = nappaimisto.getKey();
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      moodi='7';
      lcd.clear();
      break;
     }
    }
  }

  /**
 * Toivottaa onnea
 */
void onnea(){
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("  Hyvaa ");
  lcd.setCursor(0,1);
  lcd.print("Syntymapaivaa!");
  while(true){
     char nollataanko = nappaimisto.getKey();
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      moodi='7';
      lcd.clear();
      break;
     }
    }
  }

/**
 * Näyttää nopeuden
 */
void NaytaNopeus(unsigned long aika){
    tila=false;
    lcd.clear();
    double nopeus = laskeNopeusMS(aika);
    lcd.setCursor(5,0);
    lcd.print("Nopeus");
    lcd.setCursor(2,1);
    lcd.print(nopeus,5);
    lcd.print(" m/s");
    
    while(true){
     char nollataanko = nappaimisto.getKey();
     // Aloitetaan uusi ajanotto
     if(nollataanko=='6'){
      NaytaNopeusKMH(aika);
      break;
     }
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      looppi=false;
      break;
     }
    }
    lcd.clear();
}

/**
 * Näyttää nopeuden kilometreinä tunnissa
 */
void NaytaNopeusKMH(unsigned long aika){
    tila=false;
    lcd.clear();
    double nopeus = laskeNopeusKMH(aika);
    lcd.setCursor(5,0);
    lcd.print("Nopeus");
    lcd.setCursor(2,1);
    lcd.print(nopeus,5);
    lcd.print(" km/h");
    
    while(true){
     char nollataanko = nappaimisto.getKey();
     // Aloitetaan uusi ajanotto
     if(nollataanko=='6'){;
        lcd.clear();
        lcd.setCursor(5,0);
        lcd.print("Aika");
        break;
     }
     if(nollataanko=='7'){
      //Mennään moodin valitsemiseen
      looppi=false;
      break;
     }
    }
    lcd.clear();
}
/**
 * Lähettää USB-portin kautta dataa
 */
void sarjaLiikenne(bool alustus, int mod, unsigned int viive){
  if(alustus){
    Serial.begin(115200);
    while(!Serial) {}
    looppi=false;
  }
  switch(mod){
    case 1:
    Serial.println(analogRead(valoPinni1));
    break;

    case 2:
    Serial.println(analogRead(mikrofoniPinni));
    break;
  }
  delayMicroseconds(viive-200);
}
/**
 * Sarjaliikenne ilman viivettä
 */
void sarjaLiikenneNopea(int mod){
  switch(mod){
    case 1:
    Serial.println(analogRead(valoPinni1));
    break;

    case 2:
    Serial.println(analogRead(mikrofoniPinni));
    break;
  }
}
/**
 * Laskee hypyn korkeuden ajasta millisekunneissa
 * TODO:oikea kaava
 */
double LaskeKorkeus(int aika){
  return 0.5*9.81*(aika*0.5*0.001)*(aika*0.5*0.001)*100;
}

