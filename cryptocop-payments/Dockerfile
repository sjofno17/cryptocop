FROM node:latest

LABEL maintainer="Sjöfn Óskarsdóttir"

COPY . /app
WORKDIR /app

RUN npm install

ENTRYPOINT [ "npm", "run", "build" ]