# Product Support - V1.5.0

Welcome to the Product Support project, version 1.5. This project has undergone significant updates to enhance functionality and usability.

## Project Overview

Product Support V1.5.0 is a versatile CRUD (Create, Read, Update, Delete) application designed for managing and supporting product information. It allows you to add, modify, and delete products, as well as create and manage customized categories. Companies can be associated with products to track ownership and relationships. The project leverages Entity Framework Core with PostgreSQL as the relational database management system (RDBMS) and AutoMapper for efficient data mapping.

## Diagrams

![ERD](https://github.com/kamikazeayoup/ProductSupport.API/blob/master/ERD.png)
                            ER-Diagram
The Project Contains 3 Tables : Products, Categories and Companies
## Project Content

This project now includes the following key features:

- **Entity Framework Core and PostgreSQL**: The project has migrated to Entity Framework Core, using PostgreSQL as the RDBMS. This provides a robust and scalable database solution.

- **CRUD Operations**: The project supports basic CRUD operations for managing products, categories, and companies.

- **Company Table**: A new "Company" table has been added to associate companies with products. This enables tracking and managing product ownership.

- **Automapper**: AutoMapper is used for efficient data mapping between different data models, simplifying data transfer and management.

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
11. `GET /api/Company` - Retrieve a list of all companies.
12. `GET /api/Company/{id}` - Retrieve a specific company by ID.
13. `POST /api/Company` - Create a new company.
14. `PUT /api/Company/{id}` - Update an existing company.
15. `DELETE /api/Company/{id}` - Delete a company by ID.

## Packages Used

This project utilizes the following packages:

1. [AutoMapper](https://www.nuget.org/packages/AutoMapper)
2. [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/2.0.1)
3. [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/7.0.13)
4. [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.13)
5. [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/7.0.11)
6. [Npgsql.EntityFrameworkCore.PostgreSQL.Design](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL.Design/1.1.0)
7. [Npgsql.EntityFrameworkCore.PostgreSQL.NetTopologySuite](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL.NetTopologySuite/7.0.11)

These packages play a crucial role in the functionality and features of the project. You can explore their documentation and learn more about how they are used within the code.

## Getting Started

To get started with this updated project, follow these steps:

1. **Install .NET Core 6**: If you haven't already installed .NET Core 6, you can download and install it from the official website:
   - [Download .NET](https://dotnet.microsoft.com/download)
2. Clone the repository to your local development environment.
3. Go to the `appsettings.json` file and add your PostgreSQL connection string as follows:
   ```json
   "DefaultConnection": "Host=YOUR_HOST;Port=YOUR_PORT;Database=YOUR_DATABASE;Username=YOUR_USERNAME;Password=YOUR_PASSWORD"
4. Open the Package Manager Console in Visual Studio (or use the command-line equivalent) and run the following command to create the database tables based on the migrations:
   ```Shell
   Update-Database
5. Create the necessary directories for the project's file structure. You can do this manually by following these steps:
   Navigate to the root of your project.
   Create a directory named "Images."
   Inside the "Images" directory, create two subdirectories: "Products" and "Companies."
   Your file structure should look like this:
   ```markdown
      - Images/
        - Products/
        - Companies/


## Previous Version

If you are looking for the previous version of this project, you can find it in the [ProductSupport V1.0 repository](https://github.com/kamikazeayoup/ProductSupport.API/tree/ProductSupportV1.0).

Please note that the latest updates and features are available in the current version (V1.5.0).


