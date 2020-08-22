using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click start");

            // method 1: can get value returned
            //var task = MyMethodAsync();
            //var items = await task;

            // method 2: don't get value returned
            await MyMethodAsync();
            Console.WriteLine("click end");
            
        }
        //private async void Test()
        //{
        //    Console.WriteLine("thread start");
        //    System.Threading.Thread A = new System.Threading.Thread(new System.Threading.ThreadStart(MyMethodAsync2));
            
        //    Console.WriteLine("thread end");
        //}

        private async Task<int> MyMethodAsync()
        {
            System.Threading.Thread _t = new System.Threading.Thread(new System.Threading.ThreadStart(() => {
                for (int i = 0; i < 1000000; i++)
                {
                    Console.WriteLine($"{i}");
                    //i++;
                }
                test2();
            }));
            _t.Start();
            
            return 0;
        }
        private void  MyMethodAsync2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}");
            }
        }
        private void test2()
        {
            Console.WriteLine("thread complete");
        }
    }
}
