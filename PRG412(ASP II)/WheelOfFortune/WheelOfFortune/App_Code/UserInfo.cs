using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public enum Level
{
    Easy, Medium, Hard, Nightmare
}


public class UserInfo
{
    public string Username;
    public Level Difficulty;
    
}