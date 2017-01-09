using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteUser;

public partial class Site : System.Web.UI.MasterPage
{
    public bool admin;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Users.getUserType(System.Web.HttpContext.Current.User.Identity.Name).Equals("admin"))
        {
            admin = true;
        } else
        {
            admin = false;
        }
    }
}
