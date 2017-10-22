﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PictureFiltering
{
    class FilterHelper
    {
        public static Bitmap filterRed(Bitmap pic)
        {
            Bitmap bmp = null;

            for (var y = 0; y < pic.Height; y++)
            {
                for (var x = 0; x < pic.Width; x++)
                {
                        System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb( pic.GetPixel(x,y).R, 0, 0);
                        pic.SetPixel(x, y, Color.FromArgb(color.A, color.R, color.G,color.B));
                        
                }
             }

            bmp = pic;
            return bmp;
        }

        public static Bitmap filterGreen(Bitmap pic)
        {
            Bitmap bmp = null;

            for (var y = 0; y < pic.Height; y++)
            {
                for (var x = 0; x < pic.Width; x++)
                {
                    System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(0, 0, pic.GetPixel(x,y).G);
                    pic.SetPixel(x, y, Color.FromArgb(color.A, color.R, color.G, color.B));
                }
           }

            bmp = pic;
            return bmp;
        }
        public static Bitmap filterBlue(Bitmap pic)
        {
            Bitmap bmp = null;

            for (var y = 0; y < pic.Height; y++)
            {
                for (var x = 0; x < pic.Width; x++)
                {
                    System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(0, pic.GetPixel(x,y).B, 0);
                    pic.SetPixel(x, y, Color.FromArgb(color.A, color.R, color.G, color.B));
                }
           }

            bmp = pic;
            return bmp;
        }
    }
}
