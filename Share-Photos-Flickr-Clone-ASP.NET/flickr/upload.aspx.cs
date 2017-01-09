using System;
using System.Web.Security;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using SiteUser;

public partial class upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }

        int count=0;
        AlbumsList.Items.Insert(count++, new ListItem("---- None selected ----", "none"));
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            string query = "SELECT ID_ALBUM,NAME FROM album ORDER BY ID_ALBUM DESC";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read()) {
                        int temp = Convert.ToInt32(sdr["ID_ALBUM"]);
                        AlbumsList.Items.Insert(count++, new ListItem(sdr["NAME"].ToString(), temp.ToString()));
                }
                }
                con.Close();
            }
        }
    }

    protected void upload_photo(object sender, EventArgs e)
    {
        if (!AlbumsList.SelectedValue.Equals("none")) {
         string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        int photoID = 0;
         using (SqlConnection con = new SqlConnection(constr))
        {
            string query = "SELECT TOP 1 ID_PHOTO FROM photo ORDER BY ID_PHOTO DESC";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read()) {
                       photoID = Convert.ToInt32(sdr["ID_PHOTO"]);
                }
                }
                con.Close();
            }
        }
        
        string photoName = "photo_"+photoID.ToString()+".jpg";

        string folderPath = Server.MapPath("~/Photos/");

        //Check whether Directory (Folder) exists.
        if (!Directory.Exists(folderPath))
        {
            //If Directory (Folder) does not exists. Create it.
            Directory.CreateDirectory(folderPath);
        }

        //Save the File to the Directory (Folder).
        FileUpload1.SaveAs(folderPath + Path.GetFileName(photoName));

       
        using (SqlConnection con = new SqlConnection(constr))
        {
            string query = "INSERT INTO photo VALUES (@IdAlbum, @IdUser, @Photo, @Description, @Facebook, @Twitter, @Date)";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@IdAlbum", AlbumsList.SelectedValue);
                cmd.Parameters.AddWithValue("@IdUser", Users.getUserId(System.Web.HttpContext.Current.User.Identity.Name));
                cmd.Parameters.AddWithValue("@Photo", photoName);
                cmd.Parameters.AddWithValue("@Description", inputDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Facebook", inputFacebook.Text.Trim());
                cmd.Parameters.AddWithValue("@Twitter", inputTwitter.Text.Trim());
                DateTime today = DateTime.Today;
                cmd.Parameters.AddWithValue("@Date",  today.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


            //Display the success message.
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "The photo has been uploaded!" + "'); window.location='" +
"upload.aspx';", true);
        } else {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" +"Selected album does not exist!" + "'); window.location='" +
  "upload.aspx';", true);
        }
    }
}