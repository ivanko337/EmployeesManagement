FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeesManagement/EmployeesManagement.csproj", "EmployeesManagement/"]
COPY ["EmployeesManagement.Domain/EmployeesManagement.Domain.csproj", "EmployeesManagement.Domain/"]
COPY ["EmployeesManagement.Foundation/EmployeesManagement.Foundation.csproj", "EmployeesManagement.Foundation/"]
COPY ["EmployeesManagement.Data/EmployeesManagement.Data.csproj", "EmployeesManagement.Data/"]
COPY . .
RUN dotnet restore "EmployeesManagement/EmployeesManagement.csproj"

FROM build AS publish
WORKDIR /src/EmployeesManagement
RUN dotnet publish "EmployeesManagement.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app/run
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeesManagement.dll"]