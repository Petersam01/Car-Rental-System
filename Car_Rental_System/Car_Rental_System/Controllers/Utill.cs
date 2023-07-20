using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Car_Rental_System.Controllers
{
    public class Utill
    {

        public static string ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
            {
               
                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                string imgSrc = string.Format("data:image/jpg;base64,{0}", base64String);
                return imgSrc;


                //can also work for png
                // string imgSrc = string.Format("data:image/png;base64,{0}", base64String);
            }

        }

    }
}