using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCommon;

namespace TestWpfRadiaButton
{
    internal class TestWpfRadiaBtnViewModel : ViewModelBase
    {

        private bool _isChoice1Checked = true;
        public bool IsChoice1Checked
        {
            get => _isChoice1Checked;
            set => SetProperty(ref _isChoice1Checked, value);
        }

        private bool _isChoice2Checked = true;
        public bool IsChoice2Checked
        {
            get => _isChoice2Checked;
            set => SetProperty(ref _isChoice2Checked, value);
        }
    }
}
