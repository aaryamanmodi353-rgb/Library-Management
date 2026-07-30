# 📚 Library Management System

![.NET](https://img.shields.io/badge/.NET-8.0%2B-blueviolet)
![ASP.NET Core](https://img.shields.io/badge/Framework-ASP.NET_Core_MVC-blue)
![EF Core](https://img.shields.io/badge/ORM-Entity_Framework_Core-orange)
![xUnit](https://img.shields.io/badge/Testing-xUnit-brightgreen)

An enterprise-grade, highly responsive Model-View-Controller (MVC) web application built with **ASP.NET Core**. This platform serves as a modern digital portal for libraries to track physical and digital assets, manage borrowing records, and streamline user administration.

---

## ✨ Key Features

- **Modern Glassmorphic UI**: Beautifully crafted interface using advanced Bootstrap grids, hover animations, CSS gradients, and high-quality cover images.
- **Dynamic Asset Tracking**: Complete CRUD lifecycle management for multiple asset types:
  - 📖 **Books**
  - 📰 **Publications** (Magazines & Newspapers)
- **Advanced Borrowing Engine**: Track real-time item availability. Seamlessly manage checkout instances, overdue tracking, and return processing without manual data entry.
- **Identity & Authorization**: Role-based access control with robust models for **Librarians** and **Students**.
- **Pagination & Search**: High-performance querying using Entity Framework Core, providing instantaneous paginated results and search filtering.
- **Deterministic Unit Testing**: Heavily tested controllers using **xUnit** and **FluentAssertions** with an InMemory Database provider for conflict-free CI/CD execution.

---

## 🛠️ Technology Stack

| Category | Technology |
|---|---|
| **Backend Framework** | ASP.NET Core MVC (C#) |
| **ORM & Data Access** | Entity Framework Core (EF Core) |
| **Database** | SQLite (Designed for easy migration to SQL Server/PostgreSQL) |
| **Frontend** | Razor Views (`.cshtml`), Bootstrap 5, Vanilla CSS, Bootstrap Icons |
| **Testing** | xUnit, FluentAssertions, Microsoft.EntityFrameworkCore.InMemory |

---

## 🚀 Getting Started

Follow these instructions to get a local copy of the project up and running.

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) (or later)
- Visual Studio 2022, Rider, or VS Code.

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/aaryamanmodi353-rgb/Library-Management.git
   cd Library-Management
   ```

2. **Restore NuGet dependencies**
   ```bash
   dotnet restore
   ```

3. **Apply Database Migrations**
   The project uses EF Core Code-First migrations. Apply them to generate the local SQLite database (`library.db`):
   ```bash
   dotnet ef database update
   ```
   *(Note: The database comes pre-seeded with sample books and publications for immediate testing).*

4. **Run the Application**
   ```bash
   dotnet run
   ```

5. **Access the App**
   Open your browser and navigate to `http://localhost:5039` (or the port specified in your console output).

---

## 🧪 Running Unit Tests

The repository includes a dedicated test suite (`TestProject1`) built with **xUnit** to guarantee business logic integrity (e.g., verifying `BooksController` pagination and valid model states).

To execute the tests:
```bash
dotnet test
```

---

## 🏗️ Architecture Overview

The application follows a strict **N-Tier MVC Architecture**:
*   **Models**: Pure domain entities (`Book.cs`, `BorrowRecord.cs`) representing the database schema.
*   **ViewModels**: Data Transfer Objects (DTOs) tailored specifically for Razor view binding (`BookListViewModel.cs`), ensuring the UI only receives the exact data it needs.
*   **Controllers**: Lean controllers responsible for HTTP routing, validating `ModelState`, and orchestrating database queries via `LibraryContext`.
*   **Views**: Razor pages leveraging partials and layouts (`_Layout.cshtml`) for a DRY, easily maintainable frontend.

---

## 👨‍💻 Authors

Developed by [Aaryaman Modi](https://github.com/aaryamanmodi353-rgb).
