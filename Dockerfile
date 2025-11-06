# 1. Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Kopiér csproj og hent dependencies
COPY CerealAPI/*.csproj ./CerealAPI/
RUN dotnet restore CerealAPI/CerealAPI.csproj

# Kopiér resten af projektet og byg
COPY . .
RUN dotnet publish CerealAPI/CerealAPI.csproj -c Release -o /app/out

# 2. Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Kopiér build-output
COPY --from=build /app/out .

# Kopiér Data-mappen med CSV
COPY CerealAPI/Data ./Data

# Eksponer Docker-port
EXPOSE 5556

# Lyt på alle interfaces
ENV ASPNETCORE_URLS=http://+:5556

ENTRYPOINT ["dotnet", "CerealAPI.dll"]
