using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using md5hash;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Login_User(object sender, EventArgs e)
    {
        string md5_hash = md5.CalculateMD5Hash(inputPassword.Text);
        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Login_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", inputUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", md5_hash);
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            switch (userId)
            {
                case -1:
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Username and/or password is incorrect." + "');", true);
                    break;
                default:
                    //Response.Redirect("Default.aspx");
                    FormsAuthentication.RedirectFromLoginPage(inputUsername.Text, inputRememberMe.Checked);
                    break;
            }
        }
    }
}