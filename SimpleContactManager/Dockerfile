#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleContactManager/SimpleContactManager.csproj", "SimpleContactManager/"]
RUN dotnet restore "SimpleContactManager/SimpleContactManager.csproj"
COPY . .
WORKDIR "/src/SimpleContactManager"
RUN dotnet build "SimpleContactManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleContactManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080 DOTNET_RUNNING_IN_CONTAINER=true 
ENTRYPOINT ["dotnet", "SimpleContactManager.dll"]