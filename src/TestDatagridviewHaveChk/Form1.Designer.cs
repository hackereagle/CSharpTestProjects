namespace TestDatagridviewHaveChk
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
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.btnAddData = new System.Windows.Forms.Button();
            this.btnAddData2 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTest
            // 
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Location = new System.Drawing.Point(33, 31);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.RowTemplate.Height = 24;
            this.dgvTest.Size = new System.Drawing.Size(460, 276);
            this.dgvTest.TabIndex = 0;
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(47, 338);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(111, 29);
            this.btnAddData.TabIndex = 1;
            this.btnAddData.Text = "Test Adding Data";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnAddData2
            // 
            this.btnAddData2.Location = new System.Drawing.Point(196, 338);
            this.btnAddData2.Name = "btnAddData2";
            this.btnAddData2.Size = new System.Drawing.Size(135, 30);
            this.btnAddData2.TabIndex = 2;
            this.btnAddData2.Text = "Test Add Data Method2";
            this.btnAddData2.UseVisualStyleBackColor = true;
            this.btnAddData2.Click += new System.EventHandler(this.btnAddData2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(367, 338);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Test Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddData2);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.dgvTest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.Button btnAddData2;
        private System.Windows.Forms.Button btnDelete;
    }
}

