<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find
                ("tr:first"))).dataTable();
        });
    </script>
    

       


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

            <div class="container">
        <div class="row">

            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <Center> <img width="100px" src="images/user.png" /> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <Center> <h4>Your Profile</h4> </Center>
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
                                     runat="server" placeholder="Contact Number" TextMode="Number" required="" ></asp:TextBox>
                                </div>
                            </div>

                          
                        </div>


                        <div class="row">
                            <div class="col">
                              <center>  <span class="badge badge-pill badge-light">Login Credentials</span> </center>
                            </div>
                        </div>

                         <div class="row">
                     
                            <div class="col-md-4">
                             <label>Email Address</label>
                                <div class="form-group">                                   
                                    <asp:TextBox type="email" class="form-control" ID="TextBox4"
                                     runat="server" placeholder="Email Address" required="auto-focus" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                             <label>Old Password</label>
                                <div class="form-group">                                   
                                    <asp:TextBox type="Password" class="form-control" ID="SignPassword"
                                     runat="server" placeholder="Password"  required="auto-focus" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                                <div class="col-md-4">
                             <label>New Password</label>
                                <div class="form-group">                                   
                                    <asp:TextBox type="password" class="form-control" ID="TextBox5"
                                     runat="server" placeholder="Password" textmode="password"  ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg"
                                        ID="Button1" runat="server" Text="Update" OnClick="Button1_Click"  />
                                </div>
                                    </center>
                            </div>
                        </div>

       

                    </div>
                </div>

                <a href="HomePage.aspx"><< Back to Home page</a> <br /><br />
            </div>

<%--           <div class="col-md-7">
                                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <Center> <img width="100px" src="images/Books.png" /> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <Center> <h4>Your E-Books</h4> </Center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                              <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>



       

                    </div>
                </div>


            </div>--%>
                
        </div>

    </div>

       

</asp:Content>
