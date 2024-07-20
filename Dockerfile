
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /src

COPY ["Employee_Management_API/Employee_Management_API.csproj", "Employee_Management_API/"]
COPY ["Employee_Management_Data/Employee_Management_Data.csproj", "Employee_Management_Data/"]
COPY ["Employee_Management_Repository/Employee_Management_Repository.csproj", "Employee_Management_Repository/"]
RUN dotnet restore "./Employee_Management_API/Employee_Management_API.csproj"

COPY . .
WORKDIR "/src/Employee_Management_API"
RUN dotnet build "./Employee_Management_API.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Employee_Management_API.csproj" -c Release -o /app/publish 



FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS final
WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Employee_Management_API.dll"]


