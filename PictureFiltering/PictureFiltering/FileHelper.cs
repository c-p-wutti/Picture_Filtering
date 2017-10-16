using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Windows.Interop;
using System;
using System.Windows;
using System.Windows.Media;
using System.Drawing.Imaging;

namespace PictureFiltering
{
    class FileHelper
    {
        public static Bitmap getImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            Bitmap SourcePic = null;

            dialog.Filter = "Image Files(*.bmp;*.jpg;)| *.BMP;*.JPG;";

            if (dialog.ShowDialog() == true)
            {
                Bitmap pic = new Bitmap(dialog.FileName);
                SourcePic = pic;
            }

            return SourcePic;
        }

        public static void saveImage(Bitmap pic)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            Stream stream;

            var handle = pic.GetHbitmap();
            Image img = Image.FromHbitmap(handle);

            dialog.Filter = "Image Files(.jpg;)| .JPG;";

            if(dialog.ShowDialog() == true)
            {
                if((stream = dialog.OpenFile()) != null)
                {

                    img.Save(stream, ImageFormat.Jpeg);
                    stream.Close();
                }

            }
        }
        
        public static BitmapSource getBitmapSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        public static Bitmap getBitmapFromBitmapSource(BitmapSource bmSrc)
        {
            Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bmSrc));
                enc.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }
            return bmp;
        }
    }
}
