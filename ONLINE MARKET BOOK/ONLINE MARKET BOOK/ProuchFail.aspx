<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="ProuchFail.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    

    <div class="container p-1 p-sm-3" >

            <div class="row">
                <div class="alert alert-danger" class="btn btn-light btn-block btn-lg" role="alert">
 

             <h1>The Purchase Is Fail Please Check You Payment Methhood Again</h1>
                
                <h4>
                    <asp:Label ID="Error" runat="server" Text="Error"></asp:Label>
                </h4>
                </div>
            <asp:Button class="btn btn-light btn-block btn-lg" ID="BackToMain1" runat="server" Text="Main" onclick="BackToMain1_Click"  />  

             <asp:Button class="btn btn-light btn-block btn-lg" ID="BackToCart1" runat="server" Text="Cart" onclick="BackToCart1_Click"  />  
            
             <asp:Button class="btn btn-light btn-block btn-lg" ID="BackToPayment1" runat="server" Text="Payment" onclick="BackToPayment1_Click"  />  

             
           
            

        </div>
        </div>


</asp:Content>
