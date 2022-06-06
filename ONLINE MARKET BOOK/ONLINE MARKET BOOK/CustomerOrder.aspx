<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="CustomerOrder.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm11" %>
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
                <div class="col-md-12">
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="false">
                                  <%------------------------------------  testing---------------------%>
                                   <Columns>

                                    <asp:BoundField DataField="Order_Id" HeaderText="Order Id" />
                                   <asp:BoundField DataField="Book_Name" HeaderText="Book Name" />
                                   <asp:BoundField DataField="Order_Date" HeaderText="Order Date" />                           
                                   <asp:TemplateField>
                                       <ItemTemplate>
                                           <asp:LinkButton class="btn btn-outline-dark" ID="Send_To_Downloag_Page" runat="server" CommandArgument='<%#Eval("Book_Id").ToString() %>' onclick="Send_To_Downloag_Page_Click" >Download</asp:LinkButton>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   
                                    </Columns>
                                    <%------------------------------------  testing---------------------%>
                                </asp:GridView>                              
                            </div>
                        </div>

    
                    </div>
                </div>
            </div>


</div>


</asp:Content>
