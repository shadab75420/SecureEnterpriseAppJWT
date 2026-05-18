# SecureEnterpriseApp

## Project Overview

SecureEnterpriseApp is a secure ASP.NET Core Web API application developed using ASP.NET Core, Entity Framework Core, SQL Server, ASP.NET Identity, and JWT Authentication.

The project focuses on implementing enterprise-level authentication and authorization mechanisms with secure communication using HTTPS and Role-Based Access Control (RBAC).

This application demonstrates secure backend development practices including JWT-based Authentication, Secure User Login and Registration, Role-Based Authorization, Protected API Endpoints, HTTPS Security, Token Expiry and Validation, ASP.NET Identity Integration, and Swagger API Testing.

---

# Features

## Authentication Features

- User Registration
- User Login
- JWT Token Generation
- JWT Token Validation
- Token Expiry Handling
- Secure Password Hashing using ASP.NET Identity

## Authorization Features

- Role-Based Access Control (RBAC)
- Admin Role Authorization
- User Role Authorization
- Protected API Endpoints
- Secure API Access using JWT Bearer Token

## Security Features

- HTTPS Enabled
- Secure Authentication Middleware
- JWT Signature Validation
- Issuer and Audience Validation
- Protected Routes using Authorization
- Secure API Communication

## API Documentation

- Swagger/OpenAPI Integration
- Swagger JWT Authorization Support
- API Testing Interface

---

# Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core Web API | Backend Framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| ASP.NET Identity | Authentication & User Management |
| JWT Authentication | Secure Authentication |
| Swagger/OpenAPI | API Documentation & Testing |
| HTTPS/SSL | Secure Communication |

---

# Project Structure

```plaintext
SecureEnterpriseApp
│
├── Controllers
│   ├── AuthController.cs
│   └── SecureController.cs
│
├── Models
│   └── ApplicationUser.cs
│
├── DTOs
│   ├── LoginDto.cs
│   └── RegisterDto.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Services
│   ├── IJwtService.cs
│   └── JwtService.cs
│
├── Repositories
│
├── Middleware
│
├── Security
│
├── Helpers
│
├── Migrations
│
├── Properties
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
└── SecureEnterpriseApp.csproj
```

---

# Authentication Flow

## User Registration Flow

1. User submits registration details.
2. The server validates the data.
3. ASP.NET Identity creates the user.
4. Password is securely hashed.
5. User role is assigned.
6. User data is stored in SQL Server database.

## User Login Flow

1. User submits email and password.
2. Server validates credentials.
3. JWT token is generated upon successful authentication.
4. JWT token is returned to the user.

## Protected API Access Flow

1. User sends JWT token in Authorization header.
2. JWT middleware validates token.
3. Server checks user claims and roles.
4. Access is granted or denied based on authorization rules.

---

# API Endpoints

## Authentication APIs

- Register User
- Login User

## Secure APIs

- Public Endpoint
- Protected Endpoint
- Admin Endpoint
- User Endpoint

---

# JWT Authentication

The application uses JWT (JSON Web Token) for secure authentication.

JWT contains:
- User ID
- Email
- Role Claims
- Expiry Time

The token is sent in the Authorization header using Bearer Authentication.

---

# Database Configuration

The application uses SQL Server with Entity Framework Core.

Database includes ASP.NET Identity tables such as:
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- AspNetUserClaims

---

# Swagger Testing

Swagger is integrated for API documentation and testing.

Features:
- API endpoint testing
- JWT Authorization support
- Request and response visualization

Swagger provides an easy interface to test protected APIs using JWT tokens.

---

# Security Implementations

- JWT Authentication
- Role-Based Authorization
- HTTPS Enforcement
- Secure Password Hashing
- Token Expiry Validation
- Secure API Access
- Authentication Middleware
- Authorization Middleware

---

# How the Project Works

## Step 1 — Create Backend API Project

An ASP.NET Core Web API project is created with HTTPS and Swagger enabled.

## Step 2 — Configure Database

SQL Server is connected using Entity Framework Core and ASP.NET Identity.

## Step 3 — Configure Authentication

JWT Authentication is configured to validate tokens securely.

## Step 4 — Create User Management System

ASP.NET Identity is used to manage users, passwords, and roles.

## Step 5 — Implement Registration and Login

Users can register and log in securely using APIs.

## Step 6 — Generate JWT Token

After successful login, the server generates a JWT token containing user identity and role claims.

## Step 7 — Protect APIs

Protected endpoints are secured using authorization attributes.

## Step 8 — Implement Role-Based Authorization

Different APIs are accessible only to specific user roles like Admin and User.

## Step 9 — Test APIs Using Swagger

Swagger is used to test login, token authorization, and protected APIs.

---

# Learning Outcomes

This project helped in understanding:

- ASP.NET Core Web API Development
- JWT Authentication
- ASP.NET Identity
- Secure Authentication Systems
- Role-Based Authorization
- Entity Framework Core
- SQL Server Integration
- Swagger/OpenAPI
- HTTPS Security
- Backend API Security

---

# Conclusion

SecureEnterpriseApp is a secure authentication-based ASP.NET Core Web API project implementing enterprise-level security mechanisms using JWT Authentication and Role-Based Authorization.

The project demonstrates secure API development practices, authentication workflows, authorization techniques, and secure communication between client and server using HTTPS.
