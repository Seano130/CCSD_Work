using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;



public class Keymaker
{
    public Keymaker()
    {
       
        
    }

    public bool CheckUserExists(string user)
    {

    }

    public bool CheckPWMatches(string user, string pw)
    {

    }

    public UserInfo GetUser(string user)
    {
        UserInfo ui = null;
        using (SqlConnection conn = new SqlConnection())
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "select * from UserInfo where Username = '" + user + "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read() == true)
                    {
                        string first = (string)rdr["Username"];
                        string last = (string)rdr["Last"];
                        string email = (string)rdr["Email"];
                        int age = (int)rdr["Age"];
                        bool male = (bool)rdr["IsMale"];
                        string rights = (string)rdr["Rights"];
                        AdminRights ar;
                        Enum.TryParse(rights, out ar);
                        ui = new UserInfo(user, "", first, last, email, age, male, AdminRights.User);
                    }
                }
            }
        }
        return ui;
    }
}