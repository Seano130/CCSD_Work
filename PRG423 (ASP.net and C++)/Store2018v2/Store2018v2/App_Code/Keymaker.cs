using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;



public class Keymaker
{

    protected string connStr = @"Data Source=DESKTOP-ABPPNGK\SQLEXPRESS;Initial Catalog=Store2018;Integrated Security=True";
    
    //protected string connStr = @"Data source = den1.mssq14.gear.host; Database=store2018; User ID=Store2018; Password ";
    public Keymaker()
    {
       
        
    }

    public bool AddProduct(Product newP)
    {
        using (SqlConnection conn = new SqlConnection(connStr)) // USING statement properlly disposes of objects that are related to resources once the connection is closed
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "select ID from Product where " + newP.ID.ToString() + ";";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    { // we already HAVE this ID in DB
                        
                        return false;
                    }
                }
                query = "insert into Products values (" + newP.ID.ToString() + ", '" + newP.Mfg + "','" + newP.Mfg
                    + "','" + newP.Model + "','" + "','" + newP.Part + "','" + newP.Description + "','" + newP.Image
                    + "'," + newP.Price + ");";

                cmd = new SqlCommand();
            }
            
        }
        return true;

    }

    public bool UpdateProduct(Product newP)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                string query = "Update Product Set Mfr = '" + newP.Mfg
                    + "',Model = '" + newP.Model
                    + "',Part = '" + newP.Part
                    + "',Description = '" + newP.Description
                    + "', Image = '" + newP.Image
                    + "', Price = " + newP.Price
                    + "' ID = " + newP.ID + ";";





            }
        }
    }


    public Product GetProductChoice(int id)
    {
        Product p = null;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                string query = "select * from Product where ID = "
                    + id + ";";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        string mfg = (string)rdr["Mfg"];
                        string model = (string)rdr["Model"];
                        string part = (string)rdr["Part"];
                        string desc = (string)rdr["Description"];
                        string imgFile = (string)rdr["Image"];
                        decimal price = (decimal)rdr["Price"];
                        p = new Product(id, mfg, model, part, desc, imgFile, price);
                    }
                }
            }
        }

        return p;
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
                        decimal price = (decimal)rdr["Price"];
                        Product p = new Product(id, mfg, model, part, desc, imgFile, price);
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