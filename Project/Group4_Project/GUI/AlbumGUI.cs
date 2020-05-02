
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group4_Project.DAL;
using Group4_Project.DTL;

namespace Group4_Project.GUI
{
    public partial class AlbumGUI : Form
    {
        MainGUI m;
        DataTable dt_list = new DataTable();
        int check = 0;
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
        public void reloadData()
        {
            this.a = m.A;
            this.dt_list = m.List;
        }
        public AlbumGUI(MainGUI m)
        {
            this.m = m;
            this.a = m.A;
            this.dt_list = m.List;
            InitializeComponent();
            //get Genres
            loadGenre();

            // get Arits
            loadArtist();
            
            loadData();
            displayButton();
        }
        public void displayButton()
        {
            if(a.type == "True")
            {
                btMyCart.Visible = false;
            }
            else
            {
                btAdd.Visible = false;
                btDelete.Visible = false;
                btEdit.Visible = false;
            }
        }
        public void loadGenre()
        {
            DataTable dt = GenreDAO.getAllGenres();
            DataRow r = dt.NewRow();
            r["genreid"] = -1;
            r["name"] = "----- ALL -----";
            dt.Rows.Add(r);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "genreid";

            comboBox1.SelectedIndex = dt.Rows.Count - 1;
        }
        public void loadArtist()
        {
            DataTable dt1 = ArtistDAO.getAllArtist();
            DataRow r1 = dt1.NewRow();
            r1["artistid"] = -1;
            r1["name"] = "----- ALL -----";
            dt1.Rows.Add(r1);

            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "artistid";


            comboBox2.SelectedIndex = dt1.Rows.Count - 1;
        }
        public void loadData()
        {
            setName();
            check++;
            try
            {
                if(check > 4)
                {
                    int genreid = int.Parse(comboBox1.SelectedValue.ToString());
                    int artistid = int.Parse(comboBox2.SelectedValue.ToString());
                    DataTable dt = AlbumDAO.GetAlbum(genreid, artistid);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                }     
            }
            catch (Exception ex)
            {
                throw ex;
                return;
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 )
            {
                bool check = true;
                foreach (DataRow rd1 in dt_list.Rows)
                {
                    if (rd1["albumid"].ToString() == dataGridView1.Rows[e.RowIndex].Cells["albumid"].Value.ToString())
                    {
                        rd1["amount"] = int.Parse(rd1["amount"].ToString()) + 1;
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    DataRow rd = dt_list.NewRow();
                    rd[0] = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["albumid"].Value.ToString());
                    rd[1] = dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString();
                    rd[2] = float.Parse(dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
                    rd[3] = dataGridView1.Rows[e.RowIndex].Cells["albumurl"].Value.ToString();
                    rd[4] = 1;
                    dt_list.Rows.Add(rd);
                }
                m.List = dt_list;
                MessageBox.Show("Add Successfully !!!");
            }
        }

        private void btMyCart_Click(object sender, EventArgs e)
        {
            MyCartForm mc = new MyCartForm(dt_list, this.a, this.m, this);
            mc.ShowDialog();
        }
        private bool isSelected()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select a album in the list of albums!");
                return false;
            }
            if (dataGridView1.SelectedRows[0].Cells["albumid"].Value == null)
            {
                MessageBox.Show("You must select a album in the list of albums!");
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditAlbumForm aef = new AddEditAlbumForm(0, this);
            aef.ShowDialog();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (isSelected())
            {
                if(dataGridView1.SelectedRows.Count > 1)
                {
                    MessageBox.Show("You can chose only one albums !!!");
                    return;
                }
                /*
                Album al = new Album(int.Parse(dataGridView1.SelectedRows[0].Cells["albumid"].Value.ToString()),
                    int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()),
                    dataGridView1.SelectedRows[0].Cells["title"].Value.ToString(),
                    float.Parse(dataGridView1.SelectedRows[0].Cells["price"].Value.ToString()),
                    dataGridView1.SelectedRows[0].Cells["albumurl"].Value.ToString());*/
                AddEditAlbumForm aef = new AddEditAlbumForm(int.Parse(dataGridView1.SelectedRows[0].Cells["albumid"].Value.ToString()), this);
                aef.ShowDialog();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (isSelected())
            {
                foreach(DataGridViewRow rd in dataGridView1.SelectedRows)
                {
                    if (!AlbumDAO.DeleteAlbumById(int.Parse(rd.Cells["albumid"].Value.ToString())))
                    {
                        MessageBox.Show("Some Albums can't delete !!!");
                        loadData();
                        return;
                    }
                }
                MessageBox.Show("Delete albums successfully");
                loadData();
            }
        }
    }
}
