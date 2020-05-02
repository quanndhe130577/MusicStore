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
    class AlbumDAO : DAO
    {
        public static DataTable GetAlbum(int genreid, int artistid)
        {
            String sql = "SELECT albumid, title, price, albumurl FROM Albums";
            if(genreid != -1 && artistid != -1)
            {
                sql += " WHERE genreid = " + genreid + " and artistid = " + artistid;
            }else if(genreid == -1 && artistid == -1 )
            {
            }else if(artistid == -1)
            {
                sql += " WHERE genreid = " + genreid;
            }
            else
            {
                sql += " WHERE artistid = " + artistid;
            }
            return DAO.GetDataTable(sql);
        }

        public static bool InsertAlbum(Album a)
        {
            SqlCommand cmd = new SqlCommand("INSERT Albums (genreid, artistid, title, price, albumurl)" +
                " VALUES(@gi, @ai, @ti, @pr, @al)");
            cmd.Parameters.AddWithValue("@gi", a.Genreid);
            cmd.Parameters.AddWithValue("@ai", a.Artistid);
            cmd.Parameters.AddWithValue("@ti", a.Title);
            cmd.Parameters.AddWithValue("@pr", a.Price);
            cmd.Parameters.AddWithValue("@al", a.AlbumUrl);
            return DAO.UpdateTable(cmd);
        }

        public static bool UpdateAlbum(Album a)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Albums SET genreid = @gi, artistid = @ai, title = @ti," +
                " price = @pr, albumurl = @abu WHERE albumid = @i");
            cmd.Parameters.AddWithValue("@gi", a.Genreid);
            cmd.Parameters.AddWithValue("@ai", a.Artistid);
            cmd.Parameters.AddWithValue("@ti", a.Title);
            cmd.Parameters.AddWithValue("@pr", a.Price);
            cmd.Parameters.AddWithValue("@abu", a.AlbumUrl);
            cmd.Parameters.AddWithValue("@i", a.Albumid);
            return DAO.UpdateTable(cmd);
        }
        public static Album GetAlbumByID(int albumid)
        {
            String sql = "SELECT * FROM albums WHERE albumid = " + albumid;
            DataTable dt = DAO.GetDataTable(sql);
            return new Album(albumid, int.Parse(dt.Rows[0]["genreid"].ToString()),
                int.Parse(dt.Rows[0]["artistid"].ToString()), dt.Rows[0]["title"].ToString(), float.Parse(dt.Rows[0]["price"].ToString()),
                dt.Rows[0]["albumurl"].ToString());
        }

        public static bool DeleteAlbumById(int albumid)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Albums WHERE albumid = " + albumid);
            return DAO.UpdateTable(cmd);
        }
    }
}

