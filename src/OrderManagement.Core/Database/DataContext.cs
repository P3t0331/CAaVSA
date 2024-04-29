using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using OrderManagement.Core.Attributes;
using System.Data;

namespace OrderManagement.Core.Database;

public interface IDataContext
{
    IDbConnection CreateConnection();
    Task Init();
}

[Register<IDataContext>]
public class DataContext : IDataContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection("Data Source=sqlite.db");
    }

    public async Task Init()
    {
        // create database tables if they don't exist
        using var connection = CreateConnection();
        await _init();

        async Task _init()
        {
            var sql = """
            CREATE TABLE IF NOT EXISTS Customer (
                Id VARCHAR(255) PRIMARY KEY,
                Name VARCHAR(255),
                Email VARCHAR(255),
                Address VARCHAR(255)
            );

            CREATE TABLE IF NOT EXISTS Orders (
                Id VARCHAR(255) PRIMARY KEY,
                CustomerId VARCHAR(255),
                OrderDate DATETIME,
                TotalAmount DECIMAL(10, 2),
                FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
            );

            CREATE TABLE IF NOT EXISTS OrderItem (
                Id VARCHAR(255) PRIMARY KEY,
                OrderId VARCHAR(255),
                ProductId VARCHAR(255),
                Quantity INT,
                CurrentPrice DECIMAL(10, 2),
                FOREIGN KEY (OrderId) REFERENCES Orders(Id)
            );

            -- -- Inserting data into Customer table
            -- INSERT INTO Customer (Id, Name, Email, Address)
            -- VALUES
            --     ('a113dd3e-1d12-4518-9e74-fa4beefcc5db', 'John Doe', 'john.doe@example.com', '123 Main Street'),
            --     ('d5dbe204-a5ab-4357-a853-e03b6d03b608', 'Jane Smith', 'jane.smith@example.com', '456 Oak Avenue'),
            --     ('886fa729-f886-4036-bf7d-766dd7c69271', 'Michael Johnson', 'michael.johnson@example.com', '789 Elm Drive');

            -- -- Inserting data into Orders table
            -- INSERT INTO Orders (Id, CustomerId, OrderDate, TotalAmount)
            -- VALUES
            --     ('43421f9a-d688-4097-a728-0399534b821c', 'a113dd3e-1d12-4518-9e74-fa4beefcc5db', '2024-04-29 10:00:00', 150.00),
            --     ('d30fda67-4078-41fe-ace0-6c9ce0f9309f', 'd5dbe204-a5ab-4357-a853-e03b6d03b608', '2024-04-28 15:30:00', 25.50),
            --     ('4f236473-5962-47ec-8ca5-e208ae21a347', '886fa729-f886-4036-bf7d-766dd7c69271', '2024-04-27 09:45:00', 150.00);

            -- -- Inserting data into OrderItem table
            -- INSERT INTO OrderItem (Id, OrderId, ProductId, Quantity, CurrentPrice)
            -- VALUES
            --     ('f37936a3-930d-4b68-998f-31990dee79b5', '43421f9a-d688-4097-a728-0399534b821c', 'a7d10701-3492-4e6c-9ec3-fba1254d889e', 2, 50.00),
            --     ('32b89420-9d01-4d21-a187-e212467c9867', '43421f9a-d688-4097-a728-0399534b821c', 'cffc3410-7129-49fa-a9d8-dac6e3189312', 1, 50.00),
            --     ('9b7db2ce-8e58-4642-9c0b-49fffd8837c5', 'd30fda67-4078-41fe-ace0-6c9ce0f9309f', '4d40d17b-854e-4097-ab46-7b529f9cb46f', 1, 25.50),
            --     ('ddf2cf46-56aa-4a3f-a540-89eb83b2d7b4', '4f236473-5962-47ec-8ca5-e208ae21a347', 'a2d54ce8-0bf1-46fb-8c82-2bc85baaee49', 3, 50.00);
            
            """;
            await connection.ExecuteAsync(sql);
        }
    }
}
