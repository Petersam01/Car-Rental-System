using Car_Rental_System.Admin.Cars;
using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System
{
    public partial class Rent : System.Web.UI.Page
    {
        DataHandler data = new DataHandler();
        Barky barky = new Barky();
        protected void Page_Load(object sender, EventArgs e)
        {
            //user session
            if (Session["ID"] == null)
            {
                Response.Redirect("/LogIn.aspx");
            }
           /* else 
            {
                int id2 = getBarkie();
                if (data.GetBarkieById(id2).Equals("Barkie"))
                {
                    Session["BarkieID"] = barky.Id;
                    Session["BarkieType"] = "Barkie";
                }
            }*/
            int userID = (int)Session["ID"];

            if (Session["BarkieID"] == null)
            {
                Response.Redirect("/LogIn.aspx");
            }
            int barkieID = (int)Session["BarkieID"];
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            string bookedDate = book.Value;
            string returnDate = returnDs.Value;

           
            string usertype = Request.QueryString["userType"];
            string cartype = (string)Session["BarkieType"];
            int id = (int)Session["BarkieID"];

            //  if (cartype.Equals("BarkieType") && usertype.Equals("userType"))
            //   {
            if (Session["BarkieID"] != null)
            {
                int userID = Convert.ToInt32(Session["ID"]);
                int barkieID = Convert.ToInt32(Session["BarkieID"]);
                data.BookBarkie(date, bookedDate, returnDate, userID, id);
                Response.Redirect("Barkie.aspx");
            }

        }

    }
}