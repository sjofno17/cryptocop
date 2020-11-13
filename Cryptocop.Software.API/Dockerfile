FROM mcr.microsoft.com/dotnet/core/sdk:3.1

LABEL maintainer="Sjöfn Óskarsdóttir"

ENV ASPNETCORE_URLS=http://+:5000

COPY . /app
WORKDIR /app
RUN dotnet restore
ENTRYPOINT [ "dotnet", "run" ]