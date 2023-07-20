using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System
{
    public partial class Sedan : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
        // Barky carB = new Barky();

        protected void Page_Load(object sender, EventArgs e)
        {
            sedanCar();

            int id = getSedanss();

            Session["SedanType"] = db.GetBarkieTypeById(id);
            Session["SedanID"] = id;
        }

        private void sedanCar()
        {
            string lines = "";

            foreach (CarSedan sedan in db.getSedan())
            {
                //string imageUrl = Utill.GetImageUrlByBase64(barkie.Image);

                lines += $" <div class='col-lg-4 col-md-6 col-sm-6'> ";
                lines += " <div class='blog__item'> ";
                lines += $" <div class='blog__item__pic set-bg' data-setbg='{Utill.ByteArrayToImage(sedan.Image)}'> </div> ";
                lines += " <div class='blog__item__text'> ";
                lines += $" <h5>{sedan.Name}</h5> ";
                lines += $" <h5>Kilometeres: {sedan.Distance}km</h5> ";
                lines += $" <h5>{sedan.Description}</h5> ";
                lines += " <a href = 'Rent.aspx' > Rent Car</a> ";
                lines += " </div> ";
                lines += " </div> ";
                lines += " </div> ";


            }

            loadSedan.InnerHtml = lines;

            // txtName.InnerText = currentUser.Name;
            //txtUser.InnerText = currentUser.UserType;


        }

        private int getSedanss()
        {
            int Id = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT ID FROM Sedans ", sqlCon);// WHERE BarkieType='" + type + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            Id = (int)num;



            return Id;

        }
    }
}