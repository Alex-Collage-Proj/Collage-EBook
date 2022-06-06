<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <Center> <img width="150px" src="images/admin.png" /> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <Center> <h3>Admin Login</h3> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                              <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                
                                <div class="form-group">                                   
                                    <asp:TextBox type="UserName" class="form-control" ID="inputUserName"
                                     runat="server" placeholder="User Name" required="auto-focus"></asp:TextBox>
                                </div>

                                     
                                     <div class="form-group">
                                  
                                      <asp:TextBox type="password" class="form-control" ID="inputPassword2"
                                       runat="server" placeholder="Password" TextMode="Password" required=""></asp:TextBox>
                                     </div>

                                     <div class="form-group">
                                        <asp:Button class="btn btn-light btn-block btn-lg" ID="ButtonAdmin" runat="server" Text="Login" OnClick="ButtonAdmin_Click" />
                                      
                                     </div>

                                     


                            </div>
                        </div>

                    </div>
                </div>

<%--                <a href="HomePage.aspx"><< Back to Home page</a> <br /><br />--%>
            </div>

        </div>

    </div>




</asp:Content>
