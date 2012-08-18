using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using anm_utility;

public partial class Controls_UsersOnline : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("OnlineUsers") == "True")
        {
            pnlVisitors.Visible = true;
            int numberOfUsersOnline = Membership.GetNumberOfUsersOnline();
            Members.Text = numberOfUsersOnline.ToString();
            string totalUsers = Application["OnlineUsers"].ToString();
            TotalUsers.Text = totalUsers;
            int visitors = Convert.ToInt32(totalUsers) - numberOfUsersOnline;
            if (visitors < 0) visitors = 0;
            Visitors.Text = visitors.ToString();
            var onlineUsers = (from a in Membership.GetAllUsers().Cast<MembershipUser>().ToList()
                               where a.IsOnline
                               select a.UserName).ToList();
            string users = "";
            for (int i = 0; i < onlineUsers.Count; i++)
            {
                if (i==0)
                    users = onlineUsers[0];
                else
                    users = users + ", " + onlineUsers[i].Replace("&", "&amp;");
            }
            OnlineNow.Text = users;
        }
    }
}