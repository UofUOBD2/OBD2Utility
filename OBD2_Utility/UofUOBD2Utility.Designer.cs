namespace OBD2_Utility
{
    partial class UofUOBD2Utility
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UofUOBD2Utility));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuGraph1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraph2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraph3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsOne = new System.Windows.Forms.ToolStripMenuItem();
            this.Default = new System.Windows.Forms.ToolStripMenuItem();
            this.Dark = new System.Windows.Forms.ToolStripMenuItem();
            this.Neon = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsThree = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFour = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHeader = new System.Windows.Forms.Label();
            this.graphGenerateButton = new System.Windows.Forms.Button();
            this.graphYAxisSelect = new System.Windows.Forms.ListBox();
            this.graphXAxisSelect = new System.Windows.Forms.ListBox();
            this.graphBarBox = new System.Windows.Forms.CheckBox();
            this.graphLineBox = new System.Windows.Forms.CheckBox();
            this.graphOption1Select = new System.Windows.Forms.ListBox();
            this.graphOption2Select = new System.Windows.Forms.ListBox();
            this.graphOption3Select = new System.Windows.Forms.ListBox();
            this.graphGraphButton = new System.Windows.Forms.Button();
            this.menuStatusBar = new System.Windows.Forms.TextBox();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.graphFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.graphDataPointOneLabel = new System.Windows.Forms.Label();
            this.graphDataPointTwoLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dashBoardTitle = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.fuelPic = new System.Windows.Forms.PictureBox();
            this.tempPic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tempGauge = new System.Windows.Forms.AGauge();
            this.fuelGauge = new System.Windows.Forms.AGauge();
            this.rpmGauge = new System.Windows.Forms.AGauge();
            this.speedGauge = new System.Windows.Forms.AGauge();
            this.dashBoard = new System.Windows.Forms.PictureBox();
            this.messageBubble = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageBubble)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGraph1,
            this.menuGraph2,
            this.menuGraph3,
            this.menuOption4,
            this.menuSettings,
            this.menuHome});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1382, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuGraph1
            // 
            this.menuGraph1.Name = "menuGraph1";
            this.menuGraph1.Size = new System.Drawing.Size(92, 24);
            this.menuGraph1.Text = "Graph One";
            this.menuGraph1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuGraph2
            // 
            this.menuGraph2.Name = "menuGraph2";
            this.menuGraph2.Size = new System.Drawing.Size(92, 24);
            this.menuGraph2.Text = "Graph Two";
            this.menuGraph2.Click += new System.EventHandler(this.menuGraph2_Click);
            // 
            // menuGraph3
            // 
            this.menuGraph3.Name = "menuGraph3";
            this.menuGraph3.Size = new System.Drawing.Size(102, 24);
            this.menuGraph3.Text = "Graph Three";
            this.menuGraph3.Click += new System.EventHandler(this.menuGraph3_Click);
            // 
            // menuOption4
            // 
            this.menuOption4.Name = "menuOption4";
            this.menuOption4.Size = new System.Drawing.Size(116, 24);
            this.menuOption4.Text = "Trouble Codes";
            // 
            // menuSettings
            // 
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsOne,
            this.settingsTwo,
            this.settingsThree,
            this.settingsFour});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(74, 24);
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // settingsOne
            // 
            this.settingsOne.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Default,
            this.Dark,
            this.Neon});
            this.settingsOne.Name = "settingsOne";
            this.settingsOne.Size = new System.Drawing.Size(217, 26);
            this.settingsOne.Text = "Colors";
            // 
            // Default
            // 
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(164, 26);
            this.Default.Text = "Red/White";
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // Dark
            // 
            this.Dark.Name = "Dark";
            this.Dark.Size = new System.Drawing.Size(164, 26);
            this.Dark.Text = "White/Black";
            this.Dark.Click += new System.EventHandler(this.Dark_Click);
            // 
            // Neon
            // 
            this.Neon.Name = "Neon";
            this.Neon.Size = new System.Drawing.Size(164, 26);
            this.Neon.Text = "Neon";
            this.Neon.Click += new System.EventHandler(this.Neon_Click);
            // 
            // settingsTwo
            // 
            this.settingsTwo.Name = "settingsTwo";
            this.settingsTwo.Size = new System.Drawing.Size(217, 26);
            this.settingsTwo.Text = "toolStripMenuItem2";
            // 
            // settingsThree
            // 
            this.settingsThree.Name = "settingsThree";
            this.settingsThree.Size = new System.Drawing.Size(217, 26);
            this.settingsThree.Text = "toolStripMenuItem3";
            // 
            // settingsFour
            // 
            this.settingsFour.Name = "settingsFour";
            this.settingsFour.Size = new System.Drawing.Size(217, 26);
            this.settingsFour.Text = "toolStripMenuItem4";
            // 
            // menuHome
            // 
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(62, 24);
            this.menuHome.Text = "Home";
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // graphHeader
            // 
            this.graphHeader.AutoSize = true;
            this.graphHeader.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphHeader.Location = new System.Drawing.Point(1133, 7);
            this.graphHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphHeader.Name = "graphHeader";
            this.graphHeader.Size = new System.Drawing.Size(127, 54);
            this.graphHeader.TabIndex = 4;
            this.graphHeader.Text = "X VS Y";
            // 
            // graphGenerateButton
            // 
            this.graphGenerateButton.Location = new System.Drawing.Point(1144, 193);
            this.graphGenerateButton.Margin = new System.Windows.Forms.Padding(4);
            this.graphGenerateButton.Name = "graphGenerateButton";
            this.graphGenerateButton.Size = new System.Drawing.Size(172, 71);
            this.graphGenerateButton.TabIndex = 9;
            this.graphGenerateButton.Text = "Load Data";
            this.graphGenerateButton.UseVisualStyleBackColor = true;
            this.graphGenerateButton.Click += new System.EventHandler(this.graphGenerateButton_Click);
            // 
            // graphYAxisSelect
            // 
            this.graphYAxisSelect.FormattingEnabled = true;
            this.graphYAxisSelect.ItemHeight = 16;
            this.graphYAxisSelect.Location = new System.Drawing.Point(1141, 137);
            this.graphYAxisSelect.Margin = new System.Windows.Forms.Padding(4);
            this.graphYAxisSelect.Name = "graphYAxisSelect";
            this.graphYAxisSelect.Size = new System.Drawing.Size(173, 20);
            this.graphYAxisSelect.TabIndex = 10;
            // 
            // graphXAxisSelect
            // 
            this.graphXAxisSelect.FormattingEnabled = true;
            this.graphXAxisSelect.ItemHeight = 16;
            this.graphXAxisSelect.Location = new System.Drawing.Point(1141, 108);
            this.graphXAxisSelect.Margin = new System.Windows.Forms.Padding(4);
            this.graphXAxisSelect.Name = "graphXAxisSelect";
            this.graphXAxisSelect.Size = new System.Drawing.Size(173, 20);
            this.graphXAxisSelect.TabIndex = 11;
            this.graphXAxisSelect.SelectedIndexChanged += new System.EventHandler(this.graphXAxisSelect_SelectedIndexChanged);
            // 
            // graphBarBox
            // 
            this.graphBarBox.AutoSize = true;
            this.graphBarBox.Location = new System.Drawing.Point(1144, 165);
            this.graphBarBox.Margin = new System.Windows.Forms.Padding(4);
            this.graphBarBox.Name = "graphBarBox";
            this.graphBarBox.Size = new System.Drawing.Size(52, 21);
            this.graphBarBox.TabIndex = 12;
            this.graphBarBox.Text = "Bar";
            this.graphBarBox.UseVisualStyleBackColor = true;
            // 
            // graphLineBox
            // 
            this.graphLineBox.AutoSize = true;
            this.graphLineBox.Location = new System.Drawing.Point(1255, 165);
            this.graphLineBox.Margin = new System.Windows.Forms.Padding(4);
            this.graphLineBox.Name = "graphLineBox";
            this.graphLineBox.Size = new System.Drawing.Size(57, 21);
            this.graphLineBox.TabIndex = 13;
            this.graphLineBox.Text = "Line";
            this.graphLineBox.UseVisualStyleBackColor = true;
            // 
            // graphOption1Select
            // 
            this.graphOption1Select.FormattingEnabled = true;
            this.graphOption1Select.ItemHeight = 16;
            this.graphOption1Select.Location = new System.Drawing.Point(1147, 288);
            this.graphOption1Select.Margin = new System.Windows.Forms.Padding(4);
            this.graphOption1Select.Name = "graphOption1Select";
            this.graphOption1Select.Size = new System.Drawing.Size(171, 196);
            this.graphOption1Select.TabIndex = 15;
            this.graphOption1Select.SelectedIndexChanged += new System.EventHandler(this.graphOption1Select_SelectedIndexChanged);
            // 
            // graphOption2Select
            // 
            this.graphOption2Select.FormattingEnabled = true;
            this.graphOption2Select.ItemHeight = 16;
            this.graphOption2Select.Location = new System.Drawing.Point(1144, 508);
            this.graphOption2Select.Margin = new System.Windows.Forms.Padding(4);
            this.graphOption2Select.Name = "graphOption2Select";
            this.graphOption2Select.Size = new System.Drawing.Size(171, 196);
            this.graphOption2Select.TabIndex = 16;
            this.graphOption2Select.SelectedIndexChanged += new System.EventHandler(this.graphOption2Select_SelectedIndexChanged);
            // 
            // graphOption3Select
            // 
            this.graphOption3Select.FormattingEnabled = true;
            this.graphOption3Select.ItemHeight = 16;
            this.graphOption3Select.Location = new System.Drawing.Point(1144, 713);
            this.graphOption3Select.Margin = new System.Windows.Forms.Padding(4);
            this.graphOption3Select.Name = "graphOption3Select";
            this.graphOption3Select.Size = new System.Drawing.Size(171, 20);
            this.graphOption3Select.TabIndex = 17;
            this.graphOption3Select.SelectedIndexChanged += new System.EventHandler(this.graphOption3Select_SelectedIndexChanged);
            // 
            // graphGraphButton
            // 
            this.graphGraphButton.Location = new System.Drawing.Point(1144, 741);
            this.graphGraphButton.Margin = new System.Windows.Forms.Padding(4);
            this.graphGraphButton.Name = "graphGraphButton";
            this.graphGraphButton.Size = new System.Drawing.Size(172, 103);
            this.graphGraphButton.TabIndex = 18;
            this.graphGraphButton.Text = "Graph";
            this.graphGraphButton.UseVisualStyleBackColor = true;
            this.graphGraphButton.Click += new System.EventHandler(this.graphGraphButton_Click);
            // 
            // menuStatusBar
            // 
            this.menuStatusBar.Location = new System.Drawing.Point(633, 5);
            this.menuStatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.menuStatusBar.Name = "menuStatusBar";
            this.menuStatusBar.Size = new System.Drawing.Size(687, 22);
            this.menuStatusBar.TabIndex = 19;
            // 
            // graphFlowPanel
            // 
            this.graphFlowPanel.AutoScroll = true;
            this.graphFlowPanel.Location = new System.Drawing.Point(7, 7);
            this.graphFlowPanel.Margin = new System.Windows.Forms.Padding(4);
            this.graphFlowPanel.Name = "graphFlowPanel";
            this.graphFlowPanel.Size = new System.Drawing.Size(1129, 837);
            this.graphFlowPanel.TabIndex = 21;
            this.graphFlowPanel.MouseHover += new System.EventHandler(this.graphFlowPanel_MouseHover);
            // 
            // graphDataPointOneLabel
            // 
            this.graphDataPointOneLabel.AutoSize = true;
            this.graphDataPointOneLabel.Location = new System.Drawing.Point(1209, 268);
            this.graphDataPointOneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphDataPointOneLabel.Name = "graphDataPointOneLabel";
            this.graphDataPointOneLabel.Size = new System.Drawing.Size(39, 17);
            this.graphDataPointOneLabel.TabIndex = 22;
            this.graphDataPointOneLabel.Text = "DP 1";
            // 
            // graphDataPointTwoLabel
            // 
            this.graphDataPointTwoLabel.AutoSize = true;
            this.graphDataPointTwoLabel.Location = new System.Drawing.Point(1209, 489);
            this.graphDataPointTwoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphDataPointTwoLabel.Name = "graphDataPointTwoLabel";
            this.graphDataPointTwoLabel.Size = new System.Drawing.Size(39, 17);
            this.graphDataPointTwoLabel.TabIndex = 23;
            this.graphDataPointTwoLabel.Text = "DP 2";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1333, 862);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.graphFlowPanel);
            this.tabPage1.Controls.Add(this.graphHeader);
            this.tabPage1.Controls.Add(this.graphDataPointTwoLabel);
            this.tabPage1.Controls.Add(this.graphGraphButton);
            this.tabPage1.Controls.Add(this.graphXAxisSelect);
            this.tabPage1.Controls.Add(this.graphOption3Select);
            this.tabPage1.Controls.Add(this.graphDataPointOneLabel);
            this.tabPage1.Controls.Add(this.graphOption2Select);
            this.tabPage1.Controls.Add(this.graphYAxisSelect);
            this.tabPage1.Controls.Add(this.graphBarBox);
            this.tabPage1.Controls.Add(this.graphLineBox);
            this.tabPage1.Controls.Add(this.graphOption1Select);
            this.tabPage1.Controls.Add(this.graphGenerateButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1325, 853);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.messageBubble);
            this.tabPage2.Controls.Add(this.dashBoardTitle);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.fuelPic);
            this.tabPage2.Controls.Add(this.tempPic);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.tempGauge);
            this.tabPage2.Controls.Add(this.fuelGauge);
            this.tabPage2.Controls.Add(this.rpmGauge);
            this.tabPage2.Controls.Add(this.speedGauge);
            this.tabPage2.Controls.Add(this.dashBoard);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1325, 853);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // dashBoardTitle
            // 
            this.dashBoardTitle.AutoSize = true;
            this.dashBoardTitle.BackColor = System.Drawing.Color.Black;
            this.dashBoardTitle.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashBoardTitle.ForeColor = System.Drawing.Color.White;
            this.dashBoardTitle.Location = new System.Drawing.Point(417, 85);
            this.dashBoardTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dashBoardTitle.Name = "dashBoardTitle";
            this.dashBoardTitle.Size = new System.Drawing.Size(400, 98);
            this.dashBoardTitle.TabIndex = 40;
            this.dashBoardTitle.Text = "Dashboard";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(943, 513);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(267, 296);
            this.pictureBox4.TabIndex = 38;
            this.pictureBox4.TabStop = false;
            // 
            // fuelPic
            // 
            this.fuelPic.Image = ((System.Drawing.Image)(resources.GetObject("fuelPic.Image")));
            this.fuelPic.Location = new System.Drawing.Point(1059, 396);
            this.fuelPic.Margin = new System.Windows.Forms.Padding(4);
            this.fuelPic.Name = "fuelPic";
            this.fuelPic.Size = new System.Drawing.Size(39, 41);
            this.fuelPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.fuelPic.TabIndex = 37;
            this.fuelPic.TabStop = false;
            // 
            // tempPic
            // 
            this.tempPic.BackColor = System.Drawing.Color.Black;
            this.tempPic.Image = ((System.Drawing.Image)(resources.GetObject("tempPic.Image")));
            this.tempPic.Location = new System.Drawing.Point(177, 396);
            this.tempPic.Margin = new System.Windows.Forms.Padding(4);
            this.tempPic.Name = "tempPic";
            this.tempPic.Size = new System.Drawing.Size(52, 41);
            this.tempPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tempPic.TabIndex = 36;
            this.tempPic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1059, 373);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "FUEL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(177, 373);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "TEMP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(788, 418);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "SPEED";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(415, 418);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "RPM";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(616, 223);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // tempGauge
            // 
            this.tempGauge.BackColor = System.Drawing.Color.Black;
            this.tempGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.tempGauge.BaseArcRadius = 80;
            this.tempGauge.BaseArcStart = 180;
            this.tempGauge.BaseArcSweep = 90;
            this.tempGauge.BaseArcWidth = 2;
            this.tempGauge.Center = new System.Drawing.Point(100, 100);
            this.tempGauge.Location = new System.Drawing.Point(16, 351);
            this.tempGauge.Margin = new System.Windows.Forms.Padding(0);
            this.tempGauge.MaxValue = 300F;
            this.tempGauge.MinValue = 150F;
            this.tempGauge.Name = "tempGauge";
            this.tempGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.tempGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.tempGauge.NeedleRadius = 60;
            this.tempGauge.NeedleType = System.Windows.Forms.NeedleType.Simple;
            this.tempGauge.NeedleWidth = 4;
            this.tempGauge.ScaleLinesInterColor = System.Drawing.Color.White;
            this.tempGauge.ScaleLinesInterInnerRadius = 73;
            this.tempGauge.ScaleLinesInterOuterRadius = 80;
            this.tempGauge.ScaleLinesInterWidth = 1;
            this.tempGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.tempGauge.ScaleLinesMajorInnerRadius = 70;
            this.tempGauge.ScaleLinesMajorOuterRadius = 80;
            this.tempGauge.ScaleLinesMajorStepValue = 50F;
            this.tempGauge.ScaleLinesMajorWidth = 3;
            this.tempGauge.ScaleLinesMinorColor = System.Drawing.Color.White;
            this.tempGauge.ScaleLinesMinorInnerRadius = 75;
            this.tempGauge.ScaleLinesMinorOuterRadius = 80;
            this.tempGauge.ScaleLinesMinorTicks = 9;
            this.tempGauge.ScaleLinesMinorWidth = 1;
            this.tempGauge.ScaleNumbersColor = System.Drawing.Color.White;
            this.tempGauge.ScaleNumbersFormat = null;
            this.tempGauge.ScaleNumbersRadius = 95;
            this.tempGauge.ScaleNumbersRotation = 0;
            this.tempGauge.ScaleNumbersStartScaleLine = 0;
            this.tempGauge.ScaleNumbersStepScaleLines = 1;
            this.tempGauge.Size = new System.Drawing.Size(200, 158);
            this.tempGauge.TabIndex = 29;
            this.tempGauge.Text = "aGauge3";
            this.tempGauge.Value = 150F;
            // 
            // fuelGauge
            // 
            this.fuelGauge.BackColor = System.Drawing.Color.Black;
            this.fuelGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.fuelGauge.BaseArcRadius = 80;
            this.fuelGauge.BaseArcStart = 0;
            this.fuelGauge.BaseArcSweep = -90;
            this.fuelGauge.BaseArcWidth = 2;
            this.fuelGauge.Center = new System.Drawing.Point(100, 100);
            this.fuelGauge.Location = new System.Drawing.Point(1011, 351);
            this.fuelGauge.Margin = new System.Windows.Forms.Padding(0);
            this.fuelGauge.MaxValue = 100F;
            this.fuelGauge.MinValue = 0F;
            this.fuelGauge.Name = "fuelGauge";
            this.fuelGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.fuelGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.fuelGauge.NeedleRadius = 60;
            this.fuelGauge.NeedleType = System.Windows.Forms.NeedleType.Simple;
            this.fuelGauge.NeedleWidth = 4;
            this.fuelGauge.ScaleLinesInterColor = System.Drawing.Color.White;
            this.fuelGauge.ScaleLinesInterInnerRadius = 73;
            this.fuelGauge.ScaleLinesInterOuterRadius = 80;
            this.fuelGauge.ScaleLinesInterWidth = 1;
            this.fuelGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.fuelGauge.ScaleLinesMajorInnerRadius = 70;
            this.fuelGauge.ScaleLinesMajorOuterRadius = 80;
            this.fuelGauge.ScaleLinesMajorStepValue = 20F;
            this.fuelGauge.ScaleLinesMajorWidth = 3;
            this.fuelGauge.ScaleLinesMinorColor = System.Drawing.Color.White;
            this.fuelGauge.ScaleLinesMinorInnerRadius = 75;
            this.fuelGauge.ScaleLinesMinorOuterRadius = 80;
            this.fuelGauge.ScaleLinesMinorTicks = 9;
            this.fuelGauge.ScaleLinesMinorWidth = 1;
            this.fuelGauge.ScaleNumbersColor = System.Drawing.Color.White;
            this.fuelGauge.ScaleNumbersFormat = null;
            this.fuelGauge.ScaleNumbersRadius = 95;
            this.fuelGauge.ScaleNumbersRotation = 0;
            this.fuelGauge.ScaleNumbersStartScaleLine = 0;
            this.fuelGauge.ScaleNumbersStepScaleLines = 1;
            this.fuelGauge.Size = new System.Drawing.Size(284, 158);
            this.fuelGauge.TabIndex = 28;
            this.fuelGauge.Text = "aGauge2";
            this.fuelGauge.Value = 0F;
            // 
            // rpmGauge
            // 
            this.rpmGauge.BackColor = System.Drawing.Color.Black;
            this.rpmGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.rpmGauge.BaseArcRadius = 80;
            this.rpmGauge.BaseArcStart = 135;
            this.rpmGauge.BaseArcSweep = 270;
            this.rpmGauge.BaseArcWidth = 2;
            this.rpmGauge.Center = new System.Drawing.Point(110, 100);
            this.rpmGauge.Location = new System.Drawing.Point(294, 223);
            this.rpmGauge.Margin = new System.Windows.Forms.Padding(0);
            this.rpmGauge.MaxValue = 8000F;
            this.rpmGauge.MinValue = 0F;
            this.rpmGauge.Name = "rpmGauge";
            this.rpmGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.rpmGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.rpmGauge.NeedleRadius = 60;
            this.rpmGauge.NeedleType = System.Windows.Forms.NeedleType.Simple;
            this.rpmGauge.NeedleWidth = 4;
            this.rpmGauge.ScaleLinesInterColor = System.Drawing.Color.White;
            this.rpmGauge.ScaleLinesInterInnerRadius = 73;
            this.rpmGauge.ScaleLinesInterOuterRadius = 80;
            this.rpmGauge.ScaleLinesInterWidth = 1;
            this.rpmGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.rpmGauge.ScaleLinesMajorInnerRadius = 70;
            this.rpmGauge.ScaleLinesMajorOuterRadius = 80;
            this.rpmGauge.ScaleLinesMajorStepValue = 1000F;
            this.rpmGauge.ScaleLinesMajorWidth = 3;
            this.rpmGauge.ScaleLinesMinorColor = System.Drawing.Color.White;
            this.rpmGauge.ScaleLinesMinorInnerRadius = 75;
            this.rpmGauge.ScaleLinesMinorOuterRadius = 80;
            this.rpmGauge.ScaleLinesMinorTicks = 9;
            this.rpmGauge.ScaleLinesMinorWidth = 1;
            this.rpmGauge.ScaleNumbersColor = System.Drawing.Color.White;
            this.rpmGauge.ScaleNumbersFormat = null;
            this.rpmGauge.ScaleNumbersRadius = 95;
            this.rpmGauge.ScaleNumbersRotation = 0;
            this.rpmGauge.ScaleNumbersStartScaleLine = 0;
            this.rpmGauge.ScaleNumbersStepScaleLines = 1;
            this.rpmGauge.Size = new System.Drawing.Size(284, 235);
            this.rpmGauge.TabIndex = 27;
            this.rpmGauge.Text = "rpmGauge";
            this.rpmGauge.Value = 0F;
            // 
            // speedGauge
            // 
            this.speedGauge.BackColor = System.Drawing.Color.Black;
            this.speedGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.speedGauge.BaseArcRadius = 80;
            this.speedGauge.BaseArcStart = 135;
            this.speedGauge.BaseArcSweep = 270;
            this.speedGauge.BaseArcWidth = 2;
            this.speedGauge.Center = new System.Drawing.Point(110, 100);
            this.speedGauge.Location = new System.Drawing.Point(673, 223);
            this.speedGauge.Margin = new System.Windows.Forms.Padding(0);
            this.speedGauge.MaxValue = 120F;
            this.speedGauge.MinValue = 0F;
            this.speedGauge.Name = "speedGauge";
            this.speedGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.speedGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.speedGauge.NeedleRadius = 60;
            this.speedGauge.NeedleType = System.Windows.Forms.NeedleType.Simple;
            this.speedGauge.NeedleWidth = 4;
            this.speedGauge.ScaleLinesInterColor = System.Drawing.Color.White;
            this.speedGauge.ScaleLinesInterInnerRadius = 73;
            this.speedGauge.ScaleLinesInterOuterRadius = 80;
            this.speedGauge.ScaleLinesInterWidth = 1;
            this.speedGauge.ScaleLinesMajorColor = System.Drawing.Color.Red;
            this.speedGauge.ScaleLinesMajorInnerRadius = 70;
            this.speedGauge.ScaleLinesMajorOuterRadius = 80;
            this.speedGauge.ScaleLinesMajorStepValue = 10F;
            this.speedGauge.ScaleLinesMajorWidth = 3;
            this.speedGauge.ScaleLinesMinorColor = System.Drawing.Color.White;
            this.speedGauge.ScaleLinesMinorInnerRadius = 75;
            this.speedGauge.ScaleLinesMinorOuterRadius = 80;
            this.speedGauge.ScaleLinesMinorTicks = 9;
            this.speedGauge.ScaleLinesMinorWidth = 1;
            this.speedGauge.ScaleNumbersColor = System.Drawing.Color.White;
            this.speedGauge.ScaleNumbersFormat = null;
            this.speedGauge.ScaleNumbersRadius = 95;
            this.speedGauge.ScaleNumbersRotation = 0;
            this.speedGauge.ScaleNumbersStartScaleLine = 0;
            this.speedGauge.ScaleNumbersStepScaleLines = 1;
            this.speedGauge.Size = new System.Drawing.Size(284, 235);
            this.speedGauge.TabIndex = 26;
            this.speedGauge.Text = "speedGauge";
            this.speedGauge.Value = 0F;
            // 
            // dashBoard
            // 
            this.dashBoard.BackColor = System.Drawing.Color.Black;
            this.dashBoard.Location = new System.Drawing.Point(7, 7);
            this.dashBoard.Margin = new System.Windows.Forms.Padding(4);
            this.dashBoard.Name = "dashBoard";
            this.dashBoard.Size = new System.Drawing.Size(1309, 839);
            this.dashBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.dashBoard.TabIndex = 24;
            this.dashBoard.TabStop = false;
            this.dashBoard.Click += new System.EventHandler(this.dashBoard_Click);
            // 
            // messageBubble
            // 
            this.messageBubble.Image = ((System.Drawing.Image)(resources.GetObject("messageBubble.Image")));
            this.messageBubble.Location = new System.Drawing.Point(593, 513);
            this.messageBubble.Margin = new System.Windows.Forms.Padding(4);
            this.messageBubble.Name = "messageBubble";
            this.messageBubble.Size = new System.Drawing.Size(342, 296);
            this.messageBubble.TabIndex = 41;
            this.messageBubble.TabStop = false;
            // 
            // UofUOBD2Utility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1382, 953);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStatusBar);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1400, 1000);
            this.MinimumSize = new System.Drawing.Size(1400, 1000);
            this.Name = "UofUOBD2Utility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UofUOBD2Utility";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UofUOBD2Utility_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageBubble)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuGraph1;
        private System.Windows.Forms.ToolStripMenuItem menuGraph2;
        private System.Windows.Forms.ToolStripMenuItem menuGraph3;
        private System.Windows.Forms.ToolStripMenuItem menuOption4;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.Label graphHeader;
        private System.Windows.Forms.Button graphGenerateButton;
        private System.Windows.Forms.ListBox graphYAxisSelect;
        private System.Windows.Forms.ListBox graphXAxisSelect;
        private System.Windows.Forms.CheckBox graphBarBox;
        private System.Windows.Forms.CheckBox graphLineBox;
        private System.Windows.Forms.ListBox graphOption1Select;
        private System.Windows.Forms.ListBox graphOption2Select;
        private System.Windows.Forms.ListBox graphOption3Select;
        private System.Windows.Forms.Button graphGraphButton;
        private System.Windows.Forms.TextBox menuStatusBar;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.FlowLayoutPanel graphFlowPanel;
        private System.Windows.Forms.Label graphDataPointOneLabel;
        private System.Windows.Forms.Label graphDataPointTwoLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox dashBoard;
        private System.Windows.Forms.AGauge speedGauge;
        private System.Windows.Forms.ToolStripMenuItem settingsOne;
        private System.Windows.Forms.ToolStripMenuItem settingsTwo;
        private System.Windows.Forms.ToolStripMenuItem settingsThree;
        private System.Windows.Forms.ToolStripMenuItem settingsFour;
        private System.Windows.Forms.ToolStripMenuItem Default;
        private System.Windows.Forms.ToolStripMenuItem Dark;
        private System.Windows.Forms.ToolStripMenuItem Neon;
        private System.Windows.Forms.AGauge tempGauge;
        private System.Windows.Forms.AGauge fuelGauge;
        private System.Windows.Forms.AGauge rpmGauge;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox fuelPic;
        private System.Windows.Forms.PictureBox tempPic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label dashBoardTitle;
        private System.Windows.Forms.PictureBox messageBubble;
    }
}