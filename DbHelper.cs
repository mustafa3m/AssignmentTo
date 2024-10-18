using System;
using Microsoft.Data.SqlClient;
using AssignmentTo;  // For CustomerRepository and ICustomerRepository
using AssignmentTo.Models;  // For Customer model

namespace AssignmentToNoroff
{
    public class DbHelper
    {
        // Method to create and return the connection string
        public static string GetSqlConnectionString()
        {
            // Set up the connection string builder
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost\\SQLEXPRESS06";  // Specify your local instance
            builder.InitialCatalog = "chinook";  // Replace with your database
            builder.IntegratedSecurity = true;   // Use Windows Authentication
            builder.TrustServerCertificate = true; // Trust the server certificate

            return builder.ConnectionString;  // Return the connection string
        }

        // Method to test the connection
        public static void TestConnection()
        {
            string connectionString = GetSqlConnectionString();

            // Try to connect to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection to database successful!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error during connection: {ex.Message}");
                }
            }
        }
    }
}


