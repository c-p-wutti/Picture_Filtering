using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PictureFiltering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initOtherComponents();
        }

        private void initOtherComponents()
        {
            setBackgroundColor();
        }

        private void setBackgroundColor()
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#012D41");
            brush.Freeze();
            mainWindow.Background = brush;
        }

        private void Open_Picture(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Opening Picture!");
            SourcePic.Source = FileHelper.getBitmapSourceFromBitmap(FileHelper.getImage());
        }
        
        private void Save_Picture(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Saving Picture!");
            FileHelper.saveImage(FileHelper.getBitmapFromBitmapSource((BitmapSource)SourcePic.Source));
        }
    }
}
