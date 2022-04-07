#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RVT.Monitoring.API/RVT.Monitoring.API.csproj", "RVT.Monitoring.API/"]
COPY ["RVT.Monitoring.Shared/RVT.Monitoring.Shared.csproj", "RVT.Monitoring.Shared/"]
COPY ["RVT.Monitoring.Data/RVT.Monitoring.Data.csproj", "RVT.Monitoring.Data/"]
COPY ["Libraries/RVT.Monitoring.Services/RVT.Monitoring.Services.csproj", "Libraries/RVT.Monitoring.Services/"]
RUN dotnet restore "RVT.Monitoring.API/RVT.Monitoring.API.csproj"
COPY . .
WORKDIR "/src/RVT.Monitoring.API"
RUN dotnet build "RVT.Monitoring.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RVT.Monitoring.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RVT.Monitoring.API.dll"]