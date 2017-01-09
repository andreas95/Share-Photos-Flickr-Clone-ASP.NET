using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using SiteAlbums;

/// <summary>
/// Summary description for Photos
/// </summary>
/// 

namespace SitePhotos
{
    public class Photos
    {
        private int ID_PHOTO;
        private int ID_ALBUM;
        private int ID_USER;
        private string PHOTO;
        private string DESCRIPTION;
        private string FACEBOOK;
        private string TWITTER;
        private DateTime DATE_ADDED;

        public Photos(int id)
        {
            //todo
        }

        public Photos(int ID_PHOTO, int ID_ALBUM, int ID_USER, string PHOTO, string DESCRIPTION, string FACEBOOK, string TWITTER, DateTime DATE_ADDED)
        {
            this.ID_PHOTO = ID_PHOTO;
            this.ID_ALBUM = ID_ALBUM;
            this.ID_USER= ID_USER;
            this.PHOTO = PHOTO;
            this.DESCRIPTION = DESCRIPTION;
            this.FACEBOOK = FACEBOOK;
            this.TWITTER = TWITTER;
            this.DATE_ADDED = DATE_ADDED;
        }

        public int getID_PHOTO() {return ID_PHOTO;}
        public int getID_ALBUM() {return ID_ALBUM;}
        public int getID_USER() {return ID_USER;}

        public string getALBUMNAME()
        {
            return Albums.getAlbum(getID_ALBUM());
        }
        public string getPHOTO() {return PHOTO;}
        public string getDESCRIPTION() {return DESCRIPTION;}
        public string getFACEBOOK() {return FACEBOOK;}
        public string getTWITTER() {return TWITTER;}
        public DateTime getDATE_ADDED() {return DATE_ADDED;}

        public static string getPicture(int id)
        {
            string name = "";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT PHOTO FROM photo WHERE ID_PHOTO='" + id.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            name = sdr["PHOTO"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return name;
        }

        public static string getAlbumLastPhoto(int id)
        {
            string name = "";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT PHOTO FROM photo WHERE ID_ALBUM='" + id.ToString() + "' ORDER BY ID_PHOTO DESC";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            name = sdr["PHOTO"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return name;
        }
    public static string getDescription(int id)
        {
            string name = "";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT DESCRIPTION FROM photo WHERE ID_PHOTO='" + id.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            name = sdr["DESCRIPTION"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return name;
        }


        public static Photos[] getAllPhotos()
        {
            ArrayList temp = new ArrayList();
             string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "SELECT * FROM photo ORDER BY ID_PHOTO DESC";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read()) {
                               int id = int.Parse(sdr["ID_PHOTO"].ToString());
                               int idAlbum = int.Parse(sdr["ID_ALBUM"].ToString());
                               int idUser = int.Parse(sdr["ID_USER"].ToString());
                               string photo = sdr["PHOTO"].ToString();
                               string description = sdr["DESCRIPTION"].ToString();
                               string facebook = sdr["LINK_FACEBOOK"].ToString();
                               string twitter = sdr["LINK_TWITTER"].ToString();
                               DateTime dateadded = DateTime.Parse(sdr["DATE_ADDED"].ToString());
                               temp.Add(new Photos(id,idAlbum, idUser, photo, description, facebook, twitter, dateadded));
                        }
                        }
                        con.Close();
                    }
                }
            return (Photos[])temp.ToArray(typeof(Photos));
        }

        public static Photos[] getAllPhotosFromAlbum(int idAlb)
        {
            ArrayList temp = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM photo WHERE ID_ALBUM='"+idAlb+"' ORDER BY ID_PHOTO DESC";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            int id = int.Parse(sdr["ID_PHOTO"].ToString());
                            int idAlbum = int.Parse(sdr["ID_ALBUM"].ToString());
                            int idUser = int.Parse(sdr["ID_USER"].ToString());
                            string photo = sdr["PHOTO"].ToString();
                            string description = sdr["DESCRIPTION"].ToString();
                            string facebook = sdr["LINK_FACEBOOK"].ToString();
                            string twitter = sdr["LINK_TWITTER"].ToString();
                            DateTime dateadded = DateTime.Parse(sdr["DATE_ADDED"].ToString());
                            temp.Add(new Photos(id, idAlbum,idUser, photo, description, facebook, twitter, dateadded));
                        }
                    }
                    con.Close();
                }
            }
            return (Photos[])temp.ToArray(typeof(Photos));
        }
        public static Photos[] search(string text) {
            ArrayList temp = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM photo WHERE DESCRIPTION LIKE '%"+text+"%' ORDER BY ID_PHOTO DESC";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            int id = int.Parse(sdr["ID_PHOTO"].ToString());
                            int idAlbum = int.Parse(sdr["ID_ALBUM"].ToString());
                            int idUser = int.Parse(sdr["ID_USER"].ToString());
                            string photo = sdr["PHOTO"].ToString();
                            string description = sdr["DESCRIPTION"].ToString();
                            string facebook = sdr["LINK_FACEBOOK"].ToString();
                            string twitter = sdr["LINK_TWITTER"].ToString();
                            DateTime dateadded = DateTime.Parse(sdr["DATE_ADDED"].ToString());
                            temp.Add(new Photos(id, idAlbum,idUser, photo, description, facebook, twitter, dateadded));
                        }
                    }
                    con.Close();
                }
            }
            return (Photos[])temp.ToArray(typeof(Photos));
        }

        public static int getUserId(int id) {
            int userid=0;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT ID_USER FROM photo WHERE ID_PHOTO='" + id.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            userid = int.Parse(sdr["ID_USER"].ToString());
                        }
                    }
                    con.Close();
                }
            }
            return userid;
        }

        public static bool deletePhoto(int id)
        {
            int rowsAffected = 0;
            string query = "DELETE FROM [photo] WHERE [ID_PHOTO] = @IdPhoto";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@IdPhoto", id);
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