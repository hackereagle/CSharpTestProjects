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

namespace TestTransBetween_HObj_Bitmap_BitmapImg
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            pctbxDisp = new System.Windows.Forms.PictureBox();
            pctbxDisp.BackColor = System.Drawing.Color.Gray;
            pctbxDisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctbxContainer.Child = pctbxDisp;
        }

        #region Privates Field
        private System.Windows.Forms.PictureBox pctbxDisp;
        private System.Drawing.Bitmap bitmapImg;
        private System.Windows.Media.Imaging.BitmapImage bitmapimageImg;
        //private HalconDotNet.HObject hObj;
        private HalconDotNet.HImage hImg;
        private HalconDotNet.HWindow _HWin;
        #endregion Privates Field

        /// <summary>
        /// Here testing all converting function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog of = new Microsoft.Win32.OpenFileDialog();
            of.Filter = "Image Files(*.bmp, *.jpg, *.jpeg, *.png)|*.bmp; *.jpg; *.jpeg; *png";
            if (of.ShowDialog() == true)
            {
                bitmapimageImg = new BitmapImage();
                System.IO.FileStream fs = new System.IO.FileStream(of.FileName, System.IO.FileMode.Open);

                bitmapimageImg.BeginInit();
                bitmapimageImg.StreamSource = fs;
                bitmapimageImg.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimageImg.EndInit();

                fs.Close();

                this.wpfImage.Source = bitmapimageImg;
                // ** BitmapImage -> Bitmap (OK)
                //bitmapImg = ImageTypeConverter.Bitmapimage2Bitmap(bitmapimageImg);
                //this.pctbxDisp.Image = bitmapImg;

                // ** Bitmap -> HImage (OK)
                //hImg = ImageTypeConverter.Bitmap2HImage(bitmapImg);
                //ShowHImage2HWin(hImg);

                // ** HImage -> Bitmap OK
                //hImg = new HalconDotNet.HImage();
                //hImg.ReadImage(new HalconDotNet.HTuple(of.FileName));
                //ShowHImage2HWin(hImg);
                //bitmapImg = ImageTypeConverter.HImage2Bitmap(hImg);
                //this.pctbxDisp.Image = bitmapImg;
                // ** Bitmap -> BitmapImage
                //bitmapimageImg = ImageTypeConverter.Bitmap2Bitmapimage(bitmapImg);
                //this.wpfImage.Source = bitmapimageImg;

                // ** BitmapImage -> HImage
                hImg = ImageTypeConverter.Bitmapimage2HImage(bitmapimageImg);
                ShowHImage2HWin(hImg);

                // ** HImage -> BitmapImage
                //bitmapimageImg = ImageTypeConverter.HImage2Bitmapimage(hImg);
                //this.wpfImage.Source = bitmapimageImg;
            }
        }

        private void ShowHImage2HWin(HalconDotNet.HObject HObj)
        {
            HalconDotNet.HTuple W, H;
            HalconDotNet.HOperatorSet.GetImageSize(HObj, out W, out H);

            _HWin = this.hWin.HalconWindow;
            _HWin.SetPart(new HalconDotNet.HTuple(0), new HalconDotNet.HTuple(0), W, H);
            HalconDotNet.HOperatorSet.DispObj(HObj, _HWin);
            
        }
    }
}
