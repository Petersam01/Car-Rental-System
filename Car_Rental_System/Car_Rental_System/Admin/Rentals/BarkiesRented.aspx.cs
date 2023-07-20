using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System.Admin.Rentals
{
    public partial class BarkiesRented : System.Web.UI.Page
    {
        DataHandler data = new DataHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            barkieRented();
        }

        private void barkieRented()
        {
            string lines = "";
            foreach (BarkieRent barky in data.getBKBookings())
            {
                lines += " <tr> ";
                lines += $" <td> {barky.BookingID} </td> ";
                lines += $" <td> {barky.CurrentDate} </td> ";
                lines += $" <td> {barky.Booking_date} </td> ";
                lines += $" <td> {barky.Return_date} </td> ";
                lines += $" <td> {barky.isApproved} </td> ";
                lines += $" <td> {barky.UserID} </td> ";
                lines += $" <td> {barky.ID} </td> ";
                lines += " <td> link </td> ";
                lines += " </tr> ";

            }
            loadBarkies.InnerHtml = lines;
        }
    }

}
