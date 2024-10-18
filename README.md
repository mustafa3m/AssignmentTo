Project: Data Access with SQL Client

Overview : 

This project demonstrates how to interact with two databases, SuperheroesDb and Chinook, using SQL scripts and a C# console application. The focus is on creating a database, defining relationships, inserting data, and managing customer information through SQL queries. A helper class, DbHelper, is used to streamline database connections.

Features
1. Superheroes Database (SuperheroesDb)
Tables: Includes Superhero, Assistant, and Power tables.
Relationships: One-to-many relationship between Superhero and Assistant, and a many-to-many relationship between Superhero and Power.
SQL Scripts: Scripts are provided to create the database, establish relationships, and insert data into the tables for superheroes, assistants, and powers.
2. Customer Management (Chinook Database)
The C# console application uses a repository pattern to interact with the Chinook database:

Retrieve All Customers: Fetches customer details such as ID, name, country, etc.
Get Customer by ID: Retrieves details of a specific customer by their ID.
Search Customers by Name: Finds customers using partial name matches.
Pagination: Displays paginated customer data with limit and offset parameters.
Add New Customer: Adds a new customer with basic details.
Update Customer: Updates information of an existing customer.
Customer Count by Country: Lists customers by country in descending order.
Top Spending Customers: Shows customers with the highest total spending.
Most Popular Genre per Customer: Finds the most purchased genre for each customer.
3. Database Connection with DbHelper
The DbHelper class is used to manage connections to the SQL Server. It encapsulates connection string handling and ensures safe and efficient interactions with the database. This class is utilized in the repository to perform SQL operations like reading, inserting, updating, and deleting customer data.
