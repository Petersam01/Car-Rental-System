using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class Barky
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarkieType { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public byte[] Image { get; set; }
        public int AdminID { get; set; }

        public Barky() { }

        public Barky(string name, string barkieType, string description, string distance, byte[] image, int adminID)
        {
            this.Name = name;
            this.BarkieType = barkieType;
            this.Description = description;
            this.Distance = distance;
            this.Image = image;
           this.AdminID = adminID;
        }
        public Barky(int iD, string name, string barkieType, string description, string distance, byte[] image, int adminID)
        {
            this.Id = iD;
            this.Name = name;
            this.BarkieType = barkieType;
            this.Description = description;
            this.Distance = distance;
            this.Image = image;
            this.AdminID = adminID;
        }
    }
}