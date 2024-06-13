using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] != null)
            {
                profile.Visible = true;
                logout.Visible = true;
                login.Visible = false;
            }

            if (Session["member_type"] != null)
            {
                if (Session["member_type"].ToString() == "donor")
                {
                    donateLink.InnerText = "My Donations";
                    donateLink.HRef = "manage_donation_member.aspx";
                }
                else if (Session["member_type"].ToString() == "recipient")
                {
                    donateLink.InnerText = "My Requests";
                    donateLink.HRef = "manage_assistance_member.aspx";
                }
                else
                {
                    // Handle other user types or default behavior
                    donateLink.InnerText = "Donate Now";
                    donateLink.HRef = "donate.aspx";
                }
            }
            else
            {
                // Handle case when member_type is not available in the session
                donateLink.InnerText = "Donate Now";
                donateLink.HRef = "donate.aspx";
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("home.aspx");
        }

        protected void profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile_member.aspx");
        }
    }
}