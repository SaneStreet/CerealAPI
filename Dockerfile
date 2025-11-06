# 1️⃣ Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Kopiér csproj og hent dependencies
COPY CerealAPI/*.csproj ./CerealAPI/
RUN dotnet restore CerealAPI/CerealAPI.csproj

# Kopiér resten af koden og publish
COPY CerealAPI/. ./CerealAPI/
WORKDIR /src/CerealAPI
RUN dotnet publish -c Release -o /app/publish

# 2️⃣ Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5556
EXPOSE 5556
ENTRYPOINT ["dotnet", "CerealAPI.dll"]
