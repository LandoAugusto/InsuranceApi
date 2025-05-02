# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia nuget.config e pacotes locais (relativos ao contexto definido no docker-compose)
COPY nuget.config ./nuget.config
COPY components/package ./components/package

COPY ["src/InsuranceApi/InsuranceApi.csproj", "InsuranceApi/"]
COPY ["src/InsuranceApi.Application/InsuranceApi.Application.csproj", "InsuranceApi.Application/"]
COPY ["src/InsuranceApi.Core/InsuranceApi.Core.csproj", "InsuranceApi.Core/"]
COPY ["src/InsuranceApi.Infra.Data/InsuranceApi.Infra.Data.csproj", "InsuranceApi.Infra.Data/"]
COPY ["src/InsuranceApi.Service.Client/InsuranceApi.Service.Client.csproj", "InsuranceApi.Service.Client/"]
COPY ["src/InsuranceApi.Infra.IoC/InsuranceApi.Infra.IoC.csproj", "InsuranceApi.Infra.IoC/"]

# Restaura pacotes usando o nuget.config com pacote local
RUN dotnet restore "InsuranceApi/InsuranceApi.csproj"  --configfile nuget.config

COPY ./src/InsuranceApi ./InsuranceApi
COPY ./src/InsuranceApi.Application ./InsuranceApi.Application
COPY ./src/InsuranceApi.Core ./InsuranceApi.Core
COPY ./src/InsuranceApi.Infra.Data ./InsuranceApi.Infra.Data
COPY ./src/InsuranceApi.Service.Client ./InsuranceApi.Service.Client
COPY ./src/InsuranceApi.Infra.IoC ./InsuranceApi.Infra.IoC

WORKDIR "/src/InsuranceApi"
RUN dotnet build "InsuranceApi.csproj" -c Release -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InsuranceApi.csproj" -c Release -o /app/publish

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceApi.dll"]