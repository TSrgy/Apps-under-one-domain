#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MainServerApp/MainServerApp.csproj", "src/MainServerApp/"]
RUN dotnet restore "src/MainServerApp/MainServerApp.csproj"
COPY . .
WORKDIR "/src/src/MainServerApp"
RUN dotnet build "MainServerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MainServerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MainServerApp.dll"]