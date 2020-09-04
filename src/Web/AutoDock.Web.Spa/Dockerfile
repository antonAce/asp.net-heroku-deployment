FROM node AS buildangular
WORKDIR /app

COPY /clientapp /app

RUN npm install
RUN npm run build:deploy
