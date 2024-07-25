# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Ajusta la ruta de acuerdo a tu estructura de proyecto
COPY ["Gateway.OnestVision.csproj", "."]
RUN dotnet restore "Gateway.OnestVision.csproj"

COPY . .
WORKDIR "/src"
RUN dotnet build "Gateway.OnestVision.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "Gateway.OnestVision.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.OnestVision.dll"]
