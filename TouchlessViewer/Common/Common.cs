﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace TouchlessViewer
{
    static class Common
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}