namespace TouchlessViewer
{
    partial class ApplicationSettingsWindow
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
            this.groupBoxEffects = new System.Windows.Forms.GroupBox();
            this.labelFadeDelay = new System.Windows.Forms.Label();
            this.textBoxFadeDelay = new System.Windows.Forms.TextBox();
            this.checkBoxFade = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxEffects.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEffects
            // 
            this.groupBoxEffects.Controls.Add(this.labelFadeDelay);
            this.groupBoxEffects.Controls.Add(this.textBoxFadeDelay);
            this.groupBoxEffects.Controls.Add(this.checkBoxFade);
            this.groupBoxEffects.Location = new System.Drawing.Point(13, 13);
            this.groupBoxEffects.Name = "groupBoxEffects";
            this.groupBoxEffects.Size = new System.Drawing.Size(342, 50);
            this.groupBoxEffects.TabIndex = 0;
            this.groupBoxEffects.TabStop = false;
            this.groupBoxEffects.Text = "Effects";
            // 
            // labelFadeDelay
            // 
            this.labelFadeDelay.AutoSize = true;
            this.labelFadeDelay.Enabled = false;
            this.labelFadeDelay.Location = new System.Drawing.Point(137, 20);
            this.labelFadeDelay.Name = "labelFadeDelay";
            this.labelFadeDelay.Size = new System.Drawing.Size(59, 13);
            this.labelFadeDelay.TabIndex = 2;
            this.labelFadeDelay.Text = "Fade delay";
            // 
            // textBoxFadeDelay
            // 
            this.textBoxFadeDelay.Enabled = false;
            this.textBoxFadeDelay.Location = new System.Drawing.Point(202, 16);
            this.textBoxFadeDelay.Name = "textBoxFadeDelay";
            this.textBoxFadeDelay.Size = new System.Drawing.Size(134, 20);
            this.textBoxFadeDelay.TabIndex = 1;
            // 
            // checkBoxFade
            // 
            this.checkBoxFade.AutoSize = true;
            this.checkBoxFade.Location = new System.Drawing.Point(6, 19);
            this.checkBoxFade.Name = "checkBoxFade";
            this.checkBoxFade.Size = new System.Drawing.Size(87, 17);
            this.checkBoxFade.TabIndex = 0;
            this.checkBoxFade.Text = "Fade Images";
            this.checkBoxFade.UseVisualStyleBackColor = true;
            this.checkBoxFade.CheckedChanged += new System.EventHandler(this.checkBoxFade_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(280, 69);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(199, 69);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ApplicationSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 101);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxEffects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationSettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Settings";
            this.TopMost = true;
            this.groupBoxEffects.ResumeLayout(false);
            this.groupBoxEffects.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEffects;
        private System.Windows.Forms.CheckBox checkBoxFade;
        private System.Windows.Forms.Label labelFadeDelay;
        private System.Windows.Forms.TextBox textBoxFadeDelay;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}