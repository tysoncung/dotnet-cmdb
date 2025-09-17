# .NET Core Simple CMDB

A lightweight Configuration Management Database (CMDB) built with ASP.NET Core MVC and SQLite.

## Features

- 🖥️ **Server Management** - Track physical and virtual servers
- 📱 **Application Inventory** - Manage applications and versions
- ⚙️ **Service Mapping** - Document services and their ports
- 🔗 **Dependency Tracking** - Map relationships between services
- 🚀 **No External Dependencies** - Uses SQLite (no database server needed!)

## Prerequisites

- .NET 8.0 or later
- Visual Studio 2022 / VS Code / Rider

## Quick Start

```bash
# Clone the repository
git clone https://github.com/tysoncung/dotnet-cmdb.git
cd dotnet-cmdb/SimpleCMDB

# Install Entity Framework Core tools
dotnet tool install --global dotnet-ef

# Run database migrations
dotnet ef database update

# Run the application
dotnet run

# Open browser to http://localhost:5079
```

## Project Structure

```
SimpleCMDB/
├── Controllers/         # MVC Controllers
├── Models/             # Entity models
├── Views/              # Razor views
├── Data/               # Database context
├── wwwroot/            # Static files
└── Program.cs          # Application entry point
```

## Models

- **Server** - Physical or virtual servers
- **Application** - Software applications
- **Service** - Running services on servers
- **Dependency** - Service-to-service dependencies

## Database

The application uses SQLite with Entity Framework Core. The database file `cmdb.db` is created automatically on first run.

## API Endpoints

```bash
# Servers
GET    /api/servers          # List all servers
GET    /api/servers/{id}     # Get server details
POST   /api/servers          # Create server
PUT    /api/servers/{id}     # Update server
DELETE /api/servers/{id}     # Delete server

# Applications
GET    /api/applications     # List all applications
GET    /api/applications/{id} # Get application details
POST   /api/applications     # Create application
PUT    /api/applications/{id} # Update application
DELETE /api/applications/{id} # Delete application

# Services
GET    /api/services         # List all services
GET    /api/services/{id}    # Get service details
POST   /api/services         # Create service
PUT    /api/services/{id}    # Update service
DELETE /api/services/{id}    # Delete service

# Dependencies
GET    /api/dependencies     # List all dependencies
POST   /api/dependencies     # Create dependency
DELETE /api/dependencies/{id} # Delete dependency
```

## Development

### Add New Migration

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Run with Hot Reload

```bash
dotnet watch run
```

## Docker Support

```bash
# Build Docker image
docker build -t dotnet-cmdb .

# Run container
docker run -d -p 8080:8080 --name dotnet-cmdb dotnet-cmdb
```

## Configuration

Edit `appsettings.json` to configure:
- Database connection string
- Logging levels
- Other application settings

## License

MIT

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request