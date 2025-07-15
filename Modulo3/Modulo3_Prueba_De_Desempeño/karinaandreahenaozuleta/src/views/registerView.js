import { register, login } from '../auth.js';

export function registerView() {
  const app = document.getElementById('app');
  app.innerHTML = `
    <section class="register">
      <h2>Registro</h2>
      <form id="registerForm">
        <input type="text" id="register-username" placeholder="Usuario" required />
        <input type="password" id="register-password" placeholder="Contraseña" required />
        <select id="register-role" required>
          <option value="">Selecciona un rol</option>
          <option value="visitor">Visitante</option>
        </select>
        <button type="submit">Registrarse</button>
      </form>
      <div id="register-error" style="color:red;"></div>
      <div id="register-success" style="color:green;"></div>
       <div class="mt-3 text-center">
        <button id="go-login" class="btn btn-link">¿Ya estás registrado? Inicia sesión </button>
      </div>
    </section>
  `;

  const form = document.getElementById('registerForm');
  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    const username = document.getElementById('register-username').value;
    const password = document.getElementById('register-password').value;
    const role = document.getElementById('register-role').value;
    const errorDiv = document.getElementById('register-error');
    const successDiv = document.getElementById('register-success');
    errorDiv.textContent = '';
    successDiv.textContent = '';
    try {
      await register({ username, password, role });
      // Login automático tras registro
      const user = await login({ username, password });
      // Redirigir según el rol (solo visitor)
      window.location.hash = '/dashboard/events-view';
    } catch (err) {
      errorDiv.textContent = err.message;
    }
  });

  document.getElementById('go-login').onclick = () => {
    window.location.hash = '/login';
  };
} 