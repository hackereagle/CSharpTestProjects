using System;
using System.Collections.Generic;
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

namespace TestDependencyProperties
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dlg = new Microsoft.Win32.OpenFileDialog();
        }

        Microsoft.Win32.OpenFileDialog dlg;
        //private void btnLoad_Click(object sender, RoutedEventArgs e)
        //{
        //    dlg.Filter = "Image Files(*.bmp, *.jpg, *.jpeg, *.png)|*.bmp; *.jpg; *.jpeg; *png";
        //    dlg.RestoreDirectory = true;
        //    dlg.FilterIndex = 0;
        //    if (dlg.ShowDialog() == true)
        //    {
        //        BitmapImage test;
        //        System.IO.FileStream fstream = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open); // @"D:\projects\02.Image_Processing_Tools\ImageProcessingToolTesting_WinForm\ImageProcessingToolTesting\lena_gray.bmp"
        //        test = new BitmapImage();
        //        test.BeginInit();
        //        test.StreamSource = fstream;
        //        test.CacheOption = BitmapCacheOption.OnLoad;
        //        test.EndInit();
        //        fstream.Close();

        //        this.DemoDependencyPerporty.DispImg = test;

        //    }
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
