using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSpotlightOnDesktop
{
    internal class Wallpaper
    {
        public Wallpaper() { }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}
