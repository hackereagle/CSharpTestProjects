namespace TestWinformMixWpf
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.winformUserControl1 = new TestWinformMixWpf.WinformUserControl();
            this.SuspendLayout();
            // 
            // winformUserControl1
            // 
            this.winformUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.winformUserControl1.Location = new System.Drawing.Point(61, 34);
            this.winformUserControl1.Name = "winformUserControl1";
            this.winformUserControl1.Size = new System.Drawing.Size(705, 636);
            this.winformUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(936, 769);
            this.Controls.Add(this.winformUserControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinformUserControl winformUserControl1;
    }
}

