using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System
{
    public partial class Rental : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // int ID = (int)Session["ID"];
            if (Session["ID"] != null)
            {
                if ((string)Session["UserType"] == "Client")
                {
                    login.Visible = false;
                    register.Visible = false;
                    profile.Visible = true;
                    logout.Visible = true;

                }

            }
            if (Session["ID"] == null) 
            {
                profile.Visible = false;
                logout.Visible = false;
            }
        }


       
    }
}