# 🔐 Login System — ASP.NET Core MVC

A full-stack user authentication web application built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**. Features a clean dark-themed UI with secure BCrypt password hashing.

---

## 📸 Screenshots

### Sign In
![Login Page](screenshots/login.png)

### Sign Up
![SignUp Page](screenshots/signup.png)

### Dashboard
![Dashboard Page](screenshots/dashboard.png)

---

## ✨ Features

- ✅ User Registration with Name, Gender, Age, Email & Password
- ✅ Secure **BCrypt password hashing** — passwords never stored in plain text
- ✅ Login with **session-based authentication**
- ✅ Duplicate email detection on Sign Up
- ✅ Protected Dashboard — redirects to Login if not authenticated
- ✅ Logout clears session completely
- ✅ Server-side model validation with friendly error messages
- ✅ **CSRF protection** on all forms
- ✅ Clean, responsive dark-themed UI

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| Language | C# |
| ORM | Entity Framework Core 8 |
| Database | Microsoft SQL Server |
| Security | BCrypt.Net-Next (password hashing) |
| Frontend | Razor Views, Bootstrap 5, CSS3 |
| IDE | Visual Studio 2026 |

---

## 📁 Project Structure

```
LoginformAspCore/
├── Controllers/
│   └── HomeController.cs       # Login, SignUp, Dashboard, Logout logic
├── Models/
│   ├── UserTable.cs            # User entity with data annotations
│   ├── UserDBContext.cs        # EF Core DbContext
│   └── ErrorViewModel.cs
├── Views/
│   └── Home/
│       ├── Login.cshtml        # Sign In page
│       ├── SignUp.cshtml       # Registration page
│       └── DashBoard.cshtml    # Protected dashboard
├── Migrations/                 # EF Core Code-First migrations
├── wwwroot/                    # Static files (CSS, JS, Bootstrap)
├── appsettings.json            # App config (safe placeholder)
└── Program.cs                  # DI setup, middleware, session config
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or Express)
- Visual Studio 2026 or VS Code

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/Satyamglacs22/Login-System.git
   cd Login-System
   ```

2. **Configure the database connection**

   Create `appsettings.Development.json` in the project folder (this file is gitignored):
   ```json
   {
     "ConnectionStrings": {
       "dbcs": "Server=YOUR_SERVER;Database=UserDB;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Apply EF Core migrations**
   ```bash
   dotnet ef database update
   ```
   Or in Visual Studio — **Package Manager Console:**
   ```powershell
   Update-Database
   ```

4. **Run the app**
   ```bash
   dotnet run
   ```
   Open your browser at `https://localhost:7290`

---

## 🔒 Security Highlights

| Feature | Implementation |
|---|---|
| Password Storage | BCrypt hashing (`BCrypt.Net-Next`) |
| CSRF Protection | `[ValidateAntiForgeryToken]` on all POST actions |
| Session Security | HttpOnly cookies, 30-minute idle timeout |
| Sensitive Config | Connection string kept out of source control |
| Email Uniqueness | Duplicate check before registration |

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

---

> Built by [Satyam Kumar](https://github.com/Satyamglacs22)
