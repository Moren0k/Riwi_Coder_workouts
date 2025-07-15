import { logout } from '../auth.js';
import { getEventById, updateEvent } from '../api.js';

export function editEventsView() {
  const app = document.getElementById('app');
  // Obtener id del evento de la URL/hash
  const params = new URLSearchParams(window.location.hash.split('?')[1]);
  const eventId = params.get('id');

  app.innerHTML = `
    <div class="container-fluid">
      <div class="row min-vh-100">
        <div class="col-md-3 col-lg-2 bg-light border-end d-flex flex-column align-items-center py-4">
          <small class="text-muted mb-3">Admin</small>
          <a href="#/dashboard/events" class="btn btn-outline-primary w-75 mb-2">Eventos</a>
          <a href="#/dashboard/events/create" class="btn btn-outline-primary w-75 mb-2">Agregar evento</a>
          <a href="#/login" id="logout-btn" class="btn btn-outline-secondary w-75">Cerrar sesión</a>
        </div>
        <div class="col-md-9 col-lg-10 d-flex justify-content-center align-items-center">
          <div class="bg-white p-4 shadow rounded w-100" style="max-width: 600px;">
            <h4 class="text-center mb-4">Editar Evento</h4>
            <form id="edit-event-form">
              <div class="mb-3">
                <label class="form-label">Nombre</label>
                <input type="text" class="form-control" id="event-name" placeholder="Nombre del Evento" required>
              </div>
              <div class="mb-3">
                <label class="form-label">Descripción</label>
                <textarea class="form-control" id="event-description" rows="3" placeholder="Descripción del Evento" required></textarea>
              </div>
              <div class="row g-3">
                <div class="col-md-6">
                  <label class="form-label">Fecha</label>
                  <input type="date" class="form-control" id="event-date" required>
                </div>
                <div class="col-md-6">
                  <label class="form-label">Capacidad</label>
                  <input type="number" class="form-control" id="event-capacity" placeholder="e.g. 50" required>
                </div>
              </div>
              <div class="mt-4 d-flex justify-content-end gap-2">
                <a href="#/dashboard/events" class="btn btn-outline-primary">Cancelar</a>
                <button type="submit" class="btn btn-primary">Guardar</button>
              </div>
              <div id="event-error" style="color:red; margin-top:10px;"></div>
            </form>
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

  // Cargar datos del evento
  const errorDiv = document.getElementById('event-error');
  getEventById(eventId).then(ev => {
    document.getElementById('event-name').value = ev.name;
    document.getElementById('event-description').value = ev.description;
    document.getElementById('event-date').value = ev.date;
    document.getElementById('event-capacity').value = ev.capacity;
  }).catch(err => {
    errorDiv.textContent = 'No se pudo cargar el evento.';
  });

  // Lógica para editar evento
  const form = document.getElementById('edit-event-form');
  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    const name = document.getElementById('event-name').value;
    const description = document.getElementById('event-description').value;
    const date = document.getElementById('event-date').value;
    const capacity = parseInt(document.getElementById('event-capacity').value, 10);
    errorDiv.textContent = '';
    try {
      await updateEvent(eventId, { name, description, date, capacity });
      window.location.hash = '/dashboard/events';
    } catch (err) {
      errorDiv.textContent = err.message;
    }
  });
} 