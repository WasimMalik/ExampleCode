FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Frigate.RestApi/Frigate.RestApi.csproj", "Frigate.RestApi/"]
RUN dotnet restore "Frigate.RestApi/Frigate.RestApi.csproj"
COPY . .
WORKDIR "/src/Frigate.RestApi"
RUN dotnet build "Frigate.RestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Frigate.RestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Frigate.RestApi.dll"]