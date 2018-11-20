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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuGraph1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraph2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGraph3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
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
            this.speedGauge = new System.Windows.Forms.AGauge();
            this.rpmGauge = new System.Windows.Forms.AGauge();
            this.dashBoard = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashBoard)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1206, 28);
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
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(74, 24);
            this.menuSettings.Text = "Settings";
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
            this.graphHeader.Location = new System.Drawing.Point(1016, 19);
            this.graphHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphHeader.Name = "graphHeader";
            this.graphHeader.Size = new System.Drawing.Size(127, 54);
            this.graphHeader.TabIndex = 4;
            this.graphHeader.Text = "X VS Y";
            // 
            // graphGenerateButton
            // 
            this.graphGenerateButton.Location = new System.Drawing.Point(1012, 162);
            this.graphGenerateButton.Margin = new System.Windows.Forms.Padding(4);
            this.graphGenerateButton.Name = "graphGenerateButton";
            this.graphGenerateButton.Size = new System.Drawing.Size(121, 72);
            this.graphGenerateButton.TabIndex = 9;
            this.graphGenerateButton.Text = "Load Data";
            this.graphGenerateButton.UseVisualStyleBackColor = true;
            this.graphGenerateButton.Click += new System.EventHandler(this.graphGenerateButton_Click);
            // 
            // graphYAxisSelect
            // 
            this.graphYAxisSelect.FormattingEnabled = true;
            this.graphYAxisSelect.ItemHeight = 16;
            this.graphYAxisSelect.Location = new System.Drawing.Point(1012, 105);
            this.graphYAxisSelect.Margin = new System.Windows.Forms.Padding(4);
            this.graphYAxisSelect.Name = "graphYAxisSelect";
            this.graphYAxisSelect.Size = new System.Drawing.Size(121, 20);
            this.graphYAxisSelect.TabIndex = 10;
            // 
            // graphXAxisSelect
            // 
            this.graphXAxisSelect.FormattingEnabled = true;
            this.graphXAxisSelect.ItemHeight = 16;
            this.graphXAxisSelect.Location = new System.Drawing.Point(1012, 77);
            this.graphXAxisSelect.Margin = new System.Windows.Forms.Padding(4);
            this.graphXAxisSelect.Name = "graphXAxisSelect";
            this.graphXAxisSelect.Size = new System.Drawing.Size(121, 20);
            this.graphXAxisSelect.TabIndex = 11;
            // 
            // graphBarBox
            // 
            this.graphBarBox.AutoSize = true;
            this.graphBarBox.Location = new System.Drawing.Point(1012, 133);
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
            this.graphLineBox.Location = new System.Drawing.Point(1076, 133);
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
            this.graphOption1Select.Location = new System.Drawing.Point(1012, 259);
            this.graphOption1Select.Margin = new System.Windows.Forms.Padding(4);
            this.graphOption1Select.Name = "graphOption1Select";
            this.graphOption1Select.Size = new System.Drawing.Size(121, 100);
            this.graphOption1Select.TabIndex = 15;
            this.graphOption1Select.SelectedIndexChanged += new System.EventHandler(this.graphOption1Select_SelectedIndexChanged);
            // 
            // graphOption2Select
            // 
            this.graphOption2Select.FormattingEnabled = true;
            this.graphOption2Select.ItemHeight = 16;
            this.graphOption2Select.Location = new System.Drawing.Point(1012, 397);
            this.graphOption2Select.Margin = new System.Windows.Forms.Padding(4);
            this.graphOption2Select.Name = "graphOption2Select";
            this.graphOption2Select.Size = new System.Drawing.Size(121, 100);
            this.graphOption2Select.TabIndex = 16;
            this.graphOption2Select.SelectedIndexChanged += new System.EventHandler(this.graphOption2Select_SelectedIndexChanged);
            // 
            // graphOption3Select
            // 
            this.graphOption3Select.FormattingEnabled = true;
            this.graphOption3Select.ItemHeight = 16;
            this.graphOption3Select.Location = new System.Drawing.Point(1012, 503);
            this.graphOption3Select.Margin = new System.Windows.Forms.Padding(4);
            this.graphOption3Select.Name = "graphOption3Select";
            this.graphOption3Select.Size = new System.Drawing.Size(121, 20);
            this.graphOption3Select.TabIndex = 17;
            this.graphOption3Select.SelectedIndexChanged += new System.EventHandler(this.graphOption3Select_SelectedIndexChanged);
            // 
            // graphGraphButton
            // 
            this.graphGraphButton.Location = new System.Drawing.Point(1012, 531);
            this.graphGraphButton.Margin = new System.Windows.Forms.Padding(4);
            this.graphGraphButton.Name = "graphGraphButton";
            this.graphGraphButton.Size = new System.Drawing.Size(121, 103);
            this.graphGraphButton.TabIndex = 18;
            this.graphGraphButton.Text = "Graph";
            this.graphGraphButton.UseVisualStyleBackColor = true;
            this.graphGraphButton.Click += new System.EventHandler(this.graphGraphButton_Click);
            // 
            // menuStatusBar
            // 
            this.menuStatusBar.Location = new System.Drawing.Point(591, 5);
            this.menuStatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.menuStatusBar.Name = "menuStatusBar";
            this.menuStatusBar.Size = new System.Drawing.Size(402, 22);
            this.menuStatusBar.TabIndex = 19;
            // 
            // graphFlowPanel
            // 
            this.graphFlowPanel.AutoScroll = true;
            this.graphFlowPanel.Location = new System.Drawing.Point(7, 7);
            this.graphFlowPanel.Margin = new System.Windows.Forms.Padding(4);
            this.graphFlowPanel.Name = "graphFlowPanel";
            this.graphFlowPanel.Size = new System.Drawing.Size(997, 627);
            this.graphFlowPanel.TabIndex = 21;
            this.graphFlowPanel.MouseHover += new System.EventHandler(this.graphFlowPanel_MouseHover);
            // 
            // graphDataPointOneLabel
            // 
            this.graphDataPointOneLabel.AutoSize = true;
            this.graphDataPointOneLabel.Location = new System.Drawing.Point(1054, 238);
            this.graphDataPointOneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphDataPointOneLabel.Name = "graphDataPointOneLabel";
            this.graphDataPointOneLabel.Size = new System.Drawing.Size(39, 17);
            this.graphDataPointOneLabel.TabIndex = 22;
            this.graphDataPointOneLabel.Text = "DP 1";
            // 
            // graphDataPointTwoLabel
            // 
            this.graphDataPointTwoLabel.AutoSize = true;
            this.graphDataPointTwoLabel.Location = new System.Drawing.Point(1054, 376);
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 650);
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
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.speedGauge);
            this.tabPage2.Controls.Add(this.rpmGauge);
            this.tabPage2.Controls.Add(this.dashBoard);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // speedGauge
            // 
            this.speedGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.speedGauge.BaseArcRadius = 80;
            this.speedGauge.BaseArcStart = 135;
            this.speedGauge.BaseArcSweep = 270;
            this.speedGauge.BaseArcWidth = 2;
            this.speedGauge.Center = new System.Drawing.Point(100, 100);
            this.speedGauge.Location = new System.Drawing.Point(609, 186);
            this.speedGauge.MaxValue = 400F;
            this.speedGauge.MinValue = -100F;
            this.speedGauge.Name = "speedGauge";
            this.speedGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.speedGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.speedGauge.NeedleRadius = 80;
            this.speedGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.speedGauge.NeedleWidth = 2;
            this.speedGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.speedGauge.ScaleLinesInterInnerRadius = 73;
            this.speedGauge.ScaleLinesInterOuterRadius = 80;
            this.speedGauge.ScaleLinesInterWidth = 1;
            this.speedGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.speedGauge.ScaleLinesMajorInnerRadius = 70;
            this.speedGauge.ScaleLinesMajorOuterRadius = 80;
            this.speedGauge.ScaleLinesMajorStepValue = 50F;
            this.speedGauge.ScaleLinesMajorWidth = 2;
            this.speedGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.speedGauge.ScaleLinesMinorInnerRadius = 75;
            this.speedGauge.ScaleLinesMinorOuterRadius = 80;
            this.speedGauge.ScaleLinesMinorTicks = 9;
            this.speedGauge.ScaleLinesMinorWidth = 1;
            this.speedGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.speedGauge.ScaleNumbersFormat = null;
            this.speedGauge.ScaleNumbersRadius = 95;
            this.speedGauge.ScaleNumbersRotation = 0;
            this.speedGauge.ScaleNumbersStartScaleLine = 0;
            this.speedGauge.ScaleNumbersStepScaleLines = 1;
            this.speedGauge.Size = new System.Drawing.Size(330, 299);
            this.speedGauge.TabIndex = 26;
            this.speedGauge.Text = "speedGauge";
            this.speedGauge.Value = 0F;
            // 
            // rpmGauge
            // 
            this.rpmGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.rpmGauge.BaseArcRadius = 80;
            this.rpmGauge.BaseArcStart = 135;
            this.rpmGauge.BaseArcSweep = 270;
            this.rpmGauge.BaseArcWidth = 2;
            this.rpmGauge.Center = new System.Drawing.Point(100, 100);
            this.rpmGauge.Location = new System.Drawing.Point(250, 186);
            this.rpmGauge.MaxValue = 400F;
            this.rpmGauge.MinValue = -100F;
            this.rpmGauge.Name = "rpmGauge";
            this.rpmGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Red;
            this.rpmGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.rpmGauge.NeedleRadius = 80;
            this.rpmGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.rpmGauge.NeedleWidth = 2;
            this.rpmGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.rpmGauge.ScaleLinesInterInnerRadius = 73;
            this.rpmGauge.ScaleLinesInterOuterRadius = 80;
            this.rpmGauge.ScaleLinesInterWidth = 1;
            this.rpmGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.rpmGauge.ScaleLinesMajorInnerRadius = 70;
            this.rpmGauge.ScaleLinesMajorOuterRadius = 80;
            this.rpmGauge.ScaleLinesMajorStepValue = 50F;
            this.rpmGauge.ScaleLinesMajorWidth = 2;
            this.rpmGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.rpmGauge.ScaleLinesMinorInnerRadius = 75;
            this.rpmGauge.ScaleLinesMinorOuterRadius = 80;
            this.rpmGauge.ScaleLinesMinorTicks = 9;
            this.rpmGauge.ScaleLinesMinorWidth = 1;
            this.rpmGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.rpmGauge.ScaleNumbersFormat = null;
            this.rpmGauge.ScaleNumbersRadius = 95;
            this.rpmGauge.ScaleNumbersRotation = 0;
            this.rpmGauge.ScaleNumbersStartScaleLine = 0;
            this.rpmGauge.ScaleNumbersStepScaleLines = 1;
            this.rpmGauge.Size = new System.Drawing.Size(300, 282);
            this.rpmGauge.TabIndex = 25;
            this.rpmGauge.Text = "rpmGauge";
            this.rpmGauge.Value = 15F;
            // 
            // dashBoard
            // 
            this.dashBoard.BackColor = System.Drawing.Color.White;
            this.dashBoard.Location = new System.Drawing.Point(7, 7);
            this.dashBoard.Margin = new System.Windows.Forms.Padding(4);
            this.dashBoard.Name = "dashBoard";
            this.dashBoard.Size = new System.Drawing.Size(1150, 600);
            this.dashBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.dashBoard.TabIndex = 24;
            this.dashBoard.TabStop = false;
            this.dashBoard.Click += new System.EventHandler(this.dashBoard_Click);
            // 
            // UofUOBD2Utility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1206, 693);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStatusBar);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1184, 725);
            this.Name = "UofUOBD2Utility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UofUOBD2Utility";
            this.Load += new System.EventHandler(this.UofUOBD2Utility_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dashBoard)).EndInit();
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
        private System.Windows.Forms.AGauge rpmGauge;
    }
}