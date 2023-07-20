using Car_Rental_System.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Car_Rental_System.Models;
using Car_Rental_System.Controllers;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Car_Rental_System
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


             if (db.CheckIfEmailExists(email.Value) == false)
             {
                User newUser = new User(name.Value, surname.Value, idno.Value, license.Value,
                               phone.Value, email.Value,"Client", password.Value);

                db.CreateUser(newUser);
                 Response.Redirect("LogIn.aspx");
             }
             else
             {
                 //i dont know what to do or display if the user exists
                // Response.Write("User already exists");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Sign Up Failed. email aready exist try loging in!!!');", true);
            }


        }
    }
}