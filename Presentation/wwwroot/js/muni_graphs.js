const kqzrez = "/api/service/kqzresultsbymuni";
let response = fetch(kqzrez).then(res => res.json());
let rez = response.then((data) => {
    document.getElementById("city-nacinale").innerText = `${data.Nacionale.cityName} - Zgjedhjet Nacionale`;
    document.getElementById("city-lokale").innerText = `${data.Nacionale.cityName} - Zgjedhjet Lokale`;

    console.log(data)

    const lastYear = data.Nacionale["lastYear"];
    const thisYear = data.Nacionale["thisYear"];

    const lastYearLocal = data.Lokale["lastYear"];
    const thisYearLocal = data.Lokale["thisYear"];

    const politicalSubjects = data.Nacionale["politicSubjects"];

    let nLastYear = Object.keys(lastYear).length;
    let nThisYear = Object.keys(thisYear).length

    let localLastYear = Object.keys(lastYearLocal).length;
    let localThisYear = Object.keys(thisYearLocal).length;

    console.log("nacionale last year" + nLastYear)
    console.log("nacionale this year" + nThisYear)

    console.log("local last year" + localLastYear)
    console.log("local this year" + localThisYear)


    if (nLastYear <= 0 && nThisYear <= 0) {
        new ApexCharts(document.querySelector("#columnChart"), {
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
        }).render()
    }
    else if (nThisYear <= 0 && nLastYear > 0) {
        new ApexCharts(document.querySelector("#columnChart"),
            {
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
            }).render();
    }
    else if (nThisYear > 0 && nLastYear <= 0) {
        new ApexCharts(document.querySelector("#columnChart"), {
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
        }).render();
    }
    else {
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
    }



    if (localLastYear <= 0 && localThisYear <= 0) {
        new ApexCharts(document.querySelector("#columnChart1"), {
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
        }).render();
    }
    else if (localThisYear <= 0 && localLastYear > 0) {
        new ApexCharts(document.querySelector("#columnChart1"), {
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
        }).render();
    }
    else if (localThisYear > 0 && localLastYear <= 0) {
        new ApexCharts(document.querySelector("#columnChart1"), {
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
        }).render();
    }
    else {
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
})