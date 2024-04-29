# syntax=docker/dockerfile:1

# Create a stage for building the application.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

RUN dotnet dev-certs https --trust

RUN dotnet restore

RUN dotnet build --no-restore

RUN dotnet publish --no-restore -c Release 

# Create a new stage for running the application.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/out ./

# Setting "Development" environment to use swagger
ENV ASPNETCORE_ENVIRONMENT=Development 

EXPOSE 8080

ENTRYPOINT ["dotnet", "CleanArchitecture.API.dll"]
