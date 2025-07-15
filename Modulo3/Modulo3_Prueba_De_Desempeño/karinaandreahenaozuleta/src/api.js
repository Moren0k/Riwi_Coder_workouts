const API_URL = 'http://localhost:3000';

export async function getEvents() {
  const res = await fetch(`${API_URL}/events`);
  if (!res.ok) throw new Error('Error al obtener eventos');
  return await res.json();
}

export async function getEventById(id) {
  const res = await fetch(`${API_URL}/events/${id}`);
  if (!res.ok) throw new Error('Evento no encontrado');
  return await res.json();
}

export async function createEvent(event) {
  const res = await fetch(`${API_URL}/events`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(event)
  });
  if (!res.ok) throw new Error('Error al crear evento');
  return await res.json();
}

export async function updateEvent(id, event) {
  const res = await fetch(`${API_URL}/events/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(event)
  });
  if (!res.ok) throw new Error('Error al actualizar evento');
  return await res.json();
}

export async function deleteEvent(id) {
  const res = await fetch(`${API_URL}/events/${id}`, { method: 'DELETE' });
  if (!res.ok) throw new Error('Error al eliminar evento');
  return true;
}

export async function enrollEvent(enrollment) {
  const res = await fetch(`${API_URL}/enrollments`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(enrollment)
  });
  if (!res.ok) throw new Error('Error al inscribirse');
  return await res.json();
}

export async function getUserEnrollments(userId) {
  const res = await fetch(`${API_URL}/enrollments?userId=${userId}`);
  if (!res.ok) throw new Error('Error al obtener inscripciones del usuario');
  return await res.json();
}
