using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                Session["ID"] = null;
                Session["UserType"] = null;
                Session["Email"] = null;

                Response.Redirect("LogIn.aspx");
            }
               
        }
    }
}