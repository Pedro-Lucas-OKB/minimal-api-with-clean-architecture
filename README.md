# Minimal API com Clean Architecture
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![ASP .NET](https://img.shields.io/badge/ASP_.NET-v8.0-808080?style=for-the-badge&logo=.net&logoColor=white&&labelColor=purple)
![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

## Minimal API
É uma abordagem simplificada para implementar APIs de HTTP, com foco na diminuição de código e de configuração. Com poucas linhas de código, é possível criar endpoints REST funcionais. [(Minimal API)](https://learn.microsoft.com/pt-br/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-8.0)

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();
```

## Clean Architecture
A Clean Architecture é um padrão arquitetural de software baseado no princípio da separação de interesses, onde a aplicação é dividida em diferentes camadas, cada uma com sua preocupação. O objetivo é proporcionar aos desenvolvedores uma forma melhor de organizar o código, separando as regras de negócio, facilitando o desenvolvimento e a manutenção do código.

![The Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)
: The Clean Architecture by Robert C. Martin

## Padrões Utilizados
- Command and Query Responsibility Segregation (CQRS)
- Mediator
- Repository
- Unit of Work

## Como está implementada a dependência entre os projetos nessa solução?

![Diagrama de camadas](docs/Minimal%20API%20with%20Clean%20Architecture.jpg)
: Minimal API with Clean Architecture

## Testando o Projeto
A API está documentada com a utilização do Swagger. Ao acessar a página, é possivel testar todas as requisições HTTP.

### Docker
Execute o comando ```docker compose up --build``` e acesse ```http://localhost:8080/swagger``` para testar a API. 

Também é possível baixar a imagem com o comando ```docker pull pedrolucas5100/minimal-api-with-clean-architecture``` e criar seus próprios containers.

### Testando Localmente
#### Pré-requisitos:
* [.NET 8.0 SDK](https://dotnet.microsoft.com/pt-br/download)

#### Packages utilizados 
> Os comandos ```dotnet build``` e ```dotnet run``` restauram as dependências automaticamente.

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

#### Build
```bash
cd minimal-api-with-clean-architecture/
dotnet build
```

#### Run
```bash
cd src/Presentation/CleanArchitecture.API
dotnet run
```
Acesse: ```https://localhost:7054/swagger``` ou ```http://localhost:5269/swagger``` para utilizar o Swagger e testar a API.

> Pode ser necessário autorizar o uso de HTTPS no ambiente local. Para isso, ative a confiança no *cetificado https* do *dotnet* com o seguinte comando: ```dotnet dev-certs https --trust```

## Referências

- A implementação da estrutura da Clean Architecture foi baseada no conteúdo do canal [Jose Carlos Macoratti](https://www.youtube.com/@josecarlosmacoratti).
- [Documentação ASP .NET](https://learn.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-8.0)

## Licença
[![License](https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge)](./LICENSE)