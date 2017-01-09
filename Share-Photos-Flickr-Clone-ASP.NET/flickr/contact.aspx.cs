using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Send_Email(object sender, EventArgs e)
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
        msg.From = new MailAddress(contactEmail.Text.Trim());
        msg.To.Add(new MailAddress("andreas.antone@my.fmi.unibuc.ro"));

        msg.Subject = contactName.Text+" Contacted you on Flickr";
        msg.IsBodyHtml = true;
        msg.Body = string.Format("<html><head></head><body><b>"+contactMessage.Text+"</b><br /><br /><b>Email: "+contactEmail.Text+"</b></body>");

        try
        {
            client.Send(msg);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Your message has been successfully sent." + "');", true);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Error occured while sending your message." + "');", true);
        }
    }
}