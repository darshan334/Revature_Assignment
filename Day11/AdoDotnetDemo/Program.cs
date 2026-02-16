using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            string connectionString =
    "Server=DARSHAN;Database=CrmDB;Trusted_Connection=True;TrustServerCertificate=True;";


            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection opened successfully.");

            // ExecuteNonQuery(connection);      //For data Entry like (insert, update, delete)
            ExecuteScalar(connection);           // For single value like (count, sum, max, min)
            ExecuteReader(connection);           // For multiple rows like (select * from table)
            sqlDataAdapterDemo(connection);        // For filling DataTable and working with disconnected data
            InsertCustomerDemo(connection);              // For inserting data using DataSet and SqlDataAdapter
            SqlInjectionDemo(connection);              // For demonstrating SQL Injection vulnerability
            ParameterizedQueryDemo(connection);              // For demonstrating Parameterized Queries

            // string query = "SELECT Id, Name, Age FROM Customer";

            // using var command = new SqlCommand(query, connection);
            // using var reader = command.ExecuteReader();

            // while (reader.Read())
            // {
            //     int id = reader.GetInt32(0);
            //     string name = reader.GetString(1);
            //     int age = reader.GetInt32(2);

            //     Console.WriteLine($"{id}\t{name}\t{age}");
            // }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ParameterizedQueryDemo(SqlConnection connection)
    {
        using (SqlCommand command = new SqlCommand(
            "SELECT * FROM Customer WHERE Name LIKE @Name",
            connection))

        {
            // var id = "3";
            // var id = "3 or 1 = 1";
            // var id = "3 or 1 = 1";
            // Add parameters - database treats them as DATA, never as SQL code
            var name = "John or 1 = 1";
            command.Parameters.AddWithValue("@Name", name);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
            }
            else
            {
                Console.WriteLine("No customer found with the specified Id.");
            }
        }
    }

    static void SqlInjectionDemo(SqlConnection connection)
    {
        // Query: SELECT * FROM Customer WHERE Id = 1 or 1 = 1
        var userInput = "1 or 1 = 1";
        // var userInput = "1; DROP TABLE Customer; ";
        // var userInput = "3";
        var query = $"SELECT * FROM Customer WHERE Id = {userInput}";

        using var command = new SqlCommand(query, connection);
        try
        {
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing query: {ex.Message}");
        }
    }


    static void sqlDataAdapterDemo(SqlConnection connection)
    {
        var query = "SELECT * FROM Customer";

        SqlCommand sqlcommand = new(query, connection);

        using var selectAllCustomersCommand = sqlcommand;
        using var adapter = new SqlDataAdapter(selectAllCustomersCommand);
        var customerDataTable = new DataTable();

        adapter.Fill(customerDataTable);

        foreach (DataRow row in customerDataTable.Rows)
        {
            Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}");
        }
    }

    static void InsertCustomerDemo(SqlConnection connection)
    {
        var dataSet = new DataSet();

        var selectQuery = "SELECT * FROM Customer";
        using var selectCommand = new SqlCommand(selectQuery, connection);
        using var adapter = new SqlDataAdapter(selectCommand);

        adapter.Fill(dataSet, "Customer");

        if (!dataSet.Tables.Contains("Customer"))
        {
            Console.WriteLine("Customer table not found.");
            return;
        }

        var dataTable = dataSet.Tables["Customer"]!;

        var newRow = dataTable.NewRow();
        newRow["Name"] = "John Doe";
        newRow["Age"] = 25;

        dataTable.Rows.Add(newRow);

        adapter.InsertCommand = new SqlCommand(
            "INSERT INTO Customer (Name, Age) VALUES (@Name, @Age)",
            connection);

        adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
        adapter.InsertCommand.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");

        adapter.Update(dataSet, "Customer");

        dataSet.AcceptChanges();
    }


    // ======================================================
    // 1️⃣ INSERT → ExecuteNonQuery
    // ======================================================
    static void ExecuteNonQuery(SqlConnection connection)
    {
        var query = "INSERT INTO Customer (Name, Age) VALUES ('Danny', 30)";

        using var command = new SqlCommand(query, connection);

        var rowsAffected = command.ExecuteNonQuery();

        Console.WriteLine($"Rows affected (Insert): {rowsAffected}\n");
    }


    // ======================================================
    // 2️⃣ SINGLE VALUE → ExecuteScalar
    // ======================================================
    static void ExecuteScalar(SqlConnection connection)
    {
        var query = "SELECT COUNT(*) FROM Customer";

        using var command = new SqlCommand(query, connection);

        var result = command.ExecuteScalar();   // 🔹 ExecuteScalar

        Console.WriteLine($"Total Customers: {result}\n");
    }


    // ======================================================
    // 3️⃣ MULTIPLE ROWS → ExecuteReader
    // ======================================================
    static void ExecuteReader(SqlConnection connection)
    {
        var query = "SELECT Id, Name, Age FROM Customer";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();   // 🔹 ExecuteReader

        Console.WriteLine("Customer List:");
        Console.WriteLine("----------------------------");

        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var name = reader.GetString(1);
            var age = reader.GetInt32(2);

            Console.WriteLine($"{id}\t{name}\t{age}");
        }

        Console.WriteLine();
    }
}



