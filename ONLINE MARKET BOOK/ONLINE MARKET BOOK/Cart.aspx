<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <br />
     <div class="container" >
         <h3>Your Orders:</h3>

        
         <%--<asp:Button  ID="View" runat="server" Text="View_Cart" OnClick="View_Click" />--%>
<%--         <asp:Button ID="testing" runat="server" Text="Test" OnClick="testing_Click" />--%>
         
         <br /><br /><br />
              
          <table class="table table-striped">     
  <thead>
    <tr>
      <th scope="col">Image</th>
      <th scope="col">Name</th>
      <th scope="col">Format</th>
      <th scope="col">Price</th>
      <th scope="col">B\D</th>
    </tr>
  </thead>
                
   
                 
             
                 
                 

    
            <asp:Repeater ID="d1" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate >


          

                  
                     <tbody>
               
               <tr >  
                 <th scope="row"  ><img src='<%#Eval("Book_image") %>' height="250" width="200"/></th>
                 <td  ><h6 class="card-text "><br /><br /><%#Eval("Book_Name") %></td>
                 <td ><h6 class="card-text"><br /><br /><%#Eval("Format") %></td>
                    <td ><h6 class="card-text"><br /><br /><%#Eval("Sell_Price") %>$</td>                 
                 <td ><br /><a class="btn btn-dark" href="DeleteCart.aspx?id=<%#Eval("id") %>">Delete</a></td>
                 
                 </tr>
                    </tbody>
            

               </tr>
                    <FooterTemplate>
                          
                  
                    </FooterTemplate>
                     
                 </ItemTemplate>
                </asp:Repeater>
              
              <thead id="Tot" runat="server">
                      <tr>
                      <th scope="col">Total:</th>
                       <th scope="col"></th>
                        <th scope="col"></th>
                         <th id="TotP" runat="server" scope="col"><h5 class="card-text"><asp:Label ID="ToTCPrice" runat="server" Text="0"></asp:Label>$</h5></th>
                      <%--<th scope="col"><a href="Buy?id=<%#Eval("Book_id") %>">Buy</a></th>--%>
                          <th><asp:Button class="btn btn-dark" runat="server" ID="Buy"  Text="Buy" onclick="Buy_Click"></asp:Button></th>
                  </tr>
              </thead>
              
              </table>
            <div ID="EmptyCart" runat="server"><h3>Your Cart Is Empty</h3></div>


          


              
                 </div>


</asp:Content>
