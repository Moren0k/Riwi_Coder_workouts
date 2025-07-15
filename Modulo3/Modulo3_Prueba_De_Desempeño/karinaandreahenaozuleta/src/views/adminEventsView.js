import { logout, getCurrentUser } from '../auth.js';
import { getEvents, deleteEvent } from '../api.js';

export function adminEventsView() {
  const app = document.getElementById('app');
  const user = getCurrentUser(); // Asegúrate de importar getCurrentUser desde auth.js

  app.innerHTML = `
    <nav class="navbar navbar-light bg-light border-bottom mb-3">
      <div class="container-fluid">
        <a class="navbar-brand" href="#/dashboard/events">Eventos (Admin)</a>
        <button id="logout-btn" class="btn btn-sm btn-outline-danger">Cerrar sesión</button>
      </div>
    </nav>
    <div class="container-fluid">
      <div class="row min-vh-100">

        <div class="col-md-12 p-4">
          <h4 class="mb-4">Eventos</h4>
          <a href="#/dashboard/events/create" class="btn btn-primary mb-3">Crear nuevo evento</a>
          <div id="events-table-container">Cargando eventos...</div>
        </div>
      </div>
    </div>
  `;

  // Lógica de logout
  document.getElementById('logout-btn').addEventListener('click', () => {
    logout(); // Asegúrate de importar logout desde auth.js
    window.location.hash = '/login';
  });

  // Renderizar eventos dinámicamente
  const tableContainer = document.getElementById('events-table-container');
  const errorDiv = document.getElementById('event-delete-error');

  function loadEvents() {
    tableContainer.innerHTML = '<div class="text-center">Cargando eventos...</div>';
    getEvents().then(events => {
      if (!events.length) {
        tableContainer.innerHTML = '<div class="alert alert-info">No hay eventos registrados.</div>';
        return;
      }
      let rows = events.map(ev => `
        <tr>
          <td><img src="event.jpg" width="60" alt="Evento"></td>
          <td>${ev.name}</td>
          <td>${ev.description}</td>
          <td>${ev.capacity}</td>
          <td>${ev.date}</td>
          <td>
            <a href="#/dashboard/events/edit?id=${ev.id}" class="btn btn-sm btn-primary">Editar</a>
            <button class="btn btn-sm btn-danger" data-id="${ev.id}">Eliminar</button>
          </td>
        </tr>
      `).join('');
      tableContainer.innerHTML = `
        <table class="table table-bordered table-hover">
          <thead>
            <tr>
              <th>Imagen</th>
              <th>Nombre</th>
              <th>Descripción</th>
              <th>Capacidad</th>
              <th>Fecha</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            ${rows}
          </tbody>
        </table>
      `;
      // Lógica para eliminar evento
      document.querySelectorAll('button[data-id]').forEach(btn => {
        btn.addEventListener('click', async (e) => {
          const id = btn.getAttribute('data-id');
          if (confirm('¿Seguro que deseas eliminar este evento?')) {
            try {
              await deleteEvent(id);
              loadEvents();
            } catch (err) {
              errorDiv.textContent = err.message;
            }
          }
        });
      });
    }).catch(err => {
      tableContainer.innerHTML = `<div class="alert alert-danger">${err.message}</div>`;
    });
  }

  loadEvents();
} 