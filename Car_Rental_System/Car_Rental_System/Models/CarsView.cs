using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class CarsView
    {
        public int CarID { get; set; }
        public int ID { get; set; }

        public CarsView() { }
        public CarsView(int id) 
        { 
            this.ID = id;
        }
        public CarsView(int carid,int id)
        {
            this.CarID = carid;
            this.ID = id;
        }
    }
}