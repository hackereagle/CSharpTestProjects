using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSliderBar
{
    class ViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        #region Implement interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        #endregion Implement interface INotifyPropertyChanged

        public ViewModel()
        {
            _maxValue = 200;
            _minValue = -200;
        }

        private string _barValue;
        private double _currentProgress;
        private double _maxValue;
        private double _minValue;

        public string barValue
        {
            get { return _barValue; }
            set
            {
                _barValue = value;
                OnPropertyChanged("barValue");
            }
        }

        public double CurrentProgress
        {
            get { return _currentProgress; }
            set
            {
                _currentProgress = value;
                barValue = _currentProgress.ToString();
                OnPropertyChanged("CurrentProgress");
            }
        }

        public string MaxValue
        {
            get { return SliderBarMaxmum.ToString(); }
            set
            {
                SliderBarMaxmum = Convert.ToDouble(value);
                SliderBarMinimum = Convert.ToDouble(value) * (-1);
                OnPropertyChanged("MaxValue");
            }
        }

        public double SliderBarMaxmum
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                OnPropertyChanged("SliderBarMaxmum");
            }
        }

        public double SliderBarMinimum
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                OnPropertyChanged("SliderBarMinimum");
            }
        }

    }
}
