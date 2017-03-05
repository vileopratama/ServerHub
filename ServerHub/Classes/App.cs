using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ServerHub.Classes
{
    class App
    {
        public static String baseDirectory()
        {
            return System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }
    }
}
