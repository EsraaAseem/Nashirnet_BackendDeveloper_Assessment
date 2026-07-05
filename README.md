# Roles & Permissions Product

A small ASP.NET Core MVC application demonstrating role- and permission-driven access to a product catalog, 
built with Clean Architecture.
## Tech Stack

- .NET 9 / ASP.NET Core MVC
- Entity Framework Core 9 (SQL Server)
- JWT Authentication

## Project Structure
TaskManagement/
## ProductManagement.Web/   
 Web Layer (Controllers, Views)
## ProductManagement.Application/  
 Business Logic (Services, DTOs, Interfaces)
## ProductManagement.Domain/      
 Domain Layer (Entities, Enums)
## ProductManagement.Infrastructure/ 
 External Services (JWT, Hashing Service)
## ProductManagement.Persistence/ 
 Database Layer (DbContext, Repositories, Seeders)
## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server or LocalDB

## Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/EsraaAseem/Nashirnet_BackendDeveloper_Assessment.git
cd ProductManagement
```

### 2. Update appsettings.json in ProductManagement
```json

  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ProductManagementDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "JwtSettings": {
    "Key": "Your Key",
    "Issuer": "ProductManagement",
    "Audience": "ProductManagementUsers",
    "DurationInDays": 1
  },
 
```

### 3. Apply migrations and seed data — this happens automatically on startup (see Program.cs)
   On first run, the app will:

Create the database and apply EF Core migrations.
Seed Categories and Products from the provided JSON files (SeedData/categories.json, SeedData/products.json).

 ## Code of Honor: I confirm the submitted work is my own and was completed without AI code-generation tools.  — <Your Name>, <Date>

Seed the three roles (Sales, InventoryManager, Admin) and their category/column permissions, per the permission matrix in the brief.

