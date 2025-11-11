"""Jhos Kevin Agudelo Moreno"""
lists_valid_notes = [] # Lista para almacenar calificaciones válidas
while True:
    try:
        evaluate = float(input("Desde qué número de calificación quieres evaluar (1 a 99): "))
        if 1 <= evaluate <= 99:
            break
        print("Error: La calificación de evaluación debe estar entre 1 y 99.")
    except:
        print("Error: Entrada no válida. Debe ser un número entre 1 y 99.")
        
#   Función para guardar, validar y evaluar calificaciones
def qualification_def():
    while True:
        entry = input("Ingresa una calificación (0 a 100) o 'fin' para terminar: ")
        if entry.lower() == "fin":#Verificar si el usuario quiere terminar de ingresar calificaciones
            break
        if "," in entry:
            parts = entry.split(",")
        else:
            parts = [entry]
        for parte in parts:
            try:
                qualification = float(parte.strip())
                if 0 <= qualification <= 100:
                    lists_valid_notes.append(qualification)
                    if qualification >= evaluate:
                        print(qualification, "# Aprobado")
                    else:
                        print(qualification, "# Reprobado")
                else:
                    print("Error: La calificación debe estar entre 0 y 100.")
            except ValueError:
                print("Error: Entrada no válida. Debe ser un número o 'fin'.")
qualification_def()
print("\n--- Calificaciones válidas ---")
print("Calificaciones válidas ingresadas:", lists_valid_notes)

#   Función para calcular el promedio de las calificaciones
def average(lists_valid_notes=[]):
    if not lists_valid_notes:
        print("No hay calificaciones válidas para calcular el promedio.")
        return
    prom = sum(lists_valid_notes) / len(lists_valid_notes)
    print("El promedio de las calificaciones es:", round(prom, 2))
print("\n--- Calcular promedio ---")
average(lists_valid_notes)

#   Función para contar cuántas calificaciones son mayores a un valor dado
def higher_grades (lists_valid_notes):
    if not lists_valid_notes:
        print("No hay calificaciones válidas para contar.")
        return
    value = float(input("Ingresa un valor para buscar calificaciones mayores: "))
    counter = sum(1 for qualification in lists_valid_notes if qualification > value)
    print("hay", counter, "calificaciones mayores a", value)
print("\n--- Contar calificaciones mayores a un valor ---")
higher_grades(lists_valid_notes)