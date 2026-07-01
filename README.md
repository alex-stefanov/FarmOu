# FarmOu

FarmOu is a .NET farming-simulation application with multiple user interfaces, a shared data layer, and service-driven game logic. Players can register as farmers, buy crops and tools, run farming sessions, earn XP, and interact with crop/tool bazaar workflows.

## Features

- Farmer registration and login with ASP.NET Core Identity
- Crop bazaar for buying and selling crops
- Tool bazaar for purchasing farming tools
- Farming sessions that combine farmer, crop, tool, time, XP, and progression logic
- Crop, tool, farmer, XP level, buying, selling, and session history models
- ASP.NET Core MVC web application with Razor views
- Console menu interface for game-style interaction
- WinForms project for desktop UI experiments
- Repository and service layers for reusable business logic
- NUnit and Moq tests for user and crop bazaar services

## Tech Stack

- .NET 9
- C#
- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core
- SQL Server
- Razor Pages and Razor Views
- WinForms
- NUnit, Moq, and coverlet

## Solution Structure

```text
FarmOu/                  # Console application entry point and flow
FarmOu.Common/           # Shared common code
FarmOu.Data/             # EF Core DbContext, models, migrations, repositories
FarmOu.Forms/            # WinForms UI project
FarmOu.Infrastructure/   # Application services and interfaces
FarmOu.Tests/            # NUnit service tests
FarmOu.UI/               # Console menus
FarmOu.Web/              # ASP.NET Core MVC web application
FarmOu.sln
```

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server or SQL Server container

### Run the Web App

```bash
git clone https://github.com/alex-stefanov/FarmOu.git
cd FarmOu
dotnet restore FarmOu.sln
dotnet build FarmOu.sln
dotnet run --project FarmOu.Web
```

### Run the Console App

```bash
dotnet run --project FarmOu
```

### Run Tests

```bash
dotnet test FarmOu.sln
```

## Configuration

The web app reads its connection string from `FarmOu.Web/appsettings.Development.json` through the environment-specific configuration extension. For production or shared environments, move database credentials to user secrets, environment variables, or your deployment secret store.

## Database

The data layer uses `FarmOuDbContext` with Entity Framework Core migrations. Key tables include farmers, crops, tools, XP levels, farmer-crop inventory, farmer-tool inventory, crop purchases, crop sales, tool purchases, and farming sessions.

## License

This project is licensed under the MIT License.
