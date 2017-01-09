using System;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;

public partial class newalbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
    }

    protected void Create_Album(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        bool exist=false;
        using (SqlConnection con = new SqlConnection(constr))
        {
            string query = "SELECT * FROM album WHERE NAME='"+inputAlbum.Text.Trim()+"'";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read()) {
                       exist=true;
                }
                }
                con.Close();
            }
        }
        if (exist) {
        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" +"The album already exist!" + "');", true);
        }  else {
        int userID = 0;
         using (SqlConnection con = new SqlConnection(constr))
        {
            string query = "SELECT USER_ID FROM users WHERE NAME='"+this.Page.User.Identity.Name+"'";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read()) {
                       userID = Convert.ToInt32(sdr["USER_ID"]);
                }
                }
                con.Close();
            }
        }
         using (SqlConnection con = new SqlConnection(constr))
        {
            string query = "INSERT INTO album VALUES (@Name, @UserId)";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Name", inputAlbum.Text.Trim());
                cmd.Parameters.AddWithValue("@UserId", userID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Display the success message.
        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" +"The album has been created!" + "');", true);
    }
    }
}