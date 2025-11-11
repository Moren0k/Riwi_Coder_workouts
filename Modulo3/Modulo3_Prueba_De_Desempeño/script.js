// Redirige al hacer clic en "Iniciar Sesión"
document.getElementById('new-user-button').addEventListener('click', function() {
  window.location.href = 'src/html/login.html';
});

// Redirige al hacer clic en "Registrarse"
document.getElementById('login-button').addEventListener('click', function() {
  window.location.href = 'src/html/register.html';
});

document.getElementById('registerForm').addEventListener('submit', function(event) {

  // Obtiene los valores de los campos del formulario
  const name = document.getElementById('name').value;
  const email = document.getElementById('email').value;
  const password = document.getElementById('password').value;

  // Crea un objeto de usuario
  const user = {
    name: name,
    email: email,
    password: password
  };    

  // Guarda el usuario en localStorage y en users.json haciendo un fetch
  localStorage.setItem('user', JSON.stringify(user));
  fetch('src/data/users.json', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(user)
  })

  .then(response => {
    if (!response.ok) {
      console.error('redirección fallida');
    }
    // Redirige a login.html
    window.location.href = 'src/html/login.html';
  })
  .catch(error => {
    console.error('Error:', error);
  });
});