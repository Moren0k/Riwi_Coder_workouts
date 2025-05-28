productos = []
name_shop = ()

def validate_price_quantity():
    """Validar que el numero sea un número flotante o entero"""
    while True:
        try:
            precio = input("Ingrese el precio del producto: ")
            precio = float(precio)
            cantidad = input("Ingrese la cantidad del producto: ")
            cantidad = int(cantidad)
            return precio, cantidad
        except ValueError:
            print("¡ERROR! Estás ingresando datos inválidos. Por favor, ingresa un número válido.")

def def_name_shop():
    """Definir el nombre de la tienda con una tupla"""
    global name_shop
    name = input("Ingrese el nombre de la tienda: ")
    name_shop = (name,)
    
def agregar_producto():
    """Agrega un nuevo producto al inventario"""
    while True:
        try:
            nombre = input("Ingrese el nombre del producto: ").strip().lower()
            
            if not nombre:
                print("¡ERROR! El nombre no puede estar vacío")
                continue
            
            precio, cantidad = validate_price_quantity()
            nuevo_producto = {
                "Nombre del producto": nombre,
                "precio": precio,
                "cantidad": cantidad    
            }
        
            productos.append(nuevo_producto)
            print(f"Producto {nombre} agregado al inventario.")
            break
        
        except ValueError:
            print("¡ERROR! Estás ingresando datos inválidos. Por favor, ingresa un nombre válido.")

def consultar_producto():
    """Consulta un producto en el inventario"""
    nombre = input("Ingrese el nombre del producto a consultar: ")
    for producto in productos:
        if producto["Nombre del producto"] == nombre:
            print(f"Producto encontrado: {producto}")
            return
    print("\n--- - ---")
    print(f"Producto {nombre} no encontrado en el inventario.")
    
def actualizar_producto():
    """Actualiza un producto en el inventario"""
    nombre = input("Ingrese el nombre del producto a actualizar: ")
    for producto in productos:
        if producto["Nombre del producto"] == nombre:
            nuevo_precio = float(input("Ingrese el nuevo precio del producto: "))
            nueva_cantidad = int(input("Ingrese la nueva cantidad del producto: "))
            producto["precio"] = nuevo_precio
            producto["cantidad"] = nueva_cantidad
            print(f"Producto {nombre} actualizado")
            return
    print("\n--- - ---")
    print(f"Producto {nombre} no encontrado en el inventario.")
    
def eliminar_producto():
    """Elimina un producto del inventario"""
    nombre = input("Ingrese el nombre del producto a eliminar: ")
    for producto in productos:
        if producto["Nombre del producto"] == nombre:
            productos.remove(producto)
            print(f"Producto {nombre} eliminado del inventario")
            return
    print("\n--- - ---")
    print(f"Producto {nombre} no encontrado en el inventario.")

def calcular_valor_inventario():
    """Calcula el valor total del inventario"""
    calcular_valor = lambda producto: producto["precio"] * producto["cantidad"]
    valores = map(calcular_valor, productos)
    total = sum(valores)
    print("\n--- - ---")
    print(f"El valor total del inventario es: {total}")

def menu():
    def_name_shop()
    """Muestra el menú de opciones"""
    while True:
        print(f"\nMenú de opciones de la tienda {name_shop[0]}:")
        print("1. Agregar producto")
        print("2. Consultar producto")
        print("3. Actualizar producto")
        print("4. Eliminar producto")
        print("5. Calcular valor total del inventario")
        print("6. Salir")
        
        opcion = input("Seleccione una opción: ")
        
        if opcion == "1":
            agregar_producto()
        elif opcion == "2":
            consultar_producto()
        elif opcion == "3":
            actualizar_producto()
        elif opcion == "4":
            eliminar_producto()
        elif opcion == "5":
            calcular_valor_inventario()
        elif opcion == "6":
            break
        else:
            print("Opción no válida, intente nuevamente.")
            
# Llamar a la función del menú para iniciar el programa
menu()