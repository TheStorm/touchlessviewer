using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using ComponentFactory.Krypton.Toolkit;

namespace TouchlessViewer
{
    public partial class MainWindow : Form
    {
        private ImageRotator Rotator;
        public List<string> AllowedExtensions;
        private bool _rotatorLoaded = false;

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
        }

        private void ChangeTitle(string title)
        {
            this.Text = "TouchLess Viewer - " + title;
        }

        private void loadRotator(string path, string filename)
        {
            this.Rotator = new ImageRotator();
            this.Rotator.ImagePath = path;
            this.Rotator.AllowedExtensions = this.AllowedExtensions;
            this.Rotator.PictureBox = this.pictureBoxImage;
            this.Rotator.FormTitle = this.ChangeTitle;
            this.Rotator.LoadImages();

            if (filename != null)
                this.Rotator.FindByFilename(filename);

            this.Rotator.Show();
            this._rotatorLoaded = true;
        }

        #region Resizing and positioning of MainWindow & PictureBox
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            this.PositionPictureBox();
            this.pictureBoxImage.Refresh();
            this.Rotator.Show();
        }

        private void PositionPictureBox()
        {
            this.pictureBoxImage.Width = this.ClientSize.Width;
            this.pictureBoxImage.Height = this.ClientSize.Height;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
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
                if (file.Exists && this.AllowedExtensions.Contains(file.Extension.ToLower()))
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
    }
}
