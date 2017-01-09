using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitePhotos;

public partial class album : System.Web.UI.Page
{
    public Photos[] allPhotos = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params.AllKeys.Contains<string>("id"))
        {

            int albumId = int.Parse(Request.Params.Get("id"));
            try
            {
                allPhotos = Photos.getAllPhotosFromAlbum(albumId);
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
}