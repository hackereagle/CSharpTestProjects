using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureControlAbstraction
{
    class ViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        #region Binded Command
        public ViewModel()
        {
            openDlg = new Microsoft.Win32.OpenFileDialog();
            _openImage = new PictureControlAbstraction.RelayCommand<object>(openImage);
        }

        Microsoft.Win32.OpenFileDialog openDlg;
        private PictureControlAbstraction.RelayCommand<object> _openImage;
        public System.Windows.Input.ICommand OpenBtnClick => _openImage;

        internal void openImage(object obj)
        {
            openDlg.Filter = "Image Files(*.bmp, *.jpeg, *.png)|*.bmp; *.jpeg; *.png";
            openDlg.RestoreDirectory = true;
            openDlg.FilterIndex = 0;
            if (openDlg.ShowDialog() == true)
            {
                //DispImgVM = new System.Windows.Media.Imaging.BitmapImage();
                System.Windows.Media.Imaging.BitmapImage test;
                System.IO.FileStream fstream = new System.IO.FileStream(openDlg.FileName, System.IO.FileMode.Open);
                test = new System.Windows.Media.Imaging.BitmapImage();
                test.BeginInit();
                test.StreamSource = fstream;
                test.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                test.EndInit();
                fstream.Close();

                _DispImgVM = test; // 如果是使用沒有callback function的方法，這邊賦值後，picture中不會顯示；dependencyProperties的setValue也不會作用
                OnPropertyChanged("DispImgVM");
            }
        }
        #endregion Binded Command

        #region Binded Properties And Properties Change
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        private System.Windows.Media.Imaging.BitmapImage _DispImgVM;
        public System.Windows.Media.Imaging.BitmapImage DispImgVM
        {
            get { return _DispImgVM; }
            set
            {
                _DispImgVM = value;
                OnPropertyChanged("DispImgVM");
            }
        }
        #endregion Binded Properties And Properties Change
    }
}
