<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="About us.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="breadcrumbs-section">
        <div class="container p-1 p-sm-3" >
            <div class="row">
                <div class="col-12">
                    <h2>About Us</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="HomePage.aspx">Home</a></li>
                        <li class="breadcrumb-item active">About Us</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>

    <section class="about-company-section">

        <div class="container p-1 p-sm-3" >
            <div class="row">
                <div class="col-12 text-center">
                    <h2>About E-Library</h2>
                    <hr />
                </div>

                 <div class="col-md-3 ">
                    <img class="img-fluid" src="images/Books.png" />
                    
                </div>

                 <div class="col-md-9 ">
                    <p>
                        We are a website that sells electronic books, also known as e-books.<br />
                        <br />
                        What are e-books? <br />
                        E-books are a book publication made available in digital form, consisting of text, images, or both, <br />
                        readable on the flat-panel display of computers or other electronic devices. <br />
                        <br />
                        How Students benefit from learing with Ebooks? <br />
                       -They're easily portable <br />
                       -Digital books accommodate more learning stlyes <br />
                       -The search feature is hard to beat <br />
                       -Very affordable. <br />
                       -Sources <br />
                    </p>
                     
                </div>
            </div>
           <hr />
        </div>

      
    </section>
    
    <section class="pt-3 pt-5">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <h3>
                        The team! <br />
                    </h3>
                </div>
                <hr />
            </div>
            <div class="row">
                <div class="col-md-6 text-center">
                    <img class="img-fluid p-5"  src="images/Ppic.png"  /> <br />
                    <h5> 
                        Poran
                    </h5>
                    <p>
                        A computer geek.
                    </p>

                </div>
                <div class="col-md-6 text-center">
                    <img class="img-fluid p-5" src="images/Apic.png"  /> <br />
                    <h5> 
                        Alex
                    </h5>
                    <p>
                        A pro gamer.
                    </p>

                </div>
                <%--<div class="col-md-4 text-center">
                    <mg class="img-fluid" src="images/Ppic.jpg"i  />
                    <h5> 
                        .
                    </h5>
                    <p>
                        .
                    </p>

                </div>--%>
            </div>

        </div>

    </section>

</asp:Content>
