namespace CSharpWriteAndReadXml
{
    partial class WriteAndReadXmlTestForm
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
            this.gpbWriteXml = new System.Windows.Forms.GroupBox();
            this.gpbReadXml = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gpbReadXml.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbWriteXml
            // 
            this.gpbWriteXml.Location = new System.Drawing.Point(55, 60);
            this.gpbWriteXml.Name = "gpbWriteXml";
            this.gpbWriteXml.Size = new System.Drawing.Size(517, 486);
            this.gpbWriteXml.TabIndex = 0;
            this.gpbWriteXml.TabStop = false;
            this.gpbWriteXml.Text = "Write Xml";
            // 
            // gpbReadXml
            // 
            this.gpbReadXml.Controls.Add(this.richTextBox1);
            this.gpbReadXml.Location = new System.Drawing.Point(623, 60);
            this.gpbReadXml.Name = "gpbReadXml";
            this.gpbReadXml.Size = new System.Drawing.Size(519, 486);
            this.gpbReadXml.TabIndex = 1;
            this.gpbReadXml.TabStop = false;
            this.gpbReadXml.Text = "Read Xml";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(44, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(382, 326);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // WriteAndReadXmlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 625);
            this.Controls.Add(this.gpbReadXml);
            this.Controls.Add(this.gpbWriteXml);
            this.Name = "WriteAndReadXmlTestForm";
            this.Text = "C Sharp Write And Read Xml Test App";
            this.gpbReadXml.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbWriteXml;
        private System.Windows.Forms.GroupBox gpbReadXml;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

