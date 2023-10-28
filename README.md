# Product Support - V1.0

Welcome to the Product Support project, version 1.0. This project is built using ASP.NET Core Web API 6, following the Service Layer pattern and utilizing Dependency Injection. The database used in this project is Firebase Realtime Database.

## Project Overview

Product Support V1.0 is a simple CRUD (Create, Read, Update, Delete) application designed for managing and supporting product information. It allows you to add, modify, and delete products, as well as create and manage customized categories for these products.

## Project Content

This project includes the following key features:

- **ASP.NET Core Web API 6**: The project is built on the latest version of ASP.NET Core Web API, providing robust and high-performance web services.

- **Service Layer Pattern**: The codebase follows the Service Layer pattern, which promotes a structured and modular approach to application development. Services are responsible for the business logic, separating it from the controller layer.

- **Dependency Injection**: Dependency Injection is used to promote loose coupling between components and facilitate unit testing. This makes the project more maintainable and testable.

- **Firebase Realtime Database**: The project leverages Firebase Realtime Database as the data storage solution. Firebase offers real-time data synchronization, scalability, and reliability.

- **CRUD Operations**: The project supports basic CRUD operations for managing products and their associated categories.

- **10 Endpoints**: The project exposes 10 API endpoints for interacting with product and category data. These endpoints cover operations like creating, updating, deleting, and retrieving data.

## Endpoints

Here is a summary of the project's API endpoints:

1. `GET /api/Product` - Retrieve a list of all products.
2. `GET /api/Product/{id}` - Retrieve a specific product by ID.
3. `POST /api/Product` - Create a new product.
4. `PUT /api/Product/{id}` - Update an existing product.
5. `DELETE /api/Product/{id}` - Delete a product by ID.
6. `GET /api/Category` - Retrieve a list of all categories.
7. `GET /api/Category/{id}` - Retrieve a specific category by ID.
8. `POST /api/Category` - Create a new category.
9. `PUT /api/Category/{id}` - Update an existing category.
10. `DELETE /api/Category/{id}` - Delete a category by ID.

## Getting Started

To get started with this project, follow these steps:
1. **Install .NET Core**: If you haven't already installed .NET Core, you can download and install it from the official website:
   - [Download .NET](https://dotnet.microsoft.com/download)
2. Clone the repository to your local development environment.
3. Set up your Firebase Realtime Database and update the database configuration in the project. You will find the configuration in the `Program.cs` file.

   In the `Program.cs` file, look for the following code snippet:

   ```csharp
   builder.Services.AddSingleton<FirebaseClient>(_ => new FirebaseClient("YOUR_FIREBASE_REALTIME_URL_HERE"));
3. Build and run the ASP.NET Core Web API application.
4. Use the provided API endpoints to manage products and categories.

