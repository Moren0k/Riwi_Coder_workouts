

export function notFoundView() {
  const app = document.getElementById('app');
  app.innerHTML = `
    <section class="not-found">
      <h2>Página no encontrada</h2>
      <p>La ruta solicitada no existe.</p>
      <a href="#/login">Ir al inicio</a>
    </section>
  `;
} 