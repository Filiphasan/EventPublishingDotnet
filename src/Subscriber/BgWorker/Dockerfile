FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Subscriber/BgWorker/BgWorker.csproj", "src/Subscriber/BgWorker/"]
RUN dotnet restore "src/Subscriber/BgWorker/BgWorker.csproj"
COPY . .
WORKDIR "/src/src/Subscriber/BgWorker"
RUN dotnet build "BgWorker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BgWorker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BgWorker.dll"]
