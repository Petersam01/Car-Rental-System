using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Controllers
{
    public class Settings
    {
        //Petersam Server Name
        private const string SERVER_NAME = "DESKTOP-T6RASVM";
        public const string CONNECTION_STRING = @"Data Source=" + SERVER_NAME 
                                              + ";Initial Catalog=CarRentalDB;Integrated Security=True";

    }
}