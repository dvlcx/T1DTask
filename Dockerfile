FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
RUN apt-get update 

WORKDIR /src

COPY T1D/*.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENTRYPOINT ["dotnet", "T1D.dll"]
