using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TouchlessViewer
{
    class RotatorImageComparer : IComparer<RotatorImage>
    {
        public int Compare(RotatorImage x, RotatorImage y)
        {
            return String.Compare(Path.GetFileName(x.Filename), Path.GetFileName(y.Filename), StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
