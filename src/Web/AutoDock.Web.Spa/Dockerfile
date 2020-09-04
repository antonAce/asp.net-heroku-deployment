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
