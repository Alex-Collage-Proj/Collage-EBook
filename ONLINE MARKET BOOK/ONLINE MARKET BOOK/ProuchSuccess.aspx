<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="ProuchSuccess.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


         <div class="container" >
         
            <div class="row">
             <div class="col-12">
                <center>
                     <h2>Thank You For Purchase At Our Shop We Will Glad See You Again</h2>
                    </center>
                </div>
                </div>
          
         <div class="row" >   
                 <div class="col-12">
                 <center>
                <h3> Order Id:<asp:Label ID="order_id1" runat="server" Text="Label"></asp:Label></h3> 
                        </center>
                   </div>
                    </div>
          
          <asp:Button class="btn btn-light btn-block btn-lg" ID="BackTMain" runat="server" Text="Main" onclick="BackTMain_Click"   />  
            
          <asp:Button class="btn btn-light btn-block btn-lg" ID="BackOrder" runat="server" Text="Your Books" onclick="BackOrder_Click"  /> 
        

          </div>


</asp:Content>
