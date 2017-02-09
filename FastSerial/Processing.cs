using MathNet.Numerics.IntegralTransforms;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace FastSerial
{
    /// <summary>
    /// @Aki Ruhtinas 2016
    /// </summary>
    class Processing
    {
           /// <summary>
           /// Laskee halutut tulokset
           /// </summary>
           /// <param name="n"></param>
           /// <param name="samplefrq"></param>
           /// <param name="mass"></param>
           /// <param name="autosample"></param>
           /// <param name="series1"></param>
           /// <param name="data"></param>
           /// <returns>Palauttaa käsitellyn datan listana</returns>
        public List<DataPoint> Calculate(int n,double samplefrq,double mass,bool autosample,LineSeries series1, List<DataPoint> data,int mtype,bool suunta)
        {
            List<DataPoint> result = new List<DataPoint>();
            if (n == 1) result = Derivateh2(data, series1,mtype);
            if (n == 2) result = Derivateh4(data, series1, mtype);
            if (n == 3) result = Derivate2h2(data, series1, mtype);
            if (n == 4) result = Derivate2h4(data, series1, mtype);
            if (n == 5) result = FFT(data, samplefrq,autosample,series1);
            if (n == 6) result = Force(data, mass,series1);
            if (n == 7) result = Power(data, mass, series1,suunta);
            return result;
        }
        /// <summary>
        /// laskee derivaatan keskitetysti h^2 approksimaatiolla
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<DataPoint> Derivateh2(List<DataPoint> list, LineSeries series1, int mtype)
        {
            List<DataPoint> tulos = new List<DataPoint>();
            double luku;
            for (int i = 1; i < list.Count - 1; i++)
            {
                luku = (list[i + 1].Y - list[i - 1].Y) / (2 * Math.Abs((list[i - 1].X - list[i + 1].X)));
                tulos.Add(new DataPoint(list[i].X, luku));
            }
            if (mtype == 0) series1.YAxis.Title = "Speed(m/s)";
            if (mtype == 1) series1.YAxis.Title = "1st derivative";
            if (mtype == 2) series1.YAxis.Title = "1st derivative";
            return tulos;
        }
        /// <summary>
        /// laskee derivaatan keskitetysti h^4 approksimaatiolla
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<DataPoint> Derivateh4(List<DataPoint> list, LineSeries series1, int mtype)
        {
            List<DataPoint> tulos = new List<DataPoint>();
            double luku;
            for (int i = 2; i < list.Count - 2; i++)
            {
                luku = (-list[i + 2].Y + 8 * list[i + 1].Y - 8 * list[i - 1].Y + list[i - 2].Y) / ((12 * Math.Abs((list[i - 1].X - list[i + 1].X))));
                tulos.Add(new DataPoint(list[i].X, luku));
            }
            if (mtype == 0) series1.YAxis.Title = "Speed(m/s)";
            if (mtype == 1) series1.YAxis.Title = "1st derivative";
            if (mtype == 2) series1.YAxis.Title = "1st derivative";
            return tulos;
        }
        /// <summary>
        /// laskee toisen derivaatan keskitetysti h^2 approksimaatiolla
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<DataPoint> Derivate2h2(List<DataPoint> list, LineSeries series1, int mtype)
        {
            List<DataPoint> tulos = new List<DataPoint>();
            double luku;
            for (int i = 1; i < list.Count - 1; i++)
            {
                luku = (list[i + 1].Y - 2 * list[i].Y + list[i - 1].Y) / (Math.Abs((list[i - 1].X - list[i + 1].X)) * Math.Abs((list[i - 1].X - list[i + 1].X)));
                tulos.Add(new DataPoint(list[i].X, luku));
            }
            if (mtype == 0) series1.YAxis.Title = "Acceleration(m/s^2)";
            if (mtype == 1) series1.YAxis.Title = "2nd derivative";
            if (mtype == 2) series1.YAxis.Title = "2nd derivative";
            return tulos;
        }
        /// <summary>
        /// laskee toisen derivaatan keskitetysti h^4 approksimaatiolla
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<DataPoint> Derivate2h4(List<DataPoint> list, LineSeries series1, int mtype)
        {
            List<DataPoint> tulos = new List<DataPoint>();
            double luku;
            for (int i = 2; i < list.Count - 2; i++)
            {
                luku = (-list[i + 2].Y + 16 * list[i + 1].Y - 30 * list[i].Y + 16 * list[i - 1].Y - 2 * list[i - 2].Y) / (12 * Math.Abs((list[i - 1].X - list[i + 1].X)) * Math.Abs((list[i - 1].X - list[i + 1].X)));
                tulos.Add(new DataPoint(list[i].X, luku));
            }
            if (mtype==0)series1.YAxis.Title = "Acceleration(m/s^2)";
            if (mtype == 1) series1.YAxis.Title = "2nd derivative";
            if (mtype == 2) series1.YAxis.Title = "2nd derivative";
            return tulos;
        }
        /// <summary>
        /// tekee Fourier-muunnoksen
        /// </summary>
        /// <returns></returns>
        private List<DataPoint> FFT(List<DataPoint> list, double setfreq, bool autosample, LineSeries series1)
        {
            int N = list.Count;
            double L = Math.Abs(list[0].X - list[N - 1].X);
            double Fs = 1000;                                                ///Sampling frequency
            if (setfreq != 0) Fs = (double)setfreq;
            if (autosample)
            {
                Fs = N / L * 1000.0;
            }
            Complex[] samples = new Complex[N];
            for (int i = 0; i < N; i++)
            {
                samples[i] = new Complex((float)list[i].Y, 0);
            }
            Fourier.BluesteinForward(samples, FourierOptions.Default);      ///FFT
            List<DataPoint> tulos = new List<DataPoint>();
            double[] freq = new double[N / 2];
            for (int j = 0; j < N / 2; j++)
            {
                freq[j] = Fs * j / L;
            }
            for (int i = 1; i < N / 2; i++) tulos.Add(new DataPoint(freq[i], Math.Abs(samples[i].Real) / L));
            series1.XAxis.Title = "Frequency(Hz)";
            series1.YAxis.Title = "Amplitude";
            series1.LineStyle = LineStyle.Solid;
            return tulos;
        }
        /// <summary>
        /// laskee F=ma
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<DataPoint> Force(List<DataPoint> list, double mass, LineSeries series1)
        {
            List<DataPoint> tulos = new List<DataPoint>();
            double luku;
            for (int i = 2; i < list.Count - 2; i++)
            {
                luku = (-list[i + 2].Y + 16 * list[i + 1].Y - 30 * list[i].Y + 16 * list[i - 1].Y - 2 * list[i - 2].Y) / (12 * Math.Abs((list[i - 1].X - list[i + 1].X)) * Math.Abs((list[i - 1].X - list[i + 1].X)));
                tulos.Add(new DataPoint(list[i].X, luku * mass));
            }
            series1.YAxis.Title = "Force(N)";
            series1.XAxis.Title = "Time(ms)";
            return tulos;
        }
        /// <summary>
        /// laskee tehon
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<DataPoint> Power(List<DataPoint> list, double mass, LineSeries series1,bool suunta)
        {
            const double g = 9.81;
            List<DataPoint> tulos = new List<DataPoint>();
            double nopeus;
            double kiihtyvyys;
            for (int i = 2; i < list.Count - 2; i++)
            {
                nopeus = (-list[i + 2].Y + 8 * list[i + 1].Y - 8 * list[i - 1].Y + list[i - 2].Y) / ((12 * Math.Abs((list[i - 1].X - list[i + 1].X))));
                kiihtyvyys = (-list[i + 2].Y + 16 * list[i + 1].Y - 30 * list[i].Y + 16 * list[i - 1].Y - 2 * list[i - 2].Y) / (12 * Math.Abs((list[i - 1].X - list[i + 1].X)) * Math.Abs((list[i - 1].X - list[i + 1].X)));
                if(suunta)tulos.Add(new DataPoint(list[i].X, nopeus*mass*(kiihtyvyys+g)));
                if(!suunta) tulos.Add(new DataPoint(list[i].X, nopeus * mass * kiihtyvyys));
            }
            series1.YAxis.Title = "Power(W)";
            series1.XAxis.Title = "Time(ms)";
            return tulos;
        }
    }
}
