using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public enum Level
{
    Easy, Medium, Hard, Hell
}

public class GameInfo
{
    public string Hidden;
    public List<char> Attempts = new List<char>();
    public int TriesRemaining;
    public Level Difficulty;
   
}