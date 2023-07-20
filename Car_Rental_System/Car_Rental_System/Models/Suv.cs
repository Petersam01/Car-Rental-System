using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class Suv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SuvType { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public byte[] Image { get; set; }
        public int AdminID { get; set; }

        public Suv() { }

        public Suv(string name, string suvType, string description, string distance, byte[] image, int adminID)
        {
            this.Name = name;
            this.SuvType = suvType;
            this.Description = description;
            this.Distance = distance;
            this.Image = image;
            this.AdminID = adminID;
        }
        public Suv(int iD, string name, string suvType, string description, string distance, byte[] image, int adminID)
        {
            this.Id = iD;
            this.Name = name;
            this.SuvType = suvType;
            this.Description = description;
            this.Distance = distance;
            this.Image = image;
            this.AdminID = adminID;
        }
    }
}