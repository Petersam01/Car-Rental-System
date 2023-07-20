using Car_Rental_System.Admin.Cars;
using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.util;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Car_Rental_System
{
    public partial class Barkie : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
       // Barky carB = new Barky();

        protected void Page_Load(object sender, EventArgs e)
        {
            barkieCar();

            int id = getBarkie();

            Session["BarkieType"] = db.GetBarkieTypeById(id);
            Session["BarkieID"] = id;
           // Response.Redirect("Rent.aspx");
        }

        private void barkieCar()
        {
            string lines = "";
            User user = new User();
            string BarkieType = "Barkie";
            int Id = Convert.ToInt32(Request.QueryString["BarkieID"]);
           // Barky barkie = db.getBarkies();
           foreach (Barky barkie in db.getBarkies())
            {
                //string imageUrl = Utill.GetImageUrlByBase64(barkie.Image);

                lines += $" <div class='col-lg-4 col-md-6 col-sm-6'> ";
                lines += " <div class='blog__item'> ";
                lines += $" <div class='blog__item__pic set-bg' data-setbg='{Utill.ByteArrayToImage(barkie.Image)}'> </div> ";
                lines += " <div class='blog__item__text'> ";
                lines += $" <h5>{barkie.Name}</h5> ";
                lines += $" <h5>Kilometeres: {barkie.Distance}km</h5> ";
                lines += $" <h5>{barkie.Description}</h5> ";
                lines += " <a href = '/Rent.aspx' > Rent Car</a> ";
                lines += " </div> ";
                lines += " </div> ";
                lines += " </div> "; 
            }

            loadBarkies.InnerHtml = lines;

           
        }
        private int getBarkie()
        {
            int Id = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT ID FROM Barkies ", sqlCon);// WHERE BarkieType='" + type + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            Id = (int)num;



            return Id;

        }

    }
}