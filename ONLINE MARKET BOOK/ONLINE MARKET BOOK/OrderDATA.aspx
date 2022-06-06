<%@ Page Title="" Language="C#" MasterPageFile="~/Skeleton.Master" AutoEventWireup="true" CodeBehind="OrderDATA.aspx.cs" Inherits="ONLINE_MARKET_BOOK.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


   <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.6.2/chart.min.js" integrity="sha512-tMabqarPtykgDtdtSqCL3uLVM0gS1ZkUAVhRFu1vSEFgvB73niFQWJuvviDyBGBH22Lcau4rHB5p2K2T0Xvr6Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
   <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.6.2/chart.min.js" integrity="sha512-tMabqarPtykgDtdtSqCL3uLVM0gS1ZkUAVhRFu1vSEFgvB73niFQWJuvviDyBGBH22Lcau4rHB5p2K2T0Xvr6Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>


 

     
    <style type="text/css">        .thick { border: 1px solid black; }         </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="about-company-section ">            <%--                       Changes Style       31.10        --%>        <div class="container p-1 p-sm-3 border rounded border-width:thin;" >             <%--                       Changes Style       31.10        --%>

            <div class="row">
                <div class="col-12 text-center">
                    <h2>Overall sells and income</h2> <hr />
                </div>
            </div>

         

        <div class="row">
            <div class="col-6">
               <center>  <h4>Start date</h4> <br />
                <input id="StartDate" runat="server" required="required"  type="text" name="birthday"  value="2021.10.01"  /> </center> <br /> <hr />

            </div>
            <div class="col-6">
             <center>    <h4>End date</h4> <br />
                <input id="EndDate" runat="server" required="required" type="text" name="birthday" value="2021.12.01" /> </center> <br /> <hr />

            </div>



        </div>
             

        <div class="row">
            <div class="col-6">
             <center>   <h5> Overall Sells</h5> <br /> <div class="col-3 thick">
                 <asp:label  ID="CountOfOrders" runat="server"></asp:label> </div>  </center>  
            </div>

            <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            <div class="col-6">
           <center> <h5> Overall income </h5> <br /> <div class="col-3 thick">  
               <asp:label  ID="SumOfAllOrders" runat="server"></asp:label> </div> </center>   
            </div>
                      
            
        </div>

             

            <div class="row">
                           <div class="col-5"></div>

                    <div class="col-2">
                      <asp:Button class="btn btn-block btn-light btn-lg"   ID="Calculate" runat="server" Text="Calculate" OnClick="Calculate_Click" /> 

                       </div>
          
              
    </div>

            <br />

           <div class="row">


                <div class="col-3"></div>
                     <div class="col-6">

       




<div style="width:550px;"><canvas id="myChart5" width="550" height="400"></canvas></div> 




        <script>
            const ctx5 = document.getElementById('myChart5').getContext('2d');
            const myChart5 = new Chart(ctx5, {
                type: 'bar',
                data: {
                    labels: [<asp:Literal id="LtlLabels" runat="server" />],
                    datasets: [{
                        label: [<asp:Literal id="LtlLabel" runat="server" />],
                        data: [<asp:Literal id="LtlData" runat="server" />],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ]
                    }, {
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        type: 'bar',
                        label: 'Amount of Sales',
                        data: [<asp:Literal id="LtlData1" runat="server" />],
                        backgroundColor: [
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(5, 12, 25, 0.2)',
                            'rgba(25, 26, 86, 0.2)',
                            'rgba(5, 19, 12, 0.2)',
                            'rgba(53, 2, 55, 0.2)',
                            'rgba(25, 59,64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(225, 9, 32, 1)',
                            'rgba(524, 12, 35, 1)',
                            'rgba(55, 26, 86, 1)',
                            'rgba(715, 92, 92, 1)',
                            'rgba(53, 12, 55, 1)',
                            'rgba(55, 59, 4, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });

        </script>











        </div>




                


        
           </div>   

        </section>


</asp:Content>
