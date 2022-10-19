$('#streetByNeighborhood').hide();

$('#villages').change(function () {
    var selectedNeighborhood = $(this).children('option:selected').val();
    if (selectedNeighborhood != null) {
        $('#streetByNeighborhood').hide();
        $('#streetByVillage').show();
    }
})
$('#neigborhoodsVillage').change(function () {
    var selectedVillages = $(this).children('option:selected').val();
    if (selectedVillages != null) {
        $('#streetByNeighborhood').show();
        $('#streetByVillage').hide();
    }
})
$('#pollcenter-neighborhood-container').hide();

$('#villages').change(function () {
    var selectedVillage = $(this).children('option:selected').val();
    if (selectedVillage != null) {
        $('#pollcenter-neighborhood-container').hide();
        $('#pollcenter-villages-container').show();
    } villages
})
$('#neigborhoodsVillage').change(function () {
    var selectedNeighborhood = $(this).children('option:selected').val();
    if (selectedNeighborhood != null) {
        $('#pollcenter-neighborhood-container').show();
        $('#pollcenter-villages-container').hide();
    }
});

//const url = "https://eregisterpbc-001-site1.atempurl.com/"
const url = "https://localhost:7278/api/service/";
if (document.querySelector("#villages") != undefined) {
    getVillages();
}
else {
    addNeigborhoodVillageToList(@userVillageId);
    addStreetToList(@userVillageId);
    addPollCenterToList(@userVillageId)
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
        addNeigborhoodVillageToDb(@userVillageId);
        }
    });
streets.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addStreetToDb(@userVillageId);
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
    }).
        then((value) => {
            if (value == "") {

                console.log(value);
                swal("Ju lutem shkruani të dhëna valide!");
                return false;

            }
            else if (value !== null) {
                let sm = document.querySelector("#neigborhoodsVillage").value;
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
function addPollCenterToList(userVillageId) {
    poll.innerHTML = '';
    let chooseOption = document.createElement("option");
    chooseOption.innerText = "Zgjedh qendren e votimit...";
    chooseOption.selected = true;
    chooseOption.disabled = true;
    poll.appendChild(chooseOption);


    let endpoint = url + "getpollcenterbyvillage?villId=" + userVillageId;
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