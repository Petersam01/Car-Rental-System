<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Car_Rental_System.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Breadcrumb Section Begin -->
    <section class="breadcrumb-option">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcrumb__text">
                        <h4>Shop</h4>
                        <div class="breadcrumb__links">
                            <a href="./index.html">Home</a>
                            <span>Rent Car</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->
    
    <div>
            
  <div class="half">
    <div class="bg order-1 order-md-2" style="background-image: url('images/bg_1.jpg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-6">
            <div class="form-block">
              <div class="text-center mb-5">
              <h3>Login</h3>
              
              </div>
              <form action="#" method="post">
              
                <div class="form-group first">
                  <label for="username">Email Address</label>
                  <input type="text" class="form-control" runat="server" placeholder="your-email@gmail.com" id="email">
                </div>
       
                <div class="form-group">
                  <label for="password">Password</label>
                  <input type="password" class="form-control" runat="server" placeholder="Your Password" id="password">
                </div>
       
                
                <div class="form-group">
                 
                   
                  <span class="ml-auto"><a href="RegisterUser.aspx" class="forgot-pass">Dont Have an account? Register</a></span> 
                    
                </div>
                    <div class="form-group">
                
                        <asp:Button ID="btnSave" runat="server" Text="LogIn"  type="submit" value="Login" class="btn btn-block btn-primary " OnClick="btnSave_Click"/>
                  </div>
                

              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

    
  </div>
    

     </div>
</asp:Content>
