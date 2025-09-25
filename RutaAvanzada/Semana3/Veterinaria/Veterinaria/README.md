# Configuración de Entity Framework Core con MySQL en el proyecto **Veterinaria**

Este proyecto utiliza **Entity Framework Core** con **MySQL** mediante el proveedor Pomelo. A continuación se documentan los paquetes instalados, sus versiones y los comandos principales.

## Paquetes instalados

- `Pomelo.EntityFrameworkCore.MySql` → Proveedor de EF Core para MySQL/MariaDB.  
  Versión recomendada: **9.0.0**

  ```bash
  dotnet add package Pomelo.EntityFrameworkCore.MySql
  ```

- `Microsoft.EntityFrameworkCore.Tools` → Herramientas de consola para migraciones y actualización de base de datos.  
  Versión recomendada: **9.0.9**
  
  ```bash
  dotnet add package Microsoft.EntityFrameworkCore.Tools
  ```

- `Microsoft.EntityFrameworkCore.Design` → Necesario para scaffolding y generación de migraciones.  
  Versión recomendada: **9.0.9**

  ```bash
  dotnet add package Microsoft.EntityFrameworkCore.Design
  ```

## Comandos útiles

- Crear una migración inicial:

```bash
  dotnet ef migrations add InitialCreate
```

- Aplicar migraciones a la base de datos:

```bash
  dotnet ef database update
```

- Verificar paquetes instalados:

```bash
  dotnet list package
```

## Notas

- Los paquetes se instalan en el proyecto `Veterinaria/Veterinaria.csproj`.  
- Se recomienda mantener este README.md en la raíz del proyecto para referencia rápida.  
- Las versiones indicadas son las más recientes y compatibles con .NET 8.0 al momento de documentar.
