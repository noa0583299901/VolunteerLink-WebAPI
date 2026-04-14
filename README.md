
# VolunteerLink - Professional Skill Management System

VolunteerLink is a high-performance Full-Stack Web API built with **ASP.NET Core 8.0**. The system is designed to provide a comprehensive solution for managing volunteers and their professional skills, utilizing a robust Many-to-Many relational model and Clean Architecture principles.

## Key Features

* Many-to-Many Architecture: A sophisticated data model allowing volunteers to possess multiple professional skills, managed through a dedicated relational join-table structure.
* Secure Authentication & Authorization: Full integration of JWT (JSON Web Tokens) including Role-Based Access Control (RBAC).
* Professional Skill Management: Volunteers can dynamically add skills to their profile by name, with logic to prevent duplicates and secure identity verification via JWT claims.
* Admin Control Center: Specialized endpoints protected by administrative-only permissions to manage the global skill repository.
* Asynchronous Processing: End-to-end implementation of the async/await pattern across all layers for high scalability.
* Clean Data Exposure: Implementation of DTOs and AutoMapper to ensure sensitive database entities are never exposed directly.
* Optimized API Responses: Standardized HTTP status codes (200, 201, 204, 401, 403) for a professional developer experience.

## Tech Stack

* Backend: ASP.NET Core Web API (.NET 8.0)
* Database: SQL Server (MS-SQL)
* ORM: Entity Framework Core (Code-First)
* Security: JWT Bearer Authentication
* Mapping & Tooling: AutoMapper, Swagger/OpenAPI, Newtonsoft JSON

## Installation & Setup

1. Clone the Repository:
   git clone https://github.com/YOUR_USERNAME/VolunteerLink.git

2. Configure Database:
   Update the DefaultConnection string in appsettings.json to point to your local SQL Server instance.

3. Apply Migrations:
   Run 'Update-Database' in the Package Manager Console.

4. Run the Application:
   Execute via Visual Studio (F5) or 'dotnet run'. Explore the API via Swagger at: https://localhost:XXXX/swagger

## Project Structure

* Volunteer.Api: Controllers, Middleware, and JWT configurations.
* Volunteer.Service: Business logic, validation, and DTO mapping.
* Volunteer.Repository: Data access layer and Entity Framework Context.
* Volunteer.Entities: Database models and domain interfaces.
* DTOs: Data structures for API communication.

---
Developed as a high-standard implementation of modern Web API and C# design patterns.
