﻿using Group4_Project.DTL;
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
    public partial class MyCartForm : Form
    {
        MainGUI m;
        AlbumGUI agui;
        DataTable dt;
        int numberOfCart = 0;
        Account a = new Account();
        public Account A
        {
            get { return this.a; }
            set { this.a = value; }
        }
        public MyCartForm(DataTable dt, Account a, MainGUI m, AlbumGUI agui)
        {
            InitializeComponent();
            
            this.m = m;
            this.a = a;
            this.agui = agui;
            this.dt = dt;
            foreach(DataRow dr in dt.Rows)
            {
                numberOfCart += int.Parse(dr["amount"].ToString());
            }
            lbNumberCart.Text = numberOfCart.ToString();
            dataGridView1.DataSource = dt;
            displayPanel(1);
            if (dt.Rows.Count == 0) btCheckOut.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 )
            {
                int amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["amount"].Value.ToString());
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    numberOfCart = int.Parse(lbNumberCart.Text) - amount;
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("plus"))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["amount"].Value = amount + 1;
                    numberOfCart += 1;
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("subtract"))
                {
                    if(amount > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["amount"].Value = amount - 1;
                        numberOfCart -= 1;
                    }
                    
                }
                lbNumberCart.Text = numberOfCart.ToString();
                if (numberOfCart == 0)
                {
                    btCheckOut.Enabled = false;
                }
                else
                {
                    btCheckOut.Enabled = true;
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        float total_amount = 0;
        private void btCheckOut_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Do you want to CheckOut ? (Y/N)", "Notification", MessageBoxButtons.YesNo);
            if(dlr == DialogResult.Yes)
            {
                displayPanel(2);
                DataTable dt1 = new DataTable();
                dt1.Columns.Add(new DataColumn("albumid", typeof(int)));
                dt1.Columns.Add(new DataColumn("title", typeof(string)));
                dt1.Columns.Add(new DataColumn("price", typeof(float)));
                dt1.Columns.Add(new DataColumn("amount", typeof(int)));
                dt1.Columns.Add(new DataColumn("total", typeof(float)));

                foreach (DataRow dr in dt.Rows)
                {
                    DataRow rd1 = dt1.NewRow();
                    rd1["albumid"] = dr["albumid"];
                    rd1["title"] = dr["title"];
                    rd1["price"] = dr["price"];
                    rd1["amount"] = dr["amount"];
                    rd1["total"] = float.Parse(dr["price"].ToString()) * int.Parse(dr["amount"].ToString()) ;
                    total_amount += float.Parse(rd1["total"].ToString());
                    dt1.Rows.Add(rd1);
                }
                txtTotalAmount.Text = total_amount.ToString("C2");
                dataGridView2.DataSource = dt1;
                setText();
            }
        }
        public void setText()
        {
            txtFirstName.Text = this.a.firstname;
            txtLastName.Text = this.a.lastname;
            txtAddress.Text = this.a.address;
            txtCity.Text = this.a.city;
            txtState.Text = this.a.state;
            txtCountry.Text = this.a.country;
            txtPhone.Text = this.a.phone;
            txtEmail.Text = this.a.email;
        }

        public void displayPanel(int n)
        {
            switch (n)
            {
                case 1:
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
                        panel1.Enabled = true;
                        panel2.Visible = false;
                        panel1.Focus();
                        break;
                    }
                case 2:
                    {
                        panel1.Enabled = false;
                        panel2.Visible = true;
                        panel2.Focus();
                        break;
                    }
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            displayPanel(1);
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
        private void btEdit_Click(object sender, EventArgs e)
        {
            displayUser();
            if(btEdit.Text == "Edit")
            {
                txtFirstName.Focus();
                btEdit.Text = "Save";
            }
            else
            {
                btEdit.Text = "Edit";
                //update user database
                /*
                a = new Account(a.id, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtCountry.Text , txtPhone.Text, txtEmail.Text, a.type);
                AccountDAO.UpdateAccount(a);
                */
            }
        }
        public bool checkInformation()
        {
            TextBox[] listTextBox1 = new TextBox[] { txtFirstName, txtLastName, txtAddress, txtCity, txtCountry, txtState, txtPhone, txtEmail };
            foreach(TextBox txt in listTextBox1)
            {
                if(txt.Text == "")
                {
                    MessageBox.Show("You need to fill Information before checkout !!!", "Notification", MessageBoxButtons.OK);
                    return false;
                }
            }
            return true;
        }
        private void btSubmit_Click(object sender, EventArgs e)
        {
            //check for login
            if (a.username == null || a.username == "")
            {
                DialogResult dr = MessageBox.Show("You have to login to checkout !!", "Notification", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    LoginGUI lgui = new LoginGUI(this.m, this);
                    lgui.Show();
                }
                return;
            }
            //check for information
            if (!checkInformation())
            {
                btEdit_Click(sender, e);
                return;
            }
            if(btEdit.Text == "Save")
            {
                MessageBox.Show("You need to save your information !!!");
                return;
            }
            // update order database
            Order or = new Order(dateTimePicker1.Value, txtFirstName.Text, txtLastName.Text, txtAddress.Text,
                txtCity.Text, txtState.Text, txtCountry.Text, txtPhone.Text, txtEmail.Text, total_amount, a.id);
            OrderDAO.Insert(or);
            int orderid = OrderDAO.getIDMax();
            if (orderid != -1)
            { 
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    {
                        OrderDetail ord = new OrderDetail(orderid, int.Parse(dr.Cells["albumid"].Value.ToString()), int.Parse(dr.Cells["amount"].Value.ToString()), int.Parse(dr.Cells["price"].Value.ToString()));
                        OrderDetailDAO.Insert(ord);
                    }
                }
                MessageBox.Show("Checkout Successfully !!! Thank you !!!! See You Again !!!", "Notification !!!", MessageBoxButtons.OK);
                m.resetList();
                this.Close();
            }
            else
            {
                MessageBox.Show("Checkout Error !!! Try Again !!!", "Notification !!!", MessageBoxButtons.OK);
            }
            
        }

        private void MyCartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            agui.reloadData();
            agui.setName();
        }
    }
}
