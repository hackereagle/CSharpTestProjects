﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestRichtextbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // test richtextbox properties
            rtxtTest.SelectedText = string.Empty;
        }

        private void btnAddOneLine_Click(object sender, EventArgs e)
        {
            this.rtxtTest.AppendText("One Line\n");
        }
    }
}
