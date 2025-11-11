"""
Prueba de cómo procesar una entrada de datos que el usuario escribe como una lista,
separada por comas. Por ejemplo: '45, 89, 77.5'.

✅ Aprendí a:
- Verificar si la entrada contiene comas para identificar si es una lista.
- Dividir la cadena de texto en partes usando `.split(",")`.
- Limpiar espacios innecesarios usando `.strip()`.
- Convertir cada elemento a tipo float usando `float()`.
- Recorrer listas con un bucle `for`.

Este tipo de procesamiento es muy útil cuando se trabaja con cualquier conjunto de números 
introducido por el usuario en una sola línea.
"""
entrada = input("Ingresa una lista de números separados por comas: ").strip()
if "," in entrada:
    print("Esto es una lista")
    lista_notas = entrada.split(",")
    print("Lista de números:", lista_notas)
else:
    print("Esto no es una lista")

for lista_notas in lista_notas:
    numero = float(lista_notas.strip())
    print(numero)