<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="SupManagment.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm16" %>
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
                           <h4>Supplier Details</h4>
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
                        <label>Sup ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox Class="form-control" ID="SupID" runat="server" placeholder="Sup ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="SupID" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                               <asp:Button class="btn btn-primary" ID="SupGo" CausesValidation="false" runat="server" Text="Go" onclick="SupGo_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Sup Name</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="SupName" runat="server" placeholder="Sup Name" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SupName" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>


                   <div class="row">

                         <div class="col-md-12">
                        <label>Country</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="CountryName" runat="server" placeholder="Country" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CountryName" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                        </div>
                     </div>
                   </div>

                   <div class="row">
                     <div class="col-4 ">
                        <asp:Button ID="AddSup" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" onclick="AddSup_Click" />
                     </div>
                         <div class="col-4 ">
                        <asp:Button ID="UpdateSup" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="UpdateSup_Click" />
                     </div>
                     <div class="col-4 ">
                        <asp:Button ID="DeleteSup" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" onclick="DeleteSup_Click" />
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
                           <h4>Supplier list</h4>
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
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjDb1 %>" SelectCommand="SELECT * FROM [Supplier_tbl]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Sup_Id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Sup_Id" HeaderText="Sup_Id" ReadOnly="True" SortExpression="Sup_Id" />
                               
                                <%--<asp:BoundField DataField="Sup_Name" HeaderText="Sup_Name" SortExpression="Sup_Name" />
                                <asp:BoundField DataField="Sup_Country" HeaderText="Sup_Country" SortExpression="Sup_Country" />--%>

                                                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                             <div class="col-lg-12">
                                                 <div class="row">
                                                     <div class="col-12">
                                                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("Sup_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                     </div>
                                                 </div>
                                                    <div class="row">
                                                     <div class="col-12">


                                                        

                                                         

                                                         Country-<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Sup_Country") %>'></asp:Label>


                                                        

                                                         

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
