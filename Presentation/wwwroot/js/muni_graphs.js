
const munis = document.querySelector('#munis');

//const url = "https://eregisterpbc-001-site1.atempurl.com/"
const url = "https://localhost:7278/api/service/";
getMunis();
function getMunis(id) {
    let endpoint = url + "getmunis";
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => {
            data.forEach(x => {
                let item = document.createElement("option");
                item.value = x.id;
                item.innerText = x.name;
                munis.appendChild(item);
            });
        });
}

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

    const lastYearLocal = data[select - 1].value.Lokale["lastYear"]
    const thisYearLocal = data[select - 1].value.Lokale["thisYear"]
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
}