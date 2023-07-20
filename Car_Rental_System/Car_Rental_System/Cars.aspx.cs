using Car_Rental_System.Controllers;
using Car_Rental_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental_System
{
    public partial class Cars : System.Web.UI.Page
    {
        DataHandler dh = new DataHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            viewCars();
        }

        private void viewCars()
        {
            string lines = "";

            foreach(CarsView cars in dh.GetAllCars())
            {
                lines += "< div class='col-lg-4 col-md-6 col-sm-6'>";
                lines += "< div class='product__item'>";
                lines += "<div class='product__item__pic set-bg' data-setbg='img/product/product-2.jpg'>";
                lines += "<ul class='product__hover'>";
                lines += "<li><a href = '#' >< img src='img/icon/heart.png' alt=''></a></li>";
                lines += "<li><a href = '#' >< img src='img/icon/compare.png' alt=''> <span>Compare</span></a>";
                lines += "</li>";
                lines += "<li><a href = '#' >< img src='img/icon/search.png' alt=''></a></li>";
                lines += "</ul>";
                lines += "</div>";
                lines += "<div class='product__item__text'>";
                lines += "<h6>Piqué Biker Jacket</h6>";
                lines += "<a href = '#' class='add-cart'>+ Add To Cart</a>";
                lines += "<div class='rating'>";
                lines += "<i class='fa fa-star-o'></i>";
                lines += "<i class='fa fa-star-o'></i>";
                lines += "<i class='fa fa-star-o'></i>";
                lines += "<i class='fa fa-star-o'></i>";
                lines += "<i class='fa fa-star-o'></i>";
                lines += " </div>";
                lines += " <h5>$67.24</h5>";
                lines += "<div class='product__color__select'>";
                lines += "<label for='pc-4'>";
                lines += "<input type = 'radio' id='pc-4'>";
                lines += "</label>";
                lines += "<label class='active black' for='pc-5'>";
                lines += "<input type = 'radio' id='pc-5'>";
                lines += "</label>";
                lines += "<label class='grey' for='pc-6'>";
                lines += "<input type = 'radio' id='pc-6'>";
                lines += "</label>";
                lines += "</div>";
                lines += "</div>";
                lines += "</div>";
                lines += "</div>";
                     
            }
        }
    }
}