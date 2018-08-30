using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { //Phase A
        if(!IsPostBack)
        {
            ddlDiff.Items.Add(""); // 1st item blank to prevent auto selection
            ddlDiff.Items.Add("Easy");
            ddlDiff.Items.Add("Medium");
            ddlDiff.Items.Add("Hard");
            ddlDiff.Items.Add("Nightmare");


        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    { // Phase B
        if(tbUser.Text.Length > 0)
        {
            if (ddlDiff.SelectedIndex > 0)
            {
                UserInfo ui = new UserInfo();
                ui.Username = tbUser.Text; // grab whatever bane they typed
                if(ddlDiff.SelectedIndex == 1)
                { // assign a difficulty based on what they selected in DDL
                    ui.Difficulty = Level.Easy;

                }
                else if(ddlDiff.SelectedIndex == 2)
                {
                    ui.Difficulty = Level.Medium;
                }
                else if (ddlDiff.SelectedIndex == 3)
                {
                    ui.Difficulty = Level.Hard;

                }
                else
                {
                    ui.Difficulty = Level.Nightmare;

                }
                Session["user"] = ui; // log them into Session
                Response.Redirect("Game.aspx"); // send them to Game Page
            }
        }

    }

    protected void tbUser_TextChanged(object sender, EventArgs e)
    { // Phase B
        // nothing needed here for now
    }


    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
        btnLogin.Visible = false; // hide Login btn initially
        if (tbUser.Text.Length > 0)
        {
            if (ddlDiff.SelectedIndex > 0)
            {
                btnLogin.Visible = true; // show only if name and difficulty exist
            }
        }

    }



    
}