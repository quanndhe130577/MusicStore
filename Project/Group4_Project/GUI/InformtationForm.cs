using Group4_Project.DAL;
using Group4_Project.DTL;
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
    public partial class InformtationForm : Form
    {
        int orderid;
        public InformtationForm(int orderid)
        {
            InitializeComponent();
            this.orderid = orderid;
            setText();
        }
        
        public void setText()
        {
            Order or = OrderDAO.getFullOrderByOrderID(orderid);
            txtDate.Text = or.OrderDate.ToString();
            txtFirstName.Text = or.firstname;
            txtLastName.Text = or.lastname;
            txtAddress.Text = or.address;
            txtCity.Text = or.city;
            txtState.Text = or.state;
            txtCountry.Text = or.country;
            txtPhone.Text = or.phone;
            txtEmail.Text = or.email;
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
