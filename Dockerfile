FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src"
RUN dotnet restore "dockertest.csproj"
RUN dotnet build "dockertest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dockertest.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dockertest.dll"]
