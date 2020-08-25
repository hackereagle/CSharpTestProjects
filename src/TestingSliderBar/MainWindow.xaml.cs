using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TestingSliderBar
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.slider.Maximum = Convert.ToDouble(this.txtValue.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel Test = (ViewModel)this.grid.DataContext;
            this.tbShowTestResult.Text = Test.SliderBarMaxmum.ToString();
        }

        //private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    this.textBlock.Text = e.NewValue.ToString();
        //    ViewModel Test = (ViewModel)this.grid.DataContext;
        //    Test.test();
        //}

        //private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        ViewModel Test = (ViewModel)this.grid.DataContext;
        //        Test.MaxValue = this.txtValue.Text;
        //        this.slider.Maximum = Test.SliderBarMaxmum;
        //        Console.WriteLine("this.slider.Maximum = " + this.slider.Maximum.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}
