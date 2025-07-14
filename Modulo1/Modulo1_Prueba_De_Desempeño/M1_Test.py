shop_name = ()#Save the store name
inventory = []#list where all inventory is stored

def def_shop_name():#Function to request the store name
    global shop_name
    shop = input("Ingresa el nombre de la tienda: ").strip()
    shop_name = (shop,)
def_shop_name()

def validate_price():#function that validates the entry of price data
    while True:
        price = input("Introduzca el precio del producto: ").strip()
        if not price:
            print("\n---El campo no puede estar vacío. Por favor, introduzca un número.")
            continue
        try:
            price = float(price)
            if price > 0:
                return price
            else:
                print("\n---Debes ingresar un número positivo.")
        except ValueError:
            print("\n---¡ERROR! Está introduciendo datos no válidos. Introduzca un número válido.")

def validate_quantity():#function that validates the input of data quantities
    while True:
        quantity = input("Introduzca la cantidad del producto: ").strip()
        if not quantity:
            print("\n---El campo no puede estar vacío. Por favor, introduzca un número.")
            continue
        try:
            quantity = int(quantity)
            if quantity > 0:
                return quantity
            else:
                print("\n---Debes ingresar un número positivo.")
        except ValueError:
            print("\n---¡ERROR! Está introduciendo datos no válidos. Introduzca un número válido.")
            
def add():#Function to save a product with its name, price and quantity
    while True:
            title = input("Ingresa el nombre de el producto (0 para volver al menú): ").strip().lower()
            if not title:
                print("\n¡ERROR! Este espacio no puede estar vacío.")
            elif title == "0":
                break
                
            price = validate_price()
            quantity = validate_quantity()
            
            new_product = {"title":title, "price":price, "quantity":quantity}
            inventory.append(new_product)
            print(f"\nEl producto {title} Se agregó exitosamente al inventario.")      
            return price, quantity
        
def start():#Function that verifies that the system has at least 5 minimum products to start the system
    while len(inventory) < 5:
        print(f"\nIngrese minimo {5 - len(inventory)} productos para inciar el programa")
        add()
start()
    
def search():#function to search and display product data
    while True:
        search_product = input("Ingresa el nombre de el producto que quieres buscar: ").strip().lower()
        for i in inventory:
            if i["title"] == search_product:
                print(f"\nEl producto {search_product} fue encontrado")
                print(f"--{i}--")
                return
        else:
            print(f"\nEl producto {search_product} no se encuentra en el inventario.")
            
def update():#function to modify the price and quantity of a product
    while True:
            update_to_product = input("Ingrese el nombre de el producto que desea actualizar (0 para volver al menú): ").strip().lower()
            if not update_to_product:
                print("\n¡ERROR! Este espacio no puede estar vacío.")
                continue
            elif update_to_product == "0":#Functionality to return to the menu if necessary
                break
            for i in inventory:
                if i["title"] == update_to_product:
                    new_price = validate_price()
                    new_quiantity = validate_quantity()
                    i["price"] = new_price
                    i["quantity"] = new_quiantity
                    print(f"\nEl producto {update_to_product} se actualizó correctamente")
                    return
            else:
                print(f"\nEl producto {update_to_product} no fue encontrado en el inventario.")
            
def remove():#function to remove a product from inventory
    while True:
        try:
            remove_to_product = input("Ingresa el nombre de el producto que deseas eliminar (0 para volver al menú): ").strip().lower()
            if not remove_to_product:
                print("\n¡ERROR! Este espacio no puede estar vacío.")
            elif remove_to_product == "0":#Functionality to return to the menu if necessary
                break
            for i in inventory:
                if i["title"] == remove_to_product:
                    inventory.remove(i)
                    print(f"\nEl producto {remove_to_product} se eliminó correctamente.")
                    return
            else:
                print(f"\nEl producto {remove_to_product} no fue encontrado en el inventario.")
        except ValueError:
            print("\n¡ERROR!")
    
def calculate_inventory():#function to calculate the total inventory
    value_calculate = lambda product:product["price"] * product["quantity"]
    value = map(value_calculate, inventory)
    total_value = sum(value)
    print(f"\nEl valor total del inventario es: {(round(total_value))}")

def view_inventory():#function to display the inventory
    print(f"\n===== El inventario de la tienda {shop_name[0]} =====")   
    for (i) in inventory:
        print(i)

def main_menu():#function that displays the functionality menu
    while True:
        print(f"\n--- Menu Principal De La Tienda {shop_name[0]} ---")
        print("1. Agregar producto")
        print("2. Buscar producto")
        print("3. Actualizar producto")
        print("4. Eliminar producto")
        print("5. valor total del inventario")
        print("6. Ver el inventario")
        print("0. ¡Salir!")
        print("\n--- - ---")
        option = input("Selecciona un opción: ")
        
        if option == "1":
            print("\n--- Agregar Un Producto ---")
            add()
        elif option == "2":
            print("\n--- Buscar Un Producto ---")
            search()
        elif option == "3":
            print("\n--- Actualizar Un Producto ---")
            update()
        elif option == "4":
            print("\n--- Eliminar Un Producto ---")
            remove()
        elif option == "5":
            print("\n--- Valor Total Del Inventario ---")
            calculate_inventory()
        elif option == "6":
            print("\n--- Ver El Inventario ---")
            view_inventory()
        elif option == "0":
            print("\n--- SALISTE DE EL SISTEMA ---")
            break
        else:
            print("\n--- -Opción no válida, inténtelo nuevamente.- ---")
main_menu()