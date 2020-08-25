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

namespace JCSEM.ImgProcToolsGui.Views
{
    /// <summary>
    /// wpfDisplayImgElm.xaml 的互動邏輯
    /// </summary>
    public partial class wpfDisplayImgElm : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public wpfDisplayImgElm()
        {
            InitializeComponent();

            pctbxDisp = new System.Windows.Forms.PictureBox();
            this.pctbxContainer.Child = pctbxDisp;
            pbCtrl = new JCSEM.ImgProcToolsGui.BusinessLogic.PictureboxCtrl(pctbxDisp, this.tbMouseStatue);
        }
        System.Windows.Forms.PictureBox pctbxDisp;
        static JCSEM.ImgProcToolsGui.BusinessLogic.PictureboxCtrl pbCtrl;
        private static System.Drawing.Bitmap SrcImg;

        public bool DrawLine
        {
            set
            {
                pbCtrl.DrawLine = value;
            }
        }

        public bool DrawCircle
        {
            set
            {
                pbCtrl.DrawCircle = value;
            }
        }

        public bool DrawRect
        {
            set
            {
                pbCtrl.DrawRect = value;
            }
        }

        #region Definitions of Dependency Properties
            /// <summary>
            /// 
            /// </summary>
        public static readonly System.Windows.DependencyProperty DispImgProperty = System.Windows.DependencyProperty.Register("DispImg", typeof(System.Windows.Media.Imaging.BitmapImage)
                                                                                                                            , typeof(wpfDisplayImgElm), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ValidateDispImg)));
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Media.Imaging.BitmapImage DispImg
        {
            get
            {
                return (System.Windows.Media.Imaging.BitmapImage)GetValue(DispImgProperty);
            }
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
                var usrCtrl = obj as wpfDisplayImgElm;
                var value = args.NewValue as System.Windows.Media.Imaging.BitmapImage;
                usrCtrl.DispImg = value;
                //ShowImage(usrCtrl.DispImg);
            }

        }

        #endregion Definitions of Dependency Properties

        #region show, get image methods
        /// <summary>
        /// Show image out side passing.
        /// source: https://stackoverflow.com/questions/6484357/converting-bitmapimage-to-bitmap-and-vice-versa
        /// </summary>
        /// <param name="Disp"></param>
        private static void ShowImage(System.Windows.Media.Imaging.BitmapImage Disp)
        {
            using (System.IO.MemoryStream outStream = new System.IO.MemoryStream())
            {
                System.Windows.Media.Imaging.BitmapEncoder enc = new System.Windows.Media.Imaging.BmpBitmapEncoder();
                enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(Disp));
                enc.Save(outStream);
                SrcImg = new System.Drawing.Bitmap(outStream);

                pbCtrl.Disp(SrcImg);
            }
        }

        /// <summary>
        /// get showing image, DisplayImg.
        /// </summary>
        /// <returns></returns>
        private System.Windows.Media.Imaging.BitmapImage GetDisplayImg()
        {
            System.Windows.Media.Imaging.BitmapImage retval = new BitmapImage();
            if (pbCtrl.DisplayImg == null)
                return retval;

            retval = JCSEM.ImgProcToolsGui.BusinessLogic.ImageTypeConverter.Bitmap2Bitmapimage(pbCtrl.DisplayImg);
            return retval;
        }
        #endregion show, get image methods

       
    }
}
