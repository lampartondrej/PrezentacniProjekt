# 🌦️ Weather Forecast App (.NET)

A modern **ASP.NET Core weather application** built as a portfolio project to demonstrate practical backend development skills in .NET.

The solution includes:

* a **REST API** responsible for authentication, external API communication, resilience, caching, and response handling
* an **ASP.NET MVC web application** used as a presentation layer
* a **shared model project** for DTOs and wrapper classes
* a dedicated **test project** covering helper logic, service behavior, wrappers, and API integration scenarios

---

## Overview

This project is focused on building a structured weather application around an external weather provider.

It demonstrates:

* external API integration
* service abstraction
* authentication
* logging
* resilience with Polly
* in-memory caching
* automated testing

---

## Architecture

```text
[ MVC Web App ]
        ↓
[ ASP.NET Core REST API ]
        ↓
[ External Weather API ]
```

### Solution structure

* `ShowcaseProject.Rest` – REST API
* `ShowcaseProject.Web` – MVC web application
* `ShowcaseProject.Shared` – shared DTOs and wrapper models
* `ShowcaseProject.Tests` – unit and integration tests

---

## Technologies

* .NET 8
* ASP.NET Core Web API
* ASP.NET Core MVC
* C#
* HttpClientFactory
* Polly
* IMemoryCache
* Serilog
* Swagger / OpenAPI
* Basic Authentication
* xUnit
* Moq
* Microsoft.AspNetCore.Mvc.Testing

---

## Features

* Retrieve **current weather**
* Retrieve **forecast weather**
* Secure API endpoints with **Basic Authentication**
* Use **Polly retry and timeout policies** for external HTTP calls
* Cache current and forecast responses with **IMemoryCache**
* Log application startup, requests, retries, cache usage, and failures
* Test service logic, helper methods, wrappers, and controller integration flows

---

## Screenshots

### Current Weather View

![Current](./docs/screenshots/current.png)

### Forecast View

![Forecast](./docs/screenshots/forecast.png)

### Swagger

![Swagger](./docs/screenshots/swagger.png)

> Note: depending on the external provider plan, forecast support may be limited. In this project, the architecture and endpoint flow are implemented regardless of provider-tier constraints.

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/lampartondrej/PrezentacniProjekt.git
cd PrezentacniProjekt
```

### 2. Configure environment variables

Set the following environment variables before running the API:

```bash
WeatherstackApiKey=YOUR_API_KEY
PrezentacniProjekt_ApiUsername=YOUR_USERNAME
PrezentacniProjekt_ApiPassword=YOUR_PASSWORD
```

### 3. Run the REST API

```bash
cd ShowcaseProject.Rest
dotnet run
```

### 4. Run the MVC web application

```bash
cd ShowcaseProject.Web
dotnet run
```

---

## API Endpoints

### Current weather

```http
POST /Weather/current
```

### Forecast weather

```http
POST /Weather/forecast
```

### Health check

```http
GET /health
```

---

## Authentication

The API uses **Basic Authentication**.

Example header:

```http
Authorization: Basic base64(username:password)
```

Credentials are not stored directly in source code.
The API reads the names of environment variables from configuration and loads the actual credentials from environment variables at runtime.

---

## Testing

The solution contains a separate `ShowcaseProject.Tests` project.

### Covered areas

* helper logic for building Weatherstack query strings
* service wrapper behavior
* `WeatherService` unit tests
* controller integration tests
* authentication scenarios
* health check endpoint behavior

### Testing stack

* **xUnit** for test execution
* **Moq** for mocking dependencies
* **Microsoft.AspNetCore.Mvc.Testing** for integration testing
* **coverlet.collector** for coverage collection

### Run tests

```bash
dotnet test
```

---

## Design Decisions

### Service Wrapper Pattern

The service layer returns a generic `ServiceWrapper<T>` instead of raw DTOs.
This keeps success and failure handling consistent across endpoints and simplifies controller logic.

### Dedicated Service Layer

External weather-provider communication is isolated inside `WeatherService`.
This keeps controllers thin and makes the application easier to test and evolve.

### Resilience with Polly

The REST API uses Polly retry and timeout policies for outgoing HTTP requests.
This improves robustness when external services are slow or temporarily unavailable.

### In-Memory Caching

Current and forecast responses are cached in memory for a limited period.
This reduces duplicate requests to the external provider and improves responsiveness for repeated queries.

### Environment-Based Secrets

API keys and authentication credentials are loaded from environment variables rather than being hardcoded in the repository.

### Separate Test Project

Unit and integration tests are isolated in a dedicated test project.
This makes the solution easier to maintain and demonstrates testability as a first-class concern.

---

## GitHub Copilot Usage

GitHub Copilot was used as a development assistant while implementing:

* parts of the automated tests
* Polly-based resilience policies
* in-memory caching

All generated code was manually reviewed, adjusted, and integrated into the project structure.

---

## What This Project Demonstrates

* practical ASP.NET Core backend development
* layered application design
* structured integration with an external API
* authentication and environment-based configuration
* resilience and caching patterns
* automated testing across multiple levels

---

## Author

Ondřej Lampart
GitHub: https://github.com/lampartondrej

---

## License

This repository is intended for demonstration and portfolio purposes.
