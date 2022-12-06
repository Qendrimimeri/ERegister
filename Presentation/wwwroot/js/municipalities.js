const url = "/api/service/";
getMunis();
function getMunis() {
    let endpoint = url + "getmunis";
    fetch(endpoint)
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

