const API_URL = 'http://localhost:3000';
let currentUser = JSON.parse(localStorage.getItem('currentUser')) || null;

// Credenciales quemadas para admin
const ADMIN_CREDENTIALS = {
  username: 'Karina Henao',
  password: '123456',
  role: 'admin'
};

export async function register({ username, password, role }) {
  const res = await fetch(`${API_URL}/users?username=${encodeURIComponent(username)}`);
  const users = await res.json();
  if (users.length > 0) throw new Error('El usuario ya existe');

  const response = await fetch(`${API_URL}/users`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ username, password, role })
  });
  if (!response.ok) throw new Error('Error al registrar usuario');
  return await response.json();
}

export async function login({ username, password }) {
  // Primero, verificar si es admin
  if (
    username === ADMIN_CREDENTIALS.username &&
    password === ADMIN_CREDENTIALS.password
  ) {
    currentUser = { ...ADMIN_CREDENTIALS, id: 1 };
    localStorage.setItem('currentUser', JSON.stringify(currentUser));
    return currentUser;
  }
  // Si no es admin, buscar en la base de datos de usuarios visitantes
  const res = await fetch(`${API_URL}/users?username=${encodeURIComponent(username)}&password=${encodeURIComponent(password)}&role=visitor`);
  const users = await res.json();
  if (users.length === 0) throw new Error('Usuario o contraseña incorrectos o no registrado');
  currentUser = users[0];
  localStorage.setItem('currentUser', JSON.stringify(currentUser));
  return currentUser;
}

export function logout() {
  currentUser = null;
  localStorage.removeItem('currentUser');
}

export function getCurrentUser() {
  return currentUser;
}

export function isAuthenticated() {
  return !!currentUser;
}
