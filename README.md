# 🚀 Mailroom Management

**MailroomManagement** is a powerful and intuitive ASP.NET Core Web API designed to streamline mailroom operations. It allows organizations to efficiently track, manage, and organize incoming and outgoing documents. The project leverages modern software design patterns, including Dependency Injection and the Repository Pattern, to ensure clean, maintainable, and scalable code.

## 🌟 Key Features

- **User & Organization Management**: Easily manage users and organizations.
- **Department Management**: Organize your teams and departments.
- **Document Upload & Tracking**: Upload and track documents with ease.
- **Status Updates & History Tracking**: Maintain a detailed log of document status changes.
- **JWT Authentication & Authorization**: Secure your API with JWT.

## 🛠 Technologies Used

- **Backend**: ASP.NET Core 8.0 – Utilizing the latest features such as minimal APIs, improved performance, and native AOT compilation.
- **Database**: SQL Server with Entity Framework Core 8.0 – Leveraging the latest improvements in LINQ queries, bulk updates, and JSON support.
- **Dependency Injection**: Built-in DI container for managing dependencies and promoting loose coupling.
- **Repository Pattern**: Abstracting data access logic to ensure separation of concerns and easier testing.
- **Containerization**: Docker – Ensuring consistent environments from development to production.
- **API Documentation**: Swagger/OpenAPI – Providing interactive and comprehensive API documentation.
- **Authentication**: JWT (JSON Web Tokens) – Secure and scalable authentication mechanism.

## 🏗 Project Architecture

The MailroomManagement project follows a **layered architecture** to ensure separation of concerns, maintainability, and scalability. The main layers are:

1. **Presentation Layer**: Contains the API controllers and DTOs (Data Transfer Objects).
2. **Application Layer**: Contains services and business logic.
3. **Domain Layer**: Contains entities and interfaces.
4. **Infrastructure Layer**: Contains data access logic, repositories, and database context.
5. **Shared Layer**: Contains common utilities, constants, and extensions.

### Project Structure

<img width="631" height="629" alt="image" src="https://github.com/user-attachments/assets/892c1c85-6ee3-4d8e-b299-887cd354d75a" />

### Layer Responsibilities

- **Presentation Layer (MailroomManagement.Api)**:
  - Handles HTTP requests and responses.
  - Maps between DTOs and domain entities.
  - Uses dependency injection to resolve services.

- **Application Layer (MailroomManagement.Application)**:
  - Contains business logic and application services.
  - Coordinates between domain entities and infrastructure services.
  - Uses AutoMapper for mapping between domain entities and DTOs.

- **Domain Layer (MailroomManagement.Core)**:
  - Contains domain entities and business rules.
  - Defines interfaces for repositories and services.
  - Independent of other layers, ensuring a clean architecture.

- **Infrastructure Layer (MailroomManagement.Infrastructure)**:
  - Implements data access logic using Entity Framework Core.
  - Contains repository implementations.
  - Handles database migrations.

- **Shared Layer (MailroomManagement.Shared)**:
  - Contains common utilities, constants, and extensions used across the application.

<img width="1185" height="855" alt="{5BAFECFC-EDAF-4427-9F43-A0160D640DA2}" src="https://github.com/user-attachments/assets/a6ab5346-fb23-4be0-8288-5eac6a0e6cac" />

## 🔧 Dependency Injection and Repository Pattern

The MailroomManagement project utilizes Dependency Injection (DI) and the Repository Pattern to ensure a clean architecture and maintainable codebase.

### Dependency Injection
In ASP.NET Core, Dependency Injection is built into the framework. Services and repositories are registered in the Program.cs file and injected into controllers and services as needed.
Example of DI Registration in Program.cs:
csharp




## 💻 Setup Instructions

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/) (optional)

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/desiangelova24/MailroomManagement.git
   cd MailroomManagement
