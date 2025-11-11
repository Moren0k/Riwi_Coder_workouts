# System - API en capas (API / Application / Domain / Infrastructure)

Este repositorio contiene una aplicación de ejemplo construida con .NET 9 y arquitectura en capas: **API**, **Application**, **Domain** e **Infrastructure**. El objetivo es demostrar un proyecto realista con autenticación JWT, hashing de contraseñas, uso de Entity Framework Core con MySQL (Pomelo) y separación clara de responsabilidades.

## 1. Introducción

La aplicación provee una API REST básica para gestionar usuarios y productos. Sus responsabilidades principales son:

- Registro y autenticación de usuarios (usando JWT).
- Operaciones CRUD sobre productos.
- Gestión de roles (Admin, User, Guest) para controlar acceso a ciertos endpoints.

Esta solución es adecuada para aprender patrones de arquitectura en capas, inyección de dependencias, mapeo DTO <-> entidad y uso de EF Core para persistencia.

## 2. Estructura de carpetas y proyectos

La solución (Solution.sln) contiene cuatro proyectos principales, cada uno con una responsabilidad:

- `System.Api` (Web API)
	- Contiene los controladores (`Controllers/`), configuraciones de autenticación y la entrada `Program.cs`.
	- Expone los endpoints consumidos por clientes/front-end.

- `System.Application` (Lógica de aplicación)
	- Contiene DTOs (`DTOs/`), interfaces de servicios (`Interfaces/`) y la implementación de los servicios (`Services/`).
	- Orquesta la lógica entre repositorios y capas superiores.

- `System.Domain` (Modelo de dominio)
	- Define las entidades (`Entities/`) y las interfaces del repositorio/contratos (`Interfaces/`).
	- Contiene enumeraciones y reglas de negocio puras (en este ejemplo, principalmente las entidades `User` y `Product` y el enum `Role`).

- `System.Infrastructure` (Acceso a datos e implementación)
	- Implementa repositorios concretos (`Repositories/`), `AppDbContext` en `Data/` y las migraciones.
	- Contiene la configuración específica de la base de datos (EF Core / Pomelo).

Interacción entre capas:

- `System.Api` consume interfaces de `System.Application`.
- `System.Application` depende de `System.Domain` (entidades e interfaces) y de `System.Infrastructure` en tiempo de ejecución donde se inyectan las implementaciones de repositorio.
- `System.Infrastructure` implementa las interfaces definidas en `System.Domain` y usa `AppDbContext` (EF Core) para persistir entidades.

## 3. Dependencias y referencias principales

Paquetes y librerías usados (ejemplos en este proyecto):

- Entity Framework Core (MySQL via Pomelo): `Pomelo.EntityFrameworkCore.MySql`, `Microsoft.EntityFrameworkCore.Design`, `Microsoft.EntityFrameworkCore.Tools` (se agregan al proyecto `System.Infrastructure`).
- Autenticación JWT: `Microsoft.AspNetCore.Authentication.JwtBearer`, `System.IdentityModel.Tokens.Jwt` (en `System.Api`).
- Hash de contraseñas: `BCrypt.Net-Core` (en `System.Application` para hashear/verificar contraseñas).
- Otras utilidades: `Microsoft.EntityFrameworkCore.Design` (en `System.Api` para herramientas de migración si aplica).

Las referencias entre proyectos se establecieron así (ver sección 4 para el snippet de inicialización):

- `System.Api` referencia `System.Application`.
- `System.Application` referencia `System.Domain` y `System.Infrastructure`.
- `System.Infrastructure` referencia `System.Domain`.

## 4. Inicialización del proyecto (cómo se creó)

El proyecto se creó siguiendo un flujo CLI de ejemplo (a partir de un directorio `Modulo7_Semana3`):

```bash
mkdir Modulo7_Semana3
cd Modulo7_Semana3

# Crear solución
dotnet new sln -n Solution

# Crear proyectos
dotnet new webapi -n System.Api
dotnet new classlib -n System.Application
dotnet new classlib -n System.Domain
dotnet new classlib -n System.Infrastructure

# Añadir proyectos a la solución
dotnet sln add System.Api
dotnet sln add System.Application
dotnet sln add System.Domain
dotnet sln add System.Infrastructure

# Referencias entre proyectos
dotnet add System.Api reference System.Application
dotnet add System.Application reference System.Domain
dotnet add System.Application reference System.Infrastructure
dotnet add System.Infrastructure reference System.Domain

# Paquetes (ejemplos)
dotnet add System.Infrastructure package Pomelo.EntityFrameworkCore.MySql
dotnet add System.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add System.Infrastructure package Microsoft.EntityFrameworkCore.Tools

dotnet add System.Api package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add System.Api package System.IdentityModel.Tokens.Jwt
dotnet add System.Application package BCrypt.Net-Core
dotnet add System.Api package Microsoft.EntityFrameworkCore.Design
```

> Nota: los paquetes y versiones pueden variar. Para producción, fije versiones concretas y actualice las migraciones y `appsettings` según el proveedor de DB.

## 5. Endpoints principales

Rutas expuestas por los controladores (resumen):

- `ProductsController` (`/api/products`) — requiere autorización global (`[Authorize]`):
	- POST `/api/products` : Crear un producto (consumidor: `IProductService`).
	- GET `/api/products` : Obtener todos los productos.
	- GET `/api/products/{id}` : Obtener producto por id.
	- PUT `/api/products/{id}` : Actualizar producto.
	- DELETE `/api/products/{id}` : Eliminar producto.

