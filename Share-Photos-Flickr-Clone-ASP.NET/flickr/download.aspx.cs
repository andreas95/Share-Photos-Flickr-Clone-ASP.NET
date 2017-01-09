using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params.AllKeys.Contains<string>("filename"))
        {
            string filename = Request.Params.Get("filename");
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=picture.jpg");
            Response.TransmitFile(Server.MapPath(filename));
            Response.End();
        } else
        {
            Response.Redirect("Default.aspx");
        }
    }
}