
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using AssignmentTo;  // For CustomerRepository and ICustomerRepository
using AssignmentTo.Models;  // For Customer model


namespace AssignmentTo
{
  

    // Implement the ICustomerRepository interface
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Implement the interface methods here using ADO.NET to interact with the database and return the results .
        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer", connection);
                var reader = command.ExecuteReader();

                var customers = new List<Customer>();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Country = reader["Country"] as string,
                        PostalCode = reader["PostalCode"] as string,
                        Phone = reader["Phone"] as string,
                        Email = (string)reader["Email"]
                    });
                }
                return customers;
            }
        }


        // Implement GetCustomerById method  here 
        public Customer GetCustomerById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = @CustomerId", connection);
                command.Parameters.AddWithValue("@CustomerId", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Country = reader["Country"] as string,
                        PostalCode = reader["PostalCode"] as string,
                        Phone = reader["Phone"] as string,
                        Email = (string)reader["Email"]
                    };
                }
                return null;
            }
        }

        // Implement GetCustomersByName method  here
        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Customer WHERE FirstName LIKE @Name OR LastName LIKE @Name", connection);
                command.Parameters.AddWithValue("@Name", $"%{name}%");
                var reader = command.ExecuteReader();

                var customers = new List<Customer>();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Country = reader["Country"] as string,
                        PostalCode = reader["PostalCode"] as string,
                        Phone = reader["Phone"] as string,
                        Email = (string)reader["Email"]
                    });
                }
                return customers;
            }
        }

        // Implement GetCustomers method  here
        public IEnumerable<Customer> GetCustomers(int limit, int offset)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY", connection);
                command.Parameters.AddWithValue("@Offset", offset);
                command.Parameters.AddWithValue("@Limit", limit);
                var reader = command.ExecuteReader();

                var customers = new List<Customer>();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Country = reader["Country"] as string,
                        PostalCode = reader["PostalCode"] as string,
                        Phone = reader["Phone"] as string,
                        Email = (string)reader["Email"]
                    });
                }
                return customers;
            }
        }

        // Implement AddCustomer method  here
        public void AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)", connection);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.ExecuteNonQuery();
            }
        }

        // Implement UpdateCustomer method  here
        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId", connection);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                command.ExecuteNonQuery();
            }
        }

        // Implement GetCustomerCountByCountry method  here
        public int GetCustomerCountByCountry(string country)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Customer WHERE Country = @Country", connection);
                command.Parameters.AddWithValue("@Country", country);
                return (int)command.ExecuteScalar();
            }
        }

        // Implement GetHighestSpenders method  here
        public IEnumerable<Customer> GetHighestSpenders()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                SELECT c.CustomerId, c.FirstName, c.LastName, SUM(i.Total) AS TotalSpent
                FROM Customer c
                JOIN Invoice i ON c.CustomerId = i.CustomerId
                GROUP BY c.CustomerId, c.FirstName, c.LastName
                ORDER BY TotalSpent DESC", connection);
                var reader = command.ExecuteReader();

                var customers = new List<Customer>();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"]
                    });
                }
                return customers;
            }
        }

        // Implement GetMostPopularGenre method  here
        public string GetMostPopularGenre(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                SELECT g.Name
                FROM Genre g
                JOIN Track t ON g.GenreId = t.GenreId
                JOIN InvoiceLine il ON t.TrackId = il.TrackId
                JOIN Invoice i ON il.InvoiceId = i.InvoiceId
                WHERE i.CustomerId = @CustomerId
                GROUP BY g.Name
                ORDER BY COUNT(*) DESC", connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                var reader = command.ExecuteReader();

                string genres = "";
                while (reader.Read())
                {
                    genres += (string)reader["Name"] + ", ";
                }

                return genres.TrimEnd(',', ' '); // Return trimmed genres
            }
        }
    }

}
