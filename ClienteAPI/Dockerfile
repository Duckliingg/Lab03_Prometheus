# Imagen base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["ClienteAPI.csproj", "."]
RUN dotnet restore "ClienteAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ClienteAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClienteAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClienteAPI.dll"]
