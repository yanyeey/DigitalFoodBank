using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class profile_modify_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                // Display record from first table
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                member_id.Text = dt1.Rows[0][0].ToString();
                AdminNum.Text = dt1.Rows[0][0].ToString();
                email.Text = dt1.Rows[0][3].ToString();

                // Display record from second table
                SqlDataAdapter da2 = new SqlDataAdapter("select * from ADMIN where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                admin_first_name.Text = dt2.Rows[0][1].ToString();
                admin_last_name.Text = dt2.Rows[0][2].ToString();
                contact_no.Text = dt2.Rows[0][3].ToString();
            }
        }

        protected void save_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                string query1 = "select count(*) from MEMBER where member_email = '" + email.Text + "' and member_id != '" + member_id.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

                int check1 = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

                if (check1 > 0)
                {
                    LabelEmailTakenError.Visible = true;
                    LabelEmailTakenError.ForeColor = System.Drawing.Color.Red;
                    LabelEmailTakenError.Text = "This email has been registered.";
                }

                if (check1 == 0 && contact_no.Text != "" && email.Text != "" && admin_first_name.Text != "" 
                    && admin_last_name.Text != "" && RegularExpressionValidatorEmail.IsValid)
                {

                    //update record in a table called MEMBER
                    string query2 = "update MEMBER set member_email = '" + email.Text + "' where member_id = '" + member_id.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, dbconnection1);
                    cmd2.ExecuteNonQuery();

                    //update record in a table called ADMIN
                    string query3 = "update ADMIN set admin_first_name = '" + admin_first_name.Text + "', admin_last_name = '" + admin_last_name.Text + "', admin_contact_no = '" + contact_no.Text + "' where member_id = '" + member_id.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                    cmd3.ExecuteNonQuery();
                    dbconnection1.Close();

                    Session["member_email"] = email.Text;
                    Session["member_type"] = "admin";
                    Session["member_role"] = "individual";

                    Response.Redirect("profile_admin.aspx");
                }
            }
            catch (Exception ex)
            {
                this.LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                this.LabelErrorMessage.Text = "Failed to Update Changes!" + ex.ToString();
                this.LabelErrorMessage.Visible = true;
                return;
            }
        }
    }
}