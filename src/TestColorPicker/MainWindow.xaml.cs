using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestColorPicker
{
    public class comboboxItem2
    {
        public System.Windows.Shapes.Rectangle rect { set; get; }
        public System.Windows.Controls.TextBlock textblock { set; get; }

        public comboboxItem2(string color)
        {
            rect = new System.Windows.Shapes.Rectangle();
            rect.Width = 20;
            rect.Height = 20;
            rect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));

            textblock = new System.Windows.Controls.TextBlock();
            textblock.Text = color;
        }
    }

    

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //https://www.c-sharpcorner.com/UploadFile/87b416/create-color-picker-in-wpf/
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.colorList.ItemsSource = typeof(Brushes).GetProperties();
        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush selectedColor = (Brush)(e.AddedItems[0] as PropertyInfo).GetValue(null, null);
            rtlfill.Fill = selectedColor;
        }

        // ===================== <Combox color picker> ========================

    }
}
