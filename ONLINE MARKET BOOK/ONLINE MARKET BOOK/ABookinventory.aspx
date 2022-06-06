<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="ABookinventory.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">

         $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find
                 ("tr:first"))).dataTable();
         });

         function readURL(input) {

             if (input.files && input.files[0]) {
                 var reader = new FileReader();

                 reader.onload = function (e) {
                     $('#imgview').attr('src', e.target.result);
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }


     </script>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" height="250px" width="200px" src="images/Books.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                       <div class="col-12">
                       <label>Book Image</label>
                           </div>
                   </div>
                  <div class="row">
                     <div class="col">
                         <asp:FileUpload onchange="readURL(this);" Class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>

                    <div class="row">
                     <div class="col">
                        <br />
                     </div>
                  </div>


                   <div class="row">
                       <div class="col-12">
                       <label>Book Pdf</label>
                           </div>
                   </div>

                    <div class="row">
                     <div class="col">
                         <asp:FileUpload  Class="form-control" ID="FileUpload2" runat="server" />
                     </div>
                  </div>


                   <br />

                  <div class="row">
                     <div class="col-md-3">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox Class="form-control" ID="BookId" runat="server" placeholder="Book ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="BookId" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                               <asp:Button class="btn btn-primary" CausesValidation="false" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="BookName" runat="server" placeholder="Book Name" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="BookName" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Sup ID</label>
                         <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox Class="form-control" ID="Supid" runat="server" placeholder="Sup ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Supid" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                           </div>
                        </div>
                     </div>
                   
                     <div class="col-md-4">
                        <label>Genre ID</label>
                        <div class="form-group">
                            <asp:ListBox Class="form-control" ID="GenreList" runat="server" SelectionMode="Multiple">
                                <asp:ListItem Text ="Horror" Value=1 />
                                <asp:ListItem Text ="Comedy" Value=2 />
                                <asp:ListItem Text ="Romance" Value=3 />
                                <asp:ListItem Text ="Adventure" Value=4 />
                                <asp:ListItem Text ="Crimes" Value=5 />
                            </asp:ListBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="GenreList" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>

                      <div class="col-md-4">
                        <label>Buy Price(per unit)</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="BuyPrice" runat="server" placeholder="Buy Price(per unit)" TextMode="Number"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BuyPrice" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-4">
                        <label>Format</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="Format" runat="server" placeholder="Format" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Format" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Book Cost(per unit)</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="SellPrice" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="SellPrice" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pages</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="Pagenum" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Pagenum" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Book Description</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="BookDesc" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="BookDesc" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>
                   <center>
                    <div class="row">
                        <div class="col-6 ">
                            <asp:Button ID="AddGenre" class="btn btn-sm btn-success" runat="server" Text="Add Genre" OnClick="AddGenre_Click" />
                        </div>

                        <div class="col-6 ">
                            <asp:Button ID="DeleteGenre" class="btn btn-sm btn-danger" runat="server" Text="Delete Genre" OnClick="DeleteGenre_Click" />
                        </div>
                   </div>
                       </center>
                   <br />

                  <div class="row">
                     <div class="col-4 ">
                        <asp:Button ID="AddButton" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="AddButton_Click" />
                     </div>
                         <div class="col-4 ">
                        <asp:Button ID="UpdateButton" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="UpdateButton_Click" />
                     </div>
                     <div class="col-4 ">
                        <asp:Button ID="DeleteButton" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
                     </div>
                  </div>

                  

               </div>
            </div>
<%--            <a href="homepage.aspx"><< Back to Home</a><br>--%>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Inventory</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjDb1 %>" SelectCommand="Select bt.Book_id, bt.Book_Name ,Buy_Price , Sell_Price, bt.Format, bt.PageNum, Book_Desc, Book_image,
                          STUFF((select  distinct + ', ' + Genre_Name 
                          from Genre_tbl join BookGenre_tbl 
                          on Genre_tbl.Genre_id = BookGenre_tbl.Genre_id join Book_tbl 
                          on BookGenre_tbl.Book_id = bt.Book_id
                          for xml path('')), 1, 1, '') [Genre Name]
                          from Book_tbl bt 
                          group by bt.Book_id, bt.Book_Name, bt.Format, Sell_Price,bt.PageNum, bt.Book_Desc, bt.Book_image, Buy_Price"></asp:SqlDataSource>
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

                                            </div>
                                                 <div class="col-lg-2">
                                                     <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("Book_image") %>' />

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   
</div>

   

</asp:Content>
