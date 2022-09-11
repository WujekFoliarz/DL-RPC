namespace DL_RPC
{
    partial class main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.mapIcon = new System.Windows.Forms.PictureBox();
            this.playerCountDisplay = new System.Windows.Forms.Label();
            this.mapNameDisplay = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日本語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.hidecheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapIcon)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapIcon
            // 
            this.mapIcon.Location = new System.Drawing.Point(15, 46);
            this.mapIcon.Name = "mapIcon";
            this.mapIcon.Size = new System.Drawing.Size(121, 118);
            this.mapIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapIcon.TabIndex = 0;
            this.mapIcon.TabStop = false;
            this.mapIcon.Visible = false;
            // 
            // playerCountDisplay
            // 
            this.playerCountDisplay.AutoSize = true;
            this.playerCountDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerCountDisplay.Location = new System.Drawing.Point(142, 70);
            this.playerCountDisplay.Name = "playerCountDisplay";
            this.playerCountDisplay.Size = new System.Drawing.Size(201, 24);
            this.playerCountDisplay.TabIndex = 1;
            this.playerCountDisplay.Text = "%playerCountDisplay%";
            this.playerCountDisplay.Visible = false;
            // 
            // mapNameDisplay
            // 
            this.mapNameDisplay.AutoSize = true;
            this.mapNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mapNameDisplay.Location = new System.Drawing.Point(142, 46);
            this.mapNameDisplay.Name = "mapNameDisplay";
            this.mapNameDisplay.Size = new System.Drawing.Size(188, 24);
            this.mapNameDisplay.TabIndex = 2;
            this.mapNameDisplay.Text = "%mapNameDisplay%";
            this.mapNameDisplay.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Checked = true;
            this.languageToolStripMenuItem.CheckOnClick = true;
            this.languageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polskiToolStripMenuItem,
            this.日本語ToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.languageToolStripMenuItem.Text = "%string_language%";
            this.languageToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // polskiToolStripMenuItem
            // 
            this.polskiToolStripMenuItem.CheckOnClick = true;
            this.polskiToolStripMenuItem.Name = "polskiToolStripMenuItem";
            this.polskiToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.polskiToolStripMenuItem.Text = "polski";
            this.polskiToolStripMenuItem.Click += new System.EventHandler(this.polskiToolStripMenuItem_Click);
            // 
            // 日本語ToolStripMenuItem
            // 
            this.日本語ToolStripMenuItem.CheckOnClick = true;
            this.日本語ToolStripMenuItem.Name = "日本語ToolStripMenuItem";
            this.日本語ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.日本語ToolStripMenuItem.Text = "日本語";
            this.日本語ToolStripMenuItem.Click += new System.EventHandler(this.日本語ToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.englishToolStripMenuItem.Text = "english";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(232, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Language change applies after restart!";
            // 
            // waitingLabel
            // 
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.waitingLabel.Location = new System.Drawing.Point(12, 40);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.Size = new System.Drawing.Size(270, 37);
            this.waitingLabel.TabIndex = 5;
            this.waitingLabel.Text = "%waiting_string%";
            // 
            // hidecheckbox
            // 
            this.hidecheckbox.AutoSize = true;
            this.hidecheckbox.Location = new System.Drawing.Point(143, 146);
            this.hidecheckbox.Name = "hidecheckbox";
            this.hidecheckbox.Size = new System.Drawing.Size(93, 17);
            this.hidecheckbox.TabIndex = 6;
            this.hidecheckbox.Text = "%hide_string%";
            this.hidecheckbox.UseVisualStyleBackColor = true;
            this.hidecheckbox.CheckedChanged += new System.EventHandler(this.hidecheckbox_CheckedChanged);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(421, 191);
            this.Controls.Add(this.hidecheckbox);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapNameDisplay);
            this.Controls.Add(this.playerCountDisplay);
            this.Controls.Add(this.mapIcon);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.Text = "DL Rich Presence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_form_FormClosing);
            this.Load += new System.EventHandler(this.main_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapIcon)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapIcon;
        private System.Windows.Forms.Label playerCountDisplay;
        private System.Windows.Forms.Label mapNameDisplay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日本語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.CheckBox hidecheckbox;
    }
}