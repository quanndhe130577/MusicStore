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
    public partial class NewArtitForm : Form
    {
        AddEditAlbumForm aef;
        public NewArtitForm(AddEditAlbumForm aef)
        {
            InitializeComponent();
            this.aef = aef;
        }
        public bool checkNull()
        {
            TextBox[] listTextBox1 = new TextBox[] { txtName };
            foreach (TextBox txt in listTextBox1)
            {
                if (txt.Text == "" || txt.Text == null)
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
                if (ArtistDAO.InsertArtist(txtName.Text))
                {
                    MessageBox.Show("Add Artist successfull !!!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Artist existed !!!");
                }

            }
        }

        private void NewArtitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.aef.loadArtist();
        }
    }
}
