// Validate login fields before submitting
function validateLogin() {
    var username = document.getElementById("email").value;
  var password = document.getElementById("password").value;

  if (username === "") {
    alert("El campo correo no puede estar vacío");
    return false;
  }

  if (password === "") {
      alert("El campo password no puede estar vacío");
    return false;
  }

  return true;
}

// Attach the validateLogin function to the form's submit event
document.getElementById("loginForm").addEventListener("submit", function(event) {
  if (!validateLogin()) {
    event.preventDefault(); // Prevent form submission if validation fails
  }
});
