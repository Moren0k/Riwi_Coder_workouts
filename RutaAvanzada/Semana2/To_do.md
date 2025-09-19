# ✅ To-Do List: Sistema RiwiMusic

## 1. Preparación del Proyecto

- [x] Crear proyecto de consola en C# (`dotnet new console`).
- [x] Configurar `Program.cs` con menú principal en loop (`while` con `switch`).
- [x] Definir listas globales para almacenar datos:
  - [x] `List<Concierto>`
  - [x] `List<Cliente>`
  - [x] `List<Compra>`

---

## 2. Modelado con POO

- [x] Crear clase `Concierto`
  - [x] Id (int)
  - [x] Nombre (string)
  - [x] Ciudad (string)
  - [x] Fecha (DateTime)
  - [x] PrecioEntrada (decimal)
- [x] Crear clase `Cliente`
  - [x] Id (int)
  - [x] Nombre (string)
  - [x] Email (string)
- [x] Crear clase `Compra`
  - [x] Id (int)
  - [x] ClienteId (int)
  - [x] ConciertoId (int)
  - [x] Cantidad (int)
  - [x] Total (decimal)

---

## 3. Gestión de Conciertos

- [ ] Implementar **Registrar concierto**.
- [ ] Implementar **Listar conciertos**.
- [ ] Implementar **Editar concierto**.
- [ ] Implementar **Eliminar concierto**.

---

## 4. Gestión de Clientes

- [ ] Implementar **Registrar cliente**.
- [ ] Implementar **Listar clientes**.
- [ ] Implementar **Editar cliente**.
- [ ] Implementar **Eliminar cliente**.

---

## 5. Gestión de Tiquetes

- [ ] Implementar **Registrar compra de tiquete**.
  - [ ] Validar cliente existente.
  - [ ] Validar concierto existente.
  - [ ] Calcular total.
- [ ] Implementar **Listar tiquetes vendidos**.
- [ ] Implementar **Editar compra**.
- [ ] Implementar **Eliminar compra**.

---

## 6. Historial de Compras

- [ ] Mostrar compras de un cliente específico usando su Id o Email.

---

## 7. Consultas Avanzadas (LINQ)

- [ ] Conciertos por ciudad.
- [ ] Conciertos por rango de fechas.
- [ ] Concierto con más tiquetes vendidos.
- [ ] Ingresos totales de un concierto.
- [ ] Cliente con más compras realizadas.

---

## 8. UML y Documentación

- [ ] Crear **Diagrama de Clases**.
- [ ] Crear **Diagrama de Casos de Uso**.
- [ ] Redactar justificación de cómo se aplicó POO.

---

## 9. Finalización

- [ ] Probar todos los casos del menú.
- [ ] Entregar implementación completa.
