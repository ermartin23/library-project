# -------------------------------
# Stage 1: Build (React + Vite)
# -------------------------------
FROM node:22-slim AS build
WORKDIR /app

# Copiar archivos de dependencias
COPY package*.json ./
RUN npm install

# Copiar el resto del proyecto
COPY . .

# Construir la app para producción
RUN npm run build

# -------------------------------
# Stage 2: Runtime (Nginx)
# -------------------------------
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Copiar archivos generados en el build
COPY --from=build /app/dist .

# Exponer puerto 80 (Fly.io usará este puerto por defecto)
EXPOSE 80

# Arrancar nginx
CMD ["nginx", "-g", "daemon off;"]
