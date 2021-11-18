#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/windows/servercore:ltsc2019 as superbase
WORKDIR /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["/dockerplayground.csproj", "./"]
RUN dotnet restore "./dockerplayground.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "dockerplayground.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dockerplayground.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN DIR
ENTRYPOINT ["dotnet", "dockerplayground.dll"]