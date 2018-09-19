using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;



public class Keymaker
{

    protected string connStr = @"Data Source=DESKTOP-ABPPNGK\SQLEXPRESS;Initial Catalog=Store2018;Integrated Security=True";


    public Keymaker()
    {
       
        
    }

    public bool CheckUserExists(string user)
    {
        bool userExists = false;
        using (SqlConnection conn = new SqlConnection(connStr))
        {

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "select Username from UserInfo where Username = '" + user + "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        // found the user...
                        userExists = true;
                    }                
                }
            }
        }
        return userExists;

    }

    public bool CheckPWMatches(string user, string pw)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open(); // Attempt to open the door 
            if(conn.State == ConnectionState.Open)
            {
                string query = "select Password from UserInfo where Username = '" + user + "';";

                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    { // user was found, so now check PW match...
                        string pwFromDB = (string)rdr["Password"];
                        if (pwFromDB == pw)
                        { // if pw matches DB, then return true
                            return true;
                        }                       
                    }
                }
            }
        }
        return false; // by default, return false;
    }

    public UserInfo GetUser(string user)
    {
        UserInfo ui = null;
        using (SqlConnection conn = new SqlConnection(connStr))
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
                        string first = (string)rdr["First"];
                        string last = (string)rdr["Last"];
                        string email = (string)rdr["Email"];
                        int age = (int)rdr["Age"];
                        bool male = (bool)rdr["IsMale"];
                        string rights = (string)rdr["AdminLevel"];
                        AdminRights ar;
                        Enum.TryParse(rights, out ar);
                        ui = new UserInfo(user, "", first, last, email, age, male, AdminRights.User);
                    }
                }
            }
        }
        return ui;
    }

    public List<Product> GetAllProducts()
    {
        List<Product> allProdsFound = new List<Product>();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                string query = "select * from Product;";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        int id = (int)rdr["ID"];
                        string mfg = (string)rdr["Mfg"];
                        string model = (string)rdr["Model"];
                        string part = (string)rdr["Part"];
                        string desc = (string)rdr["Description"];
                        string imgFile = (string)rdr["Image"];
                        Product p = new Product(id, mfg, model, part, desc, imgFile);
                        allProdsFound.Add(p);
                    }
                }
            }
        }
        return allProdsFound;
    }



    public void CreateNewUser(UserInfo ui)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                int isMale;
                if(ui.IsMale == true)
                {
                    isMale = 1;
                }
                else
                {
                    isMale = 0;
                }
                string query = "insert into UserInfo values ('" + ui.Username + "','" + ui.Password + "','"
                    + ui.First + "','" + ui.Last + "','" + ui.Email + "'," + "," + ui.Age + "," + isMale + ",'" + ui.Rights.ToString() + "');";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery(); // execute the command
            }

        }

    }




}