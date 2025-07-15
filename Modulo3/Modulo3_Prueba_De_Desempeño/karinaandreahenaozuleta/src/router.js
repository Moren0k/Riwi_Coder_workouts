import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { notFoundView } from './views/notFoundView.js';
import { adminEventsView } from './views/adminEventsView.js';
import { createEventsView } from './views/createEventsView.js';
import { editEventsView } from './views/editEventsView.js';
import { enrollmentsView } from './views/enrollmentsView.js';
import { eventsView } from './views/eventsView.js';
import { getCurrentUser, isAuthenticated } from './auth.js';

const routes = {
  '/': () => (window.location.hash = '/login'), // Redirige a login
  '/login': loginView,
  '/register': registerView,
  '/dashboard': () => {
    const user = getCurrentUser();
    window.location.hash = user?.role === 'admin' 
      ? '/dashboard/events' 
      : '/dashboard/events-view';
  },
  '/dashboard/events': adminEventsView,
  '/dashboard/events/create': createEventsView,
  '/dashboard/events/edit': editEventsView,
  '/dashboard/enrollments': enrollmentsView,
  '/dashboard/events-view': eventsView,
};

const routeRoles = {
  '/dashboard/events': ['admin'],
  '/dashboard/events/create': ['admin'],
  '/dashboard/events/edit': ['admin'],
  '/dashboard/enrollments': ['visitor'],
  '/dashboard/events-view': ['visitor'],
};

export function router(path) {
  const user = getCurrentUser();
  const isAuth = isAuthenticated();

  if (!isAuth && path !== '/login' && path !== '/register') {
    window.location.hash = '/login';
    return;
  }

  if (isAuth && (path === '/login' || path === '/register')) {
    window.location.hash = '/dashboard';
    return;
  }

  if (routeRoles[path] && (!user || !routeRoles[path].includes(user.role))) {
    notFoundView();
    return;
  }

  const view = routes[path] || notFoundView;
  view();
}