# Paquetes instalados y versiones exactas

- `Microsoft.EntityFrameworkCore` → Mapeado de objetos.
  Versión: **9.0.9**

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.9
```

- `Microsoft.EntityFrameworkCore.Design` → Necesario para scaffolding y generación de migraciones.
  Versión: **9.0.9**

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.9
```

- `Microsoft.EntityFrameworkCore.Tools` → Herramientas de consola para migraciones y actualización de base de datos.
  Versión: **9.0.9**

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.9
```

- `Pomelo.EntityFrameworkCore.MySql` → Proveedor de EF Core para MySQL/MariaDB.
  Versión: **9.0.0**

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0
```

- Verificar paquetes instalados:

```bash
  dotnet list package
```

- Crear Migración Inicial desde (Infrastructure)

```bash
dotnet ef migrations add InitialCreate --startup-project ../System.Api --project .
```

- Actualizar la base de datos desde (Infrastructure)

```bash
dotnet ef database update --startup-project ../System.Api --project .
```

> Se recomienda usar exactamente las versiones indicadas para evitar conflictos de compatibilidad.

---

Project 'System.**Infrastructure**' has the following package references
[net8.0]:
Top-level Package                          Requested   Resolved
> Microsoft.EntityFrameworkCore            9.0.9       9.0.9   
> Microsoft.EntityFrameworkCore.Tools      9.0.9       9.0.9   
> Pomelo.EntityFrameworkCore.MySql         9.0.0       9.0.0 


Project 'System.**Api**' has the following package references
[net8.0]:
Top-level Package                           Requested   Resolved
> Microsoft.AspNetCore.OpenApi              8.0.17      8.0.17  
> Microsoft.EntityFrameworkCore             9.0.10      9.0.10  
> Microsoft.EntityFrameworkCore.Design      9.0.9       9.0.9   
> Pomelo.EntityFrameworkCore.MySql          9.0.0       9.0.0   
> Swashbuckle.AspNetCore                    6.6.2       6.6.2
---

Cree carpeta Data para Crear el DBcontext