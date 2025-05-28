#========================================
#Sistema básico de compra de productos
#Autor: Jhos Kevin Agudelo Moreno
#Descripción: Solicita datos del producto, aplica validaciones, calcula el total con descuento y muestra un resumen.
#========================================
nombreproducto = input("Ingresa el nombre del producto: ") #Cree la variable (productname) = Con un (input) Que guarda lo que el usuario escriba en la variable (productname) y muestra el mensaje entre comillas.
#---
while True: #Cree un bucle con (while) que siempre es verdadero(True) y solo se detiene con (break).
	try: #con (try) si todo dentro del bloque se ejecuta sin errores, el código continúa. Si ocurre algun error saltara al bloque (except).
		precio = float(input("Ingresa el precio del producto: ")) #Cree la variable (precio)(=) Con un tipo de dato (float) para que guarde/convierta números decimales.
		if precio <= 0: #Aca comprovamos si(if) el precio(precio) es igual(=) o menor que(<) cero(0), Si se cumple se motrara un mensaje.
			print("El precio no puede ser negativo. Inténtalo de nuevo.") #Aca mostramos con (print) el mensaje su el (if) se cumple.
		else: #Con (else) si el precio es valido(Mayor a cero) entonces se ejecuta(else) con el (break).
			break #Se ejecuta (break) que detiene el buble de (while) y deja de pedir el precio y continúa.
	except ValueError: #Con (except) atrapa errores que pasan dentro de (try), (ValueError)Es un tipo de error cuando intentas convertir una cadera no numerica a un(float).
										 #Si el usuario ingresa algo que no se puede convertir a un número(Letras), se atrapa el error y muestra(print) un mensaje.
		print("Entrada no válida. Ingresa un precio.") #Este mensaje solo se muestra(print) cuano se atrapa el error con (except).
#---
while True: #Cree un bucle con (while) que siempre es verdadero(true) y solo se detiene con (break).
	try: #Con (try) si todo dentro del bloque se ejecuta sin errores, el código continúa. Si ocurre algun error saltara al bloque (except).
		cantidad = int(input("Ingresa la cantidad que vas a comprar: ")) #Cree la variable (cantidad)(=) Con un tipo de dato (int) para que guarde/convierta números enteros.
		if cantidad < 0: #Aca comprovamos si(if), la(cantida) es menor que(<) cero(0), Si se cumple se mostrara un mensaje.
			print("La cantidad no puede ser negativa. Inténtalo de nuevo.") #Aca mostramos con (print) el mensaje su el (if) se cumple.
		else: #Con (else) si la cantidad es valida(Mayor a cero) entonces se ejecuta(else) con el (break).
			break #Se ejecuta (break) que detiene el buble de (while) y deja de pedir la cantidad y continúa.
	except ValueError: #Con (except) atrapa cualquier errores que pasan dentro de (try), (ValueError)Es un tipo de error cuando intentas convertir una cadera no numerica a un(int).
		print("Entrada no válida. Ingresa un número entero.") #Este mensaje solo se muestra(print) cuano se atrapa el error con (except).
#---
while True: #Cree un bucle con (while) utilizando (float) Esto es útil cuando el precio puede ser un número con decimales, como 19.99, pero no negativo.
	try:
		descuento = float(input("Ingresa el descuento (0 si no hay): "))
		if descuento < 0 or descuento > 100: #Si(if) el descuento(descuento) es menor que(<) cero(0) ó el descuento(descuento) es mayor que(>) cien(100), se mostrara un mensaje.
			print("El descuento no puede ser negativo. Inténtalo de nuevo.")
		else:
			break
	except ValueError:
		print("Entrada no válida. Ingresa un número decimal.")
#---
total_sin_descuento = precio * cantidad #Creo la variable (total_sin_descuento) que sera igual(=) a el precio(precio) por(*) la cantidad(cantidad).
cantidad_descuento = total_sin_descuento * (descuento / 100) #Creo la variable (cantidad_descuento) que sera igual(=) a el (total_sin_descuento) por(*) el descuento(el descuento(descuento) dividido(/) entre cien(100)).
total_final = total_sin_descuento - cantidad_descuento #Creo la variable (total_final) que sera igual(=) a el(total_sin_descuento) menos(-) la(cantidad_descuento).
#---
#Mostramos el resultado de las varibles definidas.
print("\n--- RESUMEN DE COMPRA ---")
print("Producto:", nombreproducto) #El nombre del producto ingresado.
print("Precio unitario: $", (precio)) #El precio unitario del producto ingresado.
print("Cantidad:", cantidad) #La cantidad ingresada.
print("Descuento:", str(descuento) + "%") #El descuento que sera aplicado en porcentaje(%).
print("Total a pagar: $", (total_final)) #El total definitivo con descuento.