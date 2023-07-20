using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.IO;

namespace Car_Rental_System.Admin.Cars
{
    [Authorize(Roles = "Admin")]
    public partial class Barkie : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
        AdminRent ar = new AdminRent();
        private static string imgPath;
        private static string fileName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("/LogIn.aspx");
            }
            //  int Id = Converthttps://localhost:44318/Booking.aspx.cs.ToInt32(Request.QueryString["ID"]);
            //  int modelID = Convert.ToInt32(Request.QueryString["CAR"]);

            int adminID = (int)Session["AdminID"];
        }

        protected void register_Click(object sender, EventArgs e)
        {
            // string virtualPath = "~/car_images";

            if (upload1.HasFile)
            {
                fileName = Path.GetFileName(upload1.PostedFile.FileName);
                upload1.PostedFile.SaveAs(Server.MapPath("~/car_images") + fileName);

            }
            // imgPath = "C:/Users/peter/Desktop/IFM/2023_ IFM_PROJECT/Car_Rental_System/Car_Rental_System/car_images" + fileName.ToString();
            imgPath = "~/car_images" + fileName.ToString();
            FileStream stream = new FileStream(Server.MapPath(imgPath), FileMode.Open, FileAccess.Read);
            byte[] carImage = new byte[stream.Length];
            stream.Read(carImage, 0, carImage.Length);


            int adminID = Convert.ToInt32(Session["AdminID"]);
            Barky newBarkie = new Barky(name.Value,"Barkie", textarea.Value, distance.Value, carImage,adminID);

            db.InsertBarkie(newBarkie);
            Response.Redirect("/Admin/Cars/Barkie.aspx");


            //i dont know what to do or display if the user exists
            // Response.Write("User already exists");
            // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Sign Up Failed. email aready exist try loging in!!!');", true);

        }

    }
}