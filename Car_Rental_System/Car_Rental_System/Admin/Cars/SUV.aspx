<%@ Page Title="" Language="C#" MasterPageFile="~/AdminRentals.Master" AutoEventWireup="true" CodeBehind="SUV.aspx.cs" Inherits="Car_Rental_System.Admin.Cars.SUV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="breadcrumbs">
            <div class="breadcrumbs-inner">
                <div class="row m-0">
                    <div class="col-sm-4">
                        <div class="page-header float-left">
                            <div class="page-title">
                                <h1>Add SUV</h1>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>

        <div style="position:relative" class="content">
            <div class="animated fadeIn">


                <div class="row">
                    
                    

                    <div class="col-lg-6">
                        <div class="card">
                            <div class="card-header">
                                <strong>Car Registration</strong> 
                            </div>
                            <div class="card-body card-block">
                                <form action="#" method="post" runat="server" enctype="multipart/form-data" class="form-horizontal">
                                  
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label for="text-input" runat="server" class=" form-control-label">Car Name</label></div>
                                        <div class="col-12 col-md-9"><input type="text" runat="server" id="name" name="text-input" placeholder="Car name" class="form-control"><small class="form-text text-muted">Car name</small></div>
                                    </div>
                                   
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label for="textarea-input" runat="server" class=" form-control-label">Description</label></div>
                                        <div class="col-12 col-md-9"><textarea name="textarea-input" runat="server" id="textarea" rows="9" placeholder="Content..." class="form-control"></textarea></div>
                                    </div>

                                   <div class="row form-group">
                                        <div class="col col-md-3"><label for="email-input" runat="server" class="form-control-label">Distance(KM)</label></div>
                                        <div class="col-12 col-md-9"><input type="distances"  min="0" max="10000000"  runat="server" id="distance" name="distance-input" placeholder="Enter Distance" class="form-control"><small class="help-block form-text">Enter distance car travelled</small></div>
                                    </div>
                                  
                               <!--  <div class="row form-group">
                                        <div class="col col-md-3"><label for="file-input" runat="server" class=" form-control-label">Input Car Image</label></div>
                                        <div class="col-12 col-md-9"> <asp:FileUpload ID="upload2" runat="server" type="file" name="file-multiple-input" multiple="" class="form-control-file"/></div>
                                    </div> -->
                                    <div class="row form-group">
                                        <div class="col col-md-3"><label for="file-multiple-input" runat="server" class=" form-control-label">Input Car Images</label></div>
                                        <div class="col-12 col-md-9"> <asp:FileUpload ID="upload1" runat="server" type="file" name="file-multiple-input" multiple="" class="form-control-file"/> </div>
                                    </div>

                                      <div class="row form-group">
                                        <div class="col col-md-3"><label for="email-input" runat="server" class="form-control-label">Car ID</label></div>
                                        <div class="col-12 col-md-9"><input type="carID" runat="server"  min="0" max="1000000"  id="carid" name="email-input" placeholder="Car ID" class="form-control"><small class="help-block form-text">Enter Car ID</small></div>
                                    </div>

                                     <div   class="row form-group">
                                         <asp:Button id="register" Text="Register" runat="server" value="Register car" type="submit" class="btn btn-lg btn-info btn-block" OnClick="register_Click"/>
                                     </div>
                                </form>
                            </div>
                          
                 </div>
                        </div>
                    </div>
            </div>

       </div>
</asp:Content>
