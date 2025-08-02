# Caso de Estudio: Sistema de Gestión Académica Universitaria

## 1. Introducción

La universidad virtual **"Aprende Online"** enfrenta problemas en la gestión de su información académica debido al uso actual de hojas de cálculo en cada área académica, lo que provoca:

- Errores en las inscripciones.
- Dificultades para generar reportes confiables.
- Pérdida de datos importantes.

Para mejorar la administración y confiabilidad, se plantea desarrollar un sistema de base de datos relacional centralizado que gestione la información de estudiantes, docentes, cursos, inscripciones y calificaciones de manera integrada.

## 2. Objetivo

Diseñar y documentar un modelo de base de datos relacional que permita:

- Registrar y gestionar información completa de estudiantes y docentes.
- Gestionar los cursos y sus asignaciones a docentes.
- Registrar las inscripciones de los estudiantes a los cursos con fecha y calificación final.
- Facilitar consultas y reportes que permitan analizar el rendimiento estudiantil y mejorar la administración académica.

## 3. Descripción funcional

El sistema debe permitir:

- Registro de estudiantes con datos: nombre completo, correo electrónico, género, número de identificación, carrera, fecha de nacimiento y fecha de ingreso.
- Registro de docentes con datos: nombre completo, correo institucional, departamento académico y años de experiencia.
- Gestión de cursos con información: nombre, código, número de créditos, semestre y docente asignado.
- Registro de inscripciones con fecha y calificación final.
- Consultas avanzadas utilizando funciones de agregación (`AVG()`, `SUM()`, `COUNT()`, `MAX()`, `MIN()`).
- Filtros con cláusulas (`WHERE`, `ORDER BY`, `BETWEEN`, `IN`, `LIKE`, `IS NULL`).
- Agrupamiento de datos por carrera o curso (`GROUP BY`, `HAVING`).
- Uso de subconsultas y joins para combinar y filtrar información.
- Creación de vistas para mostrar historial académico con detalle de cursos, docentes, calificaciones y semestres.
- Gestión de permisos y roles (`GRANT`, `REVOKE`).
- Control de integridad en transacciones con comandos `COMMIT`, `ROLLBACK` y `SAVEPOINT`.

## 4. Beneficios esperados

- Centralización y seguridad en el almacenamiento de datos académicos.
- Reducción de errores en inscripciones y reportes.
- Facilidades para el análisis avanzado del rendimiento estudiantil.
- Mejora en la toma de decisiones administrativas basadas en datos confiables y actualizados.

---

## 5. Entidades y Atributos Principales Creados

### 5.1 Estudiantes

- **id_estudiante** (PK)
- nombre, primer_apellido, segundo_apellido
- correo
- **id_genero** (FK)
- numero_identificacion
- **id_carrera** (FK)
- fecha_nacimiento
- fecha_ingreso

### 5.2 Docentes

- **id_docente** (PK)
- nombre, primer_apellido, segundo_apellido
- correo_institucional
- años_experiencia

### 5.3 Cursos

- **id_curso** (PK)
- nombre
- codigo
- creditos
- semestre
- **id_docente_academico** (FK)

### 5.4 Inscripciones

- **id_inscripcion** (PK)
- **id_estudiante** (FK)
- **id_curso** (FK)
- fecha_inscripcion
- calificacion

### 5.5 Docentes_Academicos (relación M:N entre docentes y departamentos)

- **id_docente_academico** (PK)
- **id_docente** (FK)
- **id_departamento_academico** (FK)

### 5.6 Géneros

- **id_genero** (PK)
- genero

### 5.7 Carreras

- **id_carrera** (PK)
- nombre
- descripcion
- duracion

### 5.8 Departamentos Académicos

- **id_departamento_academico** (PK)
- nombre_departamento

---

## 4. Relaciones Clave y Cardinalidades

- **Estudiante a Inscripciones:** (1:N)  
  Un estudiante puede tener muchas inscripciones, pero una inscripción solo pertenece a un estudiante.

