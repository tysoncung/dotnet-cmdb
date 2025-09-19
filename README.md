# .NET Core Simple CMDB

A comprehensive Configuration Management Database (CMDB) built with ASP.NET Core MVC and SQLite, featuring interactive dependency visualization and support for both internal and external services.

## Features

- 🖥️ **Server Management** - Track physical and virtual servers with detailed specifications
- 📱 **Application Inventory** - Manage applications, versions, and ownership
- ⚙️ **Service Mapping** - Document both internal services and external cloud services
- 🔗 **Advanced Dependency Tracking** - Map relationships with authentication, protocols, and SLA details
- 📊 **Interactive Visualization** - View service dependencies as UML deployment diagrams using vis.js
- ☁️ **External Service Support** - Track cloud services like AWS, Azure, Stripe, SendGrid
- 🔐 **Authentication Tracking** - Document service accounts, certificates, and auth methods
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

# Open browser to http://localhost:5111
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

- **Server** - Physical or virtual servers with environment, location, and resource specifications
- **Application** - Software applications with version, owner, and criticality tracking
- **Service** - Both internal services (on servers) and external services (cloud/SaaS)
- **Dependency** - Advanced service-to-service relationships with:
  - Connection details (protocol, port, timeout, retry)
  - Authentication (service accounts, certificates, auth methods)
  - SLA parameters (criticality flags, API versions)

## Key Features

### Interactive Dependency Visualization
- Navigate to `/Dependencies` to see an interactive network diagram
- Servers displayed as boxes containing their services
- External services shown as cloud-shaped nodes
- Color-coded by environment (Production, Staging, Development)
- Click nodes for detailed information
- Drag nodes to rearrange the layout

### External Service Support
- Track cloud services (AWS S3, Azure, Google Cloud)
- Document third-party APIs (Stripe, SendGrid, Auth0)
- Specify external URLs and endpoints
- Maintain SLA and authentication details

## Database

The application uses SQLite with Entity Framework Core. The database file `cmdb.db` is created automatically on first run with sample data.

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