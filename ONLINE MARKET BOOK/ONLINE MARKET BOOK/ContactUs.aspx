<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <section class="breadcrumbs-section">
        <div class="container p-1 p-sm-3" >
            <div class="row">
                <div class="col-12">
                    <h2>Contact Us</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="HomePage.aspx">Home</a></li>
                        <li class="breadcrumb-item active">Contact Us</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
        
        <section class="p-3">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center"> 
                        Fill out the contact form below and we'll do our best to reply within 24 hours by mail.
                        <hr />
                    </div>
                </div>
            </div>

        </section>

        <section class="form-section">
        <div class="container p-1 p-sm-3 border rounded border-width:thin;" >
                <div class="row">
                    <div class="col-2">

                    </div>
                    <div class="col-md-8 "> 

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:TextBox id="FullName" type="text" runat="server" class="form-control" placeholder="Full name" /> 
                             <asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="FullName" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                         <div class="form-group col-md-6">
                            <asp:TextBox id="Email" type="email" runat="server" class="form-control" placeholder="Email Address" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                    </div>

                       <div class="form-row">
                        <div class="form-group col-md-6">
                              <asp:TextBox ID="PhoneNum" type="number" runat="server" class="form-control" placeholder="Contact Number" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PhoneNum" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                        <%-- <div class="form-group col-md-6">
                            <select class="form-control" name="" id="">
                                <option selected>Country</option>
                                <option>Israel</option>
                                <option>China</option>
                            </select>
                        </div>--%>
                       </div>

                        <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:TextBox ID="Subject" runat="server" type="text" class="form-control" placeholder="Subject" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Subject" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>                      
                       </div>

                        <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:TextBox ID="Desc" runat="server" TextMode="MultiLine" type="text" class="form-control" placeholder="Body"></asp:TextBox>                          
                        </div>                      
                       </div>

                        <div class="form-row">
                        <div class="form-group col-md-12 text-center">
                            <asp:Button ID="ContactSend" type="submit" Text="Send Message" runat="server" class="btn btn-outline-dark" onclick="ContactSend_Click" ></asp:Button>
                        </div>                      
                       </div>


                    </div>
                  
                     <div class="col-2">

                    </div>
                </div>
            </div>

        </section>


</asp:Content>
