using System;
using System.Data.SqlClient;
using System.Configuration;
using md5hash;

public partial class changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Change_Password(object sender, EventArgs e)
    {
        string hash_oldpass = md5.CalculateMD5Hash(OLDPASSWORD.Text.Trim());
        string hash_newpass = md5.CalculateMD5Hash(NEWPASSWORD.Text.Trim());
        int rowsAffected = 0;
        string query = "UPDATE [users] SET [PASSWORD] = @NewPassword WHERE [USERNAME] = @Username AND [PASSWORD] = @OldPassword";
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Parameters.AddWithValue("@Username", this.Page.User.Identity.Name);
                    cmd.Parameters.AddWithValue("@OldPassword", hash_oldpass);
                    cmd.Parameters.AddWithValue("@NewPassword", hash_newpass);
                    cmd.Connection = con;
                    con.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (rowsAffected > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Password has been changed successfully" + "');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Password does not match with our database records." + "');", true);
            }
        }
    }
}

