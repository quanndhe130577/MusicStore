
using Group4_Project.DAL;
using Group4_Project.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DAL
{
    class GenreDAO : DAO
    {
        public static DataTable getAllGenres()
        {
            String sql = "SELECT * FROM Genres";
            return DAO.GetDataTable(sql);
        }

        public static bool InsertGenre(Genres g)
        {
            SqlCommand cmd = new SqlCommand("INSERT genres (name, description) VALUES(@na, @des)");
            cmd.Parameters.AddWithValue("@na", g.Name);
            cmd.Parameters.AddWithValue("@des", g.Description);
            return DAO.UpdateTable(cmd);
        }
    }
}
