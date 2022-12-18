FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 7021


COPY . ./
WORKDIR /KOF/Game
RUN dotnet restore
RUN dotnet publish -c Release -o DockerBuilds
WORKDIR /KOF/Game/DockerBuilds
COPY --from=build-env /KOF/Out .
ENTRYPOINT ["dotnet", "KOF.dll", "--environment=Development"]