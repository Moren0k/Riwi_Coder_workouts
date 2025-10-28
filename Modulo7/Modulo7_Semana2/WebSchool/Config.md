# Creation and Configuration of the Project

This document outlines the steps to create and configure a new project for the WebSchool application.

## Project Creation Folder

```bash
mkdir WebSchool
cd WebSchool
```

## Create a solution file

```bash
dotnet new sln -n Solution
```

## Create the 4 projects (API, Application, Domain, Infrastructure)

```bash
dotnet new webapi -n WebSchool.Api
dotnet new classlib -n WebShool.Application
dotnet new classlib -n WebSchool.Domain
dotnet new classlib -n WebSchool.Infrastructure
```

view the project structure:

```bash
WebSchool/
├── Solution.sln
├── WebSchool.Api/
├── WebSchool.Application/
├── WebSchool.Domain/
│   └── Entities/
│       ├── Student.cs
│       ├── Course.cs
│       └── Inscription.cs
└── WebSchool.Infrastructure/
```

## Add the projects to the solution

```bash
dotnet sln Solution.sln add WebSchool.Api
dotnet sln Solution.sln add WebSchool.Application
dotnet sln Solution.sln add WebSchool.Domain
dotnet sln Solution.sln add WebSchool.Infrastructure
```

view all projects in the solution:

```bash
dotnet sln Solution.sln list
```

## Add references between projects

```bash
dotnet add WebSchool.Api reference WebSchool.Application
dotnet add WebSchool.Application reference WebSchool.Domain
dotnet add WebSchool.Application reference WebSchool.Infrastructure
dotnet add WebSchool.Api reference WebSchool.Infrastructure
```

view the references in the API project:

```bash
dotnet list reference
```

> Use this command inside in the one of the project folders

## Add NuGet packages

Add the necessary NuGet packages to the Infrastructure project for Entity Framework Core and MySQL support.

```bash
cd WebSchool.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

view the installed packages:

```bash
dotnet list packages
```

>Install the packages inside the Infrastructure project folder

---
