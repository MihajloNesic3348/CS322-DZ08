using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS322_DZ08
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBConfig.Init();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFirstName.Text) && 
                !String.IsNullOrEmpty(txtLastName.Text) &&
                !String.IsNullOrEmpty(txtEmail.Text) &&
                !String.IsNullOrEmpty(txtEmailReenter.Text) &&
                !String.IsNullOrEmpty(txtPassword.Text))
            {
                if (txtEmail.Text == txtEmailReenter.Text)
                {
                    Application["FirstName"] = txtFirstName.Text;
                    Application["LastName"] = txtLastName.Text;
                    Application["Email"] = txtEmail.Text;
                    Application["Password"] = txtPassword.Text;

                    DBConfig.InsertUser(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text);

                    Response.Redirect("Result.aspx");
                }
            }
        }
    }
}