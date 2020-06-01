FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CustomerManagement.Console/CustomerManagement.ConsoleApp.csproj", "CustomerManagement.Console/"]
COPY ["CustomerManagement.Services/CustomerManagement.Services.csproj", "CustomerManagement.Services/"]
COPY ["CustomerManagement.Repositories/CustomerManagement.Repositories.csproj", "CustomerManagement.Repositories/"]
COPY ["CustomerManagement.Models/CustomerManagement.Models.csproj", "CustomerManagement.Models/"]
COPY ["CustomerManagement.Infrastructures/CustomerManagement.Infrastructures.csproj", "CustomerManagement.Infrastructures/"]
RUN dotnet restore "CustomerManagement.Console/CustomerManagement.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/CustomerManagement.Console"
RUN dotnet build "CustomerManagement.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerManagement.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerManagement.ConsoleApp.dll"]