- **Curso a Inscripciones:** (1:N)  
  Un curso puede estar en muchas inscripciones, pero una inscripción solo pertenece a un curso.

- **Estudiante a Género:** (1:N)  
  Cada estudiante tiene un género, pero un género puede pertenecer a muchos estudiantes.

- **Estudiante a Carrera:** (1:N)  
  Un estudiante pertenece a una carrera, pero una carrera puede tener muchos estudiantes.

- **Docente a Docentes_Academicos:** (1:N)  
  Un docente puede estar en muchos departamentos académicos (relación M:N a través de tabla intermedia).

- **Departamento Académico a Docentes_Academicos:** (1:N)  
  Un departamento puede tener muchos docentes asociados mediante la tabla intermedia.

- **Curso a Docente Académico:** (1:N)  
  Un docente académico puede impartir muchos cursos, pero un curso solo puede ser impartido por un docente académico.

---

## Notas adicionales

- La relación **Docente – Departamento Académico** es de muchos a muchos, normalizada mediante la tabla intermedia `docentes_academicos`.
- La entidad `docentes_academicos` también sirve como puente para vincular cursos a un docente en el contexto de su departamento.
- Las claves primarias están correctamente definidas y las foráneas refuerzan la integridad referencial en todo el modelo.

---

## 5. Diagrama Entidad-Relación (ER)

![Diagrama M4S2](/Modulo4/Modulo4_Semana2/docs/M4S2.drawio.png)

---

## 6. Tablas y Tipos de Datos

### 6.1 Tabla: estudiantes

- id_estudiante: INT, PRIMARY KEY, AUTO_INCREMENT
- nombre: VARCHAR(100), NOT NULL
- primer_apellido: VARCHAR(100), NOT NULL
- segundo_apellido: VARCHAR(100), NULL
- correo: VARCHAR(150), NOT NULL, UNIQUE
- id_genero: INT, FOREIGN KEY
- numero_identificacion: VARCHAR(50), NOT NULL, UNIQUE
- id_carrera: INT, FOREIGN KEY
- fecha_nacimiento: DATE, NULL
- fecha_ingreso: DATE, NULL

### 6.2 Tabla: docentes

- id_docente: INT, PRIMARY KEY, AUTO_INCREMENT
- nombre: VARCHAR(100), NOT NULL
- primer_apellido: VARCHAR(100), NOT NULL
- segundo_apellido: VARCHAR(100), NULL
- correo_institucional: VARCHAR(150), NOT NULL, UNIQUE
- años_experiencia: INT, NULL

### 6.3 Tabla: cursos

- id_curso: INT, PRIMARY KEY, AUTO_INCREMENT
- nombre: VARCHAR(100), NOT NULL
- codigo: VARCHAR(20), NOT NULL, UNIQUE
- creditos: INT, NOT NULL
- semestre: VARCHAR(20), NOT NULL
- id_docente_academico: INT, FOREIGN KEY

### 6.4 Tabla: inscripciones

- id_inscripcion: INT, PRIMARY KEY, AUTO_INCREMENT
- id_estudiante: INT, FOREIGN KEY
- id_curso: INT, FOREIGN KEY
- fecha_inscripcion: DATE, NOT NULL
- calificacion: DECIMAL(5,2), NULL

### 6.5 Tabla: docentes_academicos

- id_docente_academico: INT, PRIMARY KEY, AUTO_INCREMENT
- id_docente: INT, FOREIGN KEY
- id_departamento_academico: INT, FOREIGN KEY

### 6.6 Tabla: generos

- id_genero: INT, PRIMARY KEY, AUTO_INCREMENT
- genero: VARCHAR(50), NOT NULL

### 6.7 Tabla: carreras

- id_carrera: INT, PRIMARY KEY, AUTO_INCREMENT
- nombre: VARCHAR(100), NOT NULL
- descripcion: TEXT, NULL
- duracion: INT, NULL (en semestres)

### 6.8 Tabla: departamentos_academicos

- id_departamento_academico: INT, PRIMARY KEY, AUTO_INCREMENT
- departamento_academico: VARCHAR(100), NOT NULL
