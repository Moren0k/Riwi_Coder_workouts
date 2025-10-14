-- ==============================================
--  DATABASE DESIGN - Medical Appointment System
-- ==============================================

CREATE DATABASE MedicalDB;
GO

USE MedicalDB;
GO

-- ======================
--  TABLE: Patients
-- ======================
CREATE TABLE Patients (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    SecondLastName NVARCHAR(100),
    Document NVARCHAR(20) NOT NULL UNIQUE,
    Age INT NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20)
);
GO

-- ======================
--  TABLE: Doctors
-- ======================
CREATE TABLE Doctors (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    SecondLastName NVARCHAR(100),
    Document NVARCHAR(20) NOT NULL UNIQUE,
    Age INT NOT NULL,
    Specialty NVARCHAR(100) NOT NULL
);
GO

-- ======================
--  TABLE: Appointments
-- ======================
CREATE TABLE Appointments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    Date DATETIME NOT NULL,
    Reason NVARCHAR(200),
    Status NVARCHAR(20) NOT NULL DEFAULT('Scheduled'),

    CONSTRAINT FK_Appointments_Patients FOREIGN KEY (PatientId) REFERENCES Patients(Id),
    CONSTRAINT FK_Appointments_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);
GO