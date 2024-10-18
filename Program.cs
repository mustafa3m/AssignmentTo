using System;
using Microsoft.Data.SqlClient;
using AssignmentTo;  // For CustomerRepository and ICustomerRepository
using AssignmentTo.Models;  // For Customer model

// Main program to test the connection
Console.WriteLine("Attempting to connect to the database...");

Console.WriteLine();// Add a line break

string connectionString = "Data Source=localhost\\SQLEXPRESS06;Initial Catalog=Chinook;Integrated Security=True;TrustServerCertificate=True;";
// Use your actual connection string

using (var connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();
        Console.WriteLine("Connection successful!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Connection failed: {ex.Message}");
    }
}

// Create an instance of the CustomerRepository
ICustomerRepository customerRepository = new CustomerRepository(connectionString);

// 1 Example: Get all customers
var customers = customerRepository.GetAllCustomers();
Console.WriteLine();
Console.WriteLine("All Customers:");
Console.WriteLine();


foreach (var customer in customers)
{
    Console.WriteLine($"{customer.CustomerId}: {customer.FirstName} {customer.LastName}, {customer.Country}, {customer.PostalCode}, {customer.Phone}, {customer.Email}");
}

// 2 Example: Get a customer by ID
int customerId = 1; // Change to an existing customer ID
var customerById = customerRepository.GetCustomerById(customerId);
if (customerById != null)
{
    Console.WriteLine($"\nCustomer {customerId}: {customerById.FirstName} {customerById.LastName}, {customerById.Country}");
}
else
{
    Console.WriteLine($"\nCustomer with ID {customerId} not found.");
}

Console.WriteLine();

// 3 Example: Add a new customer
var newCustomer = new Customer
{
    FirstName = "Ali",
    LastName = "Osman",
    Country = "Norway",
    PostalCode = "1234525",
    Phone = "123-456-789056",
    Email = "ali.osman@gmail.com"
};
customerRepository.AddCustomer(newCustomer);
Console.WriteLine($"\nAdded new customer: {newCustomer.FirstName} {newCustomer.LastName}");

// 4 Example: Update an existing customer
customerById.LastName = "Smith"; // Change the last name
customerRepository.UpdateCustomer(customerById);
Console.WriteLine($"\nUpdated customer: {customerById.FirstName} {customerById.LastName}");

// 5 Example: Get the number of customers from a specific country
string country = "USA"; // Change to a specific country
int customerCount = customerRepository.GetCustomerCountByCountry(country);
Console.WriteLine($"\nNumber of customers from {country}: {customerCount}");

// 6 Example: Get highest spenders
var highestSpenders = customerRepository.GetHighestSpenders();
Console.WriteLine("\nHighest Spenders:");
Console.WriteLine();
foreach (var spender in highestSpenders)
{
    Console.WriteLine($"{spender.CustomerId}: {spender.FirstName} {spender.LastName}");
}

// 7 Example: Get the most popular genre for a customer
string popularGenre = customerRepository.GetMostPopularGenre(customerId);
Console.WriteLine($"\nMost popular genre for customer {customerId}: {popularGenre}");

// 8 Example: Get a page of customers
int limit = 10; // Nombre de clients par page
int offset = 0; // Décalage (page 1)
var pagedCustomers = customerRepository.GetCustomers(limit, offset);
Console.WriteLine("\nPaged Customers:");
foreach (var customer in pagedCustomers)
{
    Console.WriteLine($"{customer.CustomerId}: {customer.FirstName} {customer.LastName}, {customer.Country}");
}


// 9 Example: Search for customers by name
string searchName = "Ali"; // Change to a name to search
var customersByName = customerRepository.GetCustomersByName(searchName);
Console.WriteLine($"\nCustomers matching '{searchName}':");
foreach (var customer in customersByName)
{
    Console.WriteLine($"{customer.CustomerId}: {customer.FirstName} {customer.LastName}, {customer.Country}");
}

