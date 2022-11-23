function getPollCenterId() {
    let poll = document.getElementById("poll");
    let pollNeighborhood = document.getElementById("pollNeighborhood");

    if (document.getElementById("pollcenter-villages-container").style.display === "none") {
        const endpoint = '/api/service/KqzValidation?id=' + pollNeighborhood.value;
        let response = fetch(endpoint).then(x => x.json());
        response.then(y => {
            document.getElementById("response-village").innerText = y["value"];
        });

    } else {
        const endpoint = '/api/service/KqzValidation?id=' + poll.value;
        let response = fetch(endpoint).then(x => x.json());
        response.then(y => {
            document.getElementById("response-city").innerText = y["value"];
        });
    }
}