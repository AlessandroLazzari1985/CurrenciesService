#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BancaSempione.Presentation.Divise.WebApi/BancaSempione.Presentation.Divise.WebApi.csproj", "BancaSempione.Presentation.Divise.WebApi/"]
COPY ["Apsoft.Domain.Services/Apsoft.Domain.Services.csproj", "Apsoft.Domain.Services/"]
COPY ["Apsoft.Domain.Repositories/Apsoft.Domain.Repositories.csproj", "Apsoft.Domain.Repositories/"]
COPY ["Apsoft.FinancialData/Apsoft.Domain.FinancialData.csproj", "Apsoft.FinancialData/"]
COPY ["Apsoft.Domain.Entities/Apsoft.Domain.Entities.csproj", "Apsoft.Domain.Entities/"]
COPY ["Apsoft.Infrastructure.Database/Apsoft.Infrastructure.Database.csproj", "Apsoft.Infrastructure.Database/"]
COPY ["Apsoft.Infrastructure.Repositories/Apsoft.Infrastructure.Repositories.csproj", "Apsoft.Infrastructure.Repositories/"]
COPY ["BancaSempione.Application.Provider.Boss/BancaSempione.Application.Provider.Boss.csproj", "BancaSempione.Application.Provider.Boss/"]
COPY ["BancaSempione.Domain.Repositories/BancaSempione.Domain.Repositories.csproj", "BancaSempione.Domain.Repositories/"]
COPY ["BancaSempione.Domain.Boss/BancaSempione.Domain.Boss.csproj", "BancaSempione.Domain.Boss/"]
COPY ["BancaSempione.Domain.Divise/BancaSempione.Domain.Divise.csproj", "BancaSempione.Domain.Divise/"]
COPY ["BancaSempione.Domain.Services/BancaSempione.Domain.Services.csproj", "BancaSempione.Domain.Services/"]
COPY ["BancaSempione.Infrastructure.Cache/BancaSempione.Infrastructure.Cache.csproj", "BancaSempione.Infrastructure.Cache/"]
COPY ["BancaSempione.Infrastructure.Database/BancaSempione.Infrastructure.Database.csproj", "BancaSempione.Infrastructure.Database/"]
COPY ["BancaSempione.Infrastructure.Logging/BancaSempione.Infrastructure.Logging.csproj", "BancaSempione.Infrastructure.Logging/"]
COPY ["BancaSempione.Infrastructure.Repositories/BancaSempione.Infrastructure.Repositories.csproj", "BancaSempione.Infrastructure.Repositories/"]
RUN dotnet restore "./BancaSempione.Presentation.Divise.WebApi/BancaSempione.Presentation.Divise.WebApi.csproj"
COPY . .
WORKDIR "/src/BancaSempione.Presentation.Divise.WebApi"
RUN dotnet build "./BancaSempione.Presentation.Divise.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BancaSempione.Presentation.Divise.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Debugging: elenca i contenuti della directory dopo la pubblicazione
RUN ls -la /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000
EXPOSE 8080
ENTRYPOINT ["dotnet", "BancaSempione.Presentation.Divise.WebApi.dll"]
