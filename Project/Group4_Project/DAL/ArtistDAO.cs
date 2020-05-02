using Group4_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DAL
{
    class ArtistDAO : DAO
    {
        public static DataTable getAllArtist()
        {
            String sql = "SELECT * FROM Artists";
            return DAO.GetDataTable(sql);
        }

        public static bool InsertArtist(String name)
        {
            SqlCommand cmd = new SqlCommand("Insert Artists (name) VALUES (@na)");
            cmd.Parameters.AddWithValue("@na", name);
            return DAO.UpdateTable(cmd);
        }
    }
}
