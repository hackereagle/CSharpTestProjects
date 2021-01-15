using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDatagridviewHaveChk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupDataGridView(this.dgvTest);
        }

        private enum DgvColContain
        { 
            Priority = 0,
            IsUsed,
            Algorithm,
            Name,
        }

        private void SetupDataGridView(System.Windows.Forms.DataGridView dgv)
        {
            dgv.ColumnCount = 4;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // with this setting, I can not use DataGridView.NewRowIndex property. DataGridView.NewRowIndex would be -1 ever
            // refer to https://stackoverflow.com/questions/31990665/adding-new-row-to-the-bottom-of-datagridview
            dgv.AllowUserToAddRows = false; 
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = false;


            dgv.Columns[(int)DgvColContain.Priority].Name = "Priority";
            // create DataGridView CheckBox column
            DataGridViewCheckBoxColumn dgvChkColumn = new DataGridViewCheckBoxColumn();
            dgv.Columns.Insert((int)DgvColContain.IsUsed, dgvChkColumn);
            dgv.Columns[(int)DgvColContain.IsUsed].Name = "Use";
            dgv.Columns[(int)DgvColContain.Algorithm].Name = "Algorithm";
            dgv.Columns[(int)DgvColContain.Name].Name = "Name";

            dgv.Columns[(int)DgvColContain.Priority].ReadOnly = true;
            dgv.Columns[(int)DgvColContain.Priority].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[(int)DgvColContain.IsUsed].ReadOnly = false;
            dgv.Columns[(int)DgvColContain.Algorithm].ReadOnly = true;
            dgv.Columns[(int)DgvColContain.Name].ReadOnly = true;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            this.dgvTest.Rows.Add();
            this.dgvTest.Rows[this.dgvTest.RowCount - 1].Cells[0].Value = this.dgvTest.Rows.Count;
            this.dgvTest.Rows[this.dgvTest.RowCount - 1].Cells[1].Value = false; // if true, CheckBox would be check out.
            this.dgvTest.Rows[this.dgvTest.RowCount - 1].Cells[2].Value = "Algorithm";
            this.dgvTest.Rows[this.dgvTest.RowCount - 1].Cells[3].Value = "yo~";
        }

        private void btnAddData2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"string.Compare result: {string.Compare("Algorithm", "Algorithm")}"); // just test
            this.dgvTest.Rows.Add(new object[] { this.dgvTest.Rows.Count + 1, true, "Algorithm2", "yo yo~~"});
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (dgvTest.SelectedRows.Count > 0 &&
            //    dgvTest.SelectedRows[0].Index != dgvTest.Rows.Count - 1)
            if (dgvTest.SelectedRows.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("");
                dgvTest.Rows.RemoveAt(dgvTest.SelectedRows[0].Index);
            }
        }
    }
}
