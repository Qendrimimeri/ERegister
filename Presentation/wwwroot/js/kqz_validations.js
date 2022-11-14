function getPollCenterId() {

    let poll = document.getElementById("poll").value;
    let pollNeighborhood = document.getElementById("pollNeighborhood").value;

    if (poll === null || poll === undefined) {
        const endpoint = '/api/service/KqzValidation?id=' + pollNeighborhood;
        let response = fetch(endpoint).then(x => x.json());
        response.then(y => {
            document.getElementById("response-village").innerText = y["value"];
        });
        document.querySelector(".validation-message").style.display = "none";
        const BreakException = {};
        const forma = document.querySelector("#forma");
        forma.addEventListener("submit", function (e) {
            let response = fetch(endpoint).then(x => x.json());
            response.then(y => {
                if (!(y["value"] === "Të dhënat janë të regjistruar për këtë qendër të votimit")) {
                    const parties = document.querySelectorAll(".partyNumber");
                    try {
                        parties.forEach(el => {
                            if (el.value === "") {
                                swal({
                                    title: "Ju lutem plotësoni tabelën me rezultatet e KQZ!",
                                    icon: "warning",
                                    button: "Plotëso rezultatet!",
                                }).then(okay => {
                                    if (okay) {
                                        const linku1 = document.getElementById('klasa1');
                                        const linku2 = document.getElementById('klasa2');
                                        linku1.classList.remove('active');
                                        linku2.classList.add('active');
                                        $('#table').show();
                                        $('#forma').hide();
                                        $('#titulli').hide();
                                    }
                                });
                                e.preventDefault();
                            }
                        });
                    } catch (err) {
                        if (err !== BreakException) throw err;
                    }
                }
            });
        });

    } else {
        const endpoint = '/api/service/KqzValidation?id=' + poll;
        let response = fetch(endpoint).then(x => x.json());
        response.then(y => {
            document.getElementById("response-city").innerText = y["value"];
        });
        const BreakException = {};
        const forma = document.querySelector("#forma");
        forma.addEventListener("submit", function (e) {
            let response = fetch(endpoint).then(x => x.json());
            console.log("form inside")
            response.then(y => {
                if (!(y["value"] === "Të dhënat janë të regjistruar për këtë qendër të votimit")) {
                    const parties = document.querySelectorAll(".partyNumber");
                    try {
                        parties.forEach(el => {
                            if (el.value === "") {
                                swal({
                                    title: "Ju lutem plotësoni tabelën me rezultatet e KQZ!",
                                    //text: "You clicked the button!",
                                    icon: "warning",
                                    button: "Plotëso rezultatet!",
                                }).then(okay => {
                                    if (okay) {
                                        const linku1 = document.getElementById('klasa1');
                                        const linku2 = document.getElementById('klasa2');
                                        linku1.classList.remove('active');
                                        linku2.classList.add('active');
                                        $('#table').show();
                                        $('#forma').hide();
                                        $('#titulli').hide();
                                    }
                                });
                            }
                            e.preventDefault();
                        });
                    } catch (err) {
                        if (err !== BreakException) throw err;
                    }
                }
            });
        });
    }
}