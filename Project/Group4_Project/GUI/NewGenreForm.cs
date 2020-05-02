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
    public partial class NewGenreForm : Form
    {
        AddEditAlbumForm aef;
        public NewGenreForm(AddEditAlbumForm aef)
        {
            InitializeComponent();
            this.aef = aef;
        }
        public bool checkNull()
        {
            TextBox[] listTextBox1 = new TextBox[] { txtDesc, txtName };
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
                Genres g = new Genres(txtName.Text, txtDesc.Text);
                if (GenreDAO.InsertGenre(g))
                {
                    MessageBox.Show("Add Genre successfull !!!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Genre has exited !!!");
                }
            }  
        }

        private void NewGenreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.aef.loadGenre();
        }
    }
}
