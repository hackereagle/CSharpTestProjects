using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUserControl
{
    public partial class UserControl_method2 : UserControl
    {
        public UserControl_method2()
        {
            InitializeComponent();
            i = 0;
        }

        private int i;
        private void button1_Click(object sender, EventArgs e)
        {
            if (i % 2 == 0)
                label1.Text = "yo";
            else
                label1.Text = "ya";

            i++;
        }
    }
}
