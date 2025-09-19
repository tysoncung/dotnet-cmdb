# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY SimpleCMDB/SimpleCMDB.csproj SimpleCMDB/
RUN dotnet restore SimpleCMDB/SimpleCMDB.csproj
COPY SimpleCMDB/ SimpleCMDB/
WORKDIR /src/SimpleCMDB
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Create directory for SQLite database
RUN mkdir -p /app/data

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port
EXPOSE 8080

# Run the application
ENTRYPOINT ["dotnet", "SimpleCMDB.dll"]