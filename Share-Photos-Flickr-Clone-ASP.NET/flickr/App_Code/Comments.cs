using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for Comments
/// </summary>
namespace SiteComments
{
    public class Comments
    {
    	private int id_comment;
    	private string text;
    	private int id_user;
    	private int id_photo;
    	private int status;
    	private DateTime date_added;

        public Comments(int id_comment, string text, int id_user, int id_photo, int status, DateTime date_added)
        {
        	this.id_comment=id_comment;
        	this.text=text;
        	this.id_user=id_user;
        	this.id_photo=id_photo;
        	this.status=status;
        	this.date_added=date_added;
        }

    	public Comments(string text, int id_user, int id_photo)
        {
        	this.text=text;
        	this.id_user=id_user;
        	this.id_photo=id_photo;
        }

        public int getId_commnet() { return id_comment;}
        public string getText() { return text; }
        public int getId_user() { return id_user; }
        public int getId_photo() { return id_photo; }
        public int getStatus() { return status; }
        public DateTime getDate_added() { return date_added; }

        public static Comments[] getAllComments(int id) {
 			ArrayList temp = new ArrayList();
             string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "SELECT * FROM comment WHERE ID_PHOTO="+id.ToString()+" ORDER BY ID_COMMENT DESC";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read()) {
                            	int id_comment = int.Parse(sdr["ID_COMMENT"].ToString());
                            	string text = sdr["TEXT"].ToString();
                            	int id_user = int.Parse(sdr["ID_USER"].ToString());
                            	int id_photo = int.Parse(sdr["ID_PHOTO"].ToString());
								int status = int.Parse(sdr["STATUS"].ToString());
								DateTime date_added = DateTime.Parse(sdr["DATE_ADDED"].ToString());
                                DateTime dateadded = DateTime.Parse(sdr["DATE_ADDED"].ToString());
                                temp.Add(new Comments(id_comment, text, id_user, id_photo, status, date_added));
                        }
                       }
                        con.Close();
                    }
                }
            return (Comments[])temp.ToArray(typeof(Comments));
        }

        public static bool addComment(Comments c) {
        	int rowsAffected = 0;
        	string query = "INSERT INTO comment (TEXT, ID_USER, ID_PHOTO, DATE_ADDED) VALUES (@Text, @IdUser, @IdPhoto, @DateAdded)";
        	string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        	using (SqlConnection con = new SqlConnection(constr))
            {
	            using (SqlCommand cmd = new SqlCommand(query))
	            {
	                cmd.Connection = con;
	                cmd.Parameters.AddWithValue("@Text", c.getText());
	                cmd.Parameters.AddWithValue("@IdUser", c.getId_user());
	                cmd.Parameters.AddWithValue("@IdPhoto", c.getId_photo());
	                DateTime today = DateTime.Today;
	                cmd.Parameters.AddWithValue("@DateAdded",  today.ToString());
	                con.Open();
	                rowsAffected = cmd.ExecuteNonQuery();
	                con.Close();
	            }
	             if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
	        }
        }

        public static bool deleteComment(int id) {
            int rowsAffected = 0;
            string query = "DELETE FROM [comment] WHERE [ID_COMMENT] = @IdComment";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@IdComment", id);
                        cmd.Connection = con;
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool acceptComment(int id) {
            int rowsAffected = 0;
            string query = "UPDATE [comment] SET [status] = 1 WHERE [ID_COMMENT] = @IdComment";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@IdComment", id);
                        cmd.Connection = con;
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}