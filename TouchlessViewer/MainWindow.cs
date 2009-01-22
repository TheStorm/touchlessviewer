﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace TouchlessViewer
{
    public partial class MainWindow : Form
    {
        private TouchlessManager Touchless;
        private ImageRotator Rotator;
        public List<string> AllowedExtensions;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            this.ChangeTitle("No images loaded");
            this.PositionPictureBox();

            this.AllowedExtensions = new List<string>();
            this.AllowedExtensions.Add(".jpg");
            this.AllowedExtensions.Add(".png");
            this.AllowedExtensions.Add(".gif");
            this.AllowedExtensions.Add(".bmp");

            if (args.Length == 1 && args[0] != "")
            {
                FileInfo file = new FileInfo(args[0]);
                if (file.Exists && this.AllowedExtensions.Contains(file.Extension.ToLower()))
                {
                    this.loadRotator(file.DirectoryName, file.FullName);
                }
            }

            this.loadTouchless();
        }

        private void ChangeTitle(string title)
        {
            this.Text = "TouchLessViewer - " + title;
        }

        private void loadRotator(string path)
        {
            this.loadRotator(path, null);
        }

        private void loadRotator(string path, string filename)
        {
            this.Rotator = new ImageRotator();
            this.Rotator.ImagePath = path;
            this.Rotator.AllowedExtensions = this.AllowedExtensions;
            this.Rotator.PictureBox = this.pictureBoxImage;
            this.Rotator.FormTitle = this.ChangeTitle;

            this.ChangeTitle("Loading...");
            this.Rotator.LoadImages();

            if (filename != null)
                this.Rotator.FindByFilename(filename);

            this.Rotator.Show();
        }

        private void loadTouchless()
        {
            this.Touchless = new TouchlessManager();
        }

        #region Resizing and positioning of MainWindow & PictureBox
        private void MainWindow_ResizeBegin(object sender, EventArgs e)
        {
            // avoid "jumping around" when image is centered before resizing
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            this.PositionPictureBox();
            this.Rotator.Show();
            this.pictureBoxImage.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void PositionPictureBox()
        {
            this.pictureBoxImage.Width = this.ClientSize.Width;
            this.pictureBoxImage.Height = this.ClientSize.Height - this.MainMenuStrip.Height - this.statusStrip.Height;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, this.MainMenuStrip.Height);
            this.pictureBoxImage.Refresh();
        }
        #endregion

        #region Drag&Drop
        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string filename;
            bool isValid = CheckDragAndDropItem(out filename, e);
            
            if (isValid)
            {
                FileInfo file = new FileInfo(filename);
                if (file.Exists)
                {
                    this.ChangeTitle("Loading...");
                    this.loadRotator(file.DirectoryName, file.FullName);
                }
            }
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            string filename;
            bool isValid = CheckDragAndDropItem(out filename, e);
            
            if (isValid)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;            
        }

        private bool CheckDragAndDropItem(out string filename, DragEventArgs e)
        {
            filename = String.Empty;
            bool isValid = false;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        if(this.AllowedExtensions.Contains(Path.GetExtension(filename).ToLower()))
                        {
                            isValid = true;
                        }
                    }
                }
            }

            return isValid;
        }
        #endregion

        #region Keyboard events
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.P || e.KeyCode == Keys.B)
                this.Rotator.ShowPrevious();
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.N)
                this.Rotator.ShowNext();
        }
        #endregion

        #region Mainmenu
        private void fileChangeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select a directory.";

            if(this.Rotator != null)
                dialog.SelectedPath = this.Rotator.ImagePath;
          
            DialogResult dResult = dialog.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                this.loadRotator(dialog.SelectedPath);
            }            
        }

        private void fileQuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationSettingsWindow applicationSettings = new ApplicationSettingsWindow();
            applicationSettings.ShowDialog();
        }

        private void cameraSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraSettingsWindow cameraSettings = new CameraSettingsWindow();
            cameraSettings.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
        #endregion
    }
}
