# -------------------------------
# Stage 1: Build
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy Dependecies 
COPY ./Api/Api.csproj ./Api/
RUN dotnet restore ./Api/Api.csproj

# Copy Api
COPY ./Api ./Api
WORKDIR /src/Api

# Release 
RUN dotnet publish -c Release -o /app/publish -p:UseAppHost=false

# -------------------------------
# Stage 2: Runtime
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy
COPY --from=build /app/publish .

# Port 8080 para Fly.io
EXPOSE 8080

ENTRYPOINT ["dotnet", "Api.dll"]

