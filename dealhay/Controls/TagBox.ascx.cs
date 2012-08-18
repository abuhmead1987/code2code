using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using anm_utility;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Controls_TagBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("TagBox") == "True")
        {
            pnlTags.Visible = true;
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_GetTags", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();

            String res = "- ";
            while (reader.Read())
            {
                res = res + "<a href='" + Page.Request.ApplicationPath.ToString() + "/tag/" + ut.UrlEncode(reader["tag"].ToString()) + ".aspx' style='font-size: " + reader["size"].ToString() + "px'>" + reader["tag"].ToString() + "</a> - ";
            }
            myConnection.Close();
            Label1.Text = res;
        }
    }
}