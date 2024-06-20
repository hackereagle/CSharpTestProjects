using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using MvvmCommon;

namespace TestImageStrech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        public BitmapImage DisplayedImage
        {
            get { return (BitmapImage)GetValue(DisplayedImageProperty); }
            set { SetValue(DisplayedImageProperty, value); }
        }

        public static readonly DependencyProperty DisplayedImageProperty =
            DependencyProperty.Register("DisplayedImage", typeof(BitmapImage), typeof(MainWindow), new PropertyMetadata(null));

        public ICommand LoadImageCommand => new RelayCommand<object>(LoadImage);

        private void LoadImage(object obj)
        { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp,*.png;*.jpeg;*.jpg)|*.bmp;*.png;*.jpeg;*.jpg";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;

                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = fs;
                bitmapImage.EndInit();

                DisplayedImage = bitmapImage;
            }
        }
    }
}