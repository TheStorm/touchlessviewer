using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchlessViewer
{
    class MyList<T> : List<T>
    {
        private int index = -1;

        public T Next()
        {
            if (++index >= this.Count)
                index = 0;

            return this[index];
        }

        public T Previous()
        {
            if(--index <= 0)
                index = this.Count - 1;

            return this[index];
        }
    }
}
