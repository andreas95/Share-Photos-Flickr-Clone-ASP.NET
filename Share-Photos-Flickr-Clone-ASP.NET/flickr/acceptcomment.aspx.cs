using System;
using System.Linq;
using SitePhotos;
using SiteUser;
using SiteComments;

public partial class acceptcomment : System.Web.UI.Page
{
public int commentId;
    public int photoId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("Default.aspx");
        }
        else {
            if (Request.Params.AllKeys.Contains<string>("comment"))
            {
                commentId = int.Parse(Request.Params.Get("comment"));
            }
            else
            {
                Response.Redirect("browse.aspx");
            }
            if (Request.Params.AllKeys.Contains<string>("photo"))
            {
                photoId = int.Parse(Request.Params.Get("photo"));
            }
            else
            {
                Response.Redirect("browse.aspx");
            }
        }
        if (!Users.getUserType(System.Web.HttpContext.Current.User.Identity.Name).Equals("user") || (Photos.getUserId(photoId) == Users.getUserId(System.Web.HttpContext.Current.User.Identity.Name)))
        {
            Comments.acceptComment(commentId);
            Response.Redirect("viewphoto.aspx?id=" + photoId.ToString());
        }
    }
}