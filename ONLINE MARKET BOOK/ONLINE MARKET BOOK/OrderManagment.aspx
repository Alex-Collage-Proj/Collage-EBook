<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="OrderManagment.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm20" %>
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
                           <h4>Order Details</h4>
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
                        <label>Order ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox Class="form-control" ID="OrderID" runat="server" placeholder="Order ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqField" runat="server" ControlToValidate="OrderID" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                               <asp:Button class="btn btn-primary" ID="OrderGo" CausesValidation="false" runat="server" Text="Go" onclick="OrderGo_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Customer ID</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="CustomerID" runat="server" placeholder="Customer ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>


                   <div class="row">

                         <div class="col-md-6">
                        <label>Order Date</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="OrderD" runat="server" placeholder="Order Date" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>

                            <div class="col-md-6">
                        <label>Order Status</label>
                        <div class="form-group">
                            <div class="input-group">
                           <asp:TextBox Class="form-control" ID="Status" runat="server" placeholder="Order Status" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Status" Text="*" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:Button Class="btn btn-success" ID="StatusYes" runat="server" Text="V" OnClick="StatusYes_Click" />
                                </div>
                        </div>
                     </div>
                   </div>

                   <%--<div class="row">
                   
                         <div class="col-4 ">
                        <asp:Button ID="UpdateSup" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="UpdateSup_Click" />
                     </div>
                   
                  </div>--%>



                    </div>


                </div>




            </div>


            <div class="col-md-7">

                            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Order list</h4>
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
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProjDb1 %>" SelectCommand="SELECT * FROM [Order_tbl]"></asp:SqlDataSource>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Order_Id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="Order_Id" HeaderText="Order_Id" ReadOnly="True" SortExpression="Order_Id" />
                                <asp:BoundField DataField="Customer_Id" HeaderText="Customer_Id" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Order_Date" HeaderText="Order_Date" SortExpression="Order_Date" />
                                <asp:BoundField DataField="Order_Status" HeaderText="Order_Status" SortExpression="Order_Status" />

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
