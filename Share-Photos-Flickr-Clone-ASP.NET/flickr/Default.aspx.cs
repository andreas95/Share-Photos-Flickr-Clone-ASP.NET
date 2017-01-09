using System;
using SitePhotos;

public partial class _Default : System.Web.UI.Page
{
    public Photos[] allPhotos = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        allPhotos = Photos.getAllPhotos();
    }
}