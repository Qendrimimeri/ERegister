function getPollCenterId() {
    let poll = document.getElementById("poll").value;
    let pollNeighborhood = document.getElementById("pollNeighborhood").value;

    if (poll === null || poll === "Zgjedh qendren e votimit..." || poll === undefined) {
        const endpoint = '/api/service/KqzValidation?id=' + pollNeighborhood;
        let response = fetch(endpoint).then(x => x.json());
        response.then(y => {
            var show = document.getElementById("response-village").innerText = y["value"];
        });

    } else {
        const endpoint = '/api/service/KqzValidation?id=' + poll;
        let response = fetch(endpoint).then(x => x.json());
        response.then(y => {
            var show = document.getElementById("response-city").innerText = y["value"];
        });
    }
}