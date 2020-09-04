FROM node AS buildangular
WORKDIR /app

COPY /clientapp /app

RUN npm install
RUN npm run build:deploy

FROM mcr.microsoft.com/dotnet/core/sdk AS buildcore
WORKDIR /web

COPY --from=buildangular /app/wwwroot /web/clientapp/wwwroot

COPY [^clientapp]* ./
RUN dotnet restore AutoDock.Web.Spa.csproj
RUN dotnet publish AutoDock.Web.Spa.csproj -c Release -o release

FROM mcr.microsoft.com/dotnet/core/aspnet AS runtime
WORKDIR /app

COPY --from=buildcore /web/release /app
ENV ASPNETCORE_URLS https://*:5001
ENV ASPNETCORE_ENVIRONMENT Production

ENTRYPOINT ["dotnet", "AutoDock.Web.Spa.dll"]
