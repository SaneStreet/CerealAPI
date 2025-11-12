# 1️⃣ Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Kopiér csproj og hent dependencies
COPY *.csproj ./
RUN dotnet restore

# Kopiér resten af koden og publish
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 2️⃣ Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5556
EXPOSE 5556
ENTRYPOINT ["dotnet", "CerealAPI.dll"]
