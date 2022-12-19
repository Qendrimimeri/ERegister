var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0');
var yyyy = today.getFullYear();
today = yyyy + '-' + mm + '-' + dd;
$('#year').attr('max', today);
$('#table').hide();
$('#streetByNeighborhood').hide();
$('#neigborhoodsVillage').change(function () {
    var selectedVillages = $(this).children('option:selected').val();
    if (selectedVillages != null) {
        $('#streetByNeighborhood').show();
        $('#streetByVillage').hide();
    }
})
$('#pollcenter-neighborhood-container').hide();
$('#neigborhoodsVillage').change(function () {
    var selectedNeighborhood = $(this).children('option:selected').val();
    if (selectedNeighborhood != null) {
        $('#pollcenter-neighborhood-container').show();
        $('#pollcenter-villages-container').hide();
    }
});

var userVillageId = document.getElementById("get-user-villageId").value
var userMuniId = document.getElementById("get-user-muniId").value

const url = "/api/service/";
if (document.querySelector("#villages") != undefined) {
    getVillages();
}
else {
    addNeigborhoodVillageToList(userVillageId);
    addStreetToList(userVillageId);
    addPollCenterToList(userVillageId)
}
neigborhoodsVillage.addEventListener('change', event => {
    if (event.target.value !== "shto") {
        addStreetNeighborhoodToList(event.target.value);
        addPollCenterNeighborhoodToList(event.target.value);
    }
    else {
    }
});
neigborhoodsVillage.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == "shto") {
        addNeigborhoodVillageToDb(userVillageId);
    }
});
streets.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addStreetToDb(userVillageId);
    }
});
streetsNeighborhood.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == "shto") {
        addStreetNeighborhoodToDb();
    }
});
function getVillages(userId) {
    let endpoint = url + "getmunis";
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => {
            data.forEach(x => {
                let item = document.createElement("option");
                item.value = x.id;
                item.innerText = x.name;
            });
        });
}
//neigborhood by village
function addNeigborhoodVillageToList(userVillageId) {
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
    let endpoint = url + "getneighborhoodsbyvillage?villId=" + userVillageId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            neigborhoodsVillage.appendChild(item);
        }));
}
function addNeigborhoodVillageToDb(userVillageId) {
    let endpoint = url + "addneighborhoodbyvillage";
    let input = swal("Shto lagje te re:", {
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
            fetch(endpoint, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: 'post',
                body: JSON.stringify({ villageId: userVillageId, neighborhoodName: value })
            }).then(() => addNeigborhoodVillageToList(userVillageId));
        });
}
//street by village
function addStreetToList(userVillageId) {
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
    let endpoint = url + "getstreetbyvillage?villId=" + userVillageId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            streets.appendChild(item);
        }));
}
function addStreetToDb(userVillageId) {
    let endpoint = url + "addstreetbyvillage";
    let input = swal("Shto rruge te re", {
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
            fetch(endpoint, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: 'post',
                body: JSON.stringify({ villageId: userVillageId, streetName: value })
            }).then(() => addStreetToList(userVillageId));
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
    let input = swal("Shto rruge te re:", {
        content: "input",
        buttons: {
            cancel: "Anulo",
            confirm: {
                text: "Shto",
                className: "test",
            }
        }
    }).
        then((value) => {
            if (value == "" || value.match(/\d/)) {
                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;
            }
            let sm = document.querySelector("#neigborhoodsVillage").value;
            fetch(endpoint, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: 'post',
                body: JSON.stringify({ neighborhoodId: sm, streetName: value })
            }).then(() => addStreetNeighborhoodToList(sm));
        })
}
//poll center by village
function addPollCenterToList(userVillageId) {
    poll.innerHTML = '';
    let chooseOption = document.createElement("option");
    chooseOption.innerText = "Zgjedh qendrën e votimit...";
    chooseOption.selected = true;
    chooseOption.disabled = true;
    poll.appendChild(chooseOption);
    let addOption = document.createElement("option");
    addOption.innerText = "Shto qendrën e re...";
    addOption.value = "shto";
    poll.appendChild(addOption);
    let endpoint = url + "getpollcenterbyvillage?villId=" + userVillageId;
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
    chooseOption.innerText = "Zgjedh qendrën e votimit...";
    chooseOption.selected = true;
    chooseOption.disabled = true;
    pollNeighborhood.appendChild(chooseOption);
    let addOption = document.createElement("option");
    addOption.innerText = "Shto qendrën e re...";
    addOption.value = "shto";
    pollNeighborhood.appendChild(addOption);
    let endpoint = url + "getpollcenterbyneigborhood?neighId=" + neighId;   ///////neigh?????
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.centerNumber;
            pollNeighborhood.appendChild(item);
        }));
}


const button = document.getElementById('main-button');
const butoni = document.getElementById('second-button');
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
button.addEventListener('click', event => {
    addDataToDb();
});
butoni.addEventListener('click', event => {
    addDataToDb();
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
    let endpoint = url + "addpollcenter";
    let input = swal("Emri i qendrës së votimit:", {
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

            if (value) {
                let sm2 = document.querySelector("#neigborhoodsVillage");
                console.log(sm2);
                var sm;
                console.log(sm)
                if (sm2.selectedIndex !== 0) {
                    sm = sm2.options[sm2.selectedIndex].value;
                }
                else {
                    sm = null;
                }
                console.log(sm)
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({
                        centerNumber: value,
                        centerName: "", municipalitydId: userMuniId, neighborhoodId: sm, villageId: userVillageId
                    })
                })
                    .then(() => addPollCenterNeighborhoodToList(sm))
                    .then(() => addPollCenterToList(userVillageId));

            }



        });
}