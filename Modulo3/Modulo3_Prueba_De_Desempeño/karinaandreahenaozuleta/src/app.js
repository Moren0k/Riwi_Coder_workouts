import { router } from './router.js';

function handleRouteChange() {
  const path = window.location.hash.replace('#', '') || '/';
  router(path);
}

window.addEventListener('hashchange', handleRouteChange);
window.addEventListener('DOMContentLoaded', handleRouteChange);
