#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Reservation.Api/Reservation.Api.csproj", "Services/Reservation.Api/"]
COPY ["Services/ReservationAPI/Reservation.API.Infrastructure/Reservation.API.Infrastructure.csproj", "Services/ReservationAPI/Reservation.API.Infrastructure/"]
COPY ["Services/ReservationAPI/Reservation.API.Models/Reservation.API.Models.csproj", "Services/ReservationAPI/Reservation.API.Models/"]
COPY ["Services/ReservationAPI/Reservation.API.Services/Reservation.API.Services.csproj", "Services/ReservationAPI/Reservation.API.Services/"]
COPY ["Services/ContactAPI/Contact.API.Infrastructure/Contact.API.Infrastructure.csproj", "Services/ContactAPI/Contact.API.Infrastructure/"]
COPY ["Services/ContactAPI/Contact.API.Models/Contact.API.Models.csproj", "Services/ContactAPI/Contact.API.Models/"]
RUN dotnet restore "Services/Reservation.Api/Reservation.Api.csproj"
COPY . .
WORKDIR "/src/Services/Reservation.Api"
RUN dotnet build "Reservation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reservation.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation.Api.dll"]