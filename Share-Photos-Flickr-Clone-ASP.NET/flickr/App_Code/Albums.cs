using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using SitePhotos;

/// <summary>
/// Summary description for Albums
/// </summary>
/// 
namespace SiteAlbums
{
    public class Albums
    {
        private int ID_ALBUM;
        private string NAME;
        public Albums(int ID_ALBUM, string NAME)
        {
            this.NAME = NAME;
            this.ID_ALBUM = ID_ALBUM;
        }

        public int getID_ALBUM() { return ID_ALBUM; }
        public string getNAME() { return NAME; }

        public string getLastPhoto()
        {
           return Photos.getAlbumLastPhoto(getID_ALBUM());
        }
        public static Albums[] getAllAlbums()
        {
            ArrayList temp = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM album ORDER BY ID_ALBUM DESC";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            int id = int.Parse(sdr["ID_ALBUM"].ToString());
                            string name = sdr["NAME"].ToString();
                            temp.Add(new Albums(id, name));
                        }
                    }
                    con.Close();
                }
            }
            return (Albums[])temp.ToArray(typeof(Albums));
        }
        public static string getAlbum(int id)
        {
            string name = "";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT NAME FROM album WHERE ID_ALBUM='" +id.ToString() + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            name = sdr["NAME"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return name;
        }
    }
}