import { logout } from '../auth.js';
import { getUserEnrollments, getEvents } from '../api.js';
import { getCurrentUser } from '../auth.js';

export function enrollmentsView() {
  const app = document.getElementById('app');
  app.innerHTML = `
    <div class="container-fluid">
      <div class="row min-vh-100">
        <div class="col-md-3 col-lg-2 bg-light border-end d-flex flex-column align-items-center py-4">
          <small class="text-muted mb-3">Visitante</small>
          <a href="#/dashboard/enrollments" class="btn btn-outline-primary w-75 mb-2">Mis inscripciones</a>
          <a href="#/dashboard/events-view" class="btn btn-outline-secondary w-75 mb-2">Eventos</a>
          <a href="#/login" id="logout-btn" class="btn btn-outline-secondary w-75">Cerrar sesión</a>
        </div>
        <div class="col-md-9 col-lg-10 p-4">
          <h4 class="mb-4">Mis inscripciones</h4>
          <div id="enrollments-table-container">
            <div class="text-center">Cargando inscripciones...</div>
          </div>
        </div>
      </div>
    </div>
  `;
  const logoutBtn = document.getElementById('logout-btn');
  if (logoutBtn) {
    logoutBtn.addEventListener('click', (e) => {
      e.preventDefault();
      logout();
      window.location.hash = '/login';
    });
  }

  const tableContainer = document.getElementById('enrollments-table-container');
  const user = getCurrentUser();

  Promise.all([
    getUserEnrollments(user.id),
    getEvents()
  ]).then(([enrollments, events]) => {
    if (!enrollments.length) {
      tableContainer.innerHTML = '<div class="alert alert-info">No tienes inscripciones.</div>';
      return;
    }
    let rows = enrollments.map(enr => {
      const ev = events.find(e => e.id === enr.eventId);
      if (!ev) return '';
      return `
        <tr>
          <td><img src="event.jpg" width="60" alt="Evento"></td>
          <td>${ev.name}</td>
          <td>${ev.description}</td>
          <td>${ev.date}</td>
        </tr>
      `;
    }).join('');
    tableContainer.innerHTML = `
      <table class="table table-bordered table-hover">
        <thead>
          <tr>
            <th>Imagen</th>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Fecha</th>
          </tr>
        </thead>
        <tbody>
          ${rows}
        </tbody>
      </table>
    `;
  }).catch(err => {
    tableContainer.innerHTML = `<div class=\"alert alert-danger\">${err.message}</div>`;
  });
} 