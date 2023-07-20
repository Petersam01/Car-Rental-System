using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_System.Models
{
    public class MiniB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniType { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public byte[] Image { get; set; }
        public int AdminID { get; set; }

        public MiniB() { }

        public MiniB(string name, string miniType, string description, string distance, byte[] image, int adminID)
        {
            this.Name = name;
            this.MiniType = miniType;
            this.Description = description;
            this.Distance = distance;
            this.Image = image;
            this.AdminID = adminID;
        }
        public MiniB(int iD, string name, string miniType, string description, string distance, byte[] image, int adminID)
        {
            this.Id = iD;
            this.Name = name;
            this.MiniType = miniType;
            this.Description = description;
            this.Distance = distance;
            this.Image = image;
            this.AdminID = adminID;
        }
    }
}