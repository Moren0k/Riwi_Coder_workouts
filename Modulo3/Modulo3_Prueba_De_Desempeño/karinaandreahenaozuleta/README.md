# Instrucciones para levantar el proyecto

## Requisitos previos

- Node.js y npm instalados
- json-server instalado globalmente o usar `npx`

### Instalación y ejecución

```bash
npm install
npm start
```

Esto levantará el servidor en `http://localhost:3000`

### Estructura

- `public/index.html` → entrada de la aplicación SPA
- `src/` → lógica de vistas, rutas, API y autenticación
- `db.json` → base de datos simulada

La primera vista al ejecutar es el login, si no está registrado se registra, las credenciales del admin ya deben estar quemadas, por lo cual es la única persona que puede mirar las vistas de adminEventsView.js y createEvent.js, deben tener el mismo login pero cualquier persona que se registre o inicie sesion entonces tendrá el rol de visitante (El de las credenciales quemadas por defecto es el admin), además en eventsView.js debe haber un botón para inscribirse al evento (En caso de que ya haya superado el aforo se muestra "sold out"), al mismo tiempo en enrollments.js deben aparecer los eventos a los cuales se inscribió con toda la información. Cosas que no son necesarias: archivo "navigation.js" y sus asociados en los otros archivos. el homeView.js tampoco es necesario y el mainView.js tampoco
