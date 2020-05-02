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
    public partial class MainGUI : Form
    {
        Account a = new Account();
        DataTable dt_list;
        public DataTable List
        {
            get { return this.dt_list; }
            set { this.dt_list = value; }
        }
        public Account A
        {
            get { return this.a; }
            set { this.a = value; }
        }
        public void removeAccount()
        {
            this.a = new Account();
            resetList();
        }
        public void resetList()
        {
            this.dt_list = new DataTable();
            dt_list.Columns.Add(new DataColumn("albumid", typeof(int)));
            dt_list.Columns.Add(new DataColumn("title", typeof(string)));
            dt_list.Columns.Add(new DataColumn("price", typeof(float)));
            dt_list.Columns.Add(new DataColumn("albumurl", typeof(string)));
            dt_list.Columns.Add(new DataColumn("amount", typeof(int)));
        }
        public MainGUI()
        {
            resetList();
            InitializeComponent();
            //embed(toolStripContainer1.ContentPanel, new AboutGUI());
        }

        private void AlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlbumGUI f = new AlbumGUI(this);
            embed(toolStripContainer1.ContentPanel, f);

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutGUI f = new AboutGUI();
            embed(toolStripContainer1.ContentPanel, f);
        }


        private void embed(Panel panel, Form f)
        {
            panel.Controls.Clear();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Show();

            panel.Controls.Add(f);

        }
        public bool checkForLogin()
        {
            if (a.username == "" || a.username == null)
            {
                MessageBox.Show("You need to login first !!!", "Notification", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        public bool checkForLogout()
        {
            if (a.username != null && a.username != "")
            {
                DialogResult dr = MessageBox.Show("You has already login !! Do you want to logout ? (Yes/No)", "Notification !!!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("You signed out !!!");
                    this.removeAccount();
                    this.setLogout();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private void MyAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkForLogin()) return;
            MyAccountGUI m = new MyAccountGUI(this.a);
            embed(toolStripContainer1.ContentPanel, m);
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkForLogout()) return;
            LoginGUI  m = new LoginGUI(this);
            embed(toolStripContainer1.ContentPanel, m);
        }
        public void setLogout()
        {
            if(LoginToolStripMenuItem.Text == "Login")
            {
                LoginToolStripMenuItem.Text = "LogOut";
                //lgui.Close();
            }
            else
            {
                LoginToolStripMenuItem.Text = "Login";
            }
            
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkForLogin()) return;
            HistoryGUI m = new HistoryGUI(this.a);
            embed(toolStripContainer1.ContentPanel, m);
        }

        private void reserveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ReserveGUI m = new ReserveGUI();
           // embed(toolStripContainer1.ContentPanel, m);
        }
    }
}
