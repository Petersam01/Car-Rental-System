<%@ Page Title="" Language="C#" MasterPageFile="~/Rental.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Car_Rental_System.RegisterUser" %>
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
              <h3>Register</h3>
              
              </div>
              <form action="#" method="post">
                <div class="form-group first">
                  <label for="name">Name</label>
                  <input type="text" class="form-control" runat="server" placeholder="John " id="name">
                </div>
                  <div class="form-group first">
                  <label for="name">Surname</label>
                  <input type="text" class="form-control" runat="server" placeholder="John Smith" id="surname">
                </div>
                  <div class="form-group first">
                  <label for="name">ID Number</label>
                  <input type="text" class="form-control" runat="server" placeholder="xxxxxxxxxxxxx" id="idno">
                </div>
                  <div class="form-group first">
                  <label for="name">Licinse number</label>
                  <input type="text" class="form-control" runat="server" placeholder="xxxxxxxxxxxxxxxxxxxx" id="license">
                </div>
               
                  <div class="form-group first">
                  <label for="name">Phone</label>
                  <input type="text" class="form-control" runat="server" placeholder="0123456789" id="phone">
                </div>
                   <div class="form-group first">
                  <label for="username">Email Address</label>
                  <input type="text" class="form-control" runat="server" placeholder="your-email@gmail.com" id="email">
                </div>
                <div class="form-group">
                  <label for="password">Password</label>
                  <input type="password" class="form-control" runat="server" placeholder="Your Password" id="password">
                </div>
                <div class="form-group last mb-3">
                  <label for="re-password">Re-type Password</label>
                  <input type="password" class="form-control" runat="server" placeholder="Re-type Your Password" id="password2">
                </div>
                
                <div class="d-sm-flex mb-5 align-items-center">
                  <label class="control control--checkbox mb-3 mb-sm-0"><span class="caption">Agree our <a href="#">Terms and Conditions</a></span>
                    <input type="checkbox" checked="checked"/>
                    <div class="control__indicator"></div>
                  </label>
                  <span class="ml-auto"><a href="LogIn.aspx" class="forgot-pass">Have an account? Login</a></span> 
                   
                </div>

              <div class="form-group">
      
                  <asp:Button ID="btnSave" runat="server" Text="Save"  type="submit" value="Register" class="btn btn-block btn-primary" OnClick="btnSave_Click"/>

                  </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

    
  </div>
    
    

    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>

        </div>
</asp:Content>
