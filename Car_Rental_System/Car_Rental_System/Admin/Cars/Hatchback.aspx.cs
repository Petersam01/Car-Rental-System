using Car_Rental_System.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Car_Rental_System.Models;
using Car_Rental_System.Controllers;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using System.Web.Security;

namespace Car_Rental_System.Admin.Cars
{
    [Authorize(Roles = "Admin")]
    public partial class Hatchback : System.Web.UI.Page
    {
        DataHandler db = new DataHandler();
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


            // int carid = int.Parse(Request.Form["carid"]);
            int adminID = Convert.ToInt32(Session["AdminID"]);
            HatchB newHatch = new HatchB(name.Value,"Hatchback", textarea.Value, distance.Value, carImage, adminID);

            db.InsertHatch(newHatch);
            Response.Redirect("/Admin/Cars/Hatchback.aspx");


            //i dont know what to do or display if the user exists
            // Response.Write("User already exists");
            // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Sign Up Failed. email aready exist try loging in!!!');", true);

        }
    }
}