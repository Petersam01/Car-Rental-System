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
    public partial class Hatchback : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
        // Barky carB = new Barky();

        protected void Page_Load(object sender, EventArgs e)
        {
            hatchCar();

            int id = getHatchs();
            Session["HatchType"] = db.GetBarkieTypeById(id);
            Session["HatchID"] = id;
        }

        private void hatchCar()
        {
            string lines = "";

            foreach (HatchB hatch in db.getHatchbacks())
            {
                //string imageUrl = Utill.GetImageUrlByBase64(barkie.Image);

                lines += $" <div class='col-lg-4 col-md-6 col-sm-6'> ";
                lines += " <div class='blog__item'> ";
                lines += $" <div class='blog__item__pic set-bg' data-setbg='{Utill.ByteArrayToImage(hatch.Image)}'> </div> ";
                lines += " <div class='blog__item__text'> ";
                lines += $" <h5>{hatch.Name}</h5> ";
                lines += $" <h5>Kilometeres: {hatch.Distance}km</h5> ";
                lines += $" <h5>{hatch.Description}</h5> ";
                lines += " <a href = 'Rent.aspx' > Rent Car</a> ";
                lines += " </div> ";
                lines += " </div> ";
                lines += " </div> ";


            }

            loadHatch.InnerHtml = lines;

            // txtName.InnerText = currentUser.Name;
            //txtUser.InnerText = currentUser.UserType;


        }

        private int getHatchs()
        {
            int Id = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT ID FROM Hatchbacks ", sqlCon);// WHERE BarkieType='" + type + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            Id = (int)num;



            return Id;

        }
    }
}