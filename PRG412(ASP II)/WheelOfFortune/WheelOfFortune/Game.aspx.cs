using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Game : System.Web.UI.Page
{
    private string[] words = { "Michael", "Justin", "Strawberry", "Blonde", "Kraeer", "Henderson", "Greer", "CCSD", "USMC", "Army", "Navy", "Chair Force"
                             , "Denver", "Broncos", "Foti", "Fudge", "Packers", "Wounded", "Warrior", "Everywhere", "Green", "Lantern", "Business", "suit",
                             "Tshirt", "Pants", "Dinosaur", "Apple", "IWatch", "Inconceivable", "Ipod", "maxipad", "Ipad", "Iphone", "Class", "Orange", "Juice",
                             "Network", "Security", "Guide", "Information", "Marriage", "Kid", "Visual", "Studio", "tie", "glitch", "hand", "penis", "sky",
                             "Vanilla", "coconut", "back", "broken", "disability", "rack", "spoken", "lie", "band", "orange", "apple", "strawberry", "blueberry", "peach",
                             "banana", "watermelon", "melon", "onion", "dance", "parfait", "zucchini", "pea", "soy", "sauce", "carrot", "shrimp", "pepper", "salt",
                             "rice", "noodle", "spaghetti", "red", "marinara", "alfredo"};


    protected void Page_Load(object sender, EventArgs e)
    {//Phase A
        if(Session["user"] == null)
        {//bouncer check
            Response.Redirect("Login.aspx");
        }

        if(!IsPostBack)
        {
            Random rand = new Random();
            int r = rand.Next(0, words.Length); // dice rolle a random index into the array of words
            GameInfo gi = new GameInfo();
            gi.Hidden = words[r]; // get me the hidden word
            tbHidden.Text = ""; // 1st clear out any previous word
            for(int i = 0; i < gi.Hidden.Length; i++ )
            { // add an * for every char in the hidden word
                tbHidden.Text += "*";
            }
            gi.TriesRemaining = 2 * gi.Hidden.Length; // allow twice as many chars for their tries
            Session["gameInfo"] = gi; // store game object in the Session
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {//Phase B
        Session["user"] = null;
        Response.Redirect("Login.aspx");

    }

    protected void btnGuess_Click(object sender, EventArgs e)
    {//Phase B
        if(tbGuessChar.Text.Length == 1)
        {
            char c = tbGuessChar.Text[0];
            GameInfo gi = (GameInfo)Session["gameInfo"];
            gi.Attempts.Add(c); // add the new attempted char to the list
            gi.TriesRemaining--; // decrement their tries by 1
            Session["gameInfo"] = gi; // put updated gameInfo object back into Session


        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {//Phase C
        UserInfo ui = (UserInfo)Session["user"];
        lblWelcome.Text = "Hello, " + ui.Username + "!";

        GameInfo gi = (GameInfo)Session["gameInfo"];
        lblTries.Text = "Tries remaining: " + gi.TriesRemaining;
        foreach(char c in gi.Attempts)
        {
            // add in all attempted chars...
            tbAlready.Text += c + ", ";
        }
    }
}