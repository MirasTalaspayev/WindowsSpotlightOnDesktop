using System.Runtime.InteropServices;

namespace WindowsSpotlightOnDesktop
{
    internal class Wallpaper
    {
        public Wallpaper() { }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }
}
