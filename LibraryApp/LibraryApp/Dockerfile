#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LibraryApp/LibraryApp.csproj", "LibraryApp/"]
COPY ["Library.Infrastructure/Library.Infrastructure.csproj", "Library.Infrastructure/"]
COPY ["Library.Common/Library.Common.csproj", "Library.Common/"]
RUN dotnet restore "LibraryApp/LibraryApp.csproj"
COPY . .
WORKDIR "/src/LibraryApp"
RUN dotnet build "LibraryApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApp.dll"]