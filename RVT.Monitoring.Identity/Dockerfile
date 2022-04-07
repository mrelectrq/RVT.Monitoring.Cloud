#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["rvt.monitoring.identity/RVT.Monitoring.Identity.csproj", "rvt.monitoring.identity/"]
COPY ["RVT.Monitoring.Data/RVT.Monitoring.Data.csproj", "RVT.Monitoring.Data/"]
RUN dotnet restore "rvt.monitoring.identity/RVT.Monitoring.Identity.csproj"
COPY . .
WORKDIR "/src/rvt.monitoring.identity"
RUN dotnet build "RVT.Monitoring.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RVT.Monitoring.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RVT.Monitoring.Identity.dll"]