- `UserController` (`/api/user`):
	- POST `/api/user/auth/register` : Registrar usuario (público) — crea usuario con rol opcional.
	- POST `/api/user/auth/login` : Login (público) — devuelve token JWT si credenciales válidas.
	- GET `/api/user` : Obtener todos los usuarios — requiere rol `Admin`.
	- GET `/api/user/{id}` : Obtener usuario por id — requiere autorización.
	- GET `/api/user/by-username/{username}` : Obtener usuario por username — requiere autorización.
	- PUT `/api/user/{id}` : Actualizar usuario — requiere autorización.
	- DELETE `/api/user/{id}` : Eliminar usuario — requiere autorización.

Roles y permisos:

- `Admin`: puede listar todos los usuarios (atributo `[Authorize(Roles = "Admin")]`).
- `User` y `Guest`: acceso restringido según endpoint; la autorización se controla mediante atributos `[Authorize]` y claims en el JWT.

## 6. JWT y seguridad

Autenticación:

- Al iniciar sesión (`Login`), el servicio de aplicación valida la contraseña (BCrypt) y si es correcta, `AuthService` genera un JWT con claims básicos: `sub` (username), `role` (rol del usuario) y `jti`.
- El token se firma con una clave simétrica definida en `appsettings.json` (`Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience`) y tiene una expiración corta (ej. 30 minutos en este ejemplo).

Autorización:

- Los controladores usan `[Authorize]` y `[Authorize(Roles = "Admin")]` para proteger rutas.
- En `Program.cs` de `System.Api` se configura `JwtBearer` para validar issuer/audience/clave y extraer claims que luego se usan en `[Authorize]`.

Buenas prácticas sugeridas:

- Almacenar la clave JWT en un secreto seguro (Azure Key Vault, AWS Secrets Manager, variables de entorno) en lugar de `appsettings.json` en producción.
- Rotación de claves y refresh tokens si el caso de uso lo requiere.

## 7. Base de datos

Tipo: MySQL (ej. instancia en la nube). En el proyecto se usa Pomelo como proveedor para EF Core.

Configuración:

- `System.Infrastructure` contiene `AppDbContext` con `DbSet<User>` y `DbSet<Product>`.
- Las cadenas de conexión y opciones de EF Core se configuran en `appsettings.json` y en `Program.cs` al registrar `DbContext` con `AddDbContext<AppDbContext>(options => options.UseMySql(...))`.

Migraciones:

- Se pueden crear y aplicar migraciones desde el proyecto `System.Infrastructure` o desde la solución, usando `dotnet ef migrations add` y `dotnet ef database update` apuntando al proyecto correcto.

## 8. Diagrama de arquitectura (resumen)

La solución sigue un patrón clásico en capas:

- Capa API: expone endpoints HTTP y recibe/valida peticiones.
- Capa Application: orquesta casos de uso, contiene DTOs y servicios que implementan la lógica de aplicación. Depende de los contratos del dominio (interfaces de repositorio).
- Capa Domain: contiene las entidades y contratos (interfaces) que definen la persistencia y reglas del negocio.
- Capa Infrastructure: implementa los repositorios concretos usando EF Core y ofrece el `AppDbContext`.

Dependencias clave: API → Application → Domain; en tiempo de ejecución Application usa implementaciones de Infrastructure registradas en el contenedor de DI.

 (También se proporcionó un diagrama PlantUML en este repository —revisa `System.Api` o la documentación adicional— que muestra clases, DTOs, interfaces y dependencias.)

## 9. Notas de despliegue (idea general)

- Contenerizar la API: crear un `Dockerfile` para `System.Api` que publique la app y exponga el puerto HTTP. Construir la imagen y empujarla a un registry (Docker Hub, ACR, ECR).
- Configurar la base de datos en un servicio gestionado (MySQL en la nube) y proteger credenciales mediante variables de entorno o un secreto.
- Orquestación: usar `docker-compose` para desarrollo local (API + DB) o un pipeline CI/CD para despliegue a Kubernetes/App Service.

Consejo: no incluir secretos en la imagen; inyectar la connection string y la clave JWT desde el entorno al lanzar el contenedor.

## 10. Pruebas y validaciones

Este proyecto contiene pruebas mínimas (si se agregaron) o puntos claros donde incorporar pruebas unitarias e integración:

- Pruebas unitarias para `ProductService` y `UserService`: validar que la lógica de mapeo, llamadas a repositorio y gestión de contraseñas funcionan correctamente (mockear `IProductRepository`/`IUserRepository` y `IAuthService`).
- Pruebas de integración: levantar una instancia de base de datos en memoria o una BD de pruebas y verificar endpoints y migraciones.
- Validaciones en DTOs: Atributos de DataAnnotations (`[Required]`, `[Range]`, `[MaxLength]`) ya presentes garantizan validaciones básicas a nivel de modelo.

Si quieres, puedo añadir un proyecto de test xUnit/Moq y ejemplos de tests para los servicios principales.

## 11. Recomendaciones finales y cómo usar la API

Cómo empezar rápido:

1. Clonar la solución y abrirla en VS Code / Visual Studio.
2. Configurar `appsettings.Development.json` con la `ConnectionStrings` hacia tu MySQL de pruebas y valores `Jwt` (Key, Issuer, Audience).
3. En desarrollo local puedes usar `docker-compose` para levantar un contenedor MySQL y apuntar `AppDbContext` a esa instancia.
4. Ejecutar la API y probar endpoints con Postman o cURL:

- Registrar usuario: `POST /api/user/auth/register` con `username`, `email`, `password`, opcional `role`.
- Login: `POST /api/user/auth/login` con `email` y `password`. Recibirás un token JWT.
- Incluir `Authorization: Bearer <token>` en las peticiones protegidas (ej. `GET /api/products`).

Buenas prácticas para desarrolladores:

- Añadir tests unitarios para servicios y controladores.
- Externalizar secrets y usar variables de entorno en CI/CD.
- Añadir logging estructurado y manejo centralizado de errores.

---
