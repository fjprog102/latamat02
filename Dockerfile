FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
EXPOSE 7021
EXPOSE 5000

# Copy everything
COPY . .
WORKDIR /KOF/Game
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o Docker

# Build runtime image
WORKDIR /KOF/Game/Docker
ENTRYPOINT ["dotnet", "KOF.dll"]
