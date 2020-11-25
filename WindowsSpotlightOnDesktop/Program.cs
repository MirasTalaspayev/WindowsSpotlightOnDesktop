using System.IO;
using System.Drawing;
using System;
namespace WindowsSpotlightOnDesktop
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.UserName;
            string destination = @"C:\Users\" + username + @"\OneDrive\Изображения\Windows Spotlight Image";
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
            foreach (string file in Directory.GetFiles(destination))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception)
                {
                }
            }
        }

        
        /* Copy files where Windows: Spotlight images occurs
         * to the new folder in the OneDrive 
         */
        static void CopyFiles(string destination)
        {
            string username = Environment.UserName;
            string srcpath = @"C:\Users\" + username + @"\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
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
