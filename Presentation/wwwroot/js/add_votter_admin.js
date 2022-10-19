$('#neigborhoodsVillage-container').hide();
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

const munis = document.querySelector('#munis');
const url = "https://localhost:7278/api/service/";
getMunis();
munis.addEventListener('change', event => {
    addVillagesToList(event.target.value);
    addNeigborhoodToList(event.target.value);
    addBlockToList(event.target.value);
});
villages.addEventListener('change', event => {
    addNeigborhoodVillageToList(event.target.value);
    addStreetToList(event.target.value);
    addPollCenterToList(event.target.value);
});
neigborhoods.addEventListener('change', event => {
    addStreetNeighborhoodToList(event.target.value);
    addPollCenterNeighborhoodToList(event.target.value);
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
    let input = swal("Emri i fshatit: ", {
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
            else if (value !== null) {
                //let selectedMuni = $('#munis').val();
                let sm = document.querySelector("#munis").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ municipalityId: sm, villageName: input })
                }).then(() => addVillagesToList(sm));
            }
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
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#munis").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ municipalityId: sm, neighborhoodName: value })
                }).then(() => addNeigborhoodToList(sm));
            }
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
}
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
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#munis").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ municipalityId: sm, villageName: value })
                }).then(() => addVillagesToList(sm));
            }
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
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#munis").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ municipalityId: sm, neighborhoodName: value })
                }).then(() => addNeigborhoodToList(sm));
            }
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
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#villages").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ villageId: sm, neighborhoodName: value })
                }).then(() => addNeigborhoodVillageToList(sm));
            }
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
            else if (value !== null) {
                let sm = document.querySelector("#munis").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ municipalityId: sm, blockName: value })
                }).then(() => addBlockToList(sm));
            }
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
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#villages").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ villageId: sm, streetName: input })
                }).then(() => addStreetToList(sm));
            }
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
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#neigborhoods").value;
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ neighborhoodId: sm, streetName: value })
                }).then(() => addStreetNeighborhoodToList(sm));
            }
        })
}
//poll center by village
function addPollCenterToList(villId) {
    poll.innerHTML = '';
    let chooseOption = document.createElement("option");
    chooseOption.innerText = "Zgjedh qendren e votimit...";
    chooseOption.selected = true;
    chooseOption.disabled = true;
    poll.appendChild(chooseOption);
    let endpoint = url + "getpollcenterbyvillage?villId=" + villId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
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
    let endpoint = url + "getpollcenterbyneigborhood?neighId=" + neighId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            pollNeighborhood.appendChild(item);
        }));
}