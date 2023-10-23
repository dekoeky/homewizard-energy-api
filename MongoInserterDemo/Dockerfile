#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MongoInserterDemo/MongoInserterDemo.csproj", "MongoInserterDemo/"]
RUN dotnet restore "MongoInserterDemo/MongoInserterDemo.csproj"
COPY . .
WORKDIR "/src/MongoInserterDemo"
RUN dotnet build "MongoInserterDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoInserterDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoInserterDemo.dll"]