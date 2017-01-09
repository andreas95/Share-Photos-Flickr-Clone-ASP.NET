using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteUser;

public partial class moderator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        } else if (!Users.getUserType(System.Web.HttpContext.Current.User.Identity.Name).Equals("admin")) {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Add_Moderator(object sender, EventArgs e)
    {
        if (Users.addModerator(inputName.Text)) {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "User type has been changed successfully" + "');", true);
            } else {
                 ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "User does not exist in our database." + "');", true);
            }
    }
}