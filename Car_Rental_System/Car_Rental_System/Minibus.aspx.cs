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
    public partial class Minibus : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
        // Barky carB = new Barky();

        protected void Page_Load(object sender, EventArgs e)
        {
            miniCar();

            int id = getMiniss();
            Session["MiniType"] = db.GetBarkieTypeById(id);
            Session["MiniID"] = id;
        }

        private void miniCar()
        {
            string lines = "";

            foreach (MiniB mini in db.getMinibus())
            {
                //string imageUrl = Utill.GetImageUrlByBase64(barkie.Image);

                lines += $" <div class='col-lg-4 col-md-6 col-sm-6'> ";
                lines += " <div class='blog__item'> ";
                lines += $" <div class='blog__item__pic set-bg' data-setbg='{Utill.ByteArrayToImage(mini.Image)}'> </div> ";
                lines += " <div class='blog__item__text'> ";
                lines += $" <h5>{mini.Name}</h5> ";
                lines += $" <h5>Kilometeres: {mini.Distance}km</h5> ";
                lines += $" <h5>{mini.Description}</h5> ";
                lines += " <a href = 'Rent.aspx' > Rent Car</a> ";
                lines += " </div> ";
                lines += " </div> ";
                lines += " </div> ";


            }

            loadMini.InnerHtml = lines;

            // txtName.InnerText = currentUser.Name;
            //txtUser.InnerText = currentUser.UserType;


        }

        private int getMiniss()
        {
            int Id = 0;

            SqlConnection sqlCon = new SqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("SELECT ID FROM Minibuses ", sqlCon);// WHERE BarkieType='" + type + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            Id = (int)num;



            return Id;

        }
    }

}

