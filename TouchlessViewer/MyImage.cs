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
using System.Windows.Media;

namespace TouchlessViewer
{
    public class MyImage
    {
        private ImageSource _image;
        private string _name;
        private string _filename;

        public MyImage(string filename, ImageSource image, string name)
        {
            _filename = filename;
            _image = image;
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        public ImageSource Image
        {
            get { return _image; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Filename
        {
            get { return _filename; }
        }
    }
}