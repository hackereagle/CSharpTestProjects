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

namespace TestWinformMixWpf
{
    /// <summary>
    /// WpfUserControl.xaml 的互動邏輯
    /// </summary>
    public partial class WpfUserControl : UserControl
    {
        public WpfUserControl()
        {
            InitializeComponent();
            
        }

        private int index = 0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wpfUsr2 usr = new wpfUsr2()
                {
                    Name = "usr_" + index.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Visibility = Visibility.Visible
                };
                usr.Margin = new Thickness(this.firstWpfUsr.Margin.Left,
                                            this.firstWpfUsr.Margin.Top + 100,
                                            this.firstWpfUsr.Margin.Right, this.firstWpfUsr.Margin.Bottom);

                aaa.Children.Add(usr);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("In Homework_wpf_uc.button_Click: " + ex.ToString());
            }
        }
    }
}
