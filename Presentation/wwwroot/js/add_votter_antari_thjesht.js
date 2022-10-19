$('#streetByVillage').hide();

$('#neigborhoodsVillage').change(function () {
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

var userNeigborhoodId = document.getElementById("get-user-neighborhoodId").value
var userVillageId = document.getElementById("get-user-villageId").value
var userMuniId = document.getElementById("get-user-muniId").value

//const url = "https://eregisterpbc-001-site1.atempurl.com/"
const url = "https://localhost:7278/api/service/";
if (document.querySelector("#neighborhoods") != undefined) {
    getneighborhoodsbymuni();
}
else {
    addStreetNeighborhoodToList(userNeigborhoodId);
    addPollCenterNeighborhoodToList(userNeigborhoodId);
}

if (document.querySelector("#munis") != undefined) {
    getMunis();
}
else {
    addBlockToList(userMuniId);
}
streetsNeighborhood.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == "shto") {
        addStreetNeighborhoodToDb(userNeigborhoodId);
                }
});
blocks.addEventListener('change', event => {
    event.preventDefault()
    if (event.target.value == 'shto') {
        addBlockToDb(userMuniId);
    }
});

function getneighborhoodsbymuni(userId) {
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

//street by neighborhood
function addStreetNeighborhoodToList(userNeigborhoodId) {
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

    let endpoint = url + "getstreetbyneighborhood?neighId=" + userNeigborhoodId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            streetsNeighborhood.appendChild(item);
        }));
}
function addStreetNeighborhoodToDb(userNeigborhoodId) {
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
                fetch(endpoint, {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'post',
                    body: JSON.stringify({ neighborhoodId: userNeigborhoodId, streetName: value })
                }).then(() => addStreetNeighborhoodToList(userNeigborhoodId));
            }

        })
}
//Poll Center
function addPollCenterNeighborhoodToList(userNeigborhoodId) {
    pollNeighborhood.innerHTML = '';
    let chooseOption = document.createElement("option");
    chooseOption.innerText = "Zgjedh qendren e votimit...";
    chooseOption.selected = true;
    chooseOption.disabled = true;
    pollNeighborhood.appendChild(chooseOption);

    let endpoint = url + "getpollcenterbyneigborhood?neighId=" + userNeigborhoodId;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => data.forEach(x => {
            let item = document.createElement("option");
            item.value = x.id;
            item.innerText = x.name;
            pollNeighborhood.appendChild(item);
        }));
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
