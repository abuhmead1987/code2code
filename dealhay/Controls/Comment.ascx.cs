using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using anm_utility;
using System.Data;

public partial class Controls_Comment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["comment"] != null)
        {
            anm_Utility ut = new anm_Utility();
            string idc = Request.QueryString["comment"];
            string idnews = "";
            int rownumber = 0;
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getComment", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@idcomment", SqlDbType.NVarChar).Value = idc;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                idnews = reader["idnews"].ToString();
            myConnection.Close();

                SqlCommand myCommand2 = new SqlCommand();
                myCommand2.Connection = myConnection;
                myConnection.Open();
                myCommand2.CommandText = "SELECT RowNumber FROM (SELECT idcomment, ROW_NUMBER() OVER(ORDER BY idcomment DESC) AS RowNumber FROM [anm_Comments] WHERE [idnews] = " + idnews + " and [approved] = 'true') AS NewsWithRowNumbers WHERE idcomment = " + idc + "";
                SqlDataReader reader2 = myCommand2.ExecuteReader();
                if (reader2.Read())
                {
                    rownumber = Convert.ToInt32(reader2["RowNumber"].ToString());
                }
                myConnection.Close();
            int maximumRows = 15;
            if (ut.GetSetting("NumComments") != "")
                maximumRows = Convert.ToInt32(ut.GetSetting("NumComments"));
            int page = (rownumber / maximumRows) + 1;
            if (rownumber % maximumRows == 0)
                page = page -1;
            Response.Redirect(anm_Utility.GetWebAppRoot() + "/page" + page + "/comments/articles/" + idnews + "/" + ut.RemoveNonAlfaNumeric(ut.GetTitleNews(idnews)) + ".aspx#comment"+idc);
        }

    }
}