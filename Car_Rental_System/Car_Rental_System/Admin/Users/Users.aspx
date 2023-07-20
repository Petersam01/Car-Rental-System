﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminRentals.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Car_Rental_System.Admin.Users.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="row"  >

                    <div class="col-lg-8">
                        <div class="card">
                            <div class="card-header">
                                <strong class="card-title">Users Table</strong>
                            </div>
                            <div class="table-stats order-table ov-h">
                            </div> <!-- /.table-stats -->
                        </div>
                                <table class="table" >
                                    <thead>
                                        <tr>
                                            <th>UserID</th>
                                            <th>Name</th>
                                            <th>Surname</th>
                                            <th>ID Number</th>
                                            <th>License Number</th>
                                            <th>Phone</th>
                                            <th>Email</th>
                                            <th>User Type</th>
                                        </tr>
                                    </thead>
                                    <tbody  id="loadUsers" runat="server">


                                     <!--   <tr>
                                            
                                            <td> #5469 </td>
                                             <td> Petersam </td>
                                            <td> Mkansi </td>
                                            <td> #0101255855088 </td>
                                            <td> 1234567890753524 </td>
                                            <td> 0635889101 </td>
                                            <td> sam@gmail.com </td>
                                            <td> Client </td>
                                            <td>
                                                <span class="badge badge-complete">Complete</span>
                                            </td>
                                        </tr> -->
                                       <!-- <tr>
                                            <td class="serial">2.</td>
                                            <td class="avatar">
                                                <div class="round-img">
                                                    <a href="#"><img class="rounded-circle" src="images/avatar/2.jpg" alt=""></a>
                                                </div>
                                            </td>
                                            <td> #5468 </td>
                                            <td>  <span class="name">Gregory Dixon</span> </td>
                                            <td> <span class="product">iPad</span> </td>
                                            <td><span class="count">250</span></td>
                                            <td>
                                                <span class="badge badge-complete">Complete</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="serial">3.</td>
                                            <td class="avatar">
                                                <div class="round-img">
                                                    <a href="#"><img class="rounded-circle" src="images/avatar/3.jpg" alt=""></a>
                                                </div>
                                            </td>
                                            <td> #5467 </td>
                                            <td>  <span class="name">Catherine Dixon</span> </td>
                                            <td> <span class="product">SSD</span> </td>
                                            <td><span class="count">250</span></td>
                                            <td>
                                                <span class="badge badge-complete">Complete</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="serial">4.</td>
                                            <td class="avatar">
                                                <div class="round-img">
                                                    <a href="#"><img class="rounded-circle" src="images/avatar/4.jpg" alt=""></a>
                                                </div>
                                            </td>
                                            <td> #5466 </td>
                                            <td>  <span class="name">Mary Silva</span> </td>
                                            <td> <span class="product">Magic Mouse</span> </td>
                                            <td><span class="count">250</span></td>
                                            <td>
                                                <span class="badge badge-pending">Pending</span>
                                            </td>
                                        </tr> -->
                                    </tbody>
                                </table>
                    </div>
          </div>

</asp:Content>