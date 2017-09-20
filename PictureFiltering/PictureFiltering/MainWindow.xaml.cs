using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            //Stream picStream = null;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files(*.bmp;*.jpg;)| *.BMP;*.JPG;";

            if (dialog.ShowDialog() == true)
            {
                Console.WriteLine("wohoo: " + dialog.FileName);

                BitmapImage pic = new BitmapImage();
                pic.BeginInit();
                pic.UriSource = new Uri(dialog.FileName);
                pic.EndInit();

                SourcePic.Source = pic;
            }
        }
        
        private void Save_Picture(object sender, RoutedEventArgs e)
        {

        }
    }
}
