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
            this.graphYAxisDisplay = new System.Windows.Forms.PictureBox();
            this.graphXAxisDisplay = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuGraphOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHeader = new System.Windows.Forms.Label();
            this.graphYLabel = new System.Windows.Forms.Label();
            this.graphXLabel = new System.Windows.Forms.Label();
            this.bgrndDisplay = new System.Windows.Forms.PictureBox();
            this.startHeader = new System.Windows.Forms.Label();
            this.graphDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphYAxisDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphXAxisDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgrndDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // graphYAxisDisplay
            // 
            this.graphYAxisDisplay.Location = new System.Drawing.Point(12, 98);
            this.graphYAxisDisplay.Name = "graphYAxisDisplay";
            this.graphYAxisDisplay.Size = new System.Drawing.Size(99, 550);
            this.graphYAxisDisplay.TabIndex = 1;
            this.graphYAxisDisplay.TabStop = false;
            // 
            // graphXAxisDisplay
            // 
            this.graphXAxisDisplay.Location = new System.Drawing.Point(12, 654);
            this.graphXAxisDisplay.Name = "graphXAxisDisplay";
            this.graphXAxisDisplay.Size = new System.Drawing.Size(890, 75);
            this.graphXAxisDisplay.TabIndex = 2;
            this.graphXAxisDisplay.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGraphOption,
            this.menuOption2,
            this.menuOption3,
            this.menuOption4,
            this.menuOption5,
            this.menuHome,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuGraphOption
            // 
            this.menuGraphOption.Name = "menuGraphOption";
            this.menuGraphOption.Size = new System.Drawing.Size(68, 20);
            this.menuGraphOption.Text = "Graphing";
            this.menuGraphOption.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuOption2
            // 
            this.menuOption2.Name = "menuOption2";
            this.menuOption2.Size = new System.Drawing.Size(62, 20);
            this.menuOption2.Text = "Option2";
            // 
            // menuOption3
            // 
            this.menuOption3.Name = "menuOption3";
            this.menuOption3.Size = new System.Drawing.Size(62, 20);
            this.menuOption3.Text = "Option3";
            // 
            // menuOption4
            // 
            this.menuOption4.Name = "menuOption4";
            this.menuOption4.Size = new System.Drawing.Size(62, 20);
            this.menuOption4.Text = "Option4";
            // 
            // menuOption5
            // 
            this.menuOption5.Name = "menuOption5";
            this.menuOption5.Size = new System.Drawing.Size(62, 20);
            this.menuOption5.Text = "Option5";
            // 
            // menuHome
            // 
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(52, 20);
            this.menuHome.Text = "Home";
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem7.Text = "toolStripMenuItem7";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem8.Text = "toolStripMenuItem8";
            // 
            // graphHeader
            // 
            this.graphHeader.AutoSize = true;
            this.graphHeader.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphHeader.Location = new System.Drawing.Point(391, 52);
            this.graphHeader.Name = "graphHeader";
            this.graphHeader.Size = new System.Drawing.Size(198, 43);
            this.graphHeader.TabIndex = 4;
            this.graphHeader.Text = "GRAPH X VS Y";
            // 
            // graphYLabel
            // 
            this.graphYLabel.AutoSize = true;
            this.graphYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphYLabel.Location = new System.Drawing.Point(73, 68);
            this.graphYLabel.Name = "graphYLabel";
            this.graphYLabel.Size = new System.Drawing.Size(99, 25);
            this.graphYLabel.TabIndex = 5;
            this.graphYLabel.Text = "Y LABEL";
            // 
            // graphXLabel
            // 
            this.graphXLabel.AutoSize = true;
            this.graphXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphXLabel.Location = new System.Drawing.Point(908, 623);
            this.graphXLabel.Name = "graphXLabel";
            this.graphXLabel.Size = new System.Drawing.Size(98, 25);
            this.graphXLabel.TabIndex = 6;
            this.graphXLabel.Text = "X LABEL";
            // 
            // bgrndDisplay
            // 
            this.bgrndDisplay.Location = new System.Drawing.Point(4, 2);
            this.bgrndDisplay.Name = "bgrndDisplay";
            this.bgrndDisplay.Size = new System.Drawing.Size(1001, 726);
            this.bgrndDisplay.TabIndex = 7;
            this.bgrndDisplay.TabStop = false;
            // 
            // startHeader
            // 
            this.startHeader.AutoSize = true;
            this.startHeader.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHeader.Location = new System.Drawing.Point(233, 68);
            this.startHeader.Name = "startHeader";
            this.startHeader.Size = new System.Drawing.Size(519, 129);
            this.startHeader.TabIndex = 8;
            this.startHeader.Text = "\r\n  Welcome to the UofU OBD2 Utility \r\nPlease Select an option from above\r\n";
            // 
            // graphDisplay
            // 
            this.graphDisplay.Location = new System.Drawing.Point(117, 98);
            this.graphDisplay.Name = "graphDisplay";
            this.graphDisplay.Size = new System.Drawing.Size(785, 550);
            this.graphDisplay.TabIndex = 0;
            this.graphDisplay.TabStop = false;
            // 
            // UofUOBD2Utility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 741);
            this.Controls.Add(this.startHeader);
            this.Controls.Add(this.graphXLabel);
            this.Controls.Add(this.graphYLabel);
            this.Controls.Add(this.graphHeader);
            this.Controls.Add(this.graphXAxisDisplay);
            this.Controls.Add(this.graphYAxisDisplay);
            this.Controls.Add(this.graphDisplay);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.bgrndDisplay);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UofUOBD2Utility";
            this.Text = "UofUOBD2Utility";
            this.Load += new System.EventHandler(this.UofUOBD2Utility_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphYAxisDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphXAxisDisplay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgrndDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox graphYAxisDisplay;
        private System.Windows.Forms.PictureBox graphXAxisDisplay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuGraphOption;
        private System.Windows.Forms.ToolStripMenuItem menuOption2;
        private System.Windows.Forms.ToolStripMenuItem menuOption3;
        private System.Windows.Forms.ToolStripMenuItem menuOption4;
        private System.Windows.Forms.ToolStripMenuItem menuOption5;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.Label graphHeader;
        private System.Windows.Forms.Label graphYLabel;
        private System.Windows.Forms.Label graphXLabel;
        private System.Windows.Forms.PictureBox bgrndDisplay;
        private System.Windows.Forms.Label startHeader;
        private System.Windows.Forms.PictureBox graphDisplay;
    }
}