using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TestTimerIntervalError
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            mTimer = new System.Timers.Timer();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            AppendTextToRtxt("\n\nTest System.Windows.Forms.Timer");
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine($"In {Thread.CurrentThread.ManagedThreadId}, doSomething!");
            AppendTextToRtxt($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: In {Thread.CurrentThread.ManagedThreadId}, doSomething!\n");
            Thread.Sleep(1000);
        }

        private void AppendTextToRtxt(string msg)
        {
            MethodInvoker _appendTextToRtxt = new MethodInvoker(() => 
            {
                this.rtxtDisp.AppendText(msg);
                this.rtxtDisp.ScrollToCaret();
            });

            if (this.rtxtDisp.InvokeRequired)
            {
                rtxtDisp.Invoke(_appendTextToRtxt);
            }
            else
            {
                _appendTextToRtxt();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private System.Timers.Timer mTimer;
        private void btnOtherTimerBegin_Click(object sender, EventArgs e)
        {
            mTimer.Interval = 100;
            mTimer.Elapsed += timer1_Tick; // it will create thread if trigger timer when event was not completed.
            AppendTextToRtxt("\n\nTest System.Timers.Timer");
            mTimer.Start();
        }

        private void btnStopSystemTimer_Click(object sender, EventArgs e)
        {
            mTimer.Stop();
        }
    }
}
