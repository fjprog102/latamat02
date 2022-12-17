FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

COPY . .
WORKDIR /KOF/Game
RUN dotnet restore
RUN dotnet publish -c Release -o DockerBuilds
WORKDIR /KOF/Game/DockerBuilds
ENTRYPOINT ["dotnet", "KOF.dll"]
EXPOSE 7021
