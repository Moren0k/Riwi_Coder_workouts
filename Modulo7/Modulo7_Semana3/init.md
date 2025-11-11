# INIT

## Fold

mkdir Modulo7_Semana3
cd Modulo7_Semana3

### Solution

dotnet new sln -n Solution

#### Projects

dotnet new webapi -n System.Api
dotnet new classlib -n System.Application
dotnet new classlib -n System.Domain
dotnet new classlib -n System.Infrastructure

#### Add Projects

dotnet sln add System.Api
dotnet sln add System.Application
dotnet sln add System.Domain
dotnet sln add System.Infrastructure

---

#### Api -> Application

dotnet add System.Api reference System.Application

#### Application -> Domain

dotnet add System.Application reference System.Domain

#### Application -> Infrastructure

dotnet add System.Application reference System.Infrastructure

#### Infrastructure -> Domain

dotnet add System.Infrastructure reference System.Domain

---

#### EntityFrameworkCore

dotnet add System.Infrastructure package Pomelo.EntityFrameworkCore.MySql
dotnet add System.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add System.Infrastructure package Microsoft.EntityFrameworkCore.Tools

#### Json web token

dotnet add System.Api package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add System.Api package System.IdentityModel.Tokens.Jwt
dotnet add System.Application package BCrypt.Net-Core
dotnet add System.Api package Microsoft.EntityFrameworkCore.Design
dotnet add System.Api package DotNetEnv

