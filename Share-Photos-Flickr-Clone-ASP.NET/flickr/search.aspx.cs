using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitePhotos;

public partial class search : System.Web.UI.Page
{
    public Photos[] allPhotos = null;
    public string text;
    protected void Page_Load(object sender, EventArgs e)
    {
         text = Request.Params.Get("text");
        if (text != "" || text != null)
        {
            allPhotos = Photos.search(text);
        }
    }
}