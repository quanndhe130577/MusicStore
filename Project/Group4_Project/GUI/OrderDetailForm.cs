using Group4_Project.DAL;
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
    public partial class OrderDetailForm : Form
    {
        int orderid;
        public OrderDetailForm(int orderid)
        {
            InitializeComponent();
            this.orderid = orderid;
            lbOrderID.Text = this.orderid.ToString();
            loadData();
        }

        public void loadData()
        {
            DataTable dt = OrderDetailDAO.getOrderDetailByOrderID(orderid);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btInformation_Click(object sender, EventArgs e)
        {
            InformtationForm inf = new InformtationForm(orderid);
            inf.ShowDialog();
        }
    }
}
