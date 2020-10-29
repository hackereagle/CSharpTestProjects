namespace TestRichtextbox
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
            this.rtxtTest = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtTest
            // 
            this.rtxtTest.Location = new System.Drawing.Point(24, 27);
            this.rtxtTest.Name = "rtxtTest";
            this.rtxtTest.Size = new System.Drawing.Size(336, 267);
            this.rtxtTest.TabIndex = 0;
            this.rtxtTest.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 452);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtxtTest);
            this.Name = "Form1";
            this.Text = "Test Richtextbox Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtTest;
        private System.Windows.Forms.Button button1;
    }
}

