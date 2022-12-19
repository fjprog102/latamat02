FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /KOF/Game

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o dockerBuild

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /KOF/Game
COPY --from=build-env /KOF/Game/dockerBuild .
EXPOSE 7021
ENTRYPOINT ["dotnet", "KOF.dll"]
