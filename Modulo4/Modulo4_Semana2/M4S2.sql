DROP DATABASE IF EXISTS universidad;
CREATE DATABASE universidad; #Se crea la base de datos

USE universidad; #Especificar la base de datos con la que se trabajará

# Creacion de las tablas

# Generos
CREATE TABLE generos(
    id_genero INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    genero VARCHAR(50) NOT NULL
);

# Carreras
CREATE TABLE carreras(
    id_carrera INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    duracion INT NOT NULL
);

# Departamentos Academicos
CREATE TABLE departamentos_academicos(
    id_departamento_academico INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    departamento_academico VARCHAR(100) NOT NULL
);

# Docentes
CREATE TABLE docentes(
    id_docente INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    primer_apellido VARCHAR(100) NOT NULL,
    segundo_apellido VARCHAR(100) NOT NULL,
    correo_institucional VARCHAR(150) NOT NULL UNIQUE,
    anios_experiencia INT NULL
);

# Docentes Academicos
CREATE TABLE docentes_academicos(
    id_docente_academico INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    id_docente INT, --
    id_departamento_academico INT, --

    FOREIGN KEY (id_docente) REFERENCES docentes(id_docente),
    FOREIGN KEY (id_departamento_academico) REFERENCES departamentos_academicos(id_departamento_academico)
);

# Estudiantes
CREATE TABLE estudiantes(
    id_estudiante INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    primer_apellido VARCHAR(100) NOT NULL,
    segundo_apellido VARCHAR(100) NOT NULL,
    correo VARCHAR(150) NOT NULL UNIQUE,
    id_genero INT, --
    numero_identificacion VARCHAR(50) NOT NULL UNIQUE,
    id_carrera INT, --
    fecha_nacimiento DATE NOT NULL,
    fecha_ingreso DATE NOT NULL,

    FOREIGN KEY (id_genero) REFERENCES generos(id_genero),
    FOREIGN KEY (id_carrera) REFERENCES carreras(id_carrera)
);


# Cursos
CREATE TABLE cursos(
    id_curso INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    codigo VARCHAR(50) UNIQUE,
    creditos INT NOT NULL,
    semestre INT NOT NULL,
    id_docente_academico INT, --

    FOREIGN KEY (id_docente_academico) REFERENCES docentes_academicos(id_docente_academico)
);

# Inscripciones
CREATE TABLE inscripciones(
    id_inscripcion INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    id_estudiante INT NOT NULL, --
    id_curso INT NOT NULL, --
    fecha_inscripcion DATE NOT NULL,
    calificacion DECIMAL(2,1) CHECK (calificacion BETWEEN 1.0 AND 5.0),

    FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id_estudiante),
    FOREIGN KEY (id_curso) REFERENCES cursos(id_curso),
    UNIQUE(id_estudiante, id_curso)
);

-- Datos de ejemplo

# Generos
INSERT INTO generos (genero) VALUES 
('Masculino'),
('Femenino'),
('Otro');

# Carreras
INSERT INTO carreras (nombre, descripcion, duracion) VALUES 
('Ingeniería de Sistemas', 'Enfocada en desarrollo de software', 10),
('Administración de Empresas', 'Gestión y liderazgo empresarial', 8),
('Psicología', 'Estudio del comportamiento humano', 9);

# Departamentos Academicos
INSERT INTO departamentos_academicos (departamento_academico) VALUES 
('Ingenierías'),
('Ciencias Sociales'),
('Negocios');

# Docentes
INSERT INTO docentes (nombre, primer_apellido, segundo_apellido, correo_institucional, anios_experiencia) VALUES 
('Carlos', 'Pérez', 'Gómez', 'cperez@univ.edu.co', 5),
('Laura', 'Martínez', 'López', 'lmartinez@univ.edu.co', 8),
('Andrés', 'Ramírez', 'Zapata', 'aramirez@univ.edu.co', 3);

# Docentes Academicos
INSERT INTO docentes_academicos (id_docente, id_departamento_academico) VALUES 
(1, 1), -- Carlos - Ingeniería
(2, 3), -- Laura - Negocios
(3, 2); -- Andrés - Ciencias Sociales

# Estudiantes
INSERT INTO estudiantes (nombre, primer_apellido, segundo_apellido, correo, id_genero, numero_identificacion, id_carrera, fecha_nacimiento, fecha_ingreso) VALUES 
('Juan', 'García', 'López', 'juan.garcia@correo.com', 1, '1001234567', 1, '2003-04-15', '2022-01-10'),
('Ana', 'Ruiz', 'Mejía', 'ana.ruiz@correo.com', 2, '1002234568', 2, '2002-08-22', '2021-07-10'),
('Mateo', 'Torres', 'Cano', 'mateo.torres@correo.com', 1, '1003234569', 3, '2001-10-01', '2020-02-15');

# Cursos
INSERT INTO cursos (nombre, codigo, creditos, semestre, id_docente_academico) VALUES 
('Programación Básica', 'CS101', 3, 1, 1),
('Administración Financiera', 'AD202', 4, 2, 2),
('Psicología Social', 'PS303', 3, 3, 3);

# Inscripciones
INSERT INTO inscripciones (id_estudiante, id_curso, fecha_inscripcion, calificacion) VALUES 
(1, 1, '2023-02-10', 4.5),
(2, 2, '2023-02-11', 3.8),
(3, 3, '2023-02-12', 4.2);
