-- ==============================================
--  DATABASE DESIGN - Medical Appointment System
-- ==============================================

CREATE DATABASE MedicalDB;

USE MedicalDB;

-- ======================
--  TABLE: Patients
-- ======================
create table Patients
(
    Id             int auto_increment
        primary key,
    Age            int          not null,
    FirstName      varchar(100) not null,
    LastName       varchar(100) not null,
    SecondLastName varchar(100) null,
    Document       varchar(20)  not null,
    Phone          varchar(20)  null,
    Email          varchar(100) null
);

-- ======================
--  TABLE: Doctors
-- ======================
create table Doctors
(
    Id             int auto_increment
        primary key,
    Specialty      varchar(100) not null,
    FirstName      varchar(100) not null,
    LastName       varchar(100) not null,
    SecondLastName varchar(100) null,
    Document       varchar(20)  not null,
    Phone          varchar(20)  null,
    Email          varchar(100) null
);

-- ======================
--  TABLE: Appointments
-- ======================
create table Appointments
(
    Id        int auto_increment
        primary key,
    PatientId int          not null,
    DoctorId  int          not null,
    Date      datetime(6)  not null,
    Reason    varchar(200) null,
    Status    varchar(20)  not null,
    constraint FK_Appointments_Doctors_DoctorId
        foreign key (DoctorId) references Doctors (Id)
            on delete cascade,
    constraint FK_Appointments_Patients_PatientId
        foreign key (PatientId) references Patients (Id)
            on delete cascade
);

create index IX_Appointments_DoctorId
    on Appointments (DoctorId);

create index IX_Appointments_PatientId
    on Appointments (PatientId);