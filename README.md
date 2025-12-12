# Spliit - .NET & Angular Migration

A free and open source expense splitting application built with .NET 10 and Angular.

## Architecture

### Backend (.NET 10)
- **Clean Architecture** with separation of concerns
- **Spliit.Core**: Domain entities, interfaces, enums
- **Spliit.Application**: Business logic, services, DTOs
- **Spliit.Infrastructure**: Data access, EF Core, repositories
- **Spliit.Api**: REST API controllers, dependency injection

### Frontend (Angular)
- **Feature-based structure** with lazy loading
- **PrimeNG** for UI components
- **Tailwind CSS** for styling
- **Reactive Forms** for form handling
- **HttpClient** for API communication

## Features

- ✅ Clean Architecture with SOLID principles
- ✅ Unit of Work pattern for explicit transaction management
- ✅ Repository pattern with direct DI injection
- ✅ Dependency Injection throughout (no service locator anti-pattern)
- ✅ Base entity with common properties (ID, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
- ✅ GUID-based IDs
- ✅ PostgreSQL database with EF Core
- ✅ RESTful API
- ✅ Health check endpoints

## Prerequisites

- .NET 10 SDK
- Node.js 18+
- PostgreSQL 14+
- Angular CLI

## Getting Started

### Backend Setup

1. Navigate to backend directory:
```bash
cd backend
```

2. Update connection string in `src/Spliit.Api/appsettings.json`

3. Install EF Core tools:
```bash
dotnet tool install --global dotnet-ef
```

4. Create database migration:
```bash
cd src/Spliit.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../Spliit.Api
dotnet ef database update --startup-project ../Spliit.Api
```

5. Run the API:
```bash
cd ../Spliit.Api
dotnet run
```

API will be available at `http://localhost:5000`

### Frontend Setup

1. Navigate to frontend directory:
```bash
cd frontend
```

2. Install dependencies:
```bash
npm install
```

3. Run the application:
```bash
npm start
```

Application will be available at `http://localhost:4200`

## Project Structure

```
backend/
├── src/
│   ├── Spliit.Core/           # Domain layer
│   │   ├── Common/            # Base entities
│   │   ├── Entities/          # Domain entities
│   │   ├── Enums/             # Enumerations
│   │   └── Interfaces/        # Repository interfaces
│   ├── Spliit.Application/    # Application layer
│   │   ├── DTOs/              # Data transfer objects
│   │   ├── Interfaces/        # Service interfaces
│   │   └── Services/          # Business logic
│   ├── Spliit.Infrastructure/ # Infrastructure layer
│   │   ├── Data/              # DbContext, UnitOfWork
│   │   └── Repositories/      # Repository implementations
│   └── Spliit.Api/            # Presentation layer
│       └── Controllers/       # API controllers

frontend/
├── src/
│   ├── app/
│   │   ├── core/              # Core services and models
│   │   │   ├── models/        # TypeScript interfaces
│   │   │   └── services/      # API services
│   │   ├── features/          # Feature modules
│   │   │   ├── groups/        # Groups feature
│   │   │   └── expenses/      # Expenses feature
│   │   └── shared/            # Shared components
│   └── environments/          # Environment configs
```

## API Endpoints

### Groups
- `GET /api/groups` - Get all groups
- `GET /api/groups/{id}` - Get group by ID
- `POST /api/groups` - Create group
- `PUT /api/groups/{id}` - Update group
- `DELETE /api/groups/{id}` - Delete group

### Expenses
- `GET /api/expenses/{id}` - Get expense by ID
- `GET /api/expenses/group/{groupId}` - Get expenses by group
- `POST /api/expenses` - Create expense
- `PUT /api/expenses/{id}` - Update expense
- `DELETE /api/expenses/{id}` - Delete expense

### Health
- `GET /api/health` - Readiness check
- `GET /api/health/liveness` - Liveness check

## Database Design

All entities inherit from `BaseEntity` with common properties:
- `Id` (Guid) - Primary key
- `CreatedAt` (DateTime) - Creation timestamp
- `CreatedBy` (string) - Creator identifier
- `UpdatedAt` (DateTime?) - Last update timestamp
- `UpdatedBy` (string?) - Last updater identifier

## Technologies

### Backend
- .NET 10
- Entity Framework Core 10
- Npgsql (PostgreSQL provider)
- ASP.NET Core Web API

### Frontend
- Angular 19
- PrimeNG 17
- Tailwind CSS 3
- RxJS 7
- TypeScript 5

## License

MIT
