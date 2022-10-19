function getValue() {
    let value = document.getElementById("subjekti-politik").value;
    const data = { Text: value };
    fetch('https://localhost:7278/api/service/addpoliticalsubject', {
        method: 'POST',
        headers: {
            Accept: 'application.json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then((response) => response.json())
        .then((data) => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}