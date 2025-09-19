using Microsoft.EntityFrameworkCore;
using SimpleCMDB.Models;
using System;
using System.Linq;

namespace SimpleCMDB.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CmdbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CmdbContext>>()))
            {
                // Check if DB has been seeded
                if (context.Servers.Any())
                {
                    return; // DB has been seeded
                }

                // Add Applications
                var applications = new Application[]
                {
                    new Application { Name = "E-Commerce Platform", Version = "3.2.1", Type = "Web", Language = "C#", Criticality = "critical", Owner = "Digital Team" },
                    new Application { Name = "HR Management System", Version = "2.0.5", Type = "Desktop", Language = "Java", Criticality = "high", Owner = "HR Department" },
                    new Application { Name = "Inventory Tracker", Version = "1.5.0", Type = "Web", Language = "Python", Criticality = "medium", Owner = "Operations" },
                    new Application { Name = "Customer Portal", Version = "4.1.0", Type = "Web", Language = "JavaScript", Criticality = "critical", Owner = "Customer Service" },
                    new Application { Name = "Analytics Dashboard", Version = "2.3.0", Type = "Web", Language = "Python", Criticality = "high", Owner = "Data Team" }
                };

                context.Applications.AddRange(applications);
                context.SaveChanges();

                // Add Servers
                var servers = new Server[]
                {
                    new Server {
                        Hostname = "web-prod-01",
                        IpAddress = "10.0.1.10",
                        OsType = "Linux",
                        OsVersion = "Ubuntu 22.04",
                        Environment = "production",
                        Status = "active",
                        Owner = "DevOps Team",
                        Location = "US-East-1",
                        CpuCount = 8,
                        MemoryGb = 32,
                        DiskGb = 500
                    },
                    new Server {
                        Hostname = "web-prod-02",
                        IpAddress = "10.0.1.11",
                        OsType = "Linux",
                        OsVersion = "Ubuntu 22.04",
                        Environment = "production",
                        Status = "active",
                        Owner = "DevOps Team",
                        Location = "US-East-1",
                        CpuCount = 8,
                        MemoryGb = 32,
                        DiskGb = 500
                    },
                    new Server {
                        Hostname = "db-prod-01",
                        IpAddress = "10.0.2.10",
                        OsType = "Linux",
                        OsVersion = "RHEL 8",
                        Environment = "production",
                        Status = "active",
                        Owner = "Database Team",
                        Location = "US-East-1",
                        CpuCount = 16,
                        MemoryGb = 128,
                        DiskGb = 2000
                    },
                    new Server {
                        Hostname = "app-staging-01",
                        IpAddress = "10.1.1.10",
                        OsType = "Windows",
                        OsVersion = "Server 2022",
                        Environment = "staging",
                        Status = "active",
                        Owner = "QA Team",
                        Location = "US-West-2",
                        CpuCount = 4,
                        MemoryGb = 16,
                        DiskGb = 200
                    },
                    new Server {
                        Hostname = "dev-server-01",
                        IpAddress = "10.2.1.10",
                        OsType = "Linux",
                        OsVersion = "Debian 11",
                        Environment = "development",
                        Status = "active",
                        Owner = "Development Team",
                        Location = "On-Premise",
                        CpuCount = 4,
                        MemoryGb = 8,
                        DiskGb = 100
                    }
                };

                context.Servers.AddRange(servers);
                context.SaveChanges();

                // Add Services
                var services = new Service[]
                {
                    new Service {
                        ServiceName = "nginx",
                        ServerId = servers[0].Id,
                        ApplicationId = applications[0].Id,
                        Port = 443,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "nginx",
                        ConfigFile = "/etc/nginx/nginx.conf",
                        LogFile = "/var/log/nginx/access.log"
                    },
                    new Service {
                        ServiceName = "nginx",
                        ServerId = servers[1].Id,
                        ApplicationId = applications[0].Id,
                        Port = 443,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "nginx",
                        ConfigFile = "/etc/nginx/nginx.conf",
                        LogFile = "/var/log/nginx/access.log"
                    },
                    new Service {
                        ServiceName = "postgresql",
                        ServerId = servers[2].Id,
                        ApplicationId = applications[0].Id,
                        Port = 5432,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "postgres",
                        ConfigFile = "/etc/postgresql/14/main/postgresql.conf",
                        LogFile = "/var/log/postgresql/postgresql-14-main.log"
                    },
                    new Service {
                        ServiceName = "redis",
                        ServerId = servers[2].Id,
                        ApplicationId = applications[0].Id,
                        Port = 6379,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "redis-server",
                        ConfigFile = "/etc/redis/redis.conf",
                        LogFile = "/var/log/redis/redis-server.log"
                    },
                    new Service {
                        ServiceName = "dotnet",
                        ServerId = servers[0].Id,
                        ApplicationId = applications[0].Id,
                        Port = 5000,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "dotnet",
                        StartCommand = "dotnet /app/ecommerce.dll",
                        LogFile = "/var/log/ecommerce/app.log"
                    },
                    new Service {
                        ServiceName = "java-app",
                        ServerId = servers[3].Id,
                        ApplicationId = applications[1].Id,
                        Port = 8080,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "java",
                        StartCommand = "java -jar /app/hrms.jar",
                        LogFile = "C:\\logs\\hrms\\application.log"
                    },
                    new Service {
                        ServiceName = "python-api",
                        ServerId = servers[4].Id,
                        ApplicationId = applications[2].Id,
                        Port = 8000,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "python3",
                        StartCommand = "python3 /app/inventory/main.py",
                        LogFile = "/var/log/inventory/app.log"
                    },
                    new Service {
                        ServiceName = "node-portal",
                        ServerId = servers[0].Id,
                        ApplicationId = applications[3].Id,
                        Port = 3000,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "node",
                        StartCommand = "node /app/portal/server.js",
                        LogFile = "/var/log/portal/app.log"
                    },
                    new Service {
                        ServiceName = "analytics-api",
                        ServerId = servers[1].Id,
                        ApplicationId = applications[4].Id,
                        Port = 5001,
                        Protocol = "tcp",
                        Status = "running",
                        ProcessName = "python3",
                        StartCommand = "python3 /app/analytics/app.py",
                        LogFile = "/var/log/analytics/app.log"
                    },
                    // External services
                    new Service {
                        ServiceName = "AWS S3 Storage",
                        ServerId = null,
                        ApplicationId = applications[0].Id,
                        Port = 443,
                        Protocol = "HTTPS",
                        Status = "running",
                        IsExternal = true,
                        ExternalUrl = "https://s3.amazonaws.com"
                    },
                    new Service {
                        ServiceName = "Stripe Payment API",
                        ServerId = null,
                        ApplicationId = applications[0].Id,
                        Port = 443,
                        Protocol = "HTTPS",
                        Status = "running",
                        IsExternal = true,
                        ExternalUrl = "https://api.stripe.com"
                    },
                    new Service {
                        ServiceName = "SendGrid Email",
                        ServerId = null,
                        ApplicationId = applications[3].Id,
                        Port = 587,
                        Protocol = "SMTP",
                        Status = "running",
                        IsExternal = true,
                        ExternalUrl = "https://api.sendgrid.com"
                    },
                    new Service {
                        ServiceName = "Cloudflare CDN",
                        ServerId = null,
                        ApplicationId = applications[0].Id,
                        Port = 443,
                        Protocol = "HTTPS",
                        Status = "running",
                        IsExternal = true,
                        ExternalUrl = "https://cloudflare.com"
                    },
                    new Service {
                        ServiceName = "Auth0 Identity",
                        ServerId = null,
                        ApplicationId = applications[3].Id,
                        Port = 443,
                        Protocol = "HTTPS",
                        Status = "running",
                        IsExternal = true,
                        ExternalUrl = "https://auth0.com"
                    }
                };

                context.Services.AddRange(services);
                context.SaveChanges();

                // Add Dependencies
                var dependencies = new Dependency[]
                {
                    new Dependency {
                        SourceServiceId = services[0].Id, // nginx on web-prod-01
                        TargetServiceId = services[4].Id, // dotnet on web-prod-01
                        Description = "Nginx proxies requests to .NET application"
                    },
                    new Dependency {
                        SourceServiceId = services[4].Id, // dotnet app
                        TargetServiceId = services[2].Id, // postgresql
                        Description = ".NET application connects to PostgreSQL database"
                    },
                    new Dependency {
                        SourceServiceId = services[4].Id, // dotnet app
                        TargetServiceId = services[3].Id, // redis
                        Description = ".NET application uses Redis for caching"
                    },
                    new Dependency {
                        SourceServiceId = services[1].Id, // nginx on web-prod-02
                        TargetServiceId = services[7].Id, // node-portal
                        Description = "Nginx proxies requests to Node.js portal"
                    },
                    new Dependency {
                        SourceServiceId = services[7].Id, // node-portal
                        TargetServiceId = services[2].Id, // postgresql
                        Description = "Portal connects to PostgreSQL database"
                    },
                    new Dependency {
                        SourceServiceId = services[8].Id, // analytics-api
                        TargetServiceId = services[2].Id, // postgresql
                        Description = "Analytics API reads from PostgreSQL"
                    },
                    new Dependency {
                        SourceServiceId = services[4].Id, // dotnet app
                        TargetServiceId = services[9].Id, // AWS S3
                        Description = ".NET app stores files in AWS S3"
                    },
                    new Dependency {
                        SourceServiceId = services[4].Id, // dotnet app
                        TargetServiceId = services[10].Id, // Stripe
                        Description = ".NET app processes payments via Stripe"
                    },
                    new Dependency {
                        SourceServiceId = services[7].Id, // node-portal
                        TargetServiceId = services[11].Id, // SendGrid
                        Description = "Portal sends emails via SendGrid"
                    },
                    new Dependency {
                        SourceServiceId = services[7].Id, // node-portal
                        TargetServiceId = services[13].Id, // Auth0
                        Description = "Portal authenticates users via Auth0"
                    }
                };

                context.Dependencies.AddRange(dependencies);
                context.SaveChanges();
            }
        }
    }
}