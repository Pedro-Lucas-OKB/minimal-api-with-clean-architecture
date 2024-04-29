# syntax=docker/dockerfile:1

# Create a stage for building the application.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY ./*.sln .

# Copying project files to use dotnet restore
COPY ./src/Core/CleanArchitecture.Application/*.csproj ./src/Core/CleanArchitecture.Application/
COPY ./src/Core/CleanArchitecture.Domain/*.csproj ./src/Core/CleanArchitecture.Domain/
COPY ./src/Infrastructure/CleanArchitecture.Persistence/*.csproj ./src/Infrastructure/CleanArchitecture.Persistence/
COPY ./src/Presentation/CleanArchitecture.API/*.csproj ./src/Presentation/CleanArchitecture.API/
COPY ./tests/CleanArchitecture.Tests/*.csproj ./tests/CleanArchitecture.Tests/

RUN dotnet restore 

# Copying the remaining files
COPY . .

RUN dotnet dev-certs https --trust

RUN dotnet build --no-restore

RUN dotnet publish --no-restore -c Release --property:PublishDir=out

# Create a new stage for running the application.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copying publish files
COPY --from=build /app/tests/*/out/ ./
COPY --from=build /app/src/*/*/out/ ./

# Setting "Development" environment to use swagger
ENV ASPNETCORE_ENVIRONMENT=Development 

EXPOSE 8080

ENTRYPOINT ["dotnet", "CleanArchitecture.API.dll"]