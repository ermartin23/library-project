Library Books 📚
A full-stack library management system with CRUD operations, Swagger API documentation, and a modern frontend interface.
 Key Features
📚 Complete book management (Add, View, Update, Delete)
🔧 RESTful API with full CRUD operations
📖 Interactive Swagger API documentation
🎨 Simple UI with DaisyUI
🗄️ Neon Database integration

library-project/
├── Api/                          # Backend API (.NET Core)
│   ├── Controllers/              # API Controllers
│   │   ├── AuthorController.cs
│   │   ├── BookController.cs
│   │   └── GenreController.cs
│   ├── DataAccess/              # Data access layer
│   ├── Dtos/                    # Data transfer objects (Author,Books and Genre Dtos.cs)
│   ├── Migrations/              # Database migrations
│   ├── Api.http                 # HTTP request 
│   ├── appsettings.json         # Configuration
│   ├── appsettings.Development.json
│   ├── Dockerfile               # Docker configuration
│   ├── fly.toml                 # Fly.io deployment config
│   └── Program.cs               # Application entry point
│
├── frontend/                    
│   ├── dist/                    # Build output
│   ├── node_modules/            # Dependencies
│   ├── public/                  # Static assets
│   ├── src/                     # Source code
│   │   ├── components/         # React components
│   │   ├── pages/              # Page components
│   │   ├── services/           # API services
│   │   ├── App.jsx             # Main component
│   │   ├── main.jsx            # Entry point
│   │   └── index.css           # Global styles
│   ├── index.html              # HTML template
│   ├── vite.config.js          # Vite configuration
│   ├── tailwind.config.js      # Tailwind configuration
│   └── package.json            # Frontend dependencies


Tech Stack

Backend
.NET Core - Backend framework
C# - Programming language
Neon Database - PostgreSQL database
Swagger - API documentation
Fly.io - Cloud deployment

Open Swagger 
https://library-api-erica.fly.dev/swagger

Frontend
React + Vite - Frontend framework
DaisyUI - UI component library
Tailwind CSS - Utility-first CSS
JavaScript - Programming language

Open Application 
http://localhost:5173

OBS: Several issues with Docker and dockerfile implementation 

Screenshot 
<img width="1707" height="816" alt="image" src="https://github.com/user-attachments/assets/6792805e-02d5-44c4-8124-d186b70a5b80" />
<img width="1857" height="730" alt="image" src="https://github.com/user-attachments/assets/ed5b2c4b-2a4e-4e2d-841c-38e6d0d49ddb" />

Ermartin23

GitHub: @ermartin23
Project Repository: library-project
Please:  


