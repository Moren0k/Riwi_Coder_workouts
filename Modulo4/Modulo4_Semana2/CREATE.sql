CREATE DATABASE universidad; #Se crea la base de datos

USE universidad; #Especificar la base de datos con la que se trabajará

# Creacion de las tablas

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

# Docentes
CREATE TABLE docentes(
    id_docente INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    primer_apellido VARCHAR(100) NOT NULL,
    segundo_apellido VARCHAR(100) NOT NULL,
    correo_institucional VARCHAR(150) NOT NULL UNIQUE,
    años_experiencia INT NULL
)

# Cursos
CREATE TABLE cursos(
    id_curso INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    codigo VARCHAR(50) UNIQUE,
    creditos INT(20) NOT NULL,
    semestre VARCHAR(20) NOT NULL,
    id_docente_academico INT, --

    FOREIGN KEY (id_docente_academico) REFERENCES docentes_academicos(id_docente_academico)
)

# Inscripciones
CREATE TABLE inscripciones(
    id_inscripcion INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    id_estudiante INT, --
    id_curso INT, --
    fecha_inscripcion DATE NOT NULL,
    calificacion DECIMAL(1,1) NULL,

    FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id_estudiante),
    FOREIGN KEY (id_curso) REFERENCES cursos(id_curso)
)

# Docentes Academicos
CREATE TABLE docentes_academicos(
    id_docente_academico INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    id_docente INT, --
    id_departamento_academico INT, --

    FOREIGN KEY (id_docente) REFERENCES docentes(id_docente),
    FOREIGN KEY (id_departamento_academico) REFERENCES departamentos_academicos(id_departamento_academico)
)

# Generos
CREATE TABLE generos(
    id_genero INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    genero VARCHAR(50) NOT NULL,
)

# Carreras
CREATE TABLE carreras(
    id_carrera INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    duracion INT NOT NULL
)

# Departamentos Academicos
CREATE TABLE departamentos_academicos(
    id_departamento_academico INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    departamento_academico VARCHAR(100) NOT NULL
)