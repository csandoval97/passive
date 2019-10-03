FROM mcr.microsoft.com/dotnet/core-nightly/sdk:3.0


RUN apt-get update && \
apt-get install -y build-essential apt-transport-https lsb-release ca-certificates curl && \
curl -sL https://deb.nodesource.com/setup_10.x | bash - && \
apt-get install -y nodejs

WORKDIR /app
COPY . .

RUN dotnet publish -c Release -o out

EXPOSE 5001
EXPOSE 5000

WORKDIR /app/out

ENTRYPOINT dotnet passive.dll
