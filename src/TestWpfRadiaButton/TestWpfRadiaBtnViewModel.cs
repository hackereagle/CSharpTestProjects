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
        public TestWpfRadiaBtnViewModel()
        {
            //OtherString = $"GroupName = ";
            Result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
        }

        private string _otherString = string.Empty;
        public string OtherString
        {
            get => _otherString;
            set => SetProperty(ref _otherString, value);
        }

        private bool _isChoice1Checked = true;
        public bool IsChoice1Checked
        {
            get => _isChoice1Checked;
            set
            {
                if (_isChoice1Checked != value)
                { 
                    SetProperty(ref _isChoice1Checked, value);
                    Result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
                }
            }
        }

        private bool _isChoice2Checked = false;
        public bool IsChoice2Checked
        {
            get => _isChoice2Checked;
            set
            {
                if (_isChoice2Checked != value)
                { 
                    SetProperty(ref _isChoice2Checked, value);
                    Result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
                }
            }
        }

        private bool _isChoice3Checked = false;
        public bool IsChoice3Checked
        {
            get => _isChoice3Checked;
            set
            {
                if (_isChoice3Checked != value)
                { 
                    SetProperty(ref _isChoice3Checked, value);
                    Result = $"Choice1 = {_isChoice1Checked}, Choice2 = {_isChoice2Checked}, Choice3 = {_isChoice3Checked}";
                }
            }
        }

        private string _result = string.Empty;
        public string Result
        { 
            get => _result;
            private set => SetProperty(ref _result, value);
        }
    }
}
