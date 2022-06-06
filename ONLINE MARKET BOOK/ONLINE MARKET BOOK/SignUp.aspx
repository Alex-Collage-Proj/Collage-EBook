<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <Center> <img width="100px" src="images/user.png" /> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <Center> <h4>Member Sign up</h4> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                              <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                              <label>First Name</label>
                                <div class="form-group">                                   
                                    <asp:TextBox  class="form-control" ID="TextBox1"
                                     runat="server" placeholder="First Name" required=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                              <label>Last name</label>
                                     <div class="form-group">
                                  
                                      <asp:TextBox  class="form-control" ID="TextBox2"
                                       runat="server" placeholder="Last Name"  required=""></asp:TextBox>
                                     </div>
                            </div>
                        </div>

                        <div class="row">

                       

                            <div class="col-md-6">
                              <label>Contact Number</label>
                                <div class="form-group">                                   
                                    <asp:TextBox  class="form-control" ID="TextBox3"
                                     runat="server" placeholder="Contact Number"  TextMode="Phone" required=""></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="PhoneValid" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please enter a valid phone number" Text="*" ValidationExpression="05[0-9][-]*[0-9]{7}"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                          
                        </div>


                        <div class="row">
                            <div class="col">
                              <center>  <span class="badge badge-pill badge-light">Login Credentials</span> </center>
                            </div>
                        </div>

                         <div class="row">
                     
                            <div class="col-md-6">
                             <label>Email Address</label>
                                <div class="form-group">                                   
                                    <asp:TextBox type="email" class="form-control" ID="TextBox4"
                                     runat="server" placeholder="Email Address" required="auto-focus"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                             <label>Password</label>
                                <div class="form-group">                                   
                                    <asp:TextBox type="password" class="form-control" ID="SignPassword"
                                     runat="server" placeholder="Password" textmode="password" required="auto-focus"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-light btn-block btn-lg"
                                        ID="Button1" runat="server" Text="Sign Up" OnClick="SignU" />
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
