using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class BarkieRent
    {
        public int BookingID { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Booking_date { get; set; }
        public string Return_date { get; set; }
        public string isApproved { get; set; }
        public int UserID { get; set; }
        public int ID { get; set; }

        public BarkieRent() { }
        public BarkieRent(int bookingID, DateTime current, string booking_date, string return_date, string isApproved, int userID, int iD)
        {
            BookingID = bookingID;
            CurrentDate = current;
            Booking_date = booking_date;
            Return_date = return_date;
            this.isApproved = isApproved;
            UserID = userID;
            ID = iD;
        }
    }
}