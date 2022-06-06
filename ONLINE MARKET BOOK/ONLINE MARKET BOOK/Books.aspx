<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <section class="about-company-section">

        <div class="container p-1 p-sm-3  border rounded border-width:thin;">
            <div class="row">

            <asp:Repeater ID="d1" runat="server">
                <ItemTemplate>
      <div class="col-12 text-center">
                    <h2><%#Eval("Book_Name") %></h2>
                    <hr />
                </div>
                     <%--                       Changes Style       31.10        --%>
                 <div class="col-md-4 container border rounded border-width:thin;" >
                     <br />
                    <img class="img-fluid rounded" style="width:350px;height:480px;" src='<%#Eval("Book_image") %>' /><img />
                     <br /> <br />
                    
                </div>
                   
                 <div class="col-md-7  ">
                     <%--<div class="col-md-7 container border rounded border-width:thin; ">--%>
                     <br />
                  
                   <div class="col"><div class="row " ><p style="font-size:20px;"> Price: <%#Eval("Sell_Price")%>$</p><br /><br /></div></div>
                    <div class="col"><div class="row"><p style="font-size:20px;">Format:  <%#Eval("Format")%> </p><br /><br /></div></div>
                    <div class="col"><div class="row"><p style="font-size:20px;">Page Number:  <%#Eval("PageNum")%></p><br /><br /></div></div>
                    <div class="col"><div class="row"><p style="font-size:20px;">Genre:  <%#Eval("Genre Name")%> </p><br /><br /></div></div>
                    <div class="col"><div class="row"><p style="font-size:20px;">Description: <%#Eval("Book_Desc")%></p></panel>  <br /></div></div>


                      <%--                       Changes Style       31.10        --%>




                  <%--   <h6>Price:</h6> $<%#Eval("Sell_Price")%> <br /> <br />    
                     <h6>Format:</h6> <%#Eval("Format")%> <br /> <br />
                     <h6>Page Number:</h6> <%#Eval("PageNum")%>  <br /> <br />
                     <h6>Genre:</h6> <%#Eval("Genre Name")%> <br /> <br />
                     <h6>Description:</h6> <%#Eval("Book_Desc")%> <br /> <br />--%>
                     <br />



                      
              
                        
             
                    


                     
                                        
                </div>
                </ItemTemplate>

                </asp:Repeater>
                
                

               <div class="col-2"></div>               <div class="col-8 text-center"> <br>                       <asp:LinkButton class="btn btn-light btn-block btn-lg " ID="AddToCart" runat="server" Visible="false" onclick="AddToCart_Click"                                   >Add To Cart</asp:LinkButton>                                      <a class="btn btn-light btn-block btn-lg" href="ViewBooks.aspx" role="button"> Back to all products </a> </div>                 <%--                       Changes Style       31.10        --%>            





            </div>

               

           
        </div>

      
    </section>

</asp:Content>
