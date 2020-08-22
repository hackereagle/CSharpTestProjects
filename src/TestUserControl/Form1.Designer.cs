namespace TestUserControl
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
            this.userControl_method21 = new TestUserControl.UserControl_method2();
            this.userControl11 = new TestUserControl.UserControl1();
            this.SuspendLayout();
            // 
            // userControl_method21
            // 
            this.userControl_method21.Location = new System.Drawing.Point(142, 255);
            this.userControl_method21.Name = "userControl_method21";
            this.userControl_method21.Size = new System.Drawing.Size(183, 137);
            this.userControl_method21.TabIndex = 1;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(66, 26);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(247, 185);
            this.userControl11.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 473);
            this.Controls.Add(this.userControl_method21);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl11;
        private UserControl_method2 userControl_method21;
    }
}

