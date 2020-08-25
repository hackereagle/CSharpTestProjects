﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformComboBoxDrawImg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// reference:
    /// https://stackoverflow.com/questions/4080719/placing-images-and-strings-with-a-c-sharp-combobox
    /// 
    /// other references:
    /// http://csharphelper.com/blog/2016/03/easily-make-owner-drawn-comboboxes-display-images-with-text-in-c/
    /// https://www.codeguru.com/csharp/csharp/cs_graphics/customizinguserinterfaces/creating-an-image-combobox-with-c.html
    /// </summary>
    class ColorSelector : ComboBox
    {
        public ColorSelector()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Draws the items into the ColorSelector object
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            DropDownItem item = new DropDownItem(Items[e.Index].ToString());
            // Draw the colored 16 x 16 square
            e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);
            // Draw the value (in this case, the color name)
            e.Graphics.DrawString(item.Value, e.Font, new
                    SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);

            base.OnDrawItem(e);
        }
    }

    public class DropDownItem
    {
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private string value;

        public Image Image
        {
            get { return img; }
            set { img = value; }
        }
        private Image img;

        public DropDownItem() : this("")
        {}

        public DropDownItem(string val)
        {
            value = val;
            this.img = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(img);
            Brush b = new SolidBrush(Color.FromName(val));
            g.DrawRectangle(Pens.White, 0, 0, img.Width, img.Height);
            g.FillRectangle(b, 1, 1, img.Width - 1, img.Height - 1);
        }

        public override string ToString()
        {
            return value;
        }
    }
}
