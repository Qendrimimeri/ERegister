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


$('#villages').change(function () {

    var selectedNeighborhood = $(this).children('option:selected').val();
    if (selectedNeighborhood != null) {
        $('#streetByNeighborhood').hide();
        $('#streetByVillage').show();
    } 
})

$('#neighborhoods').change(function () {

    var selectedVillages = $(this).children('option:selected').val();
    if (selectedVillages != null) {
        $('#streetByNeighborhood').show();
        $('#streetByVillage').hide();
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

var userMuniId = document.getElementById("get-user-muniId").value
var userVillageId = document.getElementById("get-user-villageId").value
var userNeigborhoodId = document.getElementById("get-user-neighborhoodId").value


const url = "/api/service/";
if (document.querySelector("#munis") != undefined) {
    getMunis();
}
else {
    addVillagesToList(userMuniId);
    addNeigborhoodToList(userMuniId);
    addBlockToList(userMuniId);
}
villages.addEventListener('change', event => {
    if (event.target.value !== "shto") {
        addNeigborhoodVillageToList(event.target.value);
        addStreetToList(event.target.value);
        addPollCenterToList(event.target.value);
    }
    else {

    }
});
neigborhoods.addEventListener('change', event => {
    if (event.target.value !== "shto") {
        addStreetNeighborhoodToList(event.target.value);
        addPollCenterNeighborhoodToList(event.target.value);
    }
    else {

    }
});
villages.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addVillageToDb(userMuniId);

         }
     });

neigborhoods.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addNeigborhoodToDb(userMuniId);

             }
     });

blocks.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addBlockToDb(userMuniId);

            }
     });

streets.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addStreetToDb(userVillageId);
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
poll.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addPollCenterToDb(userMuniId);
    }
});

function getMunis(userId) {
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
//villages
function addVillagesToList(userMuniId) {
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

    let endpoint = url + "GetVillagesByMuni?muniid=" + userMuniId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            villages.appendChild(item);
        }));
}
function addVillageToDb(userMuniId) {
    let endpoint = url + "addvillage";
    let input = swal("Shto fshat të ri:", {
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
                body: JSON.stringify({ MunicipalityId: userMuniId, villageName: value })
            }).then(() => addVillagesToList(userMuniId));
        });
}
//neigborhoods
function addNeigborhoodToList(userMuniId) {
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

    let endpoint = url + "getneighborhoodsbymuni?muniId=" + userMuniId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            neigborhoods.appendChild(item);
        }));
}
function addNeigborhoodToDb(userMuniId) {
    let endpoint = url + "addneighborhood";
    let input = swal("Shto lagje te re :", {
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
                body: JSON.stringify({ MunicipalityId: userMuniId, neighborhoodName: value })
            }).then(() => addNeigborhoodToList(userMuniId));
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
function addBlockToList(userMuniId) {
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

    let endpoint = url + "getblocksbymuni?muniid=" + userMuniId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            blocks.appendChild(item);
        }));
}
function addBlockToDb(userMuniId) {
    let endpoint = url + "addblock";
    let input = swal("Shto bllok te ri:", {
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
            fetch(endpoint, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: 'post',
                body: JSON.stringify({ MunicipalityId: userMuniId, blockName: value })
            }).then(() => addBlockToList(userMuniId));
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
    let input = swal("Emri i rrugës", {
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
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ villageId: userVillageId, streetName: value })
                }).then(() => addStreetToList(userVillageId));
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
function addPollCenterToDb(villId) {
    let endpoint = url + "addpollcenterbyvillage";
    let input = swal("Shto qender te re:", {
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
            fetch(endpoint, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: 'post',
                body: JSON.stringify({ villageId: sm, blockName: value })
            }).then(() => addPollCenterToList(sm));
        });
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
    console.log(neigborhoods.value);
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

            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;
            }

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
                console.log(sm)

                let munis = document.getElementById('munis');

                let villages = document.getElementById('villages');
                var villagess;
                if (villages.selectedIndex !== 0) {
                    villagess = villages.options[villages.selectedIndex].value;
                }
                console.log(villagess)
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({
                        centerNumber: value,
                        centerName: "", municipalitydId: userMuniId, neighborhoodId: sm, villageId: villagess
                    })
                }).then(() => addPollCenterNeighborhoodToList(sm))

                    .then(() => addPollCenterToList(villagess));

            }
        });
}
