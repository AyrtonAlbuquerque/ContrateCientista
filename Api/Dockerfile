FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /api
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet dev-certs https
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /api/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /api/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /api
COPY --from=publish /api/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
