# Minimal API with Clean Architecture
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![ASP .NET](https://img.shields.io/badge/ASP_.NET-v8.0-808080?style=for-the-badge&logo=.net&logoColor=white&&labelColor=purple)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)

## Minimal API
It is a simplified approach to implement HTTP APIs, focusing on reducing code and configuration. With just a few lines of code, it is possible to create functional REST endpoints. [(Minimal API)](https://learn.microsoft.com/pt-br/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-8.0)

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();
```

## Clean Architecture
Clean Architecture is a software architectural pattern based on the principle of separation of concerns, where the application is divided into different layers, each with its own concern. The goal is to provide developers with a better way to organize code, separating business rules, facilitating development, and code maintenance.

![The Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)
: The Clean Architecture by Robert C. Martin

## Used Patterns
- Command and Query Responsibility Segregation (CQRS)
- Mediator
- Repository
- Unit of Work

## How is the dependency between projects implemented in this solution?

![layers diagram](docs/Minimal%20API%20with%20Clean%20Architecture.jpg)
: Minimal API with Clean Architecture

## Testing the Project
The API is documented using Swagger. By accessing the page, it is possible to test all HTTP requests.

### Prerequisites:
* [.NET 8.0 SDK](https://dotnet.microsoft.com/pt-br/download)

### Used Packages
> The ```dotnet build``` and ```dotnet run``` commands automatically restore dependencies.

* Application
    - [AutoMapper](https://www.nuget.org/packages/automapper/) : ```dotnet add package AutoMapper --version 13.0.1```
    - [FluentValidation](https://www.nuget.org/packages/FluentValidation.DependencyInjectionExtensions) : ```dotnet add package FluentValidation.DependencyInjectionExtensions --version 11.9.0```
    - [MediatR](https://www.nuget.org/packages/MediatR) : ```dotnet add package MediatR --version 12.2.0```
* Persistence
    - [SQLite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/8.0.4) : ```dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.4```
* API
    - [OpenAPI](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/8.0.4) : ```dotnet add package Microsoft.AspNetCore.OpenApi --version 8.0.4```
    - [EntityFrameworkCore.Design]() : ```dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0```
    - [Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore/6.4.0) : ```dotnet add package Swashbuckle.AspNetCore --version 6.4.0```

### Build
```bash
cd minimal-api-with-clean-architecture/
dotnet build
```

### Run
```bash
cd src/Presentation/CleanArchitecture.API
dotnet run
```
Access: ```https://localhost:7054/swagger``` or ```http://localhost:5269/swagger``` to use Swagger and test the API.

> You may need to authorize the use of HTTPS in the local environment. To do this, trust the dotnet https certificate with the following command: ```dotnet dev-certs https --trust```

## References

- The implementation of the Clean Architecture structure was based on the content from the [Jose Carlos Macoratti](https://www.youtube.com/@josecarlosmacoratti) channel.
- [ASP .NET Documentation](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-8.0)

## License
[![License](https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge)](./LICENSE)