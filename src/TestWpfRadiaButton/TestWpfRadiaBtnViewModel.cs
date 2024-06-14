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
            set
            { 
                SetProperty(ref _isChoice1Checked, value);
                _result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
                OnPropertyChanged(nameof(Result));
            }
        }

        private bool _isChoice2Checked = false;
        public bool IsChoice2Checked
        {
            get => _isChoice2Checked;
            set
            {
                SetProperty(ref _isChoice2Checked, value);
                _result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
                OnPropertyChanged(nameof(Result));
            }
        }

        private bool _isChoice3Checked = false;
        public bool IsChoice3Checked
        {
            get => _isChoice3Checked;
            set
            {
                SetProperty(ref _isChoice3Checked, value);
                _result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
                OnPropertyChanged(nameof(Result));
            }
        }

        private string _result = string.Empty;
        public string Result => _result;
    }
}
