# .NET Application

## Description

This is a web application built using **.NET 9.0** and **C# 13.0**. 

## Technologies Used

- **.NET 9.0**: Framework for modern application development.
- **C# 13.0**: The programming language used for the backend.
- **Dapper ORM
- **RabbitMQ
- **xUnit for unit testing

### Prerequisites

Ensure you have the following software installed:

- **.NET SDK 9.0** or higher
- **Visual Studio 2022** or another IDE compatible with .NET
- **A supported database** (e.g., SQL Server, SQLite) if needed

### Steps to Run the Application

1. Clone the repository:
   ```bash
   git clone [https://github.com/milaneznando/sup-tech-challenge](https://github.com/milaneznando/SupplierTechnicalChallenge.git)
   ```

2. Navigate to the project folder:
   ```bash
   cd SupplierTechnicalChallenge
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Start the database (if required).

5. Run the application:
   ```bash
   dotnet run
   ```

## Features

- Auth, add a new Authenticated user and Login in the system.
- Customer, authenticated users can create customers and also can list them all.
- Transaction, authenticated users can create transactions for existing customers.


## File Structure

- `Program.cs`: The entry point of the application.
- `appsettings.json`: Application configuration file, such as connection strings and other settings.
- Additional folders for services, middlewares, etc., if applicable.

## Useful Scripts

Commands you can run for common development tasks:

- **Run tests (if tests are configured):**
  ```bash
  dotnet test
  ```

- **Build and publish the package:**
  ```bash
  dotnet publish
  ```

## Contribution

1. Fork this repository.
2. Create a branch for your changes.
3. Submit a pull request with a clear description of your changes.

## License

This project is licensed under the [PROJECT_LICENSE].

---

**Note:** Update this file with specific details about your project's features, authors, configuration, and more to ensure it is 100% relevant to your application.
```sql
create table Customers
(
    Id         varchar(255)   not null
        primary key,
    Name       varchar(255)   not null,
    CPF        varchar(11)    not null,
    LimitValue decimal(10, 2) not null
);

create table Users
(
    Id       varchar(255) not null
        primary key,
    Email    varchar(255) not null,
    Password varchar(255) not null
);

create table Transactions
(
    Id         varchar(36)    not null
        primary key,
    Value      decimal(10, 2) not null,
    CustomerId varchar(36)    null,
    constraint transactions_customers_Id_fk
        foreign key (CustomerId) references customers (Id)
);
```

Needed script to start a docker container and initialize the RabbitMQ
```script
docker run -d --name my-rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
