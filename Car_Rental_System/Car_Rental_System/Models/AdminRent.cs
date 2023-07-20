using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class AdminRent
    {
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string AdminType { get; set; }
        public string Password { get; set; }

        public AdminRent() { }

        public AdminRent(string name,string surname,string email,string position,string adminType,string password) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Position = position;
            this.AdminType = adminType;
            this.Password = password;

        }

        public AdminRent(int adminid,string name, string surname, string email, string position,string adminType, string password)
        {
            this.AdminID = adminid;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Position = position;
            this.AdminType = adminType;
            this.Password = password;

        }
    }
}