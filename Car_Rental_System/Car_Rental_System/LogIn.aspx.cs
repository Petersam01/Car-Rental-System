using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System
{
    public partial class LogIn : System.Web.UI.Page
    {
        DataHandler handler = new DataHandler();
        
        protected void Page_Load(object sender, EventArgs e)
        { 

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user = handler.UserLogin(email.Value, password.Value);
            AdminRent admin = handler.AdminLogin(email.Value, password.Value);
            Barky barky = new Barky();

            if (user != null)
            {
               
                int id = getID(user.Email);
                if (handler.GetUserTypeById(id).Equals("Client"))
                {
                    Session["UserType"] = handler.GetUserTypeById(id);
                    Session["Email"] = email.Value;
                    Session["ID"] = id;
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Login Failed. Wrong Username or Password !!!');", true);
            }
            



            bool isAuthenticated = handler.Authenticate(email.Value, password.Value);

            if (handler.Authenticate(email.Value, password.Value))
            {
                if (isAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(email.Value, false);

                    if (admin != null)
                    {
                        int id1 = getAdminID(admin.Email);
                        if (handler.GetAdminTypeById(id1).Equals("Admin"))
                        {
                            Session["Email"] = email.Value;
                            Session["AdminID"] = id1;
                            Session["AdminType"] = "Admin";
                            Response.Redirect("/Admin/Dashboard.aspx");
                        }


                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Login Failed. Wrong Username or Password !!!');", true);
                    }
                }

                FormsAuthentication.RedirectFromLoginPage(email.Value, isAuthenticated);
            }
            else
            {
                Response.Redirect("Invalid email or password.");
            }


           /* <authentication mode="Forms">
          <forms loginUrl="Home" timeout="2880" />
        </authentication>
        <authorization>
          <deny users="?" />
        </authorization>

         */
        }

        private int getID(String email)
        {
            int ID = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT UserID FROM Users WHERE Email='" + email + "'" , sqlCon);

            var num = sqlcmd.ExecuteScalar();

            ID = (int)num;



            return ID;

        }

        private int getAdminID(String email)
        {
            int ID = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT AdminID FROM Admins WHERE Email='" + email + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            ID = (int)num;



            return ID;

        }

       

    }
}