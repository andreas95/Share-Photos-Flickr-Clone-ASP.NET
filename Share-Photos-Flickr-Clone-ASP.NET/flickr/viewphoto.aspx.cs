using System;
using System.Linq;
using SitePhotos;
using SiteUser;
using SiteComments;

public partial class viewphoto : System.Web.UI.Page
{
    public int photoId;
    public string picture;
    public string description;
    public bool candelete;
    public Comments[] allComments = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params.AllKeys.Contains<string>("id"))
        {

            photoId = int.Parse(Request.Params.Get("id"));
            try
            {
                picture = "Photos/" + Photos.getPicture(photoId);
                description = Photos.getDescription(photoId);
                allComments = Comments.getAllComments(photoId);
                if (!Users.getUserType(System.Web.HttpContext.Current.User.Identity.Name).Equals("user")) {
                    candelete=true;
                    } else if (Photos.getUserId(photoId) == Users.getUserId(System.Web.HttpContext.Current.User.Identity.Name)) {
                            candelete=true;
                        } else {
                            candelete=false;
                        }
                  
            }
            catch (Exception ex)
            {
                Response.Redirect("Default.aspx");
            }

        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Add_Comment(object sender, EventArgs e) {
        Comments.addComment(new Comments(inputComment.Text, Users.getUserId(System.Web.HttpContext.Current.User.Identity.Name), photoId));
        Response.Redirect("viewphoto.aspx?id="+photoId.ToString());
    }
}