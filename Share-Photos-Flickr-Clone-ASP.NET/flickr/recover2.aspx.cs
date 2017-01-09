using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Linq;
using md5hash;
using System.Text.RegularExpressions;

public partial class recover2 : System.Web.UI.Page
{
	public int id;
	public string secret;
	public string msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        } else {
        	if (Request.Params.AllKeys.Contains<string>("id"))
            {
                id = int.Parse(Request.Params.Get("id"));
            }
            else
            {
                Response.Redirect("recover.aspx");
            }
            if (Request.Params.AllKeys.Contains<string>("secret"))
            {
            	secret = Request.Params.Get("secret");
            }
            else
            {
                Response.Redirect("recover.aspx");
            }

			string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM users WHERE USER_ID="+id.ToString()+" AND SECRET='"+secret+"'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            con.Close();
                        	string new_password = System.Web.Security.Membership.GeneratePassword(15, 1);
							string new_password_hash = md5.CalculateMD5Hash(new_password);
							string new_secret = System.Web.Security.Membership.GeneratePassword(30, 0);
                    		string new_secret2 = Regex.Replace(new_secret, @"[^a-zA-Z0-9]", m => "9" );
                        	msg="Your new password is: <b style='color:red;'>"+new_password;
                        	query = "UPDATE [users] SET [PASSWORD] = @Password, [SECRET] = @Secret WHERE USER_ID=@Userid";
                        	using (SqlCommand cmd2 = new SqlCommand(query))
                        	{
								cmd2.Parameters.AddWithValue("@Password", new_password_hash);
								cmd2.Parameters.AddWithValue("@Secret", new_secret2);
								cmd2.Parameters.AddWithValue("@Userid", id);
		                        cmd2.Connection = con;
		                        con.Open();
		                        cmd2.ExecuteNonQuery();
		                        con.Close();
                        	}
                        } else {
                        	msg="Not found :(";
                        }
                    }
                }
            }
        }
    }
}