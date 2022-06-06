<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm1" %>
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
                                <Center> <img width="150px" src="images/user.png" /> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <Center> <h3>Member Login</h3> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                              <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                <label>Email Address</label>
                                <div class="form-group">                                   
                                    <asp:TextBox type="email" class="form-control" ID="inputEmail"
                                     runat="server" placeholder="Email Address" required="auto-focus"></asp:TextBox>
                                </div>

                                     <label>Password</label>
                                     <div class="form-group">
                                  
                                      <asp:TextBox type="password" class="form-control" ID="inputPassword"
                                       runat="server" placeholder="Password" TextMode="Password" required=""></asp:TextBox>
                                     </div>

                                     <div class="form-group">
                                        <asp:Button class="btn btn-light btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="LogI" />
                                      
                                     </div>

                                       <div class="form-group">
                                            <a href="SignUp.aspx" ><input class="btn btn-light btn-block btn-lg" id="Button2" type="button" value="Sign up" /> </a> 
                                      
                                     </div>


                            </div>
                        </div>

                    </div>
                </div>

<%--                <a href="HomePage.aspx"><< Back to Home page</a> <br /><br />--%>
            </div>

        </div>

    </div>



<%--<div class="col-md-6 m-auto">


   <%-- <div class="text-center">
        <img class="mb-4" src="images/Books.jpg" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Please sign in </h1> <br />
        <label for="inputEmail" class="sr-only">Email address</label>
        <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus>
        <label for="inputPassword" class="sr-only">Password</label>
        <input type="password" id="inputPassword" class="form-control" placeholder="Password" required> <br />
        <div class="checkbox mb-3">
        <label>
        <input type="checkbox" value="remember-me"> Remember me
        </label>
        </div>
        <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
    </div>--%>
    
<%--</div>--%>

</asp:Content>
