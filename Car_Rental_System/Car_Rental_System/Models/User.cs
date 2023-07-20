using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class User
    {

        //FirstName, LastName, Email, ContactPhone, DOB, UserType, IsActive, Password
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }


        public User() { }
        public User(string name, string surname,string idnumber,string licensenumber, string phone, string email, string userType, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.IDNumber = idnumber;
            this.LicenseNumber = licensenumber;
            this.Phone = phone; 
            this.Email = email;
            this.UserType = userType;
            this.Password = password;
            

        }


        public User(int userid, string name, string surname, string idnumber, string licensenumber, string phone, string email, string userType, string password)
        {
            this.UserID = userid;
            this.Name = name;
            this.Surname = surname;
            this.IDNumber = idnumber;
            this.LicenseNumber = licensenumber;
            this.Phone = phone;
            this.Email = email;
            this.UserType = userType;
            this.Password = password;

            

        }



        //User(txtName.Value, txtSurname.Value, txtEmail.Value, txtNumber.Value, "Yes", txtPassword.Value);




    }
}