using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System.Admin.Cars.Table
{
    public partial class Barkies : System.Web.UI.Page
    {
        DataHandler data = new DataHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            barkieTable();
        }

        private void barkieTable()
        {
            string lines = "";
            foreach (Barky barky in data.getBarkies())
            {
                lines += " <tr> ";
                lines += $" <td> {barky.Id} </td> ";
                lines += $" <td> {barky.Name} </td> ";
                lines += $" <td> {barky.BarkieType} </td> ";
                lines += $" <td> {barky.Description} </td> ";
                lines += $" <td> {barky.Distance} </td> ";
                lines += $" <td> {barky.AdminID} </td> ";
                lines += " </tr> ";

            }
            loadBarkies.InnerHtml = lines;
        }
    }
}