        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0');
        var yyyy = today.getFullYear();
        today = yyyy + '-' + mm + '-' + dd;
        $('#year').attr('max', today);
        $('#neigborhoodsVillage-container').hide();
        $('#table').hide();
        $('#villages').change(function () {
            var selectedVillage = $(this).children('option:selected').val();
            if (selectedVillage != null) {
                $('#neigborhoods-container').hide();
                $('#neigborhoodsVillage-container').show();
            }
        })
        $('#munis').change(function () {
            var selectedMunis = $(this).children('option:selected').val();
            if (selectedMunis != null) {
                $('#neigborhoods-container').show();
                $('#neigborhoodsVillage-container').hide();
            }
        });
        $('#streetByVillage').hide();
        $('#neighborhoods').change(function () {
            var selectedNeighborhood = $(this).children('option:selected').val();
            if (selectedNeighborhood != null) {
                $('#streetByVillage').hide();
                $('#streetByNeighborhood').show();
            }
        })
        $('#villages').change(function () {
            var selectedVillages = $(this).children('option:selected').val();
            if (selectedVillages != null) {
                $('#streetByVillage').show();
                $('#streetByNeighborhood').hide();
            }
        })
        $('#pollcenter-villages-container').hide();
        $('#neigborhoods').change(function () {
            var selectedVillage = $(this).children('option:selected').val();
            if (selectedVillage != null) {
                $('#pollcenter-villages-container').hide();
                $('#pollcenter-neighborhood-container').show();
            }
        })
        $('#villages').change(function () {
            var selectedNeighborhood = $(this).children('option:selected').val();
            if (selectedNeighborhood != null) {
                $('#pollcenter-villages-container').show();
                $('#pollcenter-neighborhood-container').hide();
            }
        });
        const poll1 = document.getElementById('pollNeighborhood');
        const poll2 = document.getElementById('poll');
        poll1.addEventListener('change', event => {
            event.preventDefault();
            if (event.target.value == 'shto') {
                addPollToDb();
            }
        });
        poll2.addEventListener('change', event => {
            event.preventDefault();
            if (event.target.value == 'shto') {
                addPollToDb();
            }
        });
        function addPollToDb() {
            //console.log(neigborhoods.value);
            let endpoint = url + "addpollcenter";
            let input = swal("Emri i qendrës së votimit: ", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {

                    //var villagess;
                    if (value) {
                        let sm1 = document.querySelector("#neigborhoods");
                        console.log(sm1);
                        let sm2 = document.querySelector("#neigborhoodsVillage");
                        console.log(sm2);
                        var sm;
                        console.log(sm)
                        if (sm1.selectedIndex !== 0) {
                            sm = sm1.options[sm1.selectedIndex].value;
                        } else if (sm2.selectedIndex !== 0) {
                            sm = sm2.options[sm2.selectedIndex].value;
                        }
                        else {
                            sm = null;
                        }
                        let munis = document.getElementById('munis');
                        let villages = document.getElementById('villages');
                        var villagess;
                        if (villages.selectedIndex !== 0) {
                            villagess = villages.options[villages.selectedIndex].value;
                        }
                        fetch(endpoint, {
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            method: 'post',
                            body: JSON.stringify({
                                centerNumber: value,
                                centerName: "", municipalitydId: munis.value, neighborhoodId: sm, villageId: villagess
                            })
                        })
                            .then(() => addPollCenterNeighborhoodToList(sm))
                            .then(() => addPollCenterToList(villagess));
                    }
                });
        }

        const munis = document.querySelector('#munis');
        const villages = document.querySelector('#villages');
        const url = "/api/service/";
        var votat = document.getElementsByClassName('Votat');
        const tabela = document.getElementById('tabela');
        const neigborhoods = document.getElementById('neigborhoods');
        const neigborhoodsVillage = document.getElementById('neigborhoodsVillage');
        getMunis();
        async function getKqzResultByMuniId(muniId) {
            let shuma1 = 0, shuma2 = 0, shuma3 = 0, shuma4 = 0, shuma5 = 0, shuma6 = 0, shuma7 = 0, shuma8 = 0;
            let endpoint = url + "getkqzresult?muniId=" + muniId;
            let result = await fetch(endpoint)
                .then(res => res.json())
                .then(data => {
                    data.forEach(x => {
                        if (x.politicalSubject == 1) {
                            shuma1 += x.noOfVotes;
                            console.log(shuma1);
                        } else if (x.politicalSubject == 2) {
                            shuma2 += x.noOfVotes;
                            console.log(shuma2);
                        } else if (x.politicalSubject == 3) {
                            shuma3 += x.noOfVotes;
                            console.log(shuma3);
                        } else if (x.politicalSubject == 4) {
                            shuma4 += x.noOfVotes;
                            console.log(shuma4);
                        } else if (x.politicalSubject == 5) {
                            shuma5 += x.noOfVotes;
                            console.log(shuma5);
                        } else if (x.politicalSubject == 6) {
                            shuma6 += x.noOfVotes;
                            console.log(shuma6);
                        } else if (x.politicalSubject == 7) {
                            shuma7 += x.noOfVotes;
                            console.log(shuma7);
                        } else if (x.politicalSubject == 8) {
                            shuma8 += x.noOfVotes;
                            console.log(shuma8);
                        }
                    });
                });
            const vv = document.getElementById('vv');
            const ldk = document.getElementById('ldk');
            const aak = document.getElementById('aak');
            const akr = document.getElementById('akr');
            const nisma = document.getElementById('nisma');
            const serbe = document.getElementById('serbe');
            const joserbe = document.getElementById('joserbe');
            const pdk = document.getElementById('pdk');
            const span = document.getElementById('span');
            total = shuma1 + shuma2 + shuma3 + shuma4 + shuma5 + shuma6 + shuma7 + shuma8;
            vv.innerHTML = shuma1;
            ldk.innerHTML = shuma2;
            pdk.innerHTML = shuma3;
            aak.innerHTML = shuma4;
            akr.innerHTML = shuma5;
            nisma.innerHTML = shuma6;
            serbe.innerHTML = shuma7;
            joserbe.innerHTML = shuma8;
            span.innerHTML = total;
        }
        async function getKqzResultByVillageId(muniId) {
            let shuma1 = 0, shuma2 = 0, shuma3 = 0, shuma4 = 0, shuma5 = 0, shuma6 = 0, shuma7 = 0, shuma8 = 0;
            let endpoint = url + "getkqzresultbyvillage?muniId=" + muniId;
            let result = await fetch(endpoint)
                .then(res => res.json())
                .then(data => {
                    data.forEach(x => {
                        if (x.politicalSubject == 1) {
                            shuma1 += x.noOfVotes;
                            console.log(shuma1);
                        } else if (x.politicalSubject == 2) {
                            shuma2 += x.noOfVotes;
                            console.log(shuma2);
                        } else if (x.politicalSubject == 3) {
                            shuma3 += x.noOfVotes;
                            console.log(shuma3);
                        } else if (x.politicalSubject == 4) {
                            shuma4 += x.noOfVotes;
                            console.log(shuma4);
                        } else if (x.politicalSubject == 5) {
                            shuma5 += x.noOfVotes;
                            console.log(shuma5);
                        } else if (x.politicalSubject == 6) {
                            shuma6 += x.noOfVotes;
                            console.log(shuma6);
                        } else if (x.politicalSubject == 7) {
                            shuma7 += x.noOfVotes;
                            console.log(shuma7);
                        } else if (x.politicalSubject == 8) {
                            shuma8 += x.noOfVotes;
                            console.log(shuma8);
                        }
                    });
                });
            const vv = document.getElementById('vv');
            const ldk = document.getElementById('ldk');
            const aak = document.getElementById('aak');
            const akr = document.getElementById('akr');
            const nisma = document.getElementById('nisma');
            const serbe = document.getElementById('serbe');
            const joserbe = document.getElementById('joserbe');
            const pdk = document.getElementById('pdk');
            const span = document.getElementById('span');
            total = shuma1 + shuma2 + shuma3 + shuma4 + shuma5 + shuma6 + shuma7 + shuma8;
            vv.innerHTML = shuma1;
            ldk.innerHTML = shuma2;
            pdk.innerHTML = shuma3;
            aak.innerHTML = shuma4;
            akr.innerHTML = shuma5;
            nisma.innerHTML = shuma6;
            serbe.innerHTML = shuma7;
            joserbe.innerHTML = shuma8;
            span.innerHTML = total;
        }
        async function getKqzResultByNeighborhoodId(muniId) {
            let shuma1 = 0, shuma2 = 0, shuma3 = 0, shuma4 = 0, shuma5 = 0, shuma6 = 0, shuma7 = 0, shuma8 = 0;
            let endpoint = url + "getkqzresultbyneighborhood?muniId=" + muniId;
            let result = await fetch(endpoint)
                .then(res => res.json())
                .then(data => {
                    data.forEach(x => {
                        if (x.politicalSubject == 1) {
                            shuma1 += x.noOfVotes;
                            console.log(shuma1);
                        } else if (x.politicalSubject == 2) {
                            shuma2 += x.noOfVotes;
                            console.log(shuma2);
                        } else if (x.politicalSubject == 3) {
                            shuma3 += x.noOfVotes;
                            console.log(shuma3);
                        } else if (x.politicalSubject == 4) {
                            shuma4 += x.noOfVotes;
                            console.log(shuma4);
                        } else if (x.politicalSubject == 5) {
                            shuma5 += x.noOfVotes;
                            console.log(shuma5);
                        } else if (x.politicalSubject == 6) {
                            shuma6 += x.noOfVotes;
                            console.log(shuma6);
                        } else if (x.politicalSubject == 7) {
                            shuma7 += x.noOfVotes;
                            console.log(shuma7);
                        } else if (x.politicalSubject == 8) {
                            shuma8 += x.noOfVotes;
                            console.log(shuma8);
                        }
                    });
                });
            const vv = document.getElementById('vv');
            const ldk = document.getElementById('ldk');
            const aak = document.getElementById('aak');
            const akr = document.getElementById('akr');
            const nisma = document.getElementById('nisma');
            const serbe = document.getElementById('serbe');
            const joserbe = document.getElementById('joserbe');
            const pdk = document.getElementById('pdk');
            const span = document.getElementById('span');
            total = shuma1 + shuma2 + shuma3 + shuma4 + shuma5 + shuma6 + shuma7 + shuma8;
            vv.innerHTML = shuma1;
            ldk.innerHTML = shuma2;
            pdk.innerHTML = shuma3;
            aak.innerHTML = shuma4;
            akr.innerHTML = shuma5;
            nisma.innerHTML = shuma6;
            serbe.innerHTML = shuma7;
            joserbe.innerHTML = shuma8;
            span.innerHTML = total;
        }
        munis.addEventListener('change', event => {
            addVillagesToList(event.target.value);
            addNeigborhoodToList(event.target.value);
            addBlockToList(event.target.value);
            //getKqzResultByMuniId(event.target.value);
        });
        villages.addEventListener('change', event => {
            addNeigborhoodVillageToList(event.target.value);
            addStreetToList(event.target.value);
            addPollCenterToList(event.target.value);
            //getKqzResultByVillageId(event.target.value);
        });
        neigborhoodsVillage.addEventListener('change', event => {
            getKqzResultByNeighborhoodId(event.target.value);
            //console.log('u thirr 2');
        });
        neigborhoods.addEventListener('change', event => {
            addStreetNeighborhoodToList(event.target.value);
            addPollCenterNeighborhoodToList(event.target.value);
            //getKqzResultByNeighborhoodId(event.target.value);
            //console.log('u thirr 1');
        });
        villages.addEventListener('change', event => {
            event.preventDefault()
            if (event.target.value == 'shto') {
                addVillageToDb();
            }
        });
        neigborhoods.addEventListener('change', event => {
            event.preventDefault()
            if (event.target.value == 'shto') {
                addNeigborhoodToDb();
            }
        });
        blocks.addEventListener('change', event => {
            event.preventDefault()
            if (event.target.value == 'shto') {
                addBlockToDb();
            }
        });
        streets.addEventListener('change', event => {
            event.preventDefault()
            if (event.target.value == 'shto') {
                addStreetToDb();
            }
        });
        neigborhoodsVillage.addEventListener('change', event => {
            event.preventDefault()
            if (event.target.value == "shto") {
                addNeigborhoodVillageToDb();
            }
        });
        streetsNeighborhood.addEventListener('change', event => {
            event.preventDefault()
            if (event.target.value == "shto") {
                addStreetNeighborhoodToDb();
            }
        });
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
        function addVillagesToList(muniId) {
            villages.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh fshatin...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            villages.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto fshat te ri...";
            addOption.value = "shto";
            villages.appendChild(addOption);
            let endpoint = url + "getvillagesbymuni?muniid=" + muniId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.name;
                    villages.appendChild(item);
                }));
        }
        function addVillageToDb() {
            let endpoint = url + "addvillage";
            let input = swal("Emri i fshatit:", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {
                    if (value == "" || value.match(/\d/)) {
                        console.log(value);
                        swal("Ju lutem shkruani të dhëna valide!");
                        return false;
                    }
                    //let selectedMuni = $('#munis').val();
                    let sm = document.querySelector("#munis").value;
                    fetch(endpoint, {
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        method: 'post',
                        body: JSON.stringify({ municipalityId: sm, villageName: value })
                    }).then(() => addVillagesToList(sm));
                });
        }
        //neigborhoods
        function addNeigborhoodToList(muniId) {
            neigborhoods.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh lagjen...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            neigborhoods.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto lagjen e re...";
            addOption.value = "shto";
            neigborhoods.appendChild(addOption);
            let endpoint = url + "getneighborhoodsbymuni?muniid=" + muniId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.name;
                    neigborhoods.appendChild(item);
                }));
        }
        function addNeigborhoodToDb() {
            let endpoint = url + "addneighborhood";
            let input = swal("Emri i lagjes:", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {
                    if (value == "" || value.match(/\d/)) {
                        console.log(value);
                        swal("Ju lutem shkruani të dhëna valide!");
                        return false;
                    }
                    let sm = document.querySelector("#munis").value;
                    fetch(endpoint, {
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        method: 'post',
                        body: JSON.stringify({ municipalityId: sm, neighborhoodName: value })
                    }).then(() => addNeigborhoodToList(sm));
                });
        }
        //neigborhood by village
        function addNeigborhoodVillageToList(villId) {
            neigborhoodsVillage.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh lagjen...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            neigborhoodsVillage.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto lagjen e re...";
            addOption.value = "shto";
            neigborhoodsVillage.appendChild(addOption);
            let endpoint = url + "getneighborhoodsbyvillage?villId=" + villId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.name;
                    neigborhoodsVillage.appendChild(item);
                }));
            function addNeigborhoodVillageToDb() {
                let endpoint = url + "addneighborhoodbyvillage";
                let input = swal("Emri i lagjes:", {
                    content: "input",
                    buttons: {
                        cancel: "Anulo",
                        confirm: {
                            text: "Shto",
                            className: "test",
                        }
                    }
                })
                    .then((value) => {
                        if (value == "" || value.match(/\d/)) {
                            console.log(value);
                            swal("Ju lutem shkruani të dhëna valide!");
                            return false;
                        }
                        let sm = document.querySelector("#villages").value;
                        fetch(endpoint, {
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            method: 'post',
                            body: JSON.stringify({ villageId: sm, neighborhoodName: value })
                        }).then(() => addNeigborhoodVillageToList(sm));
                    });
            }
            //block
            function addBlockToList(muniId) {
                blocks.innerHTML = '';
                let chooseOption = document.createElement("option");
                chooseOption.innerText = "Zgjedh bllokun...";
                chooseOption.selected = true;
                chooseOption.disabled = true;
                blocks.appendChild(chooseOption);
                let addOption = document.createElement("option");
                addOption.innerText = "Shto bllok të ri...";
                addOption.value = "shto";
                blocks.appendChild(addOption);
                let endpoint = url + "getblocksbymuni?muniid=" + muniId;
                let result = fetch(endpoint)
                    .then(res => res.json())
                    .then(data => data.forEach(x => {
                        let item = document.createElement("option");
                        item.value = x.id;
                        item.innerText = x.name;
                        blocks.appendChild(item);
                    }));
            }
            function addBlockToDb() {
                let endpoint = url + "addblock";
                let input = swal("Emri i bllokut:", {
                    content: "input",
                    buttons: {
                        cancel: "Anulo",
                        confirm: {
                            text: "Shto",
                            className: "test",
                        }
                    }
                })
                    .then((value) => {
                        if (value == "") {
                            console.log(value);
                            swal("Ju lutem shkruani të dhëna valide!");
                            return false;
                        }
                        let sm = document.querySelector("#munis").value;
                        fetch(endpoint, {
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            method: 'post',
                            body: JSON.stringify({ municipalityId: sm, blockName: value })
                        }).then(() => addBlockToList(sm));
                    });
            }
            //street by village
            function addStreetToList(villId) {
                streets.innerHTML = '';
                let chooseOption = document.createElement("option");
                chooseOption.innerText = "Zgjedh rrugen...";
                chooseOption.selected = true;
                chooseOption.disabled = true;
                streets.appendChild(chooseOption);
                let addOption = document.createElement("option");
                addOption.innerText = "Shto rrugë te re...";
                addOption.value = "shto";
                streets.appendChild(addOption);
                let endpoint = url + "getstreetbyvillage?villId=" + villId;
                let result = fetch(endpoint)
                    .then(res => res.json())
                    .then(data => data.forEach(x => {
                        let item = document.createElement("option");
                        item.value = x.id;
                        item.innerText = x.name;
                        streets.appendChild(item);
                    }));
            }
            function addStreetToDb() {
                let endpoint = url + "addstreetbyvillage";
                let input = swal("Emri i rrugës:", {
                    content: "input",
                    buttons: {
                        cancel: "Anulo",
                        confirm: {
                            text: "Shto",
                            className: "test",
                        }
                    }
                })
                    .then((value) => {
                        if (value == "" || value.match(/\d/)) {
                            console.log(value);
                            swal("Ju lutem shkruani të dhëna valide!");
                            return false;
                        }
                        let sm = document.querySelector("#villages").value;
                        fetch(endpoint, {
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            method: 'post',
                            body: JSON.stringify({ villageId: sm, streetName: value })
                        }).then(() => addStreetToList(sm));
                    });
            }
            //street by neighborhood
            function addStreetNeighborhoodToList(neighId) {
                streetsNeighborhood.innerHTML = '';
                let chooseOption = document.createElement("option");
                chooseOption.innerText = "Zgjedh rrugen...";
                chooseOption.selected = true;
                chooseOption.disabled = true;
                streetsNeighborhood.appendChild(chooseOption);
                let addOption = document.createElement("option");
                addOption.innerText = "Shto rrugë te re...";
                addOption.value = "shto";
                streetsNeighborhood.appendChild(addOption);
                let endpoint = url + "getstreetbyneighborhood?neighId=" + neighId;
                let result = fetch(endpoint)
                    .then(res => res.json())
                    .then(data => data.forEach(x => {
                        let item = document.createElement("option");
                        item.value = x.id;
                        item.innerText = x.name;
                        streetsNeighborhood.appendChild(item);
                    }));
            }
            function addStreetNeighborhoodToDb() {
                let endpoint = url + "addstreetbyneighborhood";
                let input = swal("Emri i lagjes:", {
                    content: "input",
                    buttons: {
                        cancel: "Anulo",
                        confirm: {
                            text: "Shto",
                            className: "test",
                        }
                    }
                })
                    .then((value) => {
                        if (value == "" || value.match(/\d/)) {
                            console.log(value);
                            swal("Ju lutem shkruani të dhëna valide!");
                            return false;
                        }
                        let sm = document.querySelector("#neigborhoods").value;
                        fetch(endpoint, {
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            method: 'post',
                            body: JSON.stringify({ neighborhoodId: sm, streetName: value })
                        }).then(() => addStreetNeighborhoodToList(sm));
                    });
            }
        }
        function addNeigborhoodVillageToDb() {
            let endpoint = url + "addneighborhoodbyvillage";
            let input = swal("Emri i lagjes:", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {
                    if (value == "" || value.match(/\d/)) {
                        console.log(value);
                        swal("Ju lutem shkruani të dhëna valide!");
                        return false;
                    }
                    let sm = document.querySelector("#villages").value;
                    fetch(endpoint, {
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        method: 'post',
                        body: JSON.stringify({ villageId: sm, neighborhoodName: value })
                    }).then(() => addNeigborhoodVillageToList(sm));
                });
        }
        //block
        function addBlockToList(muniId) {
            blocks.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh bllokun...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            blocks.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto bllok të ri...";
            addOption.value = "shto";
            blocks.appendChild(addOption);
            let endpoint = url + "getblocksbymuni?muniid=" + muniId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.name;
                    blocks.appendChild(item);
                }));
        }
        function addBlockToDb() {
            let endpoint = url + "addblock";
            let input = swal("Emri i bllokut:", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {
                    if (value == "") {
                        console.log(value);
                        swal("Ju lutem shkruani të dhëna valide!");
                        return false;
                    }
                    let sm = document.querySelector("#munis").value;
                    fetch(endpoint, {
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        method: 'post',
                        body: JSON.stringify({ municipalityId: sm, blockName: value })
                    }).then(() => addBlockToList(sm));
                });
        }
        //street by village
        function addStreetToList(villId) {
            streets.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh rrugen...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            streets.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto rrugë te re...";
            addOption.value = "shto";
            streets.appendChild(addOption);
            let endpoint = url + "getstreetbyvillage?villId=" + villId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.name;
                    streets.appendChild(item);
                }));
        }
        function addStreetToDb() {
            let endpoint = url + "addstreetbyvillage";
            let input = swal("Emri i rrugës:", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {
                    if (value == "" || value.match(/\d/)) {
                        console.log(value);
                        swal("Ju lutem shkruani të dhëna valide!");
                        return false;
                    }
                    let sm = document.querySelector("#villages").value;
                    fetch(endpoint, {
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        method: 'post',
                        body: JSON.stringify({ villageId: sm, streetName: value })
                    }).then(() => addStreetToList(sm));
                });
        }
        //street by neighborhood
        function addStreetNeighborhoodToList(neighId) {
            streetsNeighborhood.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh rrugen...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            streetsNeighborhood.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto rrugë te re...";
            addOption.value = "shto";
            streetsNeighborhood.appendChild(addOption);
            let endpoint = url + "getstreetbyneighborhood?neighId=" + neighId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.name;
                    streetsNeighborhood.appendChild(item);
                }));
        }
        function addStreetNeighborhoodToDb() {
            let endpoint = url + "addstreetbyneighborhood";
            let input = swal("Emri i rrugës:", {
                content: "input",
                buttons: {
                    cancel: "Anulo",
                    confirm: {
                        text: "Shto",
                        className: "test",
                    }
                }
            })
                .then((value) => {
                    if (value == "" || value.match(/\d/)) {
                        console.log(value);
                        swal("Ju lutem shkruani të dhëna valide!");
                        return false;
                    }
                    let sm = document.querySelector("#neigborhoods").value;
                    fetch(endpoint, {
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        method: 'post',
                        body: JSON.stringify({ neighborhoodId: sm, streetName: value })
                    }).then(() => addStreetNeighborhoodToList(sm));
                });
        }
        //poll center by village
        function addPollCenterToList(villId) {
            poll.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh qendren e votimit...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            poll.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto qendren e re...";
            addOption.value = "shto";
            poll.appendChild(addOption);
            let endpoint = url + "getpollcenterbyvillage?villId=" + villId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.centerNumber;
                    poll.appendChild(item);
                }));
        }
        //poll center by neighborhood
        function addPollCenterNeighborhoodToList(neighId) {
            pollNeighborhood.innerHTML = '';
            let chooseOption = document.createElement("option");
            chooseOption.innerText = "Zgjedh qendren e votimit...";
            chooseOption.selected = true;
            chooseOption.disabled = true;
            pollNeighborhood.appendChild(chooseOption);
            let addOption = document.createElement("option");
            addOption.innerText = "Shto qendren e re...";
            addOption.value = "shto";
            pollNeighborhood.appendChild(addOption);
            let endpoint = url + "getpollcenterbyneigborhood?neighId=" + neighId;
            let result = fetch(endpoint)
                .then(res => res.json())
                .then(data => data.forEach(x => {
                    let item = document.createElement("option");
                    item.value = x.id;
                    item.innerText = x.centerNumber;
                    pollNeighborhood.appendChild(item);
                }));
        }
        $('#table').hide();
        const votes = document.getElementsByClassName("votat");
        var shuma = 0;
        var input;
        var vlera;
        for (let i = 0; i < votes.length; i++) {
            votes[i].addEventListener('focus', e => {
                e.preventDefault();
                vlera = 0;
                if (votes[i].value !== '') {
                    vlera = parseInt(votes[i].value);
                }
            });
            votes[i].addEventListener('blur', e => {
                e.preventDefault();
                input = parseInt(votes[i].value);
                if (!isNaN(input)) {
                    if (vlera !== 0) {
                        shuma = shuma - vlera;
                    }
                    shuma += input;
                    span.innerHTML = shuma;
                }
                else if (isNaN(input)) {
                    shuma = shuma - vlera;
                    span.innerHTML = shuma;
                }
            });
        }