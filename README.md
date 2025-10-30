#  DogsHouseService

REST API built with **ASP.NET Core Web API** and **Entity Framework Core**.

##  Features
- `/ping` → returns version message.
- `/dogs` → get all dogs with sorting and pagination.
- `/dog` → create new dog (validation included).
- Rate limiting: 10 requests per second.
- Swagger UI for testing.

##  Technologies
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server
- xUnit for Unit Testing

##  Run Locally

```bash
dotnet run --urls "http://localhost:5134"
