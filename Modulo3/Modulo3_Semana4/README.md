# Interfaz Interactiva con Persistencia de Datos

El objetivo de esta hoja de trabajo es construir una página web interactiva que te permitirá aplicar tus conocimientos sobre el DOM y las herramientas de almacenamiento en el navegador. Crearás un sistema que:

- Manipule dinámicamente los elementos de una página utilizando JavaScript y el DOM
- Almacene y recupere información del Local Storage y Session Storage
- Valide los datos ingresados por el usuario y proporcione retroalimentación en tiempo real
  
---

Tu tarea es implementar las siguientes funcionalidades:

1. Crear un formulario HTML que capture el nombre y la edad del usuario.
2. Almacenar esta información en el Local Storage al hacer clic en un botón.
3. Mostrar los datos almacenados en la página cada vez que esta se recargue.
4. Implementar un contador de interacciones del usuario utilizando Session Storage.
5. Incluir un botón para limpiar los datos almacenados en el Local Storage

---

Funcionamiento del Código

    Guardar datos en LocalStorage:

        Los valores del formulario (nombre y edad) se guardan cuando se hace clic en "Guardar Datos".

        Los datos se muestran en la página.

    Mostrar los datos:

        Al cargar la página o después de guardar, se muestra el nombre y la edad en un div.

    Contador de interacciones:

        Cada vez que se hace clic en un botón, se incrementa un contador en SessionStorage.

    Limpiar datos:

        Al hacer clic en "Limpiar Datos", se eliminan los datos de LocalStorage y se actualiza la página.

Uso

    Ingresa tu nombre y edad en el formulario.

    Haz clic en "Guardar Datos" para almacenarlos.

    Haz clic en "Limpiar Datos" para eliminar los datos.
