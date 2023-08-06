FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["planning.WebApplication/planning.WebApplication.csproj", "planning.WebApplication/"]
COPY ["planning.EntitiesContext/planning.EntitiesContext.csproj", "planning.EntitiesContext/"]
COPY ["planning.Models/planning.Models.csproj", "planning.Models/"]
COPY ["planning.Repository.Contracts/planning.Repository.Contracts.csproj", "planning.Repository.Contracts/"]
COPY ["planning.Repository/planning.Repository.csproj", "planning.Repository/"]
COPY ["planning.Attributes/planning.Attributes.csproj", "planning.Attributes/"]
COPY ["planning.Services.Contracts/planning.Services.Contracts.csproj", "planning.Services.Contracts/"]
COPY ["planning.Services/planning.Services.csproj", "planning.Services/"]
RUN dotnet restore "planning.WebApplication/planning.WebApplication.csproj"
COPY . .
WORKDIR "/src/planning.WebApplication"
RUN dotnet build "planning.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "planning.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "planning.WebApplication.dll"]
