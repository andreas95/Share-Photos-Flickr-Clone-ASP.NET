using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteAlbums;
public partial class browse : System.Web.UI.Page
{
    public Albums[] allAlbums = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        allAlbums = Albums.getAllAlbums();
    }
}