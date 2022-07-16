#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/email/BookingApp.Email/BookingApp.Email.csproj", "src/services/email/BookingApp.Email/"]
RUN dotnet restore "src/services/email/BookingApp.Email/BookingApp.Email.csproj"
COPY . .
WORKDIR "/src/src/services/email/BookingApp.Email"
RUN dotnet build "BookingApp.Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingApp.Email.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingApp.Email.dll"]