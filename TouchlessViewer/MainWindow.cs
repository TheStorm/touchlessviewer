using System;
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

namespace TouchlessViewer
{
    public partial class MainWindow : Form
    {
        private MyList<MyImage> _files;
        private Image tmpImg;

        public MainWindow(string[] args)
        {
            InitializeComponent();

            /* check if argument is given and load corresponding file */
            if (args.Length == 1 && args[0] != "")
            {
                tb_path.Text = Path.GetDirectoryName(args[0]);
                loadDirectory(args[0]);
            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            tb_path.Text = getFolderDialog("Bitte Pfad zu den Bildern auswählen", tb_path.Text);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            loadDirectory();
        }

        /* load directory from textbox and show first image */
        private void loadDirectory()
        {
            try
            {
                loadFiles();
                showImage(_files.Next());
            }
            catch (ArgumentException ae)
            {
                showError(ae.Message);
            }
        }

        /* load directory from argument and show image referenced in parameter */
        private void loadDirectory(string filename)
        {
            try
            {
                loadFiles();

                int count = 0;
                bool found = false;
                MyImage act = null;
                while (!found)
                {
                    act = _files.Next();
                    if (act.Filename == filename)
                        found = true;

                    ++count;
                    if (count == _files.Count)
                        throw new ArgumentException("File not found");
                }

                showImage(act);
            }
            catch (ArgumentException ae)
            {
                showError(ae.Message);
            }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if(_files != null && _files.Count > 0)
                showImage(_files.Previous());
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (_files != null && _files.Count > 0)
                showImage(_files.Next());
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

        private void loadFiles()
        {
            if (tb_path.Text == "" || !Directory.Exists(tb_path.Text))
                throw new ArgumentException("Der Pfad zum Bilderverzeichnis ist ungültig");
            
            _files = new MyList<MyImage>();
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

        private void showImage(MyImage image)
        {
            this.tmpImg = Image.FromFile(image.Filename);
            fitImageToWindow();

            pictureBoxImage.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxImage.Image = this.tmpImg;
            pictureBoxImage.Refresh();
        }

        private void fitImageToWindow()
        {
            try
            {
                /* Don't perform any operation if no image is loaded. */
                if (this.tmpImg != null)
                {
                    /* Create a temporary Image.

                     * Always work from the original image, stored in the Tag. 
                     */

                    Image tempImage = (Image)this.tmpImg;

                    /* Calculate the dimensions necessary for an image to fit. */
                    Size fitImageSize = this.getScaledImageDimensions(
                        tempImage.Width, tempImage.Height, this.pictureBoxImage.Width, this.pictureBoxImage.Height);

                    /* Create a new Bitmap from the original image with the new dimensions.

                     * The constructor for the Bitmap object automatically scales as necessary.
                     */

                    Bitmap imgOutput = new Bitmap(tempImage, fitImageSize.Width, fitImageSize.Height);

                    /* Clear any existing image in the PictureBox. */
                    this.tmpImg = null;

                    /* Finally, set the Image property to point to the new, resized image. */
                    this.tmpImg = imgOutput;                    
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private Size getScaledImageDimensions(
                  int currentImageWidth,
                  int currentImageHeight,
                  int desiredImageWidth,
                  int desiredImageHeight)
        {
            /* First, we must calculate a multiplier that will be used

             * to get the dimensions of the new, scaled image.
             */

            double scaleImageMultiplier = 0;

            /* This multiplier is defined as the ratio of the

             * Desired Dimension to the Current Dimension.
             * Specifically which dimension is used depends on the larger
             * dimension of the image, as this will be the constraining dimension
             * when we fit to the window.
             */


            /* Determine if Image is Portrait or Landscape. */
            if (currentImageHeight > currentImageWidth)    /* Image is Portrait */
            {
                /* Calculate the multiplier based on the heights. */
                if (desiredImageHeight > desiredImageWidth)
                {
                    scaleImageMultiplier = (double)desiredImageWidth / (double)currentImageWidth;
                }

                else
                {
                    scaleImageMultiplier = (double)desiredImageHeight / (double)currentImageHeight;
                }
            }

            else /* Image is Landscape */
            {
                /* Calculate the multiplier based on the widths. */
                if (desiredImageHeight > desiredImageWidth)
                {
                    scaleImageMultiplier = (double)desiredImageWidth / (double)currentImageWidth;
                }

                else
                {
                    scaleImageMultiplier = (double)desiredImageHeight / (double)currentImageHeight;
                }
            }

            /* Generate and return the new scaled dimensions.

             * Essentially, we multiply each dimension of the original image
             * by the multiplier calculated above to yield the dimensions
             * of the scaled image. The scaled image can be larger or smaller
             * than the original.
             */

            return new Size(
                (int)(currentImageWidth * scaleImageMultiplier),
                (int)(currentImageHeight * scaleImageMultiplier));
        }
    }
}
