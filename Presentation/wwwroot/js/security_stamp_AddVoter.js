const newTogglePassword = document
    .querySelector('#newTogglePassword');

const newPassword = document.querySelector('#newPassword');

newTogglePassword.addEventListener('click', () => {
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

//AddVoter Fjalekalimi ToggleEye
const confirmTogglePassword = document
    .querySelector('#confirmTogglePassword');

const confirmPassword = document.querySelector('#confirmPassword');

confirmTogglePassword.addEventListener('click', () => {

    const newType1 = confirmPassword
        .getAttribute('type') === 'password' ?
        'text' : 'password';

    confirmPassword.setAttribute('type', newType1);

    // Toggle the eye and bi-eye icon
    if (document.querySelector('#confirmTogglePassword').classList.contains('bi-eye-slash')) {
        document.querySelector('#confirmTogglePassword').classList.remove('bi-eye-slash');
        document.querySelector('#confirmTogglePassword').classList.add('bi-eye');
    }
    else {
        document.querySelector('#confirmTogglePassword').classList.remove('bi-eye');
        document.querySelector('#confirmTogglePassword').classList.add('bi-eye-slash');
    }

});