using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace SiteUser { 
public class Users
{
    public Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool addModerator(string user)
        {
        int rowsAffected = 0;
        string query = "UPDATE [users] SET [TYPE] = @Type WHERE [USERNAME] = @Username";
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Parameters.AddWithValue("@Username", user);
                    cmd.Parameters.AddWithValue("@Type", "moderator");
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

    public static int getUserId(string user) {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            int id=0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT USER_ID FROM users WHERE USERNAME='" + user + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            id = int.Parse(sdr["USER_ID"].ToString());
                        }
                    }
                    con.Close();
                }
            }
            return id;
    }

    public static string getUserType(string user)
        {
            string type = "";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT TYPE FROM users WHERE USERNAME='" + user + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            type = sdr["TYPE"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return type;
        }
}
}