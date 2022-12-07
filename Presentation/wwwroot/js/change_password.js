$('document').ready(function () {
    $('#change-password').modal('show');
    $('#change-password').modal({
        backdrop: 'static',
        keyboard: false
    })

    $('#change-password').click(function () {
        let newPassword = document.getElementById('newPassword').value;
        let confirmPassword = document.getElementById('confirmPassword').value;
        console.log(newPassword);
        console.log(confirmPassword)
        if (newPassword !== confirmPassword) {
            document.getElementById("response-text").innerText = "Fjalëkalimi nuk përputhet!";
        } else {
            fetch('/api/service/changepasswordasync?password=' + confirmPassword, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: ""
            })
        }
    })
})
