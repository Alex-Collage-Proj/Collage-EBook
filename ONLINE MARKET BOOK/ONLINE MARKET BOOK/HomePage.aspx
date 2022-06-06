<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <center>

      
      <div class="col-md-4 mx-auto">


      <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>

  </ol>
  <div class="carousel-inner" role="listbox">

      <asp:Repeater ID="Carouseld1" runat="server">
          <ItemTemplate>


               <div class='carousel-item <%#Container.ItemIndex==0?"active":"" %>'>
                <a href="Books.aspx?id=<%#Eval("Book_id") %>"> <img src='<%#Eval("Book_image") %>'  alt="" style="  height:650px; width:450px; "> </a>  
                   <div class="carousel-caption">
                   </div>
               </div>



          </ItemTemplate>




      </asp:Repeater>


   
  


  </div>
  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>


          </div>












<%---------------------------------------------------------------------------%>
        <div class="col-md-8 mx-auto">
       <br /><br />

    </div>
<%-----------------------------------------------------------------------------------%>
 </center> 
<%---------------------------------------------------------------------------%>
    <div class="container">
      <div class="row-8">
         <div class="col-md-12 mx-auto">
        
        
        <div class="row " >
          <div class="col-md-7 " style="border-bottom: 1px solid #000000;" >
              <h4>LATEST RELEASES</h4>
          </div>
           <%-- <div class="col-md-3" style="border-bottom: 1px solid #000000;">
              <h3></h3>
          </div>--%>
            <div class="col-md-5   " style="border-bottom: 1px solid #000000; margin-right;" >
                <a href="ViewBooks.aspx">
               <button type="button" class="btn btn-dark float-right">View More</button> 
            <%-- <button  style="background-color:lightgrey;color:black ;border-color:black ;"    type="button" class="btn btn-primary" data-toggle="button" aria-pressed="false">
               View More
              </button>--%>
                 </a>
          </div>  

            <div class="row"><br /><br /></div>


         </div>
           
        </div>
          </div>
              </div>
  <%---------------------------------------------------------------------------%>

<br />
<div class="container">
<div class="row"  >
   
     <asp:Repeater ID="d1" runat="server">
       
        <ItemTemplate>
           

  <div class="card col-3 text-center" style="width: 14rem;" >
   
 
  <div class="card-body">
      <div class ="product-info">

     <img src='<%#Eval("Book_image") %>' class="card-img-top" alt="" height="250" width="200">
    <h5 class="card-title"><%#Eval("Book_Name") %></h5>
    <p class="card-text"><%#Eval("Sell_Price") %>$</p>
          <a class="btn btn-outline-dark" href="Books.aspx?id=<%#Eval("Book_id") %>" >View Item</a>
       </div>     
  </div>
        

    <br />
</div>
            
            
        </ItemTemplate>
   </asp:Repeater>
        

    </div>
     
        </div>



      <%----------------------------------Testing Reccomendation--------------------------%>

    <div class="row"><br /><br /></div>


    <div ID="Reco_Zan" runat="server">
       <div class="container">
      <div class="row-8">
         <div class="col-md-12 mx-auto">
        
        
        <div class="row " >
          <div class="col-md-12 " style="border-bottom: 1px solid #000000;" >
              <h4>Recommended For You:</h4>
          </div>             
         </div>
           
        </div>
          </div>
              </div>




              <br />
            <div class="container">
        <div class="row"  >
   
     <asp:Repeater ID="Zaner_Repeater" runat="server">
       
        <ItemTemplate>
           

  <div class="card col-3 text-center" style="width: 14rem;" >
   
 
  <div class="card-body">
      <div class ="product-info">

     <img src='<%#Eval("Book_image") %>' class="card-img-top" alt="" height="250" width="200">
    <h5 class="card-title"><%#Eval("Book_Name") %></h5>
    <p class="card-text"><%#Eval("Sell_Price") %>$</p>
    <a class="btn btn-outline-dark" href="Books.aspx?id=<%#Eval("Book_id") %>" >View Item</a>
          
       </div>    
    
  </div>
      <br />  
</div>
        
            
        </ItemTemplate>
   </asp:Repeater>
    

    </div>
       <br />   
        
    </div>
        </div>
<%--</div>  --%>  
  
     <%----------------------------------Testing--------------------------%>

    <div class="row-8">    <marquee behavior="alternate"><img src="images/Banner/Banner.png" /><img src="images/Banner/bunner.jpg" width="1300"  height="255"/></marquee>      </div>




   
        
    
    
  
        

</asp:Content>
