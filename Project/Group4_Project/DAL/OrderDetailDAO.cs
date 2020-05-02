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
    class OrderDetailDAO : DAO
    {
        public static bool Insert(OrderDetail ord)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO orderdetails (orderid, albumid, quantity, unitprice )" +
                " VALUES( @od, @al, @qu, @ui)");
            cmd.Parameters.AddWithValue("@od", ord.Orderid);
            cmd.Parameters.AddWithValue("@al", ord.Albumid);
            cmd.Parameters.AddWithValue("@qu", ord.Quantity);
            cmd.Parameters.AddWithValue("@ui", ord.UniPrice);
            return DAO.UpdateTable(cmd);
        }

        public static DataTable getOrderDetailByOrderID(int orderid)
        {
            String sql = "SELECT OrderDetailId, [Albums].[Title], [Genres].[Name] as Genre, Quantity, UnitPrice " +
                "FROM OrderDetails, Albums, Genres " +
                "WHERE OrderDetails.AlbumId = Albums.AlbumId and Albums.GenreId = Genres.GenreId and OrderId = " + orderid;
            return DAO.GetDataTable(sql);
        }
    }
}
