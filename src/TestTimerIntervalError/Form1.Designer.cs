namespace TestTimerIntervalError
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rtxtDisp = new System.Windows.Forms.RichTextBox();
            this.btnFormTimerBegin = new System.Windows.Forms.Button();
            this.btnFormTimerStop = new System.Windows.Forms.Button();
            this.btnBeginSystemTimer = new System.Windows.Forms.Button();
            this.btnStopSystemTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rtxtDisp
            // 
            this.rtxtDisp.Location = new System.Drawing.Point(64, 180);
            this.rtxtDisp.Name = "rtxtDisp";
            this.rtxtDisp.Size = new System.Drawing.Size(413, 96);
            this.rtxtDisp.TabIndex = 0;
            this.rtxtDisp.Text = "";
            // 
            // btnFormTimerBegin
            // 
            this.btnFormTimerBegin.Location = new System.Drawing.Point(90, 81);
            this.btnFormTimerBegin.Name = "btnFormTimerBegin";
            this.btnFormTimerBegin.Size = new System.Drawing.Size(75, 23);
            this.btnFormTimerBegin.TabIndex = 1;
            this.btnFormTimerBegin.Text = "BeginTest";
            this.btnFormTimerBegin.UseVisualStyleBackColor = true;
            this.btnFormTimerBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnFormTimerStop
            // 
            this.btnFormTimerStop.Location = new System.Drawing.Point(90, 126);
            this.btnFormTimerStop.Name = "btnFormTimerStop";
            this.btnFormTimerStop.Size = new System.Drawing.Size(75, 23);
            this.btnFormTimerStop.TabIndex = 2;
            this.btnFormTimerStop.Text = "Stop Timer";
            this.btnFormTimerStop.UseVisualStyleBackColor = true;
            this.btnFormTimerStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnBeginSystemTimer
            // 
            this.btnBeginSystemTimer.Location = new System.Drawing.Point(317, 81);
            this.btnBeginSystemTimer.Name = "btnBeginSystemTimer";
            this.btnBeginSystemTimer.Size = new System.Drawing.Size(139, 23);
            this.btnBeginSystemTimer.TabIndex = 3;
            this.btnBeginSystemTimer.Text = "Begin System Timer";
            this.btnBeginSystemTimer.UseVisualStyleBackColor = true;
            this.btnBeginSystemTimer.Click += new System.EventHandler(this.btnOtherTimerBegin_Click);
            // 
            // btnStopSystemTimer
            // 
            this.btnStopSystemTimer.Location = new System.Drawing.Point(319, 126);
            this.btnStopSystemTimer.Name = "btnStopSystemTimer";
            this.btnStopSystemTimer.Size = new System.Drawing.Size(137, 23);
            this.btnStopSystemTimer.TabIndex = 4;
            this.btnStopSystemTimer.Text = "Stop System Timer";
            this.btnStopSystemTimer.UseVisualStyleBackColor = true;
            this.btnStopSystemTimer.Click += new System.EventHandler(this.btnStopSystemTimer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 319);
            this.Controls.Add(this.btnStopSystemTimer);
            this.Controls.Add(this.btnBeginSystemTimer);
            this.Controls.Add(this.btnFormTimerStop);
            this.Controls.Add(this.btnFormTimerBegin);
            this.Controls.Add(this.rtxtDisp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtxtDisp;
        private System.Windows.Forms.Button btnFormTimerBegin;
        private System.Windows.Forms.Button btnFormTimerStop;
        private System.Windows.Forms.Button btnBeginSystemTimer;
        private System.Windows.Forms.Button btnStopSystemTimer;
    }
}

