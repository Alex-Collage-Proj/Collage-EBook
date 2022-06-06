<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="AcceptOrder.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="MyCss/Cart.css" rel="stylesheet" />

    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%-- Accept
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />--%>


    
      <br />
     <div class="container" >
    
         <br /><br /><br />
          
          <table class="table table-striped">     
  <thead>
    <tr>
       <%--<th scope="col">ID</th>--%>
      <%--<th scope="col">Image</th>--%>
       
      <th scope="col">Name</th>
      <%--<th scope="col">Format</th>--%>
        <th scope="col"></th>
        <th scope="col"></th>    
       <th scope="col">Price</th>
    </tr>
  </thead>
                              
               
         
            <asp:Repeater ID="d1" runat="server">         
                <ItemTemplate >
          
                     <tbody> 
               <tr >  
                  <%--<td  ><h6 class="card-text "><br /><br /><%#Eval("Book_id") %></td>--%>
                 <%--<th scope="row"  ><img src='<%#Eval("Book_image") %>' height="250" width="200"/></th>--%>
                 <td  ><h6 class="card-text "><br /><br /><%#Eval("Book_Name") %></td>
                 <%--<td ><h6 class="card-text"><br /><br /><%#Eval("Format") %></td>--%>

                   <th scope="col"></th>
                        <th scope="col"></th>
                    <td ><h6 class="card-text"><br /><br /><%#Eval("Sell_Price") %>$</td>                              
                 </tr>
                    </tbody>
               </tr>

                     
                 </ItemTemplate>
                </asp:Repeater>
              
              <thead id="Tot" runat="server">
                      <tr>
                      <th scope="col">Total:</th>
                       <th scope="col"></th>
                        <th scope="col"></th>
                         <th id="TotP" runat="server" scope="col"><h6 class="card-text"><asp:Label ID="ToTCPrice" runat="server" Text="0"></asp:Label>$</h6></th>                    
                  </tr>
              </thead>
              


               <div class="row">
  <div class="col-75">
    <div class="container">
      <form action="/action_page.php">

        <div class="row">
        <div class="col-50">
            <br /><br />
            <a>    </a>
          <img src="images/VISA.png" style='width: 500px; height: 300px;' />

            </div>
          <div class="col-50">
            <h3>Payment</h3>
            <label for="fname">Accepted Cards</label>
            <div class="icon-container">
              <i class="fa fa-cc-visa" style="color:navy;"></i>
              <i class="fa fa-cc-amex" style="color:blue;"></i>
              <i class="fa fa-cc-mastercard" style="color:red;"></i>
              <i class="fa fa-cc-discover" style="color:orange;"></i>
            </div>
            <label for="cname">Name on Card</label>
             <asp:TextBox Class="form-control" ID="cname"  runat="server" placeholder="John More Doe"></asp:TextBox>
         <%--<input type="text" id="cname" name="cardname" placeholder="John More Doe">--%>
            <label for="ccnum">Credit card number</label>
               <asp:TextBox Class="form-control" ID="ccnum"  runat="server" placeholder="4557-4304-0006-6161"></asp:TextBox>
               <asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="ccnum" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
            <%--<input type="text" id="ccnum" name="cardnumber" placeholder="1111-2222-3333-4444">--%>
            <%--<label for="expmonth">Exp Month</label>--%>
              <%--<asp:TextBox Class="form-control" ID="expmonth"  runat="server" placeholder="09"></asp:TextBox>--%>
            <%--<input type="text" id="expmonth" name="expmonth" placeholder="September">--%>

            <div class="row">
              <div class="col-50">
                <label for="expyear">Exp Year</label>
                  
                  <asp:TextBox Class="form-control" ID="expyear" type="text" runat="server" placeholder="1223"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="expyear" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                <%--<input type="text" id="expyear" name="expyear" placeholder="2018">--%>
              </div>
              <div class="col-50">
                <label for="cvv">CVV</label>
                  <asp:TextBox Class="form-control" ID="cvv"  runat="server" placeholder="124"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cvv" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                <%--<input type="text" id="cvv" name="cvv" placeholder="352">--%>
              </div>
            </div>
          </div>


        </div>
       <asp:Button ID="Sub_Payment" class="btn btn-lg btn-block btn-success" runat="server" Text="Continue to checkout" onclick="Sub_Payment_Click" />       
      </form>
    </div>
  </div>

          
          </table>

         </div>



</asp:Content>
