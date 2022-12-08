

//Fjalekalimi
const togglePassword = document
    .querySelector('#togglePassword');

    const password = document.querySelector('#password');

        togglePassword.addEventListener('click', () => {

            // Toggle the type attribute using
            // getAttribure() method
            const type = password
    .getAttribute('type') === 'password' ?
    'text' : 'password';

    password.setAttribute('type', type);

    // Toggle the eye and bi-eye icon
    if (document.querySelector('#togglePassword').classList.contains('bi-eye-slash')) {
        document.querySelector('#togglePassword').classList.remove('bi-eye-slash');
    document.querySelector('#togglePassword').classList.add('bi-eye');
            }
    else {
        document.querySelector('#togglePassword').classList.remove('bi-eye');
    document.querySelector('#togglePassword').classList.add('bi-eye-slash');
            }

        });


const togglePassword2 = document
    .querySelector('#togglePassword2');

const password2 = document.querySelector('#password2');

togglePassword2.addEventListener('click', () => {

    // Toggle the type attribute using
    // getAttribure() method
    const typeTest = password2
        .getAttribute('type') === 'password' ?
        'text' : 'password';

    password2.setAttribute('type', typeTest);

    // Toggle the eye and bi-eye icon
    if (document.querySelector('#togglePassword2').classList.contains('bi-eye-slash')) {
        document.querySelector('#togglePassword2').classList.remove('bi-eye-slash');
        document.querySelector('#togglePassword2').classList.add('bi-eye');
    }
    else {
        document.querySelector('#togglePassword2').classList.remove('bi-eye');
        document.querySelector('#togglePassword2').classList.add('bi-eye-slash');
    }

});

const togglePassword3 = document
    .querySelector('#togglePassword3');

const password3 = document.querySelector('#password3');

togglePassword3.addEventListener('click', () => {

    // Toggle the type attribute using
    // getAttribure() method
    const typeTest = password3
        .getAttribute('type') === 'password' ?
        'text' : 'password';

    password3.setAttribute('type', typeTest);

    // Toggle the eye and bi-eye icon
    if (document.querySelector('#togglePassword3').classList.contains('bi-eye-slash')) {
        document.querySelector('#togglePassword3').classList.remove('bi-eye-slash');
        document.querySelector('#togglePassword3').classList.add('bi-eye');
    }
    else {
        document.querySelector('#togglePassword3').classList.remove('bi-eye');
        document.querySelector('#togglePassword3').classList.add('bi-eye-slash');
    }

});


//AddVoter Fjalekalimi ToggleEye
const newTogglePassword = document
    .querySelector('#newTogglePassword');

const newPassword = document.querySelector('#newPassword');

togglePassword.addEventListener('click', () => {

    // Toggle the type attribute using
    // getAttribure() method
    const newType = newPassword
        .getAttribute('type') === 'password' ?
        'text' : 'password';

    newPassword.setAttribute('type', newType);

    // Toggle the eye and bi-eye icon
    if (document.querySelector('#newTogglePassword').classList.contains('bi-eye-slash')) {
        document.querySelector('#newTogglePassword').classList.remove('bi-eye-slash');
        document.querySelector('#newTogglePassword').classList.add('bi-eye');
    }
    else {
        document.querySelector('#newTogglePassword').classList.remove('bi-eye');
        document.querySelector('#newTogglePassword').classList.add('bi-eye-slash');
    }

});










