using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestCSUsingCppDll;
using System.Runtime.InteropServices;

namespace CSharpLoadCppDll
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ImagePath;
        Bitmap SrcImg, DisplayImg;
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JPEG檔|*.jpg*|BMP檔|*.bmp*|TIFF檔|*.tiff|PNG檔|*.png*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog.FileName;
                SrcImg = new Bitmap(openFileDialog.FileName);
                DisplayImg = SrcImg.Clone(new Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                pctbxOrgImg.Image = DisplayImg;
            }
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            try {
                unsafe {
                    // ** pinvoke
                    ImgInfomation input = new ImgInfomation();
                    input.width = SrcImg.Width;
                    input.height = SrcImg.Height;
                    input.channels = 3;
                    System.Drawing.Imaging.BitmapData imgData = SrcImg.LockBits(new Rectangle(0, 0, SrcImg.Width, SrcImg.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    input.src = (byte*)imgData.Scan0;
                    input.step = imgData.Stride;

                    ImgInfomation output;
                    output = DllSetting.Convert2Gray(input);
                    System.Drawing.Bitmap ResultImg = new System.Drawing.Bitmap(output.width, output.height, output.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, (System.IntPtr)output.src);
                    System.Drawing.Imaging.ColorPalette GreyColorPalette = null;
                    GreyColorPalette = ResultImg.Palette;
                    for (int Index = 0; Index <= byte.MaxValue; Index++)
                        GreyColorPalette.Entries[Index] = Color.FromArgb(byte.MaxValue, Index, Index, Index);
                    ResultImg.Palette = GreyColorPalette;

                    // managed class by cli
                    TestCSUsingCppDll.MangementDll_proc test = new TestCSUsingCppDll.MangementDll_proc();
                    TestCSUsingCppDll.ImgInfomation2 input2 = new TestCSUsingCppDll.ImgInfomation2();
                    input2.width = SrcImg.Width;
                    input2.height = SrcImg.Height;
                    input2.channels = 3;
                    input2.src = (byte*)imgData.Scan0;
                    input2.step = imgData.Stride;
                    TestCSUsingCppDll.ImgInfomation2 result;
                    result = test.ConvertRgb2gray(input2);

                    System.Drawing.Bitmap ResultImg2 = new System.Drawing.Bitmap(result.width, result.height, result.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, (System.IntPtr)result.src);
                    System.Drawing.Imaging.ColorPalette GreyColorPalette2 = null;
                    GreyColorPalette2 = ResultImg2.Palette;
                    for (int Index = 0; Index <= byte.MaxValue; Index++)
                        GreyColorPalette2.Entries[Index] = Color.FromArgb(byte.MaxValue, Index, Index, Index);
                    ResultImg2.Palette = GreyColorPalette2;

                    //Console.WriteLine(test.channels.ToString());

                    SrcImg.UnlockBits(imgData);
                    pctbxRecievePInvokeImg.Image = ResultImg;
                    pctbxRecieveManageClassImg.Image = ResultImg2;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString(), "ERROR!");
            }
        }
    }
}
