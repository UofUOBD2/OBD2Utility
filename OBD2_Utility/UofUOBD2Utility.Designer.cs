﻿namespace OBD2_Utility
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
            this.graphTypeLabel = new System.Windows.Forms.Label();
            this.graphOption1Select = new System.Windows.Forms.ListBox();
            this.graphOption2Select = new System.Windows.Forms.ListBox();
            this.graphOption3Select = new System.Windows.Forms.ListBox();
            this.graphGraphButton = new System.Windows.Forms.Button();
            this.menuStatusBar = new System.Windows.Forms.TextBox();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.graphFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.graphDataPointOneLabel = new System.Windows.Forms.Label();
            this.graphDataPointTwoLabel = new System.Windows.Forms.Label();
            this.dashBoard = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.graphFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGraph1,
            this.menuGraph2,
            this.menuGraph3,
            this.menuOption4,
            this.menuSettings,
            this.menuHome});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1334, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuGraph1
            // 
            this.menuGraph1.Name = "menuGraph1";
            this.menuGraph1.Size = new System.Drawing.Size(76, 20);
            this.menuGraph1.Text = "Graph One";
            this.menuGraph1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuGraph2
            // 
            this.menuGraph2.Name = "menuGraph2";
            this.menuGraph2.Size = new System.Drawing.Size(76, 20);
            this.menuGraph2.Text = "Graph Two";
            this.menuGraph2.Click += new System.EventHandler(this.menuGraph2_Click);
            // 
            // menuGraph3
            // 
            this.menuGraph3.Name = "menuGraph3";
            this.menuGraph3.Size = new System.Drawing.Size(84, 20);
            this.menuGraph3.Text = "Graph Three";
            this.menuGraph3.Click += new System.EventHandler(this.menuGraph3_Click);
            // 
            // menuOption4
            // 
            this.menuOption4.Name = "menuOption4";
            this.menuOption4.Size = new System.Drawing.Size(95, 20);
            this.menuOption4.Text = "Trouble Codes";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(61, 20);
            this.menuSettings.Text = "Settings";
            // 
            // menuHome
            // 
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(52, 20);
            this.menuHome.Text = "Home";
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // graphHeader
            // 
            this.graphHeader.AutoSize = true;
            this.graphHeader.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphHeader.Location = new System.Drawing.Point(1124, 34);
            this.graphHeader.Name = "graphHeader";
            this.graphHeader.Size = new System.Drawing.Size(198, 43);
            this.graphHeader.TabIndex = 4;
            this.graphHeader.Text = "GRAPH X VS Y";
            // 
            // graphGenerateButton
            // 
            this.graphGenerateButton.Location = new System.Drawing.Point(1144, 149);
            this.graphGenerateButton.Name = "graphGenerateButton";
            this.graphGenerateButton.Size = new System.Drawing.Size(144, 71);
            this.graphGenerateButton.TabIndex = 9;
            this.graphGenerateButton.Text = "Load Data";
            this.graphGenerateButton.UseVisualStyleBackColor = true;
            this.graphGenerateButton.Click += new System.EventHandler(this.graphGenerateButton_Click);
            // 
            // graphYAxisSelect
            // 
            this.graphYAxisSelect.FormattingEnabled = true;
            this.graphYAxisSelect.Location = new System.Drawing.Point(1144, 103);
            this.graphYAxisSelect.Name = "graphYAxisSelect";
            this.graphYAxisSelect.Size = new System.Drawing.Size(144, 17);
            this.graphYAxisSelect.TabIndex = 10;
            // 
            // graphXAxisSelect
            // 
            this.graphXAxisSelect.FormattingEnabled = true;
            this.graphXAxisSelect.Location = new System.Drawing.Point(1144, 80);
            this.graphXAxisSelect.Name = "graphXAxisSelect";
            this.graphXAxisSelect.Size = new System.Drawing.Size(144, 17);
            this.graphXAxisSelect.TabIndex = 11;
            // 
            // graphBarBox
            // 
            this.graphBarBox.AutoSize = true;
            this.graphBarBox.Location = new System.Drawing.Point(1144, 126);
            this.graphBarBox.Name = "graphBarBox";
            this.graphBarBox.Size = new System.Drawing.Size(42, 17);
            this.graphBarBox.TabIndex = 12;
            this.graphBarBox.Text = "Bar";
            this.graphBarBox.UseVisualStyleBackColor = true;
            // 
            // graphLineBox
            // 
            this.graphLineBox.AutoSize = true;
            this.graphLineBox.Location = new System.Drawing.Point(1192, 126);
            this.graphLineBox.Name = "graphLineBox";
            this.graphLineBox.Size = new System.Drawing.Size(46, 17);
            this.graphLineBox.TabIndex = 13;
            this.graphLineBox.Text = "Line";
            this.graphLineBox.UseVisualStyleBackColor = true;
            // 
            // graphTypeLabel
            // 
            this.graphTypeLabel.AutoSize = true;
            this.graphTypeLabel.Location = new System.Drawing.Point(479, 80);
            this.graphTypeLabel.Name = "graphTypeLabel";
            this.graphTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.graphTypeLabel.TabIndex = 14;
            this.graphTypeLabel.Text = "Type";
            // 
            // graphOption1Select
            // 
            this.graphOption1Select.FormattingEnabled = true;
            this.graphOption1Select.Location = new System.Drawing.Point(1144, 255);
            this.graphOption1Select.Name = "graphOption1Select";
            this.graphOption1Select.Size = new System.Drawing.Size(144, 225);
            this.graphOption1Select.TabIndex = 15;
            this.graphOption1Select.SelectedIndexChanged += new System.EventHandler(this.graphOption1Select_SelectedIndexChanged);
            // 
            // graphOption2Select
            // 
            this.graphOption2Select.FormattingEnabled = true;
            this.graphOption2Select.Location = new System.Drawing.Point(1144, 530);
            this.graphOption2Select.Name = "graphOption2Select";
            this.graphOption2Select.Size = new System.Drawing.Size(144, 212);
            this.graphOption2Select.TabIndex = 16;
            // 
            // graphOption3Select
            // 
            this.graphOption3Select.FormattingEnabled = true;
            this.graphOption3Select.Location = new System.Drawing.Point(1144, 748);
            this.graphOption3Select.Name = "graphOption3Select";
            this.graphOption3Select.Size = new System.Drawing.Size(144, 17);
            this.graphOption3Select.TabIndex = 17;
            this.graphOption3Select.SelectedIndexChanged += new System.EventHandler(this.graphOption3Select_SelectedIndexChanged);
            // 
            // graphGraphButton
            // 
            this.graphGraphButton.Location = new System.Drawing.Point(1144, 771);
            this.graphGraphButton.Name = "graphGraphButton";
            this.graphGraphButton.Size = new System.Drawing.Size(144, 64);
            this.graphGraphButton.TabIndex = 18;
            this.graphGraphButton.Text = "Graph";
            this.graphGraphButton.UseVisualStyleBackColor = true;
            this.graphGraphButton.Click += new System.EventHandler(this.graphGraphButton_Click);
            // 
            // menuStatusBar
            // 
            this.menuStatusBar.Location = new System.Drawing.Point(443, 4);
            this.menuStatusBar.Name = "menuStatusBar";
            this.menuStatusBar.Size = new System.Drawing.Size(845, 20);
            this.menuStatusBar.TabIndex = 19;
            // 
            // graphFlowPanel
            // 
            this.graphFlowPanel.AutoScroll = true;
            this.graphFlowPanel.Controls.Add(this.dashBoard);
            this.graphFlowPanel.Location = new System.Drawing.Point(12, 41);
            this.graphFlowPanel.Name = "graphFlowPanel";
            this.graphFlowPanel.Size = new System.Drawing.Size(1107, 794);
            this.graphFlowPanel.TabIndex = 21;
            this.graphFlowPanel.MouseHover += new System.EventHandler(this.graphFlowPanel_MouseHover);
            // 
            // graphDataPointOneLabel
            // 
            this.graphDataPointOneLabel.AutoSize = true;
            this.graphDataPointOneLabel.Location = new System.Drawing.Point(1141, 239);
            this.graphDataPointOneLabel.Name = "graphDataPointOneLabel";
            this.graphDataPointOneLabel.Size = new System.Drawing.Size(113, 13);
            this.graphDataPointOneLabel.TabIndex = 22;
            this.graphDataPointOneLabel.Text = "Select Data Point One";
            // 
            // graphDataPointTwoLabel
            // 
            this.graphDataPointTwoLabel.AutoSize = true;
            this.graphDataPointTwoLabel.Location = new System.Drawing.Point(1141, 514);
            this.graphDataPointTwoLabel.Name = "graphDataPointTwoLabel";
            this.graphDataPointTwoLabel.Size = new System.Drawing.Size(114, 13);
            this.graphDataPointTwoLabel.TabIndex = 23;
            this.graphDataPointTwoLabel.Text = "Select Data Point Two";
            // 
            // dashBoard
            // 
            this.dashBoard.BackColor = System.Drawing.Color.White;
            this.dashBoard.Location = new System.Drawing.Point(3, 3);
            this.dashBoard.Name = "dashBoard";
            this.dashBoard.Size = new System.Drawing.Size(1283, 794);
            this.dashBoard.TabIndex = 24;
            this.dashBoard.TabStop = false;
            // 
            // UofUOBD2Utility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1334, 861);
            this.Controls.Add(this.graphDataPointTwoLabel);
            this.Controls.Add(this.graphDataPointOneLabel);
            this.Controls.Add(this.graphFlowPanel);
            this.Controls.Add(this.menuStatusBar);
            this.Controls.Add(this.graphGraphButton);
            this.Controls.Add(this.graphOption3Select);
            this.Controls.Add(this.graphOption2Select);
            this.Controls.Add(this.graphOption1Select);
            this.Controls.Add(this.graphTypeLabel);
            this.Controls.Add(this.graphLineBox);
            this.Controls.Add(this.graphBarBox);
            this.Controls.Add(this.graphXAxisSelect);
            this.Controls.Add(this.graphYAxisSelect);
            this.Controls.Add(this.graphGenerateButton);
            this.Controls.Add(this.graphHeader);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UofUOBD2Utility";
            this.Text = "UofUOBD2Utility";
            this.Load += new System.EventHandler(this.UofUOBD2Utility_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.graphFlowPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Label graphTypeLabel;
        private System.Windows.Forms.ListBox graphOption1Select;
        private System.Windows.Forms.ListBox graphOption2Select;
        private System.Windows.Forms.ListBox graphOption3Select;
        private System.Windows.Forms.Button graphGraphButton;
        private System.Windows.Forms.TextBox menuStatusBar;
        private System.ComponentModel.BackgroundWorker bg;
        private System.Windows.Forms.FlowLayoutPanel graphFlowPanel;
        private System.Windows.Forms.Label graphDataPointOneLabel;
        private System.Windows.Forms.Label graphDataPointTwoLabel;
        private System.Windows.Forms.PictureBox dashBoard;
    }
}