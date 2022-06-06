<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="GenreManagment.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 

   
    <script type="text/javascript">

         $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find
                 ("tr:first"))).dataTable();
         });
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
                           <h4>Genre List</h4>
                            </center>
                             </div>
                        </div>

                        <div class="row">
                            <div class="col">
                              <hr>
                            </div>
                        </div>

                         <div class="row">
                     <div class="col-md-6">
                        <label>Genre ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox Class="form-control" ID="GenreID"  runat="server" placeholder="Genre ID"></asp:TextBox> 
                               <asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="GenreID" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                               <asp:Button class="btn btn-primary" ID="GenreGo" CausesValidation="false"  runat="server" Text="Go" onclick="GenreGo_Click" /> 

                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Genre Name</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="GenreName"  runat="server" placeholder="Genre Name" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="GenreName" Text="Please Enter Name" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>


                   

                   <div class="row">
                     <div class="col-6 ">
                        <asp:Button ID="AddGenre" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" onclick="AddGenre_Click" />
                     </div>
                         <%--<div class="col-4 ">
                        <asp:Button ID="UpdateSup" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="UpdateSup_Click" />
                     </div>--%>
                     <div class="col-6 ">
                        <asp:Button ID="DeleteGenre" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" onclick="DeleteGenre_Click" />
                     </div>
                  </div>



                    </div>


                </div>




            </div>


            <div class="col-md-7">

                            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Genre list</h4>
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
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjDb1 %>" SelectCommand="SELECT * FROM [Genre_tbl]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Genre_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Genre_id" HeaderText="Genre_id" ReadOnly="True" SortExpression="Genre_id" />
                                <%--<asp:BoundField DataField="Genre_Name" HeaderText="Genre_Name" SortExpression="Genre_Name" />--%>

                                                                                      <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                             <div class="col-lg-12">
                                                 <div class="row">
                                                     <div class="col-12">
                                                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("Genre_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                     </div>
                                                 </div>
                         
                                                   
                                                 </div>

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
