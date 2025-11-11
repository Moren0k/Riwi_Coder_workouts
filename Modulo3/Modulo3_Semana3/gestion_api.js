const url = "http://localhost:3000/productos";

// Get all products stored on the server and display the data in the console
function obtenerProductos(url) {
  fetch(url)
    .then(response => response.json())
    .then(data => console.log("Productos disponibles: ", data))
    .catch(error => console.error("Error al obtener los productos: ", error));
}

// Add a new product to the server collection, validating the data before sending
const nuevoProducto = { "id": 4, "nombre": "Monitor", "precio": 200 };

function agregarProducto(url, producto) {
  if (validarProducto(producto)) {
    fetch(url, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(producto)
    })
      .then(response => response.json())
      .then(data => console.log("Producto agregado: ", data))
      .catch(error => console.error("Error al agregar el producto: ", error));
  } else {
    console.error("Producto no válido: ", producto);
  }
}

// Update the properties of an existing product
const productoActualizado = { "id": 1, "nombre": "Laptop Actualizada", "precio": 1400 };

function actualizarProducto(url, producto) {
  if (validarProducto(producto)) {
    fetch(`${url}/${producto.id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(producto)
    })
      .then(response => response.json())
      .then(data => console.log("Producto actualizado: ", data))
      .catch(error => console.error("Error al actualizar el producto: ", error));
  } else {
    console.error("Producto no válido: ", producto);
  }
}

// Delete a product from the server based on its ID
const productoId = 3;

function eliminarProducto(url, id) {
  fetch(`${url}/${id}`, {
    method: "DELETE"
  })
    .then(() => console.log("Producto eliminado"))
    .catch(error => console.error("Error al eliminar el producto: ", error));
}

// Validations and error handling
function validarProducto(producto) {
  if (!producto.nombre || typeof producto.precio !== 'number') {
    console.error("Producto inválido: ", producto);
    return false;
  }
  return true;
}

// Execute the functions
obtenerProductos(url);
agregarProducto(url, nuevoProducto);
actualizarProducto(url, productoActualizado);
eliminarProducto(url, productoId);
