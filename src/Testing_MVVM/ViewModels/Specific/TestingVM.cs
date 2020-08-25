using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_MVVM.ViewModels
{
    public class test
    {
        public string label_test;
        public int noUsing;
    }

    class TestingVM : ViewModelBase
    {
        #region Private Fields
        private string lblContent;

        private Testing_MVVM.Commands.Generic.RelayCommand<object> changConent;
        private Testing_MVVM.Commands.Generic.RelayCommand<object> changContent2;

        private Testing_MVVM.BusinessLogic.TestingDoSomeThings _testingDoEvent;
        #endregion Private Fields

        public TestingVM()
        {
            _testingDoEvent = new BusinessLogic.TestingDoSomeThings();
            _testingDoEvent.Result.Subscribe(x => { Output = x; });

            changConent = new Commands.Generic.RelayCommand<object>(TestingChangeContent);
            changContent2 = new Commands.Generic.RelayCommand<object>(ConnectModel);
        }

        public System.Windows.Input.ICommand Test => changConent;
        public System.Windows.Input.ICommand ForBtn2 => changContent2;

        internal void TestingChangeContent(object obj)
        {
            Output = "Testing to change label content";
            Console.WriteLine("Testing");
        }

        internal void ConnectModel(object obj)
        {
            _testingDoEvent.Testing1(lblContent);
            Output = _testingDoEvent.Result.ToString();
        }

        public string Output
        {
            get { return lblContent; }

            set
            {
                lblContent = value;
                OnPropertyChanged("Output");
            }
        }

    }
}
