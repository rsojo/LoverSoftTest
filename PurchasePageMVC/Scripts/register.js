// Assuming the form with id "register" exists in the HTML

// Get the form element
const registerForm = document.getElementsByTagName("form")[0];

// Add event listener to the form submit event
registerForm.addEventListener("submit", function (event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get the email and password input values
    const emailInput = document.getElementById("Email");
    const passwordInput = document.getElementById("Password");
    const passwordInput2 = document.getElementById("Password2");

    // Validate the email and password inputs
    if (emailInput.value.trim() === "" || passwordInput.value.trim() === "") {
        // Display an error message or perform any other validation logic
        alert("Email o contraseña invalidas");
        return;
    }
    // Validate the email format
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(emailInput.value.trim())) {
        // Display an error message or perform any other validation logic
        alert("El campo email debe contener una dirección de correo válida");
        return;
    }
    if (passwordInput2.value.trim() != passwordInput.value.trim()) {
        // Display an error message or perform any other validation logic
        alert("Los passwords deben coincidir");
        return;
    }

    // If the inputs are valid, submit the form
    registerForm.submit();
});
