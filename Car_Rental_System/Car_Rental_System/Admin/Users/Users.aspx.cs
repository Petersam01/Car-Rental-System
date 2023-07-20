using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System.Admin.Users
{
    public partial class Users : System.Web.UI.Page
    {
        DataHandler data = new DataHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            userTable();
        }

        private void userTable()
        {
            string lines = "";
            foreach (User user in data.GetAllUsers())
            {
                lines += " <tr> ";
                lines += $" <td> {user.UserID} </td> ";
                lines += $" <td> {user.Name} </td> ";
                lines += $" <td> {user.Surname} </td> ";
                lines += $" <td> {user.IDNumber} </td> ";
                lines += $" <td> {user.LicenseNumber} </td> ";
                lines += $" <td> {user.Phone} </td> ";
                lines += $" <td> {user.Email} </td> ";
                lines += $" <td> {user.UserType} </td> ";
                lines += " <td> ";
                lines += " <span class='badge badge-complete'>Complete</span> ";
                lines += " </td> ";
                lines += " </tr> ";

            }
            loadUsers.InnerHtml = lines;
        }
    }
}