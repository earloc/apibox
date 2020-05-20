#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApiBox.Api.WebApi/ApiBox.Api.WebApi.csproj", "ApiBox.Api.WebApi/"]
COPY ["ApiBox/ApiBox.csproj", "ApiBox/"]
COPY ["ApiBox.Microsoft.Extensions.DependencyInjection/ApiBox.Microsoft.Extensions.DependencyInjection.csproj", "ApiBox.Microsoft.Extensions.DependencyInjection/"]
COPY ["ApiBox.Api/ApiBox.Api.csproj", "ApiBox.Api/"]
RUN dotnet restore "ApiBox.Api.WebApi/ApiBox.Api.WebApi.csproj"
COPY . .
WORKDIR "/src/ApiBox.Api.WebApi"
RUN dotnet build "ApiBox.Api.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiBox.Api.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiBox.Api.WebApi.dll"]
