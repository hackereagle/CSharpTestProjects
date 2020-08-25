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
    /// TestDeependencyProperties.xaml 的互動邏輯
    /// </summary>
    public partial class TestDeependencyProperties : UserControl
    {
        public TestDeependencyProperties()
        {
            InitializeComponent();

            pctbxDisp = new System.Windows.Forms.PictureBox();
            pctbxDisp.BackColor = System.Drawing.Color.Gray;
            pctbxDisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctbxContainer.Child = pctbxDisp;
        }

        #region Privates Field
        System.Windows.Forms.PictureBox pctbxDisp;
        #endregion Privates Field

        #region Definitions of Dependency Properties
        //public static System.Windows.DependencyProperty DispImgProperty = System.Windows.DependencyProperty.Register("DispImg", typeof(System.Windows.Media.Imaging.BitmapImage), typeof(TestDeependencyProperties)); // 用這個方法，在一開始DispImg不會被激活
        public static System.Windows.DependencyProperty DispImgProperty = System.Windows.DependencyProperty.Register("DispImg", typeof(System.Windows.Media.Imaging.BitmapImage), typeof(TestDeependencyProperties), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ValidateDispImg)));
        //public static System.Windows.DependencyProperty DispImgProperty = System.Windows.DependencyProperty.Register("DispImg", typeof(System.Windows.Media.Imaging.BitmapImage), typeof(TestDeependencyProperties), new FrameworkPropertyMetadata() { PropertyChangedCallback = new PropertyChangedCallback(ValidateDispImg), BindsTwoWayByDefault = true });
        public System.Windows.Media.Imaging.BitmapImage DispImg
        {
            get { return (System.Windows.Media.Imaging.BitmapImage)GetValue(DispImgProperty); }
            set
            {
                SetValue(DispImgProperty, value);
                ShowImage(DispImg);
            }
        }

        static void ValidateDispImg(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                var test = obj as TestDeependencyProperties;
                var value = args.NewValue as System.Windows.Media.Imaging.BitmapImage;
                test.DispImg = value;
            }
            
        }
        #endregion Definitions of Dependency Properties

        private void ShowImage(System.Windows.Media.Imaging.BitmapImage Disp)
        {
            System.Drawing.Bitmap DisplayImg;
            using (System.IO.MemoryStream outStream = new System.IO.MemoryStream())
            {
                System.Windows.Media.Imaging.BitmapEncoder enc = new System.Windows.Media.Imaging.BmpBitmapEncoder();
                enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(Disp));
                enc.Save(outStream);
                DisplayImg = new System.Drawing.Bitmap(outStream);

                pctbxDisp.Image = DisplayImg;
            }
        }
    }


}
