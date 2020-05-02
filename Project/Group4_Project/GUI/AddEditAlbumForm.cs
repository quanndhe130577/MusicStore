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
    public partial class AddEditAlbumForm : Form
    {
        Album al;
        AlbumGUI agui;
        int checkAddEdit = 0;
        public AddEditAlbumForm(int albumid, AlbumGUI agui)
        {
            InitializeComponent();
            this.agui = agui;
            //load Genre
            loadGenre();
            //load artits
            loadArtist();
            if (albumid != 0)
            {
                checkAddEdit = 1;
                this.al = AlbumDAO.GetAlbumByID(albumid);
            }else
            {
                al = new Album();
            }
            setText();
        }
        public void setText()
        {
            
            if (checkAddEdit == 1)
            {
                for(var i = 0; i < comboBox1.Items.Count; i++)
                {
                    comboBox1.SelectedIndex = i;
                    if (al.Genreid == int.Parse(comboBox1.SelectedValue.ToString()))
                    {
                        break;
                    }

                }
                for (var i = 0; i < comboBox2.Items.Count; i++)
                {
                    comboBox2.SelectedIndex = i;
                    if (al.Artistid == int.Parse(comboBox2.SelectedValue.ToString()))
                    {
                        break;
                    }

                }
                txtTitle.Text = al.Title;
                txtPrice.Text = al.Price.ToString();
                txtAlbumURL.Text = al.AlbumUrl;
                btAddEdit.Text = "Eidt Album";
            }
            
        }
        public void loadGenre()
        {
            DataTable dt = GenreDAO.getAllGenres();
            DataRow r = dt.NewRow();
            r["genreid"] = -1;
            r["name"] = "----- Other -----";
            dt.Rows.Add(r);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "genreid";

        }
        public void loadArtist()
        {
            DataTable dt1 = ArtistDAO.getAllArtist();
            DataRow r1 = dt1.NewRow();
            r1["artistid"] = -1;
            r1["name"] = "----- Other -----";
            dt1.Rows.Add(r1);

            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "artistid";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString() == "-1")
            {
                NewGenreForm ngf = new NewGenreForm(this);
                ngf.ShowDialog();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue.ToString() == "-1")
            {
                NewArtitForm naf = new NewArtitForm(this);
                naf.ShowDialog();
            }
        }
        public bool checkNull()
        {
            TextBox[] listTextBox1 = new TextBox[] { txtTitle, txtPrice, txtAlbumURL };
            foreach(TextBox txt in listTextBox1)
            {
                if(txt.Text == "" || txt.Text == null)
                {
                    MessageBox.Show("You need to fill all information !!!");
                    return false;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkNull())
            {
                // add album
                if(checkAddEdit == 0)
                {
                    int genreid = int.Parse(comboBox1.SelectedValue.ToString());
                    int artistid = int.Parse(comboBox2.SelectedValue.ToString());
                    Album a = new Album(genreid, artistid, txtTitle.Text, float.Parse(txtPrice.Text), txtAlbumURL.Text);
                    if (AlbumDAO.InsertAlbum(a))
                    {
                        MessageBox.Show("Add album successfully !!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Add album fail !!! Album has existed");
                    }
                }
                // edit album
                else
                {
                    al.Genreid = int.Parse(comboBox1.SelectedValue.ToString());
                    al.Artistid = int.Parse(comboBox2.SelectedValue.ToString());
                    al.Title = txtTitle.Text;
                    try
                    {
                        al.Price = float.Parse(txtPrice.Text);
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Price must be number !!!");
                        return;
                    }
                    al.AlbumUrl = txtAlbumURL.Text;
                    if (AlbumDAO.UpdateAlbum(al))
                    {
                        MessageBox.Show("Edit Album successfull !!");
                        this.Close();
                    }
                }
                
            }
            
        }

        private void AddEditAlbumForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            agui.loadArtist();
            agui.loadGenre();
            agui.loadData();
        }
    }
}
