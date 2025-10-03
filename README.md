# 🌾 CerealAPI

Et simpelt ASP.NET Core Web API projekt, der demonstrerer hvordan man kan bygge en REST API med Entity Framework Core og dokumentere den med Swagger.

## 📡 API Endpoints
| Metode | Endpoint            | Beskrivelse           | Body (JSON) eksempel                                 |
| ------ | ------------------- | --------------------- | ---------------------------------------------------- |
| GET    | `/api/Cereal`      | Hent alle cereals     | –                                                    |
| GET    | `/api/Cereal/{id}` | Hent en cereal via Id | –                                                    |
| POST   | `/api/Cereal`      | Opret en ny cereal    | `{ "name": "Corn Flakes", "calories": 120 }`         |
| PUT    | `/api/Cereal/{id}` | Opdater en cereal     | `{ "id": 1, "name": "Choco Pops", "calories": 200 }` |
| DELETE | `/api/Cereal/{id}` | Slet en cereal        | –                                                    |

## 🚀 Teknologier

- ASP.NET Core Web API
- Entity Framework Core
- MySQL Workbench
- Swagger / Swashbuckle

## 📦 Krav
- .NET 8 SDK
- MySQL database (eller anden EF Core understøttet databadase)

## ⚙️ Installation

1. Klon repoet:
```
git clone https://github.com/brugernavn/CerealsAPI.git
cd CerealsAPI
```
2. Tilføj database-forbindelse i ```appsettings.json``` :
```
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=cerealsdb;user=dinBruger;password=dinKode"
  }
```
3. Kør database migrationer:
```
dotnet ef database update
```
4. Start API'et enten i Visual Studio Run eller .NET CLI:
```
dotnet run
```
## 📖 Brug af Swagger

Når API’et kører, kan du åbne:
```
https://localhost:5555/swagger
```
Her kan du se og teste alle endpoints i browseren.

## 🧪 Test

Kald API’et fra terminalen:
```
curl https://localhost:5555/api/cereal
```
Eller benyt Swagger til GET/POST requests.
