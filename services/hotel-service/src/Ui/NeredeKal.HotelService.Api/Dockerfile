#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/hotel-service/src/Ui/NeredeKal.HotelService.Api/NeredeKal.HotelService.Api.csproj", "services/hotel-service/src/Ui/NeredeKal.HotelService.Api/"]
COPY ["services/hotel-service/src/Core/NeredeKal.HotelService.Application/NeredeKal.HotelService.Application.csproj", "services/hotel-service/src/Core/NeredeKal.HotelService.Application/"]
COPY ["services/hotel-service/src/Core/NeredeKal.HotelService.Domain/NeredeKal.HotelService.Domain.csproj", "services/hotel-service/src/Core/NeredeKal.HotelService.Domain/"]
COPY ["shared/NeredeKal.SharedKernel/NeredeKal.SharedKernel.csproj", "shared/NeredeKal.SharedKernel/"]
COPY ["services/hotel-service/src/Infrastructure/NeredeKal.HotelService.Persistence/NeredeKal.HotelService.Persistence.csproj", "services/hotel-service/src/Infrastructure/NeredeKal.HotelService.Persistence/"]
RUN dotnet restore "./services/hotel-service/src/Ui/NeredeKal.HotelService.Api/NeredeKal.HotelService.Api.csproj"
COPY . .
WORKDIR "/src/services/hotel-service/src/Ui/NeredeKal.HotelService.Api"
RUN dotnet build "./NeredeKal.HotelService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NeredeKal.HotelService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NeredeKal.HotelService.Api.dll"]