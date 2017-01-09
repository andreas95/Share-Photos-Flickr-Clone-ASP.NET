using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using md5hash;
using System.Text.RegularExpressions;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Register_User(object sender, EventArgs e)
    {
        string md5_hash = md5.CalculateMD5Hash(password.Text);

        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Insert_User"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", username.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", md5_hash);
                    string secret = System.Web.Security.Membership.GeneratePassword(30, 0);
                    string secret2 = Regex.Replace(secret, @"[^a-zA-Z0-9]", m => "9" );
                    cmd.Parameters.AddWithValue("@Secret", secret2);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            string message = string.Empty;
            switch (userId)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                case -2:
                    message = "Email address has already been used.";
                    break;
                default:
                    message = "You have registered successfully.";
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}