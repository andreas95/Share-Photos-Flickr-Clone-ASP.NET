using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Net;
using System.Net.Mail;

public partial class recover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Recover(object sender, EventArgs e) {
    	 string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT USER_ID,SECRET FROM users WHERE EMAIL='" + email.Text + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                        	SmtpClient client = new SmtpClient();
					        client.DeliveryMethod = SmtpDeliveryMethod.Network;
					        client.EnableSsl = true;
					        client.Host = "smtp.gmail.com";
					        client.Port = 587;

					        // setup Smtp authentication
					        System.Net.NetworkCredential credentials =
					            new System.Net.NetworkCredential("andreas.antone@my.fmi.unibuc.ro", "PUT_YOUR_PASSWORD_HERE");
					        client.UseDefaultCredentials = false;
					        client.Credentials = credentials;

					        MailMessage msg = new MailMessage();
					        msg.From = new MailAddress("andreas.antone@my.fmi.unibuc.ro");
					        msg.To.Add(new MailAddress(email.Text));

					        msg.Subject = "Reset your password";
					        msg.IsBodyHtml = true;
					        string link = "http://localhost:64611/recover2.aspx?id="+sdr["USER_ID"].ToString()+"&secret="+sdr["SECRET"].ToString();
					        msg.Body = "<html><head></head><body><b>For reset your password please follow the below link:</b><br /><br /><b><a href='"+link+"' style='color:red;'>Click here</a></b></body>";

					        try
					        {
					            client.Send(msg);
					            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Your password has been successfully sent." + "');", true);
					        }
					        catch (Exception ex)
					        {
					            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Error occured while sending your password." + "');", true);
					        }
                        } else {
                        	ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "The email address do not exist in our database." + "');", true);
                        }
                    }
                    con.Close();
                }

            }
    }

}