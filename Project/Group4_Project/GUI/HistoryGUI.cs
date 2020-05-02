using Group4_Project.DAL;
using Group4_Project.DTL;
using Group4_Project.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group4_Project.GUI
{
    public partial class HistoryGUI : Form
    {
        Account a = new Account();
        public Account A
        {
            get { return this.a; }
            set { this.a = value; }
        }
        public void setName()
        {
            if (a.username != null && a.username != "")
            {
                lbName.Visible = true;
                lbName.Text = "Hello, " + a.firstname + " " + a.lastname;
            }
            else
            {
                lbName.Visible = false;
            }
        }
        public HistoryGUI(Account a)
        {
            InitializeComponent();
            this.a = a;
            setName();
            loadData();
        }
        
        public void loadData()
        {
            DataTable dt = OrderDAO.getShortOrderByUserID(a.id);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                OrderDetailForm odf = new OrderDetailForm(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["orderid"].Value.ToString()));
                odf.ShowDialog();
            }
        }
    }
}
