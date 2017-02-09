using System;
using System.Drawing;
using OxyPlot;

namespace FastSerial
{
    partial class FastSerial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastSerial));
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.markerSizeUP = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dataType = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.samplFRQ = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.autoSample = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.points = new System.Windows.Forms.Label();
            this.labelRun = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colormenuCombo = new System.Windows.Forms.ToolStripComboBox();
            this.pointColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colormenuCombo2 = new System.Windows.Forms.ToolStripComboBox();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fastSerial101ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDownMass = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxMesTyp = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.horizontal = new System.Windows.Forms.RadioButton();
            this.vertical = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.markerSizeUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplFRQ)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMass)).BeginInit();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plotView1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.plotView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plotView1.BackgroundImage")));
            this.plotView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.plotView1.Location = new System.Drawing.Point(37, 71);
            this.plotView1.Margin = new System.Windows.Forms.Padding(10);
            this.plotView1.Name = "plotView1";
            this.plotView1.Padding = new System.Windows.Forms.Padding(10);
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(1062, 609);
            this.plotView1.TabIndex = 2;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotView1.Click += new System.EventHandler(this.plotView1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(146, 746);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Stop_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Lime;
            this.button2.Location = new System.Drawing.Point(65, 746);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Start_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(259, 750);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Live Tracking";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(369, 751);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Serial Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(433, 746);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "No active USB-devices";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1269, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "default";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1186, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Line style";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(1186, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Point style";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1269, 113);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.Text = "default";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // markerSizeUP
            // 
            this.markerSizeUP.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.markerSizeUP.Location = new System.Drawing.Point(1270, 145);
            this.markerSizeUP.Name = "markerSizeUP";
            this.markerSizeUP.Size = new System.Drawing.Size(120, 20);
            this.markerSizeUP.TabIndex = 12;
            this.markerSizeUP.ValueChanged += new System.EventHandler(this.markerSizeUP_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1187, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Marker size";
            // 
            // dataType
            // 
            this.dataType.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.dataType.ForeColor = System.Drawing.SystemColors.Control;
            this.dataType.FormattingEnabled = true;
            this.dataType.Location = new System.Drawing.Point(1190, 248);
            this.dataType.Name = "dataType";
            this.dataType.Size = new System.Drawing.Size(201, 108);
            this.dataType.TabIndex = 14;
            this.dataType.SelectedIndexChanged += new System.EventHandler(this.DataType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(1187, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data processing";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(1187, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sampling frequency";
            // 
            // samplFRQ
            // 
            this.samplFRQ.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.samplFRQ.Location = new System.Drawing.Point(1190, 459);
            this.samplFRQ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.samplFRQ.Name = "samplFRQ";
            this.samplFRQ.Size = new System.Drawing.Size(104, 20);
            this.samplFRQ.TabIndex = 17;
            this.samplFRQ.ValueChanged += new System.EventHandler(this.samplFRQ_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(1300, 461);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Hz";
            // 
            // autoSample
            // 
            this.autoSample.AutoSize = true;
            this.autoSample.BackColor = System.Drawing.Color.Transparent;
            this.autoSample.ForeColor = System.Drawing.SystemColors.Control;
            this.autoSample.Location = new System.Drawing.Point(1326, 460);
            this.autoSample.Name = "autoSample";
            this.autoSample.Size = new System.Drawing.Size(73, 17);
            this.autoSample.TabIndex = 19;
            this.autoSample.Text = "Automatic";
            this.autoSample.UseVisualStyleBackColor = false;
            this.autoSample.CheckedChanged += new System.EventHandler(this.autoSample_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(840, 749);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Data points:";
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.BackColor = System.Drawing.Color.Transparent;
            this.points.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.points.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.points.ForeColor = System.Drawing.SystemColors.Highlight;
            this.points.Location = new System.Drawing.Point(925, 749);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(15, 16);
            this.points.TabIndex = 21;
            this.points.Text = "0";
            // 
            // labelRun
            // 
            this.labelRun.AllowDrop = true;
            this.labelRun.AutoSize = true;
            this.labelRun.BackColor = System.Drawing.Color.Transparent;
            this.labelRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRun.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelRun.Location = new System.Drawing.Point(543, 690);
            this.labelRun.Name = "labelRun";
            this.labelRun.Size = new System.Drawing.Size(66, 16);
            this.labelRun.TabIndex = 23;
            this.labelRun.Text = "Running...";
            this.labelRun.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.infoToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(9, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(153, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuitem,
            this.saveAsToolStripMenuItem,
            this.exportDataToolStripMenuItem,
            this.openToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveMenuitem
            // 
            this.saveMenuitem.Name = "saveMenuitem";
            this.saveMenuitem.Size = new System.Drawing.Size(189, 22);
            this.saveMenuitem.Text = "Save";
            this.saveMenuitem.Click += new System.EventHandler(this.saveMenuitem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exportDataToolStripMenuItem.Text = "Export processed data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.pointColorToolStripMenuItem});
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem2.Text = "Settings";
            this.toolStripMenuItem2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colormenuCombo});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.colorToolStripMenuItem.Text = "Line color";
            // 
            // colormenuCombo
            // 
            this.colormenuCombo.Name = "colormenuCombo";
            this.colormenuCombo.Size = new System.Drawing.Size(121, 23);
            this.colormenuCombo.Text = "default";
            this.colormenuCombo.SelectedIndexChanged += new System.EventHandler(this.colormenuCombo_Click);
            // 
            // pointColorToolStripMenuItem
            // 
            this.pointColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colormenuCombo2});
            this.pointColorToolStripMenuItem.Name = "pointColorToolStripMenuItem";
            this.pointColorToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.pointColorToolStripMenuItem.Text = "Point color";
            // 
            // colormenuCombo2
            // 
            this.colormenuCombo2.Name = "colormenuCombo2";
            this.colormenuCombo2.Size = new System.Drawing.Size(121, 23);
            this.colormenuCombo2.Text = "default";
            this.colormenuCombo2.SelectedIndexChanged += new System.EventHandler(this.colormenuCombo2_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.fastSerial101ToolStripMenuItem});
            this.infoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // fastSerial101ToolStripMenuItem
            // 
            this.fastSerial101ToolStripMenuItem.Name = "fastSerial101ToolStripMenuItem";
            this.fastSerial101ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.fastSerial101ToolStripMenuItem.Text = "FastSerial1.01";
            this.fastSerial101ToolStripMenuItem.Click += new System.EventHandler(this.fastSerial101ToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // numericUpDownMass
            // 
            this.numericUpDownMass.Location = new System.Drawing.Point(1189, 589);
            this.numericUpDownMass.Name = "numericUpDownMass";
            this.numericUpDownMass.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMass.TabIndex = 25;
            this.numericUpDownMass.ValueChanged += new System.EventHandler(this.numericUpDownMass_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(1187, 561);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Mass";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(1187, 495);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Measurement type";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // comboBoxMesTyp
            // 
            this.comboBoxMesTyp.FormattingEnabled = true;
            this.comboBoxMesTyp.Location = new System.Drawing.Point(1188, 526);
            this.comboBoxMesTyp.Name = "comboBoxMesTyp";
            this.comboBoxMesTyp.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMesTyp.TabIndex = 28;
            this.comboBoxMesTyp.Text = "undefined";
            this.comboBoxMesTyp.SelectedIndexChanged += new System.EventHandler(this.comboBoxMesTyp_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(1315, 591);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "kg";
            // 
            // horizontal
            // 
            this.horizontal.AutoSize = true;
            this.horizontal.BackColor = System.Drawing.Color.Transparent;
            this.horizontal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.horizontal.Location = new System.Drawing.Point(1189, 624);
            this.horizontal.Name = "horizontal";
            this.horizontal.Size = new System.Drawing.Size(72, 17);
            this.horizontal.TabIndex = 30;
            this.horizontal.TabStop = true;
            this.horizontal.Text = "Horizontal";
            this.horizontal.UseVisualStyleBackColor = false;
            // 
            // vertical
            // 
            this.vertical.AutoSize = true;
            this.vertical.BackColor = System.Drawing.Color.Transparent;
            this.vertical.ForeColor = System.Drawing.SystemColors.Highlight;
            this.vertical.Location = new System.Drawing.Point(1190, 647);
            this.vertical.Name = "vertical";
            this.vertical.Size = new System.Drawing.Size(60, 17);
            this.vertical.TabIndex = 31;
            this.vertical.TabStop = true;
            this.vertical.Text = "Vertical";
            this.vertical.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(1352, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 16);
            this.button3.TabIndex = 33;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(1318, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 16);
            this.button4.TabIndex = 34;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(1318, 222);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 20);
            this.button5.TabIndex = 35;
            this.button5.Text = "Refresh";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Location = new System.Drawing.Point(1269, 181);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 20);
            this.button6.TabIndex = 36;
            this.button6.Text = "Auto zoom";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.AutozoomEvent);
            // 
            // FastSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1404, 842);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.vertical);
            this.Controls.Add(this.horizontal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxMesTyp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownMass);
            this.Controls.Add(this.labelRun);
            this.Controls.Add(this.points);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.autoSample);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.samplFRQ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.markerSizeUP);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "FastSerial";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.markerSizeUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplFRQ)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown markerSizeUP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox dataType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown samplFRQ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox autoSample;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label points;
        private System.Windows.Forms.Label labelRun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fastSerial101ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuitem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripComboBox colormenuCombo;
        private System.Windows.Forms.ToolStripMenuItem pointColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox colormenuCombo2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownMass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxMesTyp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton horizontal;
        private System.Windows.Forms.RadioButton vertical;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

