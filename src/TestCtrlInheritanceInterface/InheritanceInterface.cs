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
    public partial class InheritanceInterface : UserControl, ITestInterfaceForCtrl
    {
        public InheritanceInterface()
        {
            InitializeComponent();
        }

        System.Windows.Forms.Label ITestInterfaceForCtrl.ShowText
        {
            get { return this.lblShow; }
        }
    }
}
