const kqzrez = "/api/service/kqzresultsbymuni";
let response = fetch(kqzrez).then(res => res.json());
var lokaleChart = null;
var nacionaleChart = null;

async function getId() {

    const select = document.getElementById("munis").value
    const baseUrl = '/api/service/';
    const kqzrez = baseUrl + "kqzresultsbymuni?id=" + select;
    let response = await fetch(kqzrez).then(res => res.json());
    var data = [];
    response.forEach(x => {
        data.push(x)
    });


    const lastYear = data[select - 1].value.Nacionale["lastYear"];
    const thisYear = data[select - 1].value.Nacionale["thisYear"];

    const lastYearLocal = data[select - 1].value.Lokale["lastYear"];
    const thisYearLocal = data[select - 1].value.Lokale["thisYear"];

    const politicalSubjects = data[select - 1].value.Nacionale["politicSubjects"];

    document.getElementById("city-nacinale").innerText = `${data[select - 1].key} - Zgjedhjet Nacionale`;
    document.getElementById("city-lokale").innerText = `${data[select - 1].key} - Zgjedhjet Lokale`;

    let nLastYear = Object.keys(lastYear).length;
    let nThisYear = Object.keys(thisYear).length

    let localLastYear = Object.keys(lastYearLocal).length;
    let localThisYear = Object.keys(thisYearLocal).length;

    console.log("nacionale last year" + nLastYear)
    console.log("nacionale this year" + nThisYear)

    console.log("local last year" + localLastYear)
    console.log("local this year" + localThisYear)


    if (nLastYear <= 0 && nThisYear <= 0) {
        const nacionaleOptions = {
            series: [{
                name: 'Viti 2021',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
            }, {
                name: 'Tani',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
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

    }
    else if (nThisYear <= 0 && nLastYear > 0) {
        const nacionaleOptions = {
            series: [{
                name: 'Viti 2021',
                data: [lastYear[politicalSubjects[0]], lastYear[politicalSubjects[1]], lastYear[politicalSubjects[2]], lastYear[politicalSubjects[3]], lastYear[politicalSubjects[4]], lastYear[politicalSubjects[5]], lastYear[politicalSubjects[6]], lastYear[politicalSubjects[7]]]
            }, {
                name: 'Tani',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
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
    }
    else if (nThisYear > 0 && nLastYear <= 0) {
        const nacionaleOptions = {
            series: [{
                name: 'Viti 2021',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
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
    }
    else {
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
    }


    if (localLastYear <= 0 && localThisYear <= 0) {
        const lokaleOptions = {
            series: [{
                name: 'Viti 2021',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
            }, {
                name: 'Tani',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
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
    else if (localThisYear <= 0 && localLastYear > 0) {
        const lokaleOptions = {
            series: [{
                name: 'Viti 2021',
                data: [lastYearLocal[politicalSubjects[0]], lastYearLocal[politicalSubjects[1]], lastYearLocal[politicalSubjects[2]], lastYearLocal[politicalSubjects[3]], lastYearLocal[politicalSubjects[4]], lastYearLocal[politicalSubjects[5]], lastYearLocal[politicalSubjects[6]], lastYearLocal[politicalSubjects[7]]]
            }, {
                name: 'Tani',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
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
    else if (localThisYear > 0 && localLastYear <= 0) {
        const lokaleOptions = {
            series: [{
                name: 'Viti 2021',
                data: [0, 0, 0, 0, 0, 0, 0, 0]
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
    else {
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
}