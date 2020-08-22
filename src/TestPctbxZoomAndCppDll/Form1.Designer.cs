namespace TestPctbxZoomAndCppDll
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pctbx = new System.Windows.Forms.PictureBox();
            this.lblPicturePath = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openPicture = new System.Windows.Forms.OpenFileDialog();
            this.label_position = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_position, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pctbx, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPicturePath, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(60, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.06349F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.936508F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pctbx
            // 
            this.pctbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctbx.Location = new System.Drawing.Point(3, 3);
            this.pctbx.Name = "pctbx";
            this.pctbx.Size = new System.Drawing.Size(720, 386);
            this.pctbx.TabIndex = 0;
            this.pctbx.TabStop = false;
            this.pctbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctbx_MouseDown);
            this.pctbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctbx_MouseMove);
            this.pctbx.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pctbx_MouseWheel);
            // 
            // lblPicturePath
            // 
            this.lblPicturePath.AutoSize = true;
            this.lblPicturePath.Location = new System.Drawing.Point(3, 425);
            this.lblPicturePath.Name = "lblPicturePath";
            this.lblPicturePath.Size = new System.Drawing.Size(74, 15);
            this.lblPicturePath.TabIndex = 1;
            this.lblPicturePath.Text = "picture path";
            this.lblPicturePath.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(354, 500);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openPicture
            // 
            this.openPicture.FileName = "openFileDialog1";
            // 
            // label_position
            // 
            this.label_position.AutoSize = true;
            this.label_position.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_position.Location = new System.Drawing.Point(564, 392);
            this.label_position.Name = "label_position";
            this.label_position.Size = new System.Drawing.Size(159, 33);
            this.label_position.TabIndex = 11;
            this.label_position.Text = "(x, y) = ( 0, 0) || Gray = ()";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 546);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pctbx;
        private System.Windows.Forms.Label lblPicturePath;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openPicture;
        private System.Windows.Forms.Label label_position;
    }
}

