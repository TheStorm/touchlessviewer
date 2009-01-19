namespace TouchlessViewer
{
    partial class MainWindow
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
            this.tb_path = new System.Windows.Forms.TextBox();
            this.lbl_path = new System.Windows.Forms.Label();
            this.btn_path = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(12, 679);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(378, 20);
            this.tb_path.TabIndex = 0;
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(9, 663);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(29, 13);
            this.lbl_path.TabIndex = 1;
            this.lbl_path.Text = "Pfad";
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(396, 677);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(101, 23);
            this.btn_path.TabIndex = 2;
            this.btn_path.Text = "Durchsuchen...";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(711, 677);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "Laden";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(774, 635);
            this.pictureBoxImage.TabIndex = 4;
            this.pictureBoxImage.TabStop = false;
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(630, 677);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "weiter";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.Location = new System.Drawing.Point(549, 677);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(75, 23);
            this.btn_previous.TabIndex = 6;
            this.btn_previous.Text = "zurück";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(798, 711);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.tb_path);
            this.Name = "MainWindow";
            this.Text = "TouchlessViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
    }
}

