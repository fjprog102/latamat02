FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /KOF/Game

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o DockerBuild

# Build runtime image
WORKDIR /KOF/Game/DockerBuild
ENTRYPOINT ["dotnet", "KOF.dll"]
