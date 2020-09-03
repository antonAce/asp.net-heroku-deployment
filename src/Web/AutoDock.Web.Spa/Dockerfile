FROM node AS buildangular
WORKDIR /clientapp

COPY /clientapp /clientapp

RUN npm install
RUN npm run build:deploy

FROM mcr.microsoft.com/dotnet/core/sdk AS buildcore
WORKDIR .

COPY --from=buildangular ./clientapp/wwwroot ./clientapp/wwwroot
COPY . .

RUN dotnet restore
RUN dotnet publish AutoDock.Web.Spa.csproj -c Release -o app

FROM mcr.microsoft.com/dotnet/core/aspnet AS runtime
WORKDIR .

COPY --from=buildcore ./app ./
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Production

ENTRYPOINT ["dotnet", "AutoDock.Web.Spa.dll"]