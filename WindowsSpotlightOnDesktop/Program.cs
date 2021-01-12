using System.IO;
using System.Drawing;
using System;
namespace WindowsSpotlightOnDesktop
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeDesktopImage();
        }
        static void ChangeDesktopImage()
        {
            string username = Environment.UserName;
            string srcpath = @"C:\Users\" + username + @"\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";

            if (Directory.Exists(srcpath))
            {
                string[] images = Directory.GetFiles(srcpath);
                int r = images.Length - 1;
                Bitmap bitmap = new Bitmap(images[r]);
                
                while (bitmap.Width != 1920)
                {
                    r--;
                    bitmap = null;
                    bitmap = new Bitmap(images[r]);
                }
                Wallpaper.SystemParametersInfo(20, 0, images[r], 0x01 | 0x02);
                bitmap.Dispose();
            }
        }
    }
}
