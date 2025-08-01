
# 💼 Ambev Developer Evaluation API

This project is an API for sales management, developed as part of a technical evaluation. The application uses a layered architecture with DDD, MediatR, and Entity Framework Core with PostgreSQL.

---

## 🚀 Tech Stack

- .NET 8
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Docker
- MediatR
- AutoMapper
- Serilog

---

## 📁 Project Structure

```
src/
├── Ambev.DeveloperEvaluation.Application
├── Ambev.DeveloperEvaluation.Common
├── Ambev.DeveloperEvaluation.Domain
├── Ambev.DeveloperEvaluation.IoC
├── Ambev.DeveloperEvaluation.ORM
└── Ambev.DeveloperEvaluation.WebApi
```

---

## ⚙️ Local Setup

### 1. Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/) running locally (default port: 5432)
- [Docker](https://www.docker.com/) (optional, to run via container)

---

### 2. Database Configuration

Edit `appsettings.json` in `Ambev.DeveloperEvaluation.WebApi`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=DeveloperEvaluation;Username=postgres;Password=postgres"
}
```

⚠️ Ensure PostgreSQL is running and the credentials are correct.

---

### 3. Apply Migrations

From the root of the solution:

```bash
dotnet build
dotnet ef database update --project ./src/Ambev.DeveloperEvaluation.ORM --startup-project ./src/Ambev.DeveloperEvaluation.WebApi --context DefaultContext
```

---

### 4. Run the Application Locally

From the `src/Ambev.DeveloperEvaluation.WebApi` folder:

```bash
dotnet run
```

API will run on:

- `https://localhost:5001`
- `http://localhost:5000`

---

## 🐳 Running via Docker

### 1. Build the Docker Image

```bash
docker build -t ambev-evaluation-api -f src/Ambev.DeveloperEvaluation.WebApi/Dockerfile .
```

### 2. Run the Container

```bash
docker run -d -p 8080:8080 -e ASPNETCORE_URLS=http://+:8080 --name ambev-api ambev-evaluation-api
```

API available at `http://localhost:8080`

---

## 📮 API Endpoints

### 🔹 Create a Sale

**POST** `/api/sales`

```json
{
  "saleNumber": "001",
  "date": "2025-08-01T12:00:00Z",
  "customerId": "d290f1ee-6c54-4b01-90e6-d701748f0851",
  "customerName": "Sample Customer",
  "branchId": "BR001",
  "branchName": "SP Branch",
  "items": [
    {
      "productId": "f6e8c7ac-df8f-4d17-91b5-b61a93a3b3a0",
      "productName": "Product A",
      "quantity": 5,
      "unitPrice": 10.0
    }
  ]
}
```

### 🔹 Get Sale by ID

**GET** `/api/sales/{id}`

### 🔹 List All Sales

**GET** `/api/sales`

### 🔹 Cancel a Sale

**PUT** `/api/sales/{id}/cancel`

### 🔹 Cancel a Sale Item

**PUT** `/api/sales/{saleId}/items/{itemId}/cancel`

---

## ✅ Business Rules

- Up to 3 units: no discount
- 4 to 9 units: 10% discount
- 10 to 20 units: 20% discount
- Sales above 20 units per item are not allowed

---

## 🧪 Testing

Tests are located under `/Tests` and include unit, integration, and functional tests (in progress).

---

## 📫 Contact

For questions or suggestions, feel free to contact the repository maintainer on GitHub.




# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)