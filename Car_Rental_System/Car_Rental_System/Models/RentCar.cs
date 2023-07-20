using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class RentCar
    {
        public int BookingID { get; set; }
        public DateTime Booking_date { get; set; }
        public DateTime Return_date { get; set; }
        public string isApproved { get; set; }
        public int UserID { get; set; }
        public int ID { get; set; }

        public RentCar() { }

        public RentCar(int bookingID, DateTime booking_date, DateTime return_date, string isApproved, int userID, int iD)
        {
            BookingID = bookingID;
            Booking_date = booking_date;
            Return_date = return_date;
            this.isApproved = isApproved;
            UserID = userID;
            ID = iD;
        }
    }
}