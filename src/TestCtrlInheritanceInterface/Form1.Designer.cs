namespace TestCtrlInheritanceInterface
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inheritanceInterface1 = new TestCtrlInheritanceInterface.InheritanceInterface();
            this.noInheritanceInterface1 = new TestCtrlInheritanceInterface.NoInheritanceInterface();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Inhertance Interface\'s Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inhertance Interface\'s Control";
            // 
            // inheritanceInterface1
            // 
            this.inheritanceInterface1.Location = new System.Drawing.Point(382, 69);
            this.inheritanceInterface1.Name = "inheritanceInterface1";
            this.inheritanceInterface1.Size = new System.Drawing.Size(150, 150);
            this.inheritanceInterface1.TabIndex = 3;
            // 
            // noInheritanceInterface1
            // 
            this.noInheritanceInterface1.Location = new System.Drawing.Point(65, 69);
            this.noInheritanceInterface1.Name = "noInheritanceInterface1";
            this.noInheritanceInterface1.Size = new System.Drawing.Size(150, 150);
            this.noInheritanceInterface1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 371);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inheritanceInterface1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noInheritanceInterface1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NoInheritanceInterface noInheritanceInterface1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private InheritanceInterface inheritanceInterface1;
        private System.Windows.Forms.Button button1;
    }
}

