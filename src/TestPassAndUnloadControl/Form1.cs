using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPassAndUnloadControl
{
    public partial class Form1 : Form
    {
        private ManagedPctbxEvent _managePbEvent;
        public Form1()
        {
            InitializeComponent();
            _managePbEvent = new ManagedPctbxEvent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("In outside!");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true){
                //this.checkBox1.Checked = true;
                _managePbEvent.ManagePbClickEvent(this.pictureBox1, this.pictureBox1_Click);
            }
            else {
                //this.checkBox1.Checked = false;
                _managePbEvent.UnmanagePbClickEvent();
            }

        }
    }
}
