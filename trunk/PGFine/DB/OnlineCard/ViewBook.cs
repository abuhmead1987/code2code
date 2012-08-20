using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ViewBook
/// </summary>
public class ViewBook
{
    public SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["chuoi"]);
	public ViewBook()
	{
		
	}

    // Trả về thông tin chi tiết của một quyển sách có mã là:
    public DataSet ViewBookID(int masp)
    {
        string select = "select * from BB_SanPham where id=" + masp + "";
        SqlDataAdapter adapter = new SqlDataAdapter(select, connect);
        DataSet dts = new DataSet();
        adapter.Fill(dts, "dts");
        return dts;
    }
    // Trả về tất cả các loại sách có mã nhóm sách là 
    public DataSet ViewAllBook(string IDDausach)
    {
        string select = "select * from TBL_Sach where Ma_Dausach='" + IDDausach + "'";
        SqlDataAdapter adapter = new SqlDataAdapter(select, connect);
        DataSet dts = new DataSet();
        adapter.Fill(dts, "dts");
        return dts;
    }
    //Thêm sách vào database
    public void AddBook(string Ma, string Na, string Tacgia, string NXB, double Tien, string mota, string ID, string Mota1, string Path, string PathI, string TT)
    {
        // Goi ham kiem tra sach da ton tai trong Database chua
        if (TestID_Book(Ma)==false)
        {
            // Neu chua thi them vao database
            string Insert = "Insert into TBL_Sach(Ma_Sach,Ten_Sach,Tacgia_Sach,NXB_Sach,Dongia_Sach," +
            "Ma_Dausach,Mota_Sach,Mota_chitiet,Duongdan_Anh,PathImage,Sach_Moi)values(N'" + Ma + "',N'" + Na + "',N'" + Tacgia + "',N'" + NXB + "','" + Tien + "',N'" + mota + "',N'" + ID + "',N'" + Mota1 + "',N'" + Path + "',N'" + PathI + "',N'" + TT + "')";
            connect.Open();
            SqlCommand cmd = new SqlCommand(Insert, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            
        }
        
    }
    //Kiem tra xem cuon sach nay da ton tai trong Database chua?
    public bool TestID_Book(string Ma_Sach)
    {
        string select = "select Ma_Sach from TBL_Sach where Ma_Sach='"+Ma_Sach+"'";
        connect.Open();
        SqlCommand cmd = new SqlCommand(select, connect);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows == false)
        {
            connect.Close();
            return false;
        }
        else
        {
            connect.Close();
            return true;
        }
    }
    public DataSet ViewDsach(string ma_loai)
    {
        string select = "select Ma_Dausach, Ten_Dausach from TBL_Dausach where Ma_Loai='" + ma_loai + "'";
        SqlDataAdapter adapter = new SqlDataAdapter(select, connect);
        DataSet dts = new DataSet();
        adapter.Fill(dts, "dts");
        return dts;
    }
}
