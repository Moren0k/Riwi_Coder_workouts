FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["System.Api/System.Api.csproj", "System.Api/"]
COPY ["System.Application/System.Application.csproj", "System.Application/"]
COPY ["System.Domain/System.Domain.csproj", "System.Domain/"]
COPY ["System.Infrastructure/System.Infrastructure.csproj", "System.Infrastructure/"]
RUN dotnet restore "System.Api/System.Api.csproj"
COPY . .
WORKDIR "/src/System.Api"
RUN dotnet build "./System.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./System.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
ENTRYPOINT ["dotnet", "System.Api.dll"]
