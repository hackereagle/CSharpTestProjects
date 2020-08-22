namespace CSharpLoadCppDll
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
            this.pctbxOrgImg = new System.Windows.Forms.PictureBox();
            this.pctbxRecievePInvokeImg = new System.Windows.Forms.PictureBox();
            this.pctbxRecieveManageClassImg = new System.Windows.Forms.PictureBox();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnProcessing = new System.Windows.Forms.Button();
            this.lblSrcImg = new System.Windows.Forms.Label();
            this.lblManagementDllImg = new System.Windows.Forms.Label();
            this.lblUnmanagementDllImg = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxOrgImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRecievePInvokeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRecieveManageClassImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pctbxOrgImg
            // 
            this.pctbxOrgImg.BackColor = System.Drawing.SystemColors.Control;
            this.pctbxOrgImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbxOrgImg.Location = new System.Drawing.Point(49, 59);
            this.pctbxOrgImg.Name = "pctbxOrgImg";
            this.pctbxOrgImg.Size = new System.Drawing.Size(414, 440);
            this.pctbxOrgImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxOrgImg.TabIndex = 0;
            this.pctbxOrgImg.TabStop = false;
            // 
            // pctbxRecievePInvokeImg
            // 
            this.pctbxRecievePInvokeImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbxRecievePInvokeImg.Location = new System.Drawing.Point(527, 59);
            this.pctbxRecievePInvokeImg.Name = "pctbxRecievePInvokeImg";
            this.pctbxRecievePInvokeImg.Size = new System.Drawing.Size(414, 440);
            this.pctbxRecievePInvokeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxRecievePInvokeImg.TabIndex = 1;
            this.pctbxRecievePInvokeImg.TabStop = false;
            // 
            // pctbxRecieveManageClassImg
            // 
            this.pctbxRecieveManageClassImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbxRecieveManageClassImg.Location = new System.Drawing.Point(1004, 59);
            this.pctbxRecieveManageClassImg.Name = "pctbxRecieveManageClassImg";
            this.pctbxRecieveManageClassImg.Size = new System.Drawing.Size(414, 440);
            this.pctbxRecieveManageClassImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxRecieveManageClassImg.TabIndex = 2;
            this.pctbxRecieveManageClassImg.TabStop = false;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(618, 515);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(95, 33);
            this.btnLoadImg.TabIndex = 3;
            this.btnLoadImg.Text = "Load Image";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnProcessing
            // 
            this.btnProcessing.Location = new System.Drawing.Point(785, 515);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(90, 33);
            this.btnProcessing.TabIndex = 4;
            this.btnProcessing.Text = "Processing";
            this.btnProcessing.UseVisualStyleBackColor = true;
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // lblSrcImg
            // 
            this.lblSrcImg.AutoSize = true;
            this.lblSrcImg.Location = new System.Drawing.Point(46, 31);
            this.lblSrcImg.Name = "lblSrcImg";
            this.lblSrcImg.Size = new System.Drawing.Size(89, 15);
            this.lblSrcImg.TabIndex = 5;
            this.lblSrcImg.Text = "Source Image:";
            // 
            // lblManagementDllImg
            // 
            this.lblManagementDllImg.AutoSize = true;
            this.lblManagementDllImg.Location = new System.Drawing.Point(527, 31);
            this.lblManagementDllImg.Name = "lblManagementDllImg";
            this.lblManagementDllImg.Size = new System.Drawing.Size(195, 15);
            this.lblManagementDllImg.TabIndex = 6;
            this.lblManagementDllImg.Text = "After PInvoke Processing Image:";
            // 
            // lblUnmanagementDllImg
            // 
            this.lblUnmanagementDllImg.AutoSize = true;
            this.lblUnmanagementDllImg.Location = new System.Drawing.Point(1004, 31);
            this.lblUnmanagementDllImg.Name = "lblUnmanagementDllImg";
            this.lblUnmanagementDllImg.Size = new System.Drawing.Size(254, 15);
            this.lblUnmanagementDllImg.TabIndex = 7;
            this.lblUnmanagementDllImg.Text = "After Management Class Processing Image:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 579);
            this.Controls.Add(this.lblUnmanagementDllImg);
            this.Controls.Add(this.lblManagementDllImg);
            this.Controls.Add(this.lblSrcImg);
            this.Controls.Add(this.btnProcessing);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.pctbxRecieveManageClassImg);
            this.Controls.Add(this.pctbxRecievePInvokeImg);
            this.Controls.Add(this.pctbxOrgImg);
            this.Name = "Form1";
            this.Text = "C# Load C++ Dll Test Form";
            ((System.ComponentModel.ISupportInitialize)(this.pctbxOrgImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRecievePInvokeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxRecieveManageClassImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbxOrgImg;
        private System.Windows.Forms.PictureBox pctbxRecievePInvokeImg;
        private System.Windows.Forms.PictureBox pctbxRecieveManageClassImg;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnProcessing;
        private System.Windows.Forms.Label lblSrcImg;
        private System.Windows.Forms.Label lblManagementDllImg;
        private System.Windows.Forms.Label lblUnmanagementDllImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

