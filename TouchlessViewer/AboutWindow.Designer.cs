﻿namespace TouchlessViewer
{
    partial class AboutWindow
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
            this.aboutBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // aboutBox
            // 
            this.aboutBox.Location = new System.Drawing.Point(13, 13);
            this.aboutBox.Multiline = true;
            this.aboutBox.Name = "aboutBox";
            this.aboutBox.Size = new System.Drawing.Size(259, 239);
            this.aboutBox.TabIndex = 0;
            this.aboutBox.Text = "\r\nTouchlessviewer v 0.7b patch 0 fix 0\r\n\r\ncoded by\r\n\r\nmaff, The Storm, Knox, Heat" +
                "hcliff & Aeroangel\r\n\r\ndesigned by\r\n\r\nmaff\r\n\r\nvisit http://touchlessviewer.ailoo." +
                "net";
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.aboutBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About TouchLessViewer";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox aboutBox;

    }
}