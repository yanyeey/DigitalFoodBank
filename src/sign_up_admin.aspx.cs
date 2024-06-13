using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class sign_up_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            //read admin count
            string query1 = "select count (*) from MEMBER where member_type = 'admin'";
            SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

            //for new table with zero record

            //admin
            int record_admin = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_admin < 1)
            {
                AdminCount.Text = "1";
            }
            else
            {
                int admin_count = record_admin + 1;
                AdminCount.Text = admin_count.ToString();
            }
        }

        protected void signup_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                string query1 = "select count(*) from MEMBER where member_email = '" + email.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

                int check1 = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

                if (check1 > 0)
                {
                    LabelEmailTakenError.Visible = true;
                    LabelEmailTakenError.ForeColor = System.Drawing.Color.Red;
                    LabelEmailTakenError.Text = "This email has been registered.";
                }

                if (password.Text.Length < 8 || password.Text.Length > 16)
                {
                    LabelPasswordLengthError.Visible = true;
                    LabelPasswordLengthError.ForeColor = System.Drawing.Color.Red;
                    LabelPasswordLengthError.Text = "Password must be between 8 to 16 characters.";
                }

                if (password.Text != confirm_password.Text)
                {
                    LabelPasswordMatchError.Visible = true;
                    LabelPasswordMatchError.ForeColor = System.Drawing.Color.Red;
                    LabelPasswordMatchError.Text = "Password Does Not Match!";
                }

                if (check1 == 0 && AdminCount.Text != "" && individual_first_name.Text != ""
                    && individual_last_name.Text != "" && contact_no.Text != "" && email.Text != ""
                    && RegularExpressionValidatorEmail.IsValid && password.Text.Length > 7 
                    && password.Text.Length < 16 && password.Text == confirm_password.Text)
                {
                    //create record in a table called MEMBER
                    string query3 = "insert into MEMBER (member_id, member_role, member_type, member_email, member_password) values (@id, @role, @type, @email, @password) ";
                    SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                    cmd3.Parameters.AddWithValue("@id", "IA" + AdminCount.Text);
                    cmd3.Parameters.AddWithValue("@role", "individual");
                    cmd3.Parameters.AddWithValue("@type", "admin");
                    cmd3.Parameters.AddWithValue("@email", email.Text);
                    cmd3.Parameters.AddWithValue("@password", password.Text);
                    cmd3.ExecuteNonQuery();

                    //create record in a table called ADMIN
                    string query4 = "insert into ADMIN (member_id, admin_first_name, admin_last_name, admin_contact_no) values (@id, @first_name, @last_name, @contact_no) ";
                    SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                    cmd4.Parameters.AddWithValue("@id", "IA" + AdminCount.Text);
                    cmd4.Parameters.AddWithValue("@first_name", individual_first_name.Text);
                    cmd4.Parameters.AddWithValue("@last_name", individual_last_name.Text);
                    cmd4.Parameters.AddWithValue("@contact_no", contact_no.Text);
                    cmd4.ExecuteNonQuery();
                    dbconnection1.Close();
                }
                else
                {
                    LabelErrorMessage.Visible = true;
                    LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                    LabelErrorMessage.Text = "Registration not sucessful!";
                    return;
                }
                dbconnection1.Close();
            }
            catch (Exception ex)
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                LabelErrorMessage.Text = "Registration not sucessful!" + ex.ToString();
                return;
            }
        }
    }
}