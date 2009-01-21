using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TouchlessViewer
{
    class ImageRotator
    {
        #region Delegates
        public delegate void ImagePositionHandler();
        #endregion

        #region Events
        public event ImagePositionHandler OnFirstImage;
        public event ImagePositionHandler OnLastImage;
        #endregion

        #region Class Members
        protected List<System.Drawing.Image> _images;
        protected System.Drawing.Image _currentImage;
        protected System.Drawing.Image _tempImage;

        protected int _imageIndex = 0;

        protected System.Windows.Forms.PictureBox _pictureBox;
        public System.Windows.Forms.PictureBox PictureBox
        {
            get { return this._pictureBox; }
            set { this._pictureBox = value; }
        }

        protected string _imagePath;
        public string ImagePath
        {
            get { return this._imagePath; }
            set { this._imagePath = value; }
        }
        #endregion

        public ImageRotator()
        {
            this._images
        }

        public void LoadImages()
        {
            this._images = new List<System.Drawing.Image>();
            if(this._imagePath == "" || !Directory.Exists(this._imagePath))
                throw new ArgumentException("Path to image directory is invalid");

            foreach (string filename in System.IO.Directory.GetFiles(tb_path.Text))
            {
                try
                {
                    _files.Add(
                        new MyImage(
                            filename,
                            new BitmapImage(new Uri(filename)),
                            System.IO.Path.GetFileNameWithoutExtension(filename)));
                }
                catch { }
            }
        }

        public void Show()
        {
        }

        public void ShowNext()
        {
        }

        public void ShowPrevious()
        {
        }

        protected void ScaleTempImage()
        {
            try
            {
                if (this._tempImage != null)
                {
                    Size tempImageSize = new Size(this._tempImage.Width, this._tempImage.Height);
                    Size pictureBoxSize = new Size(this._pictureBox.Width, this._tempImage.Height);
                    Size newImageSize = this.CalcScaledDimensions(tempImageSize, pictureBoxSize);

                    this._tempImage = new Bitmap(this._tempImage, newImageSize.Width, newImageSize.Height);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected Size CalcScaledDimensions(Size imageDimensions, Size containerDimensions)
        {
            double scaleMultiplier = 0;

            if (imageDimensions.Height > imageDimensions.Width)
            {
                if (containerDimensions.Height > containerDimensions.Width)
                {
                    scaleMultiplier = (double)containerDimensions.Width / (double)imageDimensions.Width;
                }
                else
                {
                    scaleMultiplier = (double)containerDimensions.Height / (double)imageDimensions.Height;
                }
            }
            else
            {
                if (containerDimensions.Height > containerDimensions.Width)
                {
                    scaleMultiplier = (double)containerDimensions.Width / (double)imageDimensions.Width;
                }
                else
                {
                    scaleMultiplier = (double)containerDimensions.Width / (double)imageDimensions.Height;
                }
            }

            return new Size((int)(imageDimensions.Width * scaleMultiplier),
                            (int)(imageDimensions.Height * scaleMultiplier));
        }
    }
}
