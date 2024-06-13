using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Configuration;

namespace FYP_DFB
{
    public partial class profile_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                if (Session["member_type"].ToString() == "admin")
                {
                    // Display record from first table
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    member_id.Text = dt1.Rows[0][0].ToString();
                    admin_id.Text = dt1.Rows[0][0].ToString();
                    MemberEmail.Text = dt1.Rows[0][3].ToString();

                    // Display record from second table
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from ADMIN where member_id = '" + member_id.Text + "'", dbconnection1);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    MemberFirstName.Text = dt2.Rows[0][1].ToString();
                    MemberLastName.Text = dt2.Rows[0][2].ToString();
                    MemberContactNum.Text = dt2.Rows[0][3].ToString();

                    greet.Text = MemberLastName.Text;
                }
                dbconnection1.Close();
            }
        }

        protected void modify_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile_modify_admin.aspx");
        }
    }
}