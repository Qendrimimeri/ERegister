response.then((results) => {
    const lastYearLocal = results[select - 1].value.Lokale["lastYear"]
    const thisYearLocal = results[select - 1].value.Lokale["thisYear"]
    const politicalSubjects = results[select - 1].value.Nacionale["politicSubjects"];
    new ApexCharts(document.querySelector("#columnChart1"), {
        series: [{
            name: 'Viti 2021',
            data: [lastYearLocal[politicalSubjects[0]], lastYearLocal[politicalSubjects[1]], lastYearLocal[politicalSubjects[2]], lastYearLocal[politicalSubjects[3]], lastYearLocal[politicalSubjects[4]], lastYearLocal[politicalSubjects[5]], lastYearLocal[politicalSubjects[6]], lastYearLocal[politicalSubjects[7]]]
        }, {
            name: 'Tani',
            data: [thisYearLocal[politicalSubjects[0]], thisYearLocal[politicalSubjects[1]], thisYearLocal[politicalSubjects[2]], thisYearLocal[politicalSubjects[3]], thisYearLocal[politicalSubjects[4]], thisYearLocal[politicalSubjects[5]], thisYearLocal[politicalSubjects[6]], thisYearLocal[politicalSubjects[7]]]
        }],
        chart: {
            type: 'bar',
            height: 350
        }, colors: ['#339af0', '#f76707'],
        stroke: {
            curve: 'smooth',
            width: 0.5,
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: politicalSubjects
        },
        fill: {
            opacity: 1,
            colors: ['#339af0', '#f76707']
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return " " + val + " vota"
                }
            }
        }
    }).render();
})


let rez = response.then((values) => {
    const lastYear = values[select - 1].value.Nacionale["lastYear"];
    const thisYear = values[select - 1].value.Nacionale["thisYear"];
    const cityName = values[select - 1].value.Nacionale["city"];
    const politicalSubjects = values[select - 1].value.Nacionale["politicSubjects"];
    var selectedCity = document.getElementById("city-nacinale").innerText = `${values[select - 1].key} - Zgjedhjet Nacionale`;
    var selectedCity = document.getElementById("city-lokale").innerText = `${values[select - 1].key} - Zgjedhjet Lokale`;
    new ApexCharts(document.querySelector("#columnChart"), {
        series: [{
            name: 'Viti 2021',
            data: [lastYear[politicalSubjects[0]], lastYear[politicalSubjects[1]], lastYear[politicalSubjects[2]], lastYear[politicalSubjects[3]], lastYear[politicalSubjects[4]], lastYear[politicalSubjects[5]], lastYear[politicalSubjects[6]], lastYear[politicalSubjects[7]]]
        }, {
            name: 'Tani',
            data: [thisYear[politicalSubjects[0]], thisYear[politicalSubjects[1]], thisYear[politicalSubjects[2]], thisYear[politicalSubjects[3]], thisYear[politicalSubjects[4]], thisYear[politicalSubjects[5]], thisYear[politicalSubjects[6]], thisYear[politicalSubjects[7]]]
        }],
        chart: {
            type: 'bar',
            height: 350
        }, colors: ['#339af0', '#f76707'],
        stroke: {
            curve: 'smooth',
            width: 0.5,
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: politicalSubjects,
        },
        fill: {
            opacity: 1,
            colors: ['#339af0', '#f76707']
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return " " + val + " vota"
                }
            }
        }
    }).render();
})