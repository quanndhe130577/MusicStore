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
    public partial class MyAccountGUI : Form
    {
        Account a = new Account();
        public MyAccountGUI(Account a)
        {
            InitializeComponent();
            
            this.a = a;
            if(a.type == "True")
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
            txtID.Text = a.Id.ToString();
            txtFirstName.Text = a.firstname;
            txtLastName.Text = a.lastname;
            txtAddress.Text = a.address;
            txtCity.Text = a.city;
            txtState.Text = a.state;
            txtCountry.Text = a.country;
            txtPhone.Text = a.phone;
            txtEmail.Text = a.email;           
        }
        /*
        public MyAccountGUI(Account a) : this()
        {
            
        }
        */
        private void btEdit_Click(object sender, EventArgs e)
        {
            displayUser();
            if (btEdit.Text == "Edit")
            {
                btEdit.Text = "Save";
            }
            else
            {
                btEdit.Text = "Edit";
                //update user database              
                a = new Account(int.Parse(txtID.Text), txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtCountry.Text , txtPhone.Text, txtEmail.Text, a.type);
                AccountDAO.UpdateAccount(a);
            }
        }
        public void displayUser()
        {
            txtFirstName.ReadOnly = !txtFirstName.ReadOnly;
            txtLastName.ReadOnly = !txtLastName.ReadOnly;
            txtAddress.ReadOnly = !txtAddress.ReadOnly;
            txtEmail.ReadOnly = !txtEmail.ReadOnly;
            txtPhone.ReadOnly = !txtPhone.ReadOnly;
            txtCity.ReadOnly = !txtCity.ReadOnly;
            txtCountry.ReadOnly = !txtCountry.ReadOnly;
            txtState.ReadOnly = !txtState.ReadOnly;
        }
    }
}
