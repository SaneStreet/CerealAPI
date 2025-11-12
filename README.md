# 🌾 CerealAPI

Et simpelt C# .NET 9 Web API projekt, der demonstrerer hvordan man kan bygge en REST API med Entity Framework Core og dokumenteres med Swagger UI.
Derudover er der også mulighed for Dockerization, og CI/CD med Jenkins, i en samlet pakke med ```docker compose```.
Projektet kan køres lokalt med ```dotnet run``` fra projektroden og Docker containers med ```docker compose up --build``` (```--build``` er til første gang man kører det)

Når projektet køres i Docker med ```docker compose up --build``` så oprettes der 4 containere:
```cereal-api```, ```cereal-db```, ```cereal-frontend```, og ```jenkins``` i én samlet compose

```cereal-api``` er den container der holder på alt API funktionalitet. Som f.eks. Models, Controllers, Endpoints, etc.
```cereal-db``` er en MySQL database instance.
```cereal-frontend``` er React frontend der køres med Vite. Der er desuden hot-reload indbygget, så man ikke skal genstarte containere hver gang man ændre på koden.
```jenkins``` er et CI/CD værktøj der kører i sin egen instance.

---

## 🗂️ Projektstruktur

```bash
CerealAPI/
├── 📂 CerealAPI/                 # API projektmappe
│   ├── 📁 Controllers/             # API controllere
│   ├── 📁 Data/                    # CSV-fil og database seeder
│   ├── 📁 Migrations/              # Entity Framework migrations
│   ├── 📁 Models/                  # Datamodeller
│   ├── 📜 CerealAPI.csproj         # C# projektfilen
├── ├── 🐋 Dockerfile               # Dockerfilen til API
│   └── ⚙️ Program.cs               # Main entry point
├── 📂 CerealFrontEnd/            # Frontend projektmappe
│   ├── 📁 public/                  # Den "offentlige" mappe
│   ├── 📁 src/                     # Resurse mappen
├── ├── 🐋 Dockerfile               # Docker filen til Frontend
│   └── ⚙️ Config-filer..           # En hel masse config filer
├── 🎼 docker-compose.yml         # Orkestrerer API, MySQL, Frontend, og Jenkins
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
- Docker Containers
- Jenkins
- React w. Vite & TypeScript

---

## 🍽️ CSV-import og seeding

Ved første opstart importerer API’et automatisk data fra Data/Cereal.csv til databasen.
Dette håndteres af CerealSeeder under opstart:
```bash 
CerealSeeder.SeedProducts(context, "Data/Cereal.csv");
```
Hvis filen ikke findes, kaster den en exception f.eks.:
```bash
System.IO.FileNotFoundException: CSV filen blev ikke fundet
```
For at sikre adgang og at Docker faktisk kan finde filen tilføjes denne linje til ```docker-compose.yml```:
```bash
volumes:
  - ./CerealApi/Data:/app/Data
```

---

## ⚙️ Installation (Lokal Udvikling)

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

Hvis det køres i Docker er porten 5556: 
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

## 🔄 CI/CD Pipeline
Pipelinen (defineret i Jenkinsfile) består af fire hovedtrin:
🧾 Checkout – Henter projektet fra GitHub
🏗️ Build    – Genskaber og kompilerer .NET-projektet
🧪 Test     – Kører enhedstests
🚀 Deploy   – Genstarter containerne via Docker Compose

---

## 🧭 Continous Integration Flowchart (Rough sketch)
```bash
        ┌──────────────────────┐
        │       GitHub         │
        │    (CerealAPI Repo)  │
        └──────────┬───────────┘
                   │ Push / Commit
                   ▼
        ┌──────────────────────┐
        │       Jenkins        │
        │   CI/CD Pipeline     │
        ├──────────────────────┤
        │  1️⃣ Build & Test     │
        │  2️⃣ Docker Compose   │
        │  3️⃣ Deploy API       │
        └──────────┬───────────┘
                   │
                   ▼
        ┌────────────────────────────┐
        │        Docker Host         │
        │                            │
        │  🥣 CerealAPI | 🐬 MySQL  │
        │                            │
        │ Swagger → localhost:5556   │
        └────────────────────────────┘

```
<b>Repo Flow:</b>
Når der pushes ny kode til GitHub, trigger Jenkins pipelinen, der automatisk bygger, tester og genstarter hele miljøet i Docker. (I teorien)

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

---

## 📋 Mulige udvidelser
* Jenkins Agent (docker image)
* Frontend (React?)