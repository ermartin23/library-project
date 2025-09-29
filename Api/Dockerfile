# -------------------------------
# Stage 1: Build
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY Api.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# -------------------------------
# Stage 2: Runtime
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose port 8080 (Fly.io default)
EXPOSE 8080

ENTRYPOINT ["dotnet", "Api.dll"]
