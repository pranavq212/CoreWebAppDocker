FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53085
EXPOSE 44378

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CoreWebAppDocker/CoreWebAppDocker.csproj", "CoreWebAppDocker/"]
RUN dotnet restore "CoreWebAppDocker/CoreWebAppDocker.csproj"
COPY . .
WORKDIR "/src/CoreWebAppDocker"
RUN dotnet build "CoreWebAppDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoreWebAppDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreWebAppDocker.dll"]