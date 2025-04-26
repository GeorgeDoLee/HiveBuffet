FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HiveBuffet.API/HiveBuffet.API.csproj", "HiveBuffet.API/"]
COPY ["HiveBuffet.Application/HiveBuffet.Application.csproj", "HiveBuffet.Application/"]
COPY ["HiveBuffet.Domain/HiveBuffet.Domain.csproj", "HiveBuffet.Domain/"]
COPY ["HiveBuffet.Infrastructure/HiveBuffet.Infrastructure.csproj", "HiveBuffet.Infrastructure/"]
RUN dotnet restore "HiveBuffet.API/HiveBuffet.API.csproj"
COPY . .
WORKDIR "/src/HiveBuffet.API"
RUN dotnet build "HiveBuffet.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HiveBuffet.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HiveBuffet.API.dll"]