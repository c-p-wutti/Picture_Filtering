using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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

        BackgroundWorker bw;

        private void initOtherComponents()
        {
            setBackgroundColor();
            FilterHelper.ProgressBar = progressbar;
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
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
            FileHelper.saveImage(FileHelper.getBitmapFromBitmapSource((BitmapSource)FilteredPic.Source));
        }

        private void Filter_Red(object sender, RoutedEventArgs e)
        {
            bw.RunWorkerAsync();
            FilteredPic.Source = FileHelper.getBitmapSourceFromBitmap(FilterHelper.filterRed(FileHelper.getBitmapFromBitmapSource((BitmapSource)SourcePic.Source)));
        }

        private void Filter_Green(object sender, RoutedEventArgs e)
        {
            bw.RunWorkerAsync();
            FilteredPic.Source = FileHelper.getBitmapSourceFromBitmap(FilterHelper.filterGreen(FileHelper.getBitmapFromBitmapSource((BitmapSource)SourcePic.Source)));
        }
        private void Filter_Blue(object sender, RoutedEventArgs e)
        {
            bw.RunWorkerAsync();
            FilteredPic.Source = FileHelper.getBitmapSourceFromBitmap(FilterHelper.filterBlue(FileHelper.getBitmapFromBitmapSource((BitmapSource)SourcePic.Source)));
        }
 
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                progressbar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate() { progressbar.Value++; }));
                Thread.Sleep(100);
            }
        }
    }
}
