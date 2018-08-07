using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirlineSurveys2
{
    public partial class Tutorial : System.Web.UI.Page
    {

        protected void HandleClick(object sender, EventArgs e)
        {
            RadioButtonList lst = (RadioButtonList)sender;
            String criteria = lst.ID;
            String review = lst.SelectedItem.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<RadioButtonList> lst = new List<RadioButtonList>();
            lst.Add(R_cleanliness);
            lst.Add(R_friendly);
            lst.Add(R_noise);
            lst.Add(R_space);
            lst.Add(R_comfort);

            for(int i = 0; i < 5; i ++)
            {
                lst[i].Items.Add("No Opinion");
                lst[i].Items.Add("Poor");
                lst[i].Items.Add("Fair");
                lst[i].Items.Add("Good");
                lst[i].Items.Add("Excellent");

                lst[i].SelectedIndexChanged += new EventHandler(HandleClick);



            }




        }
    }
}