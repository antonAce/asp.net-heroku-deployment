FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src

COPY ./src .
RUN dotnet restore VehicleCatalog.sln
RUN dotnet publish VehicleCatalog.sln -c Release -o app

FROM mcr.microsoft.com/dotnet/core/aspnet AS runtime
WORKDIR /app
COPY --from=build ./src/app ./
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "VehicleCatalog.API.dll"]
