using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using TouchlessLib;

namespace TouchlessViewer
{
    class TouchlessManager
    {
        protected bool _addingMarker = false;
        protected static float _markerRadius;
        protected static Point _markerCenter;
        protected static Marker _markerSelected;
        protected static int _addedMarkerCount = 0;
        
        protected TouchlessMgr _touchless;
        public TouchlessMgr Touchless
        {
            get { return this._touchless; }
            set { this._touchless = value; }
        }

        public TouchlessManager()
        {
            this.Touchless = new TouchlessMgr();
            this.loadCameras();
        }

        protected void loadCameras()
        {
            foreach (Camera cam in this.Touchless.Cameras)
                MessageBox.Show(cam.ToString());
        }
    }
}
