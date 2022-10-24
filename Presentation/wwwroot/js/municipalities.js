const url = "https://localhost:7278/api/service/";
getMunis();
function getMunis() {
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

