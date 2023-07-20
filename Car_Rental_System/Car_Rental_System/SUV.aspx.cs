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
    public partial class SUV : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
        // Barky carB = new Barky();

        protected void Page_Load(object sender, EventArgs e)
        {
            suvCar();

            int id = getSuvss();

            Session["SuvType"] = db.GetBarkieTypeById(id);
            Session["SuvID"] = id;
        }

        private void suvCar()
        {
            string lines = "";

            foreach (Suv suv in db.getSuv())
            {
                //string imageUrl = Utill.GetImageUrlByBase64(barkie.Image);

                lines += $" <div class='col-lg-4 col-md-6 col-sm-6'> ";
                lines += " <div class='blog__item'> ";
                lines += $" <div class='blog__item__pic set-bg' data-setbg='{Utill.ByteArrayToImage(suv.Image)}'> </div> ";
                lines += " <div class='blog__item__text'> ";
                lines += $" <h5>{suv.Name}</h5> ";
                lines += $" <h5>Kilometeres: {suv.Distance}km</h5> ";
                lines += $" <h5>{suv.Description}</h5> ";
                lines += " <a href = 'Rent.aspx' > Rent Car</a> ";
                lines += " </div> ";
                lines += " </div> ";
                lines += " </div> ";


            }

            loadSuv.InnerHtml = lines;

            // txtName.InnerText = currentUser.Name;
            //txtUser.InnerText = currentUser.UserType;


        }

        private int getSuvss()
        {
            int Id = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT ID FROM SUVs ", sqlCon);// WHERE BarkieType='" + type + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            Id = (int)num;



            return Id;

        }
    }
}