# -------------------------------
# Stage 1: Build (React + Vite)
# -------------------------------
FROM node:22-slim AS build
WORKDIR /app

# Copy Dependencies 
COPY package*.json ./
RUN npm install

# Copy the project 
COPY . .

# Build app 
RUN npm run build

# -------------------------------
# Stage 2: Runtime (Nginx)
# -------------------------------
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Copy from app
COPY --from=build /app/dist .

# Expose port 
EXPOSE 80

# Start Nginx 
CMD ["nginx", "-g", "daemon off;"]
