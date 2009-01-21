﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using ComponentFactory.Krypton.Toolkit;

namespace TouchlessViewer
{
    public partial class MainWindow : KryptonForm
    {
        private ImageRotator Rotator;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            /* check if argument is given and load corresponding file */
            /*if (args.Length == 1 && args[0] != "")
            {
                tb_path.Text = Path.GetDirectoryName(args[0]);
                loadDirectory(args[0]);
            }*/

            this.Rotator = new ImageRotator();
            this.Rotator.ImagePath = @"D:\Downloads\Wallpapers";
            this.Rotator.AllowedExtensions.Add(".jpg");
            this.Rotator.AllowedExtensions.Add(".png");
            this.Rotator.AllowedExtensions.Add(".gif");
            this.Rotator.AllowedExtensions.Add(".bmp");
            this.Rotator.PictureBox = this.pictureBoxImage;
            this.Rotator.LoadImages();
            this.Rotator.Show();
        }



        private void btn_path_Click(object sender, EventArgs e)
        {
            tb_path.Text = getFolderDialog("Bitte Pfad zu den Bildern auswählen", tb_path.Text);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            //loadDirectory();
        }

        /* load directory from textbox and show first image */
        //private void loadDirectory()
        //{
        //    try
        //    {
        //        loadFiles();
        //        showImage(_files.Next());
        //    }
        //    catch (ArgumentException ae)
        //    {
        //        showError(ae.Message);
        //    }
        //}

        /* load directory from argument and show image referenced in parameter */
        //private void loadDirectory(string filename)
        //{
        //    try
        //    {
        //        loadFiles();

        //        int count = 0;
        //        bool found = false;
        //        MyImage act = null;
        //        while (!found)
        //        {
        //            act = _files.Next();
        //            if (act.Filename == filename)
        //                found = true;

        //            ++count;
        //            if (count == _files.Count)
        //                throw new ArgumentException("File not found");
        //        }

        //        showImage(act);
        //    }
        //    catch (ArgumentException ae)
        //    {
        //        showError(ae.Message);
        //    }
        //}

        private void btn_previous_Click(object sender, EventArgs e)
        {
            this.Rotator.ShowPrevious();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.Rotator.ShowNext();
        }

        private void showError(string message)
        {
            MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string getFolderDialog(string Description, string oldpath)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = Description;
            dialog.SelectedPath = oldpath;
            dialog.ShowDialog();
            return dialog.SelectedPath;
        }



        /**
         * assure that pictureBox always fits window
         */
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            this.positionPictureBox();
            this.positionMainControls();
            this.Rotator.Show();
        }

        private void positionPictureBox()
        {
            this.pictureBoxImage.Width = this.Width;
            this.pictureBoxImage.Height = this.Height - 100;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
        }

        private void positionMainControls()
        {
            int locationX = (int)((this.Width - this.panelMainControls.Width) / 2);
            int locationY = this.Height - this.panelMainControls.Height - 40;
            this.panelMainControls.Location = new System.Drawing.Point(locationX, locationY);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue.ToString() == "n")
        //        this.Rotator.ShowNext();

        //    if (e.KeyValue.ToString() == "p")
        //        this.Rotator.ShowPrevious();
        //}
    }
}
