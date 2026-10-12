# Food app (.NET MAUI + REST API)

Cross-platform app (.NET MAUI) for browsing food products, building components (recipes) from them and reading articles,
backed by an ASP.NET Core REST API. Early learning project (2023).

## Features
- Register / log in
- Browse and add products
- Compose components from products and keep a personal list of components
- Articles section

## Stack
.NET MAUI (net6), ASP.NET Core Web API (net7), Entity Framework Core (in-memory database), Swagger

## Run
1. Start the API: `cd RestApi && dotnet run` (data is kept in memory and lost on restart).
2. Set the API address in `Food/Services/ApiConfig.cs`. The original demo server is offline.
3. Run `Food` on Android or Windows from Visual Studio.

## What I would improve
Persist data in a real database (SQL Server / SQLite), add authentication and tests.
