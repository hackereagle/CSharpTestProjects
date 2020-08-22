using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockTextboxWithPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }


        private void txtTest_Click(object sender, EventArgs e)
        {
            frmPassword frm = new frmPassword();

            if (DialogResult.OK == frm.ShowDialog())
            {
                this.txtTest.SelectAll();
            }
            else
            {
                label1.Focus();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}
