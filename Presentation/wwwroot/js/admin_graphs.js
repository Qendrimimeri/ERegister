
//const kqzrez = "http://eregisterpbc-001-site1.atempurl.com/api/service/kqzresultsbymuni";

const kqzrez = "https://localhost:7278/api/service/kqzresultsbymuni";
let response = fetch(kqzrez).then(res => res.json());
//let rez = response.then((values) => {

//    console.log(values)
//    const lastYear = values.Nacionale["lastYear"];
//    const thisYear = values.Nacionale["thisYear"];
//    const cityName = values.Nacionale["cityName"];
//    const politicalSubjects = values.Nacionale["politicSubjects"];
//    var selectedCity = document.getElementById("city-nacinale").innerText = `${cityName} - Zgjedhjet Nacionale`;
//    var selectedCity = document.getElementById("city-lokale").innerText = `${cityName} - Zgjedhjet Lokale`;
//    new ApexCharts(document.querySelector("#columnChart"), {
//        series: [{
//            name: 'Viti 2021',
//            data: [lastYear[politicalSubjects[0]], lastYear[politicalSubjects[1]], lastYear[politicalSubjects[2]], lastYear[politicalSubjects[3]], lastYear[politicalSubjects[4]], lastYear[politicalSubjects[5]], lastYear[politicalSubjects[6]], lastYear[politicalSubjects[7]]]
//        }, {
//            name: 'Tani',
//            data: [thisYear[politicalSubjects[0]], thisYear[politicalSubjects[1]], thisYear[politicalSubjects[2]], thisYear[politicalSubjects[3]], thisYear[politicalSubjects[4]], thisYear[politicalSubjects[5]], thisYear[politicalSubjects[6]], thisYear[politicalSubjects[7]]]
//        }],
//        chart: {
//            type: 'bar',
//            height: 350
//        }, colors: ['#339af0', '#f76707'],
//        stroke: {
//            curve: 'smooth',
//            width: 0.5,
//        },
//        plotOptions: {
//            bar: {
//                horizontal: false,
//                columnWidth: '55%',
//                endingShape: 'rounded'
//            },
//        },
//        dataLabels: {
//            enabled: false
//        },
//        stroke: {
//            show: true,
//            width: 2,
//            colors: ['transparent']
//        },
//        xaxis: {
//            categories: politicalSubjects,
//        },
//        fill: {
//            opacity: 1,
//            colors: ['#339af0', '#f76707']
//        },
//        tooltip: {
//            y: {
//                formatter: function (val) {
//                    return " " + val + " vota"
//                }
//            }
//        }
//    });
//}).render()
//response.then((results) => {
//    const lastYearLocal = results.Lokale["lastYear"]
//    const thisYearLocal = results.Lokale["thisYear"]
//    const politicalSubjects = results.Nacionale["politicSubjects"];
//    new ApexCharts(document.querySelector("#columnChart1"), {
//        series: [{
//            name: 'Viti 2021',
//            data: [lastYearLocal[politicalSubjects[0]], lastYearLocal[politicalSubjects[1]], lastYearLocal[politicalSubjects[2]], lastYearLocal[politicalSubjects[3]], lastYearLocal[politicalSubjects[4]], lastYearLocal[politicalSubjects[5]], lastYearLocal[politicalSubjects[6]], lastYearLocal[politicalSubjects[7]]]
//        }, {
//            name: 'Tani',
//            data: [thisYearLocal[politicalSubjects[0]], thisYearLocal[politicalSubjects[1]], thisYearLocal[politicalSubjects[2]], thisYearLocal[politicalSubjects[3]], thisYearLocal[politicalSubjects[4]], thisYearLocal[politicalSubjects[5]], thisYearLocal[politicalSubjects[6]], thisYearLocal[politicalSubjects[7]]]
//        }],
//        chart: {
//            type: 'bar',
//            height: 350
//        }, colors: ['#339af0', '#f76707'],
//        stroke: {
//            curve: 'smooth',
//            width: 0.5,
//        },
//        plotOptions: {
//            bar: {
//                horizontal: false,
//                columnWidth: '55%',
//                endingShape: 'rounded'
//            },
//        },
//        dataLabels: {
//            enabled: false
//        },
//        stroke: {
//            show: true,
//            width: 2,
//            colors: ['transparent']
//        },
//        xaxis: {
//            categories: politicalSubjects
//        },
//        fill: {
//            opacity: 1,
//            colors: ['#339af0', '#f76707']
//        },
//        tooltip: {
//            y: {
//                formatter: function (val) {
//                    return " " + val + " vota"
//                }
//            }
//        }
//    });
//}).render()

//const ChartLokale = new ApexCharts(document.querySelector("#columnChart1"));
var lokaleChart = null;
var nacionaleChart = null;

async function getId() {
    
    const select = document.getElementById("munis").value
    const baseUrl = 'https://localhost:7278/api/service/';
    const kqzrez = baseUrl + "kqzresultsbymuni?id=" + select;
    let response = await fetch(kqzrez).then(res => res.json());
    var data = [];

    response.forEach(x => {
        console.log(x)
        data.push(x)
    });

    console.log(data)
    const lastYear = data[select - 1].value.Nacionale["lastYear"];
    const thisYear = data[select - 1].value.Nacionale["thisYear"];
    const cityName = data[select - 1].value.Nacionale["city"];
    const politicalSubjects = data[select - 1].value.Nacionale["politicSubjects"];
    var selectedCity = document.getElementById("city-nacinale").innerText = `${data[select - 1].key} - Zgjedhjet Nacionale`;
    var selectedCity = document.getElementById("city-lokale").innerText = `${data[select - 1].key} - Zgjedhjet Lokale`;

    const nacionaleOptions = {
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
    }

    if (this.nacionaleChart)
        this.nacionaleChart.destroy();

    this.nacionaleChart = await new ApexCharts(document.querySelector("#columnChart"), nacionaleOptions);
    this.nacionaleChart.render()

  //test.updateOptions(newOptions, true, true, true);

    const lastYearLocal = data[select - 1].value.Lokale["lastYear"]
    const thisYearLocal = data[select - 1].value.Lokale["thisYear"]

    const lokaleOptions = {
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
    }

    if (this.lokaleChart)
        this.lokaleChart.destroy();

    this.lokaleChart = await new ApexCharts(document.querySelector("#columnChart1"), lokaleOptions);
    this.lokaleChart.render()

    
}