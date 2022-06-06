<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">

         $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find
                 ("tr:first"))).dataTable();
         });

    


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <section class="breadcrumbs-section">
        <div class="container p-1 p-sm-3" >
            <div class="row">
                <div class="col-12">
                    <h2>View Books</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="HomePage.aspx">Home</a></li>
                        <li class="breadcrumb-item active">View Books</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>

    <div class="container">
                          <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjDb1 %>" SelectCommand="Select bt.Book_id, bt.Book_Name ,Buy_Price , Sell_Price, bt.Format, bt.PageNum, Book_Desc, Book_image,
                          STUFF((select  distinct + ', ' + Genre_Name 
                          from Genre_tbl join BookGenre_tbl 
                          on Genre_tbl.Genre_id = BookGenre_tbl.Genre_id join Book_tbl 
                          on BookGenre_tbl.Book_id = bt.Book_id
                          for xml path('')), 1, 1, '') [Genre Name]
                          from Book_tbl bt 
                          group by bt.Book_id, bt.Book_Name, bt.Format, Sell_Price,bt.PageNum, bt.Book_Desc, bt.Book_image, Buy_Price" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Book_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Book_id" HeaderText="Book_id" ReadOnly="True" SortExpression="Book_id" />
                                <%--<asp:BoundField DataField="Book_Name" HeaderText="Book_Name" SortExpression="Book_Name" />
                                <asp:BoundField DataField="Buy_Price" HeaderText="Buy_Price" SortExpression="Buy_Price" />
                                <asp:BoundField DataField="Sell_Price" HeaderText="Sell_Price" SortExpression="Sell_Price" />
                                <asp:BoundField DataField="Format" HeaderText="Format" SortExpression="Format" />
                                <asp:BoundField DataField="PageNum" HeaderText="PageNum" SortExpression="PageNum" />
                                <asp:BoundField DataField="Sup_Id" HeaderText="Sup_Id" SortExpression="Sup_Id" />
                                <asp:BoundField DataField="Book_Desc" HeaderText="Book_Desc" SortExpression="Book_Desc" />
                                <asp:BoundField DataField="Book_image" HeaderText="Book_image" SortExpression="Book_image" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                             <div class="col-lg-10">
                                                 <div class="row">
                                                     <div class="col-12">
                                                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("Book_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                     </div>
                                                 </div>
                                                    <div class="row">
                                                     <div class="col-12">


                                                        

                                                         

                                                         Genre-<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("[Genre Name]") %>'></asp:Label>


                                                        

                                                         

                                                     </div>
                                                 </div>
                                                    <div class="row">
                                                     <div class="col-12">

                                                         Pages-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("PageNum") %>'></asp:Label>

                                                     </div>
                                                 </div>
                                                    <div class="row">
                                                     <div class="col-12">

                                                         Price-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Sell_Price") %>'></asp:Label>
                                                         &nbsp;| Format-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Format") %>'></asp:Label>

                                                     </div>
                                                 </div>
                                                    <div class="row">
                                                     <div class="col-12">

                                                         Description-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Book_Desc") %>'></asp:Label>

                                                     </div>
                                                 </div>
                                                 
                                                 <br />

                                                 <div class="row">
                                                     <div class="col-12">
                                                       <a class="btn btn-dark" href="Books.aspx?id=<%#Eval("Book_id") %>" >  View item </a>
                                                     </div>
                                                 </div>



                                            </div>
                                                 <div class="col-lg-2">
                                                     <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("Book_image") %>' height="150" />

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>

<%--    <div class="row">


    <asp:Repeater ID="d1" runat="server">
       

        <ItemTemplate>

            <div class="card col-md-3 text-center" style="width: 14rem;">

            <div class="card-body">

                <a ><img src='<%#Eval("Book_image") %>' height="250" width="200" alt="" /></a>
                <div class ="product-info">
                    <h5 class="card-title"><%#Eval("Book_Name") %></h5>                                  
                    <p class ="card-text">$<%#Eval("Sell_Price") %></p> <br />
                    <a href="Books.aspx?id=<%#Eval("Book_id") %>" >  View item </a> 
                </div>
                </div>
            
            </div>
        </ItemTemplate>
       

    </asp:Repeater>


 </div>--%>

        </div>
</asp:Content>
