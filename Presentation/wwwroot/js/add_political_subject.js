document.getElementById('btnCall').addEventListener('click', getValue);

var input = document.getElementById("subjekti-politik");
input.addEventListener("keypress", function (event) {
    if (event.key === "Enter") {
        event.preventDefault();
        document.getElementById("btnCall").click();
    }
});



function getValue() {
    let value = document.getElementById("subjekti-politik").value;
    const data = { Text: value };
    fetch('https://localhost:7278/api/service/addpoliticalsubject', {

        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        method: 'post',

        body: JSON.stringify(data)
    }).then(() => getPoliticalSubjectByName(value))

        .then(() => {
            console.log(value);
            console.log(input.value);
            input.value = '';
        })

}





async function getPoliticalSubjectByName(name) {
    console.log(name);
    let endpoint = url + "getpoliticalsubjectbyname?name=" + name;
    let result = fetch(endpoint)
        .then(res => res.json())
        .then(data => {
            //alert('u thirr');
            //alert(data);
            console.log(data);
            data.forEach(x => {
                let tr = document.createElement("tr");
                let th = document.createElement('th');
                let td = document.createElement('td');
                let input = document.createElement('input');
                th.value = x.id;
                c++;
                console.log(c);
                th.innerText = x.name;
                th.classList = "parti";
                input.placeholder = "Shkruaj numrin e votave...";
                input.classList = "partyNumber border-0 votat w-100 ";
                if (c % 2 == 0) {
                    input.classList += "c";
                }
                input.type = "number";
                input.required = true;
                td.appendChild(input);
                tr.appendChild(th);
                tr.appendChild(td);
                rreshti.appendChild(tr);






            });
        }).then(() => numroVotat());
}