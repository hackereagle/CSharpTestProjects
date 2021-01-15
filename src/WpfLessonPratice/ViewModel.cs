using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLessonPratice
{
    public class ViewModel : NotifyPropertyBase
    {
        public ViewModel()
        {
        }

        private double mHeight;
        public double Height
        {
            //set { mHeight = value; }
            set { SetProperty<double>(ref mHeight, value, nameof(Height)); }
            get { return mHeight; }
        }

        private double mWeight;
        public double Weight
        {
            //set { mHeight = value; }
            set { SetProperty<double>(ref mWeight, value, nameof(Weight)); }
            get { return mWeight; }
        }

        private double mBmi;
        public double BMI
        {
            set { SetProperty<double>(ref mBmi, value, nameof(BMI)); }
            get { return mBmi; }
        }

        private System.Windows.Input.ICommand mChangeCommand;
        public System.Windows.Input.ICommand Command
        {
            get
            {
                if (mChangeCommand == null)
                {
                    mChangeCommand = new RelayCommand((x) =>  BMI = Weight / Height / Height);
                }
                return mChangeCommand;
            }
        }
    }
}
