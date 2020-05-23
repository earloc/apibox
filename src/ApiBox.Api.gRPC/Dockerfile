#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApiBox.Api.gRPC/ApiBox.Api.gRPC.csproj", "ApiBox.Api.gRPC/"]
COPY ["ApiBox/ApiBox.csproj", "ApiBox/"]
COPY ["ApiBox.Api/ApiBox.Api.csproj", "ApiBox.Api/"]
RUN dotnet restore "ApiBox.Api.gRPC/ApiBox.Api.gRPC.csproj"
COPY . .
WORKDIR "/src/ApiBox.Api.gRPC"
RUN dotnet build "ApiBox.Api.gRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiBox.Api.gRPC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiBox.Api.gRPC.dll"]
