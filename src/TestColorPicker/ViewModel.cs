using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestColorPicker
{
    class comboboxItem
    {
        /// <summary>
        /// Construstor of class, comboboxItem.
        /// </summary>
        /// <param name="color">color name</param>
        public comboboxItem(string color)
        {
            _color = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color));
            _colorName = color;
        }

        #region Privates Field
        private System.Windows.Media.SolidColorBrush _color;
        private string _colorName;
        #endregion Privates Field

        #region Publics Field
        public System.Windows.Media.SolidColorBrush Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }
        #endregion Publics Field
    }

    class ViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public ViewModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<comboboxItem>()
            {
                new comboboxItem("Blue"),
                new comboboxItem("Black")
            };
            SItems = Items[0];
        }

        public System.Collections.ObjectModel.ObservableCollection<comboboxItem> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        public comboboxItem SItems
        {
            get { return _sItems; }
            set
            {
                _sItems = value;
                Color = _sItems.Color;
                OnPropertyChanged("SItems");
            }
        }
        public System.Windows.Media.SolidColorBrush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<comboboxItem> _items;
        private comboboxItem _sItems;
        public System.Windows.Media.SolidColorBrush _color;
    }

}
