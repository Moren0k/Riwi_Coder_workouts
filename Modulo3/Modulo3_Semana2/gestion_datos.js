//Inicio del programa
console.log("!Gestion de Datos con Objetos, Sets y Maps!\n");

//Definir el objeto productos
const productos = {
    1: {id:1, nombre:"Laptop", precio:100},
    2: {id:2, nombre:"Mause", precio:50},
    3: {id:3, nombre:"Teclado", precio:25},
};
// console.log("Objeto productos:", productos)

//Crear un set con los nombres de los productos
const setProductos = new Set(Object.values(productos).map(productos => productos.nombre));
// console.log("Set de productos únicos:", setProductos)

//Creacion del map
const mapProductos = new Map([
    ["Electronica", "Laptop"],
    ["Accesorios", "Mause"],
    ["Accesorio", "Teclado"]
]);
// console.log("Mapa de productos y Categorias:", mapProductos);

//Recorrer el objeto con for
for (const id in productos) {
    console.log(`Producto ID:${id}, Detalles:`, productos[id]);
};
console.log("\n")

//Recorrer el Set usando for..of
for (const producto of setProductos) {
    console.log("Producto único:", producto);
};
console.log("\n")

//Recorrer el Map usando forEach
mapProductos.forEach((producto, categoria) => {
  console.log(`Categoria: ${categoria}, producto: ${producto}`);
});

// console.log("-----------------------------------------------------------------------------------------------------------")
// console.log("Pruebas completas de getión de datos:");
// console.log("Lista de productos (Objetos):", productos);
// console.log("Lista de productos únicos (Set):", setProductos);
// console.log("Categorías y productos (Map):", mapProductos)