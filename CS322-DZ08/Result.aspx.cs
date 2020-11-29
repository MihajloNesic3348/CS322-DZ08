using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS322_DZ08
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowInfo()
        {
            string firstName = Application["FirstName"].ToString();
            string lastName = Application["LastName"].ToString();
            string email = Application["Email"].ToString();

            Response.Write(firstName + " " + lastName + " - " + email);
        }
    }
}