using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace AirlineSurveys2
{
    public partial class Survey : System.Web.UI.Page
    {
        private MySqlConnection cnx;

        protected void Page_Load(object sender, EventArgs e)
        {

            String s = @"Data Source=localhost; Database=flights; Id=rootl; Password="";SSL Mode=None";
            cnx = new MySqlConnection(s);
            try
            {
                cnx.Open();
            }
            catch (Exception ex)
            {

                Console.Write("Error while opening the connection - Reason = ", ex.Message);
                return;

            }


        }
    }
}