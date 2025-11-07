# 🌾 CerealAPI

Et simpelt C# .NET 9 Web API projekt, der demonstrerer hvordan man kan bygge en REST API med Entity Framework Core og dokumenteres med Swagger UI.
Derudover er der også mulighed for Dockerization, og CI/CD med Jenkins, i en samlet pakke med ```docker compose```.

---

## 🗂️ Projektstruktur

```bash
CerealAPI/
├── 📂 CerealAPI/                 # Hovedprojektmappe
│   ├── 📁 Controllers/           # API controllere
│   ├── 📁 Data/                  # CSV-fil og database seeder
│   ├── 📁 Migrations/            # Entity Framework migrations
│   ├── 📁 Models/                # Datamodeller
│   ├── 📜 CerealAPI.csproj
│   └── ⚙️ Program.cs             # Main entry point
│
├── 🎼 docker-compose.yml         # Orkestrerer API, MySQL og Jenkins
├── 🐋 Dockerfile                 # Docker build for API
└── 🤵🏻‍♂️ Jenkinsfile                # CI/CD pipeline konfiguration
```

---

## 📡 API Endpoints
| Metode | Endpoint           | Beskrivelse           | Body (JSON) eksempel                                 |
| ------ | ------------------ | --------------------- | ---------------------------------------------------- |
| GET    | `/api/Cereal`      | Hent alle cereals     | –                                                    |
| GET    | `/api/Cereal/{id}` | Hent en cereal via Id | `{ "id": 15 }`                                       |
| POST   | `/api/Cereal`      | Opret en ny cereal    | `{ "name": "Corn Flakes", "calories": 120 }`         |
| PUT    | `/api/Cereal/{id}` | Opdater en cereal     | `{ "id": 1, "name": "Choco Pops", "calories": 200 }` |
| DELETE | `/api/Cereal/{id}` | Slet en cereal        | `{ "id": 37 }`                                       |

---

## 🚀 Teknologier

- ASP.NET Core Web API
- Entity Framework Core
- MySQL Workbench
- Swagger / Swashbuckle
- Docker Containerization (Valgfrit)

---

## 📦 Krav
- .NET 9 SDK
- MySQL database (eller anden EF Core understøttet database)
- Docker (Valgfrit)
- Docker Desktop (Valgfrit)

---

## ⚙️ Installation

1. Klon repoet:
```bash
git clone https://github.com/brugernavn/CerealAPI.git
cd CerealAPI
```
2. Tilføj database-forbindelse i ```appsettings.json``` :
```bash
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=cerealsdb;user=dinBruger;password=dinKode"
  }
```
3. Opret migrations og opdater databasen:
```bash
dotnet ef add migrations initialCreate
dotnet ef database update
```
4. Start API'et enten i Visual Studio Run eller .NET CLI:
```bash
dotnet run
```

---

## 📖 Brug af Swagger

Når API’et kører, kan du åbne:
```bash
http://localhost:5555/swagger
```
Her kan ud teste alle endpoints til API'et i browseren.

Hvis det skal køres i Docker er porten 5556: 
(Husk at tjekke om Docker containers kører før du går ind på adressen)
```bash
http://localhost:5556/swagger
```

---

## 🚢 Dockerization
Gennemgå ```Dockerfile``` og ```docker-compose.yml``` for at sætte dine egne værdier:
### ```Dockerfile```
```bash Dockerfile
EXPOSE 5556 # bruges i dette projekt
```
### ```docker-compose.yml```
```bash docker-compose
# Under api:
ports:
      - "5556:5556"   # Docker API port
environment:
      - ConnectionStrings__DefaultConnection=Server=db;Port=3306;Database=cerealdb;User=DockerUserDb;Password=DockerPassDb;
      - ASPNETCORE_URLS=http://+:5556
      - DOTNET_ENVIRONMENT=Development
# Under db:
environment:
  MYSQL_ROOT_PASSWORD: DbPassIDocker
  MYSQL_DATABASE: cerealdb
  MYSQL_ROOT_HOST: '%'
ports:
- "3308:3306"   # Docker MySQL port
```
Derefter kan de startes gennem Docker Desktop, eller med Docker CLI fra rod-mappen (samme sted som README):
```bash
docker compose up --build
```

---

## 🧪 Test

Kald Lokalt API fra terminalen:
```bash
curl https://localhost:5555/api/cereal
```
Eller benyt Swagger til GET/POST requests.

Kald Dockerized API i terminalen:
```bash
curl http://localhost:5556/api/cereal
```