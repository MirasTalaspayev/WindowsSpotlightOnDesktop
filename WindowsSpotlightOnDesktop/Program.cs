using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace WindowsSpotlightOnDesktop
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = @"C:\Users\tmk01\Desktop\Image";
            CopyFiles(destination);
            string[] images = Directory.GetFiles(destination);
            int r = images.Length - 1;
            Bitmap bitmap = new Bitmap(images[r]);

            while (bitmap.Width != 1920)
            {
                r--;
                bitmap = null;
                bitmap = new Bitmap(images[r]);
            }
            const int SPI_SETDESKWALLPAPER = 20;
            const int SPIF_UPDATEINIFILE = 0x01;
            const int SPIF_SENDWININICHANGE = 0x02;
            Wallpaper.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, images[r], SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            bitmap.Dispose();
            File.Delete(images[r]);
            //Directory.Delete(destination, true);
        }
        // Display the file on the desktop.
        /* Copy files where Windows: Spotlight images occurs
         * to the Images directory in the desktop
         */
        static void CopyFiles(string destination)
        {
            string srcpath = @"C:\Users\tmk01\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            Directory.CreateDirectory(destination);
            if (Directory.Exists(srcpath))
            {
                string[] files = Directory.GetFiles(srcpath);
                foreach (string s in files)
                {
                    string filename = Path.GetFileName(s) + ".bmp";
                    string destfile = Path.Combine(destination, filename);
                    File.Copy(s, destfile, true);
                }
            }
        }
    }
}
