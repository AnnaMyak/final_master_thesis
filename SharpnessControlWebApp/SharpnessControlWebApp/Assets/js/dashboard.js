var commonChartData =
           {
               labels: ["negative Schärfe-Teste", "positive Schärfe-Teste"],
               datasets: [{
                   backgroundColor: [
                       "#e62e00",
                       "#00b300",
                   ],
                   borderWidth: 2,
                   data: [@ViewBag.TotalNumberNegative , @ViewBag.TotalNumberPositive]
               }]
           };





var ctx1 = document.getElementById("commonChart").getContext("2d");
new Chart(ctx1,
    {
        type: 'pie',
        data: commonChartData,
        options:
            {
                title:
                {
                    display: true,
                    text: "Statistik von positiven und negativen Schärfe-Testen"
                },
                responsive: true,
                maintainAspectRatio: true
            }
    });


// Stains Bar chart

var stains = @Html.Raw(Json.Encode(ViewBag.Stains));
var stainsValues = @Html.Raw(Json.Encode(ViewBag.StainsValues));
var stainsColor = @Html.Raw(Json.Encode(ViewBag.StainsColor));

new Chart(document.getElementById("stainChart"), {
    type: 'bar',
    data: {
        labels: stains,
        datasets: [
          {
              backgroundColor: stainsColor,
              data: stainsValues
          }
        ]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: 'Statistik nach Färbungen vom letzten Monat'
        }
    }
});

// Organs Bar chart

var organs = @Html.Raw(Json.Encode(ViewBag.Organs));
var organsValues = @Html.Raw(Json.Encode(ViewBag.OrgansValues));
var organsColor = @Html.Raw(Json.Encode(ViewBag.OrgansColor));

new Chart(document.getElementById("organChart"), {
    type: 'bar',
    data: {
        labels: organs,
        datasets: [
          {
              backgroundColor: organsColor,
              data: organsValues
          }
        ]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: 'Statistik nach Organen vom letzten Monat'
        }
    }
});


// Tissues Bar chart

var tissues = @Html.Raw(Json.Encode(ViewBag.Tissues));
var tissuesValues = @Html.Raw(Json.Encode(ViewBag.TissuesValues));
var tissuesColor = @Html.Raw(Json.Encode(ViewBag.TissuesColor));

new Chart(document.getElementById("tissueChart"), {
    type: 'bar',
    data: {
        labels: tissues,
        datasets: [
          {
              backgroundColor: tissuesColor,
              data: tissuesValues
          }
        ]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: 'Statistik nach Gewebearten vom letzten Monat'
        }
    }
});



// Dynamics Bar chart

var months = @Html.Raw(Json.Encode(ViewBag.Months));
var monthsValues = @Html.Raw(Json.Encode(ViewBag.MonthsValues));
var monthsColor = @Html.Raw(Json.Encode(ViewBag.MonthsColor));

new Chart(document.getElementById("dynamicChart"), {
    type: 'bar',
    data: {
        labels: months,
        datasets: [
          {
              backgroundColor:  monthsColor,
              data: monthsValues
          }
        ]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: 'Dynamic des letzten Jahres'
        }
    }
});
