import { logout, getCurrentUser } from '../auth.js';
import { getEvents, enrollEvent, getUserEnrollments } from '../api.js';

export function eventsView() {
  const app = document.getElementById('app');
  const user = getCurrentUser();

  app.innerHTML = `
    <nav class="navbar navbar-light bg-light border-bottom mb-3">
      <div class="container-fluid">
        <a class="navbar-brand" href="#/dashboard/events-view">Eventos (Visitante)</a>
        <div>
          <a href="#/dashboard/enrollments" class="btn btn-sm btn-outline-primary me-2">Mis inscripciones</a>
          <button id="logout-btn" class="btn btn-sm btn-outline-danger">Cerrar sesión</button>
        </div>
      </div>
    </nav>
    <div class="container-fluid">
      <div class="row min-vh-100">
        <div class="col-md-12 p-4">
          <h4 class="mb-4">Eventos Disponibles</h4>
          <div id="events-table-container">Cargando eventos...</div>
          <div id="enroll-error" style="color: red; margin-top: 10px;"></div>
          <div id="enroll-success" style="color: green; margin-top: 10px;"></div>
        </div>
      </div>
    </div>
  `;

  // Lógica de logout
  document.getElementById('logout-btn').addEventListener('click', () => {
    logout();
    window.location.hash = '/login';
  });

  const tableContainer = document.getElementById('events-table-container');
  const errorDiv = document.getElementById('enroll-error');
  const successDiv = document.getElementById('enroll-success');

  function loadEvents() {
    tableContainer.innerHTML = '<div class="text-center">Cargando eventos...</div>';
    Promise.all([
      getEvents(),
      getUserEnrollments(user.id)
    ]).then(([events, enrollments]) => {
      if (!events.length) {
        tableContainer.innerHTML = '<div class="alert alert-info">No hay eventos disponibles.</div>';
        return;
      }

      let rows = events.map(ev => {
        const isEnrolled = enrollments.some(enr => enr.eventId === ev.id);
        const isFull = enrollments.filter(enr => enr.eventId === ev.id).length >= ev.capacity;
        
        let btn = isEnrolled 
          ? '<button class="btn btn-sm btn-secondary" disabled>Inscrito</button>'
          : isFull
            ? '<button class="btn btn-sm btn-secondary" disabled>Agotado</button>'
            : `<button class="btn btn-sm btn-primary" data-id="${ev.id}">Inscribirse</button>`;

        return `
          <tr>
            <td><img src="event.jpg" width="60" alt="Evento"></td>
            <td>${ev.name}</td>
            <td>${ev.description}</td>
            <td>${enrollments.filter(enr => enr.eventId === ev.id).length}/${ev.capacity}</td>
            <td>${ev.date}</td>
            <td>${btn}</td>
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
              <th>Inscritos/Capacidad</th>
              <th>Fecha</th>
              <th>Acción</th>
            </tr>
          </thead>
          <tbody>${rows}</tbody>
        </table>
      `;
    }).catch(err => {
      tableContainer.innerHTML = `<div class="alert alert-danger">${err.message}</div>`;
    });
  }

  // Event delegation para los botones dinámicos
  document.getElementById('events-table-container').addEventListener('click', async (e) => {
    if (e.target.matches('button[data-id]')) {
      const eventId = parseInt(e.target.getAttribute('data-id'), 10);
      errorDiv.textContent = '';
      successDiv.textContent = '';
      
      try {
        console.log('Intentando inscribir al evento:', eventId);
        const result = await enrollEvent({ userId: user.id, eventId });
        console.log('Inscripción exitosa:', result);
        successDiv.textContent = '¡Inscripción exitosa!';
        loadEvents(); // Recargar la lista
      } catch (err) {
        console.error('Error al inscribirse:', err);
        errorDiv.textContent = err.message;
      }
    }
  });

  loadEvents();
}