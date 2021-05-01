FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["StudentManagementTest.Web/*.csproj", "StudentManagementTest.Web/"]
COPY ["StudentManagementTest.Data/*.csproj", "StudentManagementTest.Data/"]
COPY ["StudentManagementTest.Library/*.csproj", "StudentManagementTest.Library/"]
COPY ["StudentManagementTest.MemberShip/*.csproj", "StudentManagementTest.MemberShip/"]
RUN dotnet restore "StudentManagementTest.Web.csproj" 
COPY . .
WORKDIR "/src/StudentManagementTest.Web"
RUN dotnet build "StudentManagementTest.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StudentManagementTest.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StudentManagementTest.Web.dll"]