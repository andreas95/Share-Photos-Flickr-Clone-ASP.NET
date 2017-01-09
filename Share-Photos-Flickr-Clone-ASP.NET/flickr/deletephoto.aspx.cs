using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitePhotos;
using SiteUser;

public partial class deletephoto : System.Web.UI.Page
{
    public int photoId;

    protected void Page_Load(object sender, EventArgs e)
    {
         if (!this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        } else {
            if (Request.Params.AllKeys.Contains<string>("id"))
            {
                 photoId = int.Parse(Request.Params.Get("id"));   
            }
            else
            {
                Response.Redirect("browse.aspx");
            }
    }
            if (!Users.getUserType(System.Web.HttpContext.Current.User.Identity.Name).Equals("user") || (Photos.getUserId(photoId) == Users.getUserId(System.Web.HttpContext.Current.User.Identity.Name))) {
                Photos.deletePhoto(photoId);
                Response.Redirect("browse.aspx");   
            }
    }
}