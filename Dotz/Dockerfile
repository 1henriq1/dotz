#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Dotz/Dotz.Application.csproj", "Dotz/"]
COPY ["Dotz.Domain/Dotz.Domain.csproj", "Dotz/"]
COPY ["Dotz.Infrastructure/Dotz.Infrastructure.csproj", "Dotz/"]
RUN dotnet restore "Dotz/Dotz.Application.csproj"
COPY . .
WORKDIR "/src/Dotz"
RUN dotnet build "Dotz.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dotz.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotz.Application.dll"]