using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;
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
        protected Image _currentImage;
        protected Image _tempImage;
        protected int _imageIndex = 0;

        /// <summary>
        /// List containing the images.
        /// </summary>
        protected List<RotatorImage> _images;
        public List<RotatorImage> Images
        {
            get { return this._images; }
            set { this._images = value; }
        }

        /// <summary>
        /// Picturebox used to show the current image.
        /// </summary>
        protected PictureBox _pictureBox;
        public PictureBox PictureBox
        {
            get { return this._pictureBox; }
            set { this._pictureBox = value; }
        }

        /// <summary>
        /// Path to image directory.
        /// </summary>
        protected string _imagePath;
        public string ImagePath
        {
            get { return this._imagePath; }
            set { this._imagePath = value; }
        }

        /// <summary>
        /// List for allowed file extensions.
        /// </summary>
        protected List<string> _allowedExtensions = new List<string>();
        public List<string> AllowedExtensions
        {
            get { return this._allowedExtensions; }
            set { this._allowedExtensions = value; }
        }

        /// <summary>
        /// Determines, if slideshow should return to first image after the last one.
        /// </summary>
        protected bool _loopImages = true;
        public bool LoopImages
        {
            get { return this._loopImages; }
            set { this._loopImages = value; }
        }
        #endregion

        public ImageRotator()
        {
        }

        /// <summary>
        /// Check for path existence and read the directory into the Images list.
        /// </summary>
        public void LoadImages()
        {
            this._images = new List<RotatorImage>();
            if(this._imagePath == "" || !Directory.Exists(this._imagePath))
                throw new ArgumentException("Path to image directory is invalid");

            this.ReadDirectory();
        }

        /// <summary>
        /// Read the directory into the Images list.
        /// </summary>
        protected void ReadDirectory()
        {
            DirectoryInfo directory = new DirectoryInfo(this.ImagePath);
            foreach(FileInfo file in directory.GetFiles())
            {
                if(this.AllowedExtensions.Contains(file.Extension.ToLower()))
                {
                    this.Images.Add(new RotatorImage(file.FullName, Image.FromFile(file.FullName)));
                }
            }
        }

        public void Show()
        {
            this._tempImage = this.Images[this._imageIndex].Image;
            this.ScaleTempImage();
            this.SwitchImage();
        }

        protected void SwitchImage()
        {
            this._currentImage = this._tempImage;

            this.PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBox.Image = this._currentImage;
            this.PictureBox.Refresh();
        }

        public void ShowNext()
        {
            if (this._imageIndex == (this.Images.Count - 1))
            {
                if (this.LoopImages)
                {
                    this._imageIndex = 0;
                    this.Show();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                ++this._imageIndex;
                this.Show();
            }
        }

        public void ShowPrevious()
        {
            if (this._imageIndex == 0)
            {
                if (this.LoopImages)
                {
                    this._imageIndex = this.Images.Count - 1;
                    this.Show();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                --this._imageIndex;
                this.Show();
            }
        }

        protected void ScaleTempImage()
        {
            if (this._tempImage != null)
            {
                Size tempImageSize = new Size(this._tempImage.Width, this._tempImage.Height);
                Size pictureBoxSize = new Size(this._pictureBox.Width, this._tempImage.Height);
                Size newImageSize = this.CalcScaledDimensions(tempImageSize, pictureBoxSize);

                this._tempImage = new Bitmap(this._tempImage, newImageSize.Width, newImageSize.Height);
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
