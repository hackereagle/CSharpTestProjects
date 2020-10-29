using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCtrlInheritanceInterface
{
    public partial class NoInheritanceInterface : UserControl
    {
        public NoInheritanceInterface()
        {
            InitializeComponent();
        }

        public System.Windows.Forms.Label ShowText
        {
            get { return this.lblShow; }
        }
    }
}
