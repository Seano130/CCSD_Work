using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class UserInfo
{
    public string Username;
    public string Password;
    public string First, Last, Email;
    public int Age;
    public bool IsMale;
    public AdminRights Rights;


    public UserInfo(string user, string pass, string first, string last, string email, int age, bool male, AdminRights rights)
    {
        Username = user;
        Password = pass;
        First = first;
        Last = last;
        Age = age;
        IsMale = male;
        Rights = rights;
        
    }
}