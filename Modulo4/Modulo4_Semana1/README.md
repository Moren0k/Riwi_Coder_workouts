# Caso de Estudio: Sistema de Gestión de Citas Médicas

---

## 1. Introducción

El Hospital **"Vida Sana"** enfrenta problemas en la gestión de sus citas médicas debido al uso actual de hojas de cálculo que provocan:

- Pérdidas de datos.
- Duplicación de citas.
- Dificultades para acceder a historiales médicos.

Para mejorar la eficiencia y confiabilidad, se plantea desarrollar un sistema de base de datos que gestione la información de pacientes, médicos, citas y diagnósticos de manera integrada.

---

## 2. Objetivo

Diseñar y documentar un modelo de base de datos relacional que permita:

- Registrar y gestionar información completa de pacientes y médicos.
- Gestionar las citas médicas con estados claros y vinculaciones necesarias.
- Registrar diagnósticos asociados a cada cita.
- Facilitar consultas y reportes para mejorar la atención médica.

---

## 3. Entidades y Atributos Principales Creados

### 3.1 Pacientes

- **id_paciente** (PK)
- nombre, apellido, segundo_apellido
- id_fecha_de_nacimiento (FK)
- id_genero (FK)
- número_de_contacto
- correo_electrónico
- id_direccion (FK)
- id_tipo_de_sangre (FK)

### 3.2 Médicos

- **id_medico** (PK)
- nombre, apellido, segundo_apellido
- teléfono
- correo_electrónico
- años_de_experiencia
- salario

### 3.3 Citas

- **id_cita** (PK)
- fecha, hora
- id_paciente (FK)
- id_medico_especialidad (FK)
- id_estado (FK)

### 3.4 Diagnóstico

- **id_diagnostico** (PK)
- id_cita (FK)
- descripción
- problema
- indicaciones_médicas

### 3.5 Otros Catálogos y Relaciones

- **fechas_de_nacimiento:** Almacena fechas para normalizar y relacionar con pacientes.
- **generos:** Catálogo de géneros para pacientes.
- **direcciones:** Información detallada de domicilio.
- **tipos_de_sangre:** Clasificación de tipo de sangre de pacientes.
- **especialidades_medicas:** Listado de especialidades médicas.
- **medicos_especialidades:** Tabla intermedia para la relación M:M entre médicos y especialidades.
- **estados:** Estado de la cita (pendiente, completada, cancelada).

---

## 4. Relaciones Clave y Cardinalidades

- **Paciente a Fecha de Nacimiento:** (1:N)  
  Un paciente tiene una única fecha de nacimiento, pero una fecha puede corresponder a muchos pacientes.

- **Paciente a Género:** (1:N)  
  Cada paciente tiene un género, pero un género puede pertenecer a muchos pacientes.

- **Paciente a Dirección:** (1:M)  
  Un paciente puede tener varias direcciones, pero una dirección pertenece a un solo paciente.

- **Paciente a Tipo de Sangre:** (1:N)  
  Cada paciente tiene un tipo de sangre, que puede ser compartido por muchos pacientes.

- **Paciente a Citas:** (1:N)  
  Un paciente puede tener muchas citas, pero una cita pertenece a un solo paciente.

- **Médico a Especialidades Médicas:** (M:M)  
  Un médico puede tener muchas especialidades, y una especialidad puede estar asignada a muchos médicos.

- **Cita a Médico Especialidad:** (M:1)  
  Cada cita está atendida por un médico con una especialidad específica.

- **Cita a Diagnóstico:** (1:1)  
  Cada cita tiene un diagnóstico único asociado.

- **Cita a Estado:** (1:N)  
  Cada cita tiene un estado, pero un estado puede estar en muchas citas.

---

## 5. Diagrama Entidad-Relación (ER)

![Diagrama M4S1](/docs/M4S1.drawio.png)

---

## 6. Carga de Datos de Ejemplo

Para ilustrar cómo funciona el modelo de base de datos, se creó un conjunto de datos de ejemplo utilizando **Google Sheets**, replicando el contenido de cada tabla con registros ficticios.

Las tablas incluyen información realista sobre:

- Pacientes
- Médicos
- Especialidades
- Citas médicas
- Diagnósticos
- Estados de cita
- Otros catálogos relacionados

Posteriormente, estas hojas se exportaron como imagen y se incluyen a continuación como referencia visual.

### 📊 Vista de datos de ejemplo (desde Google Sheets)

![Datos de ejemplo](/docs/M4S1.excel.jpg)

## 7. Técnicas y Buenas Prácticas

- **Integridad referencial:** Uso de claves foráneas para mantener la consistencia de datos.
- **Normalización:** Para evitar redundancia, fechas, géneros, direcciones y tipos de sangre están normalizados en tablas separadas.
- **Escalabilidad:** El modelo permite agregar más especialidades médicas o estados sin modificar la estructura principal.
- **Flexibilidad:** El modelo M:M entre médicos y especialidades permite que un médico tenga varias especialidades y viceversa.
- **Historial Clínico:** Al asociar diagnósticos a citas, se puede consultar el historial completo de un paciente.

---
