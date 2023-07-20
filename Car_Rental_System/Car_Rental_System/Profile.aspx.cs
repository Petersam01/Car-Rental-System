using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Car_Rental_System.Controllers;
using Car_Rental_System.Models;

namespace Car_Rental_System
{
    public partial class Profile : System.Web.UI.Page
    {
        DataHandler dh = new DataHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            getUser();
            getpic();
;        }
        private void getpic()
        {
            string lines2 = "";
            int ID = (int)Session["ID"];
            User user = dh.GetUsersById(ID);


            if (user == null)
            {
                Response.Redirect("/Home.aspx");

            }

             lines2 += $" <div class='d-flex flex-column align-items-center text-center p-3 py-5'><img class='rounded-circle mt-5' width='150px' src='https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg'><span class='font-weight-bold'>Email: </span><span class='text-black-50'>{user.Email}</span><span> </span></div> ";

            pic.InnerHtml = lines2;
        }
        private void getUser() 
        {
            string lines = "";
            int ID = (int)Session["ID"];
            User user = dh.GetUsersById(ID);


            if (user == null)
            {
                Response.Redirect("/Home.aspx");

            }
         
            lines += " <div class='p-3 py-5'> ";
            lines += " <div class='d-flex justify-content-between align-items-center mb-3'> ";
            lines += " <h4 class='text-right'>Profile</h4> ";
            lines += " </div> ";
            lines += $" <div class='col-md-12'><span class='font-weight-bold'>Name: </span><span class='text-black-50'>{user.Name}</span></div> ";
            lines += $" <div class='col-md-12'> <span class='font-weight-bold'>Surname: </span><span class='text-black-50'>{user.Surname}</span></div> ";
            lines += $" <div class='col-md-12'> <span class='font-weight-bold'>ID Number: </span><span class='text-black-50'>{user.IDNumber}</span></div> ";
            lines += $" <div class='col-md-12'> <span class='font-weight-bold'>Liense Number: </span><span class='text-black-50'>{user.LicenseNumber}</span></div> ";
            lines += $" <div class='col-md-12'> <span class='font-weight-bold'>Phone: </span><span class='text-black-50'>{user.Phone}</span></div> ";
            lines += $" <div class='col-md-12'> <span class='font-weight-bold'>Email: </span><span class='text-black-50'>{user.Email}</span></div> ";
            lines += $" <div class='col-md-12'> <span class='font-weight-bold'>Password: </span><span class='text-black-50'>{user.Password}</span></div> ";
           

            lines += " <div class='mt-5 text-center'><button class='btn btn-primary profile-button' type='button'>Edit Profile</button></div> ";
            lines += " </div> ";
            
            loadUsers.InnerHtml = lines;
        }
    }
}