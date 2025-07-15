import { login } from '../auth.js';

export function loginView() {
  const app = document.getElementById('app');
  // Detectar si hay parámetro de rol en la URL
  const params = new URLSearchParams(window.location.hash.split('?')[1]);
  const roleParam = params.get('role');
  let roleMsg = '';
  let defaultUser = '';
  if (roleParam === 'admin') {
    roleMsg = '<div class="mb-2 text-primary">Login administrador</div>';
    defaultUser = 'Karina Henao';
  } else if (roleParam === 'visitor') {
    roleMsg = '<div class="mb-2 text-primary">Login usuario</div>';
  }
  app.innerHTML = `
    <section class="login">
      <h2>Iniciar Sesión</h2>
      ${roleMsg}
      <form id="loginForm">
        <input type="text" id="login-username" placeholder="Usuario" value="${defaultUser}" required />
        <input type="password" id="login-password" placeholder="Contraseña" required />
        <button type="submit">Entrar</button>
      </form>
      <div id="login-error" style="color:red;"></div>
      <div class="mt-3 text-center">
        <button id="go-register" class="btn btn-link">¿No tienes cuenta? Regístrate</button>
      </div>
    </section>
  `;

  const form = document.getElementById('loginForm');
  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    const username = document.getElementById('login-username').value;
    const password = document.getElementById('login-password').value;
    const errorDiv = document.getElementById('login-error');
    errorDiv.textContent = '';
    try {
      const user = await login({ username, password });
      // Redirigir según el rol y forzar recarga de la ruta
      if (user.role === 'admin') {
        window.location.hash = '/dashboard/events';
      } else {
        window.location.hash = '/dashboard/events-view';
      }
      // Forzar recarga de la ruta para actualizar menú y vista
      setTimeout(() => window.dispatchEvent(new HashChangeEvent('hashchange')), 0);
    } catch (err) {
      errorDiv.textContent = err.message;
    }
  });

  document.getElementById('go-register').onclick = () => {
    window.location.hash = '/register';
  };
} 