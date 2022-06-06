chartsapp = {


  


  initchtBAR: function (pctx, plabels, pdataAreaAsia, pdataAreaAfrica, ptitle, legenddisplay,datalabelsdisplay) {

 

    //chartColor = "#FFFFFF";
    var colorIN = '#a037fc';
    var colorNM = '#3794fc';
    var colorNC = 'rgb(173,221,142)';
    var lineborderwidth = 0;
    var linepointBorderWidth = 1;


    var config_chtmon = {

      type: 'bar',
     
      data: {
        labels: [plabels[0], plabels[1], plabels[2], plabels[3], plabels[4], plabels[5]],//["JAN", "FEB", "MAR", "APR", "MAY", "JUN"],
        datasets: [{
          label: "Asia",
          
          fill: false,
          //data: [150, 15, 10, 190, 130, 90, 15, 160, 120, 14, 190, 395]
          data: [pdataAreaAsia[0], pdataAreaAsia[1], pdataAreaAsia[2], pdataAreaAsia[3], pdataAreaAsia[4], pdataAreaAsia[5], pdataAreaAsia[6], pdataAreaAsia[7], pdataAreaAsia[8], pdataAreaAsia[9], pdataAreaAsia[10], pdataAreaAsia[11]],//[150, 15, 10, 190, 130, 90, 15, 160, 120, 14, 190, 395]
          borderWidth: lineborderwidth,
          //borderColor: colorIN,
          //backgroundColor: colorIN,

          //pointBackgroundColor: colorIN,
          //pointBorderColor: colorIN,

          pointBorderWidth: linepointBorderWidth,

          datalabels: {
            align: 'end',
            anchor: 'end'
          }

        }, {
          label: "Africa",
          //borderColor: colorNM,
          //backgroundColor: colorNM,
          //pointBackgroundColor: colorNM,
          //pointBorderColor: colorNM,

          borderWidth: lineborderwidth,
          pointBorderWidth: linepointBorderWidth,

          fill: false,
          //data: [15, 150, 100, 19, 130, 90, 150, 16, 120, 140, 19, 195]
          data: [pdataAreaAfrica[0], pdataAreaAfrica[1], pdataAreaAfrica[2], pdataAreaAfrica[3], pdataAreaAfrica[4], pdataAreaAfrica[5], pdataAreaAfrica[6], pdataAreaAfrica[7], pdataAreaAfrica[8], pdataAreaAfrica[9], pdataAreaAfrica[10], pdataAreaAfrica[11]]//[15, 150, 100, 19, 130, 90, 150, 16, 120, 140, 19, 195]
          , datalabels: {
            align: 'end',
            anchor: 'end'
          }
        }
        



        ]
      },

      options: {
        title: {
          display: false,
          text: ptitle,
          position: 'top',
          //fontColor: 'rgba(255,255,255,.5)',
          fontSize: '18'
        },
         animation: {
            duration: 1400,
          },
        plugins: {
          datalabels: {
            display: datalabelsdisplay,
            //backgroundColor: function (context) {
            //  return context.dataset.backgroundColor;
            //},
            //borderRadius: 4,
            //color: 'white',
            font: {
              weight: 'normal'
            },
            //formatter: Math.round,
            //padding: 6
          },
          colorschemes: {

              scheme: 'brewer.SetOne4'//brewer.PuOr7,brewer.Paired12, office.Studio6, , tableau.JewelBright9,'tableau.ColorBlind10'
            //https://nagix.github.io/chartjs-plugin-colorschemes/colorchart.html
          },
          deferred: {
            //xOffset: 150,    defer until 150px of the canvas width are inside the viewport
            yOffset: '50%', // defer until 50% of the canvas height are inside the viewport
            delay: 250      // delay of 500 ms after the canvas is considered inside the viewport
          },

         
        },
          
        layout: {
          padding: {
            left: 20,
            right: 20,
            top: 0,
            bottom: 0
          }
        },
        maintainAspectRatio: false,
        tooltips: {
          backgroundColor: '#222',
          titleFontColor: '#eee',
          bodyFontColor: '#ccc',
          bodySpacing: 4,
          xPadding: 12,
          mode: "nearest",
          intersect: 0,
          position: "nearest"
        },
        legend: {
          position: "top",
          display: legenddisplay,
          labels: {
            //fontColor: 'rgb(255, 255, 255)',
            //usePointStyle: true,
            fillStyle: '#000000'
          }

        },
        scales: {
          yAxes: [{
            ticks: {
              //fontColor: "rgba(255,255,255,0.4)",
              fontStyle: "bold",
              beginAtZero: true,
              maxTicksLimit: 5,
              padding: 10
            },
            gridLines: {
              drawTicks: true,
              drawBorder: false,
              display: true,
              //color: "rgba(255,255,255,0.1)",
              zeroLineColor: "transparent"
            }

          }],
          xAxes: [{
            gridLines: {
              zeroLineColor: "transparent",
              display: false,

            },
            ticks: {
              padding: 10,
              //fontColor: "rgba(255,255,255,0.4)",
              fontStyle: "bold"
            }
          }]
        }
       
      }
    

    };

   
    
   var chtmon = new Chart(pctx, config_chtmon);
    
    



  }, //initchtBAR ends

  initchtPIE: function (pctx, plabels, pdata, legenddisplay,datalabelsdisplay) {
    

   

    var config_chtPie = {
      type: 'pie', data: {
       
        datasets: [{
          data: pdata //[40, 10, 5, 2, 20, 30, 2]
        }],
        labels: plabels //['January', ' February February February February', 'March1', 'April', 'May2 May2 May2 May2 May2', 'June', 'July']

      }, options: {
        responsive: true,
        //tooltips: {
        //  enabled: false
        //},
        legend: {
          position: "right",
          display: legenddisplay,
          //labels: {
          //  fontColor: 'rgb(255, 255, 255)',
          //  fillStyle: '#ffffff'
          //}

        },

        animation: {
          duration: 1400,
        },

        plugins: {
          datalabels: {
            display: datalabelsdisplay,
            //backgroundColor: function (context) {
            //  return context.dataset.backgroundColor;
            //},
            //borderRadius: 4,
            color: 'white',
            font: {
              weight: 'normal'
            },
            //formatter: Math.round,
            //padding: 6
          },
          colorschemes: {

            scheme: 'brewer.Paired12'//brewer.Paired12, office.Studio6, tableau.ColorBlind10, tableau.JewelBright9,'tableau.ColorBlind10'
            //https://nagix.github.io/chartjs-plugin-colorschemes/colorchart.html
          },
          deferred: {
            //xOffset: 150,    defer until 150px of the canvas width are inside the viewport
            yOffset: '50%', // defer until 50% of the canvas height are inside the viewport
            delay: 250      // delay of 500 ms after the canvas is considered inside the viewport
          }
        },


      },


    };


    //chtPie_MEIN.data.labels.push(plabels);
    var chtPie = new Chart(pctx, config_chtPie)

    
  }





};


// Change default options for ALL charts
Chart.helpers.merge(Chart.defaults.global.plugins.datalabels, {
  color: '#FFFFFF'
});

