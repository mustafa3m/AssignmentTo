using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentTo.Models;
using Microsoft.Data.SqlClient;
// Repositories/ICustomerRepository.cs
using System.Collections.Generic;

namespace AssignmentTo
{
    

    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomersByName(string name);
        IEnumerable<Customer> GetCustomers(int limit, int offset);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        int GetCustomerCountByCountry(string country);
        IEnumerable<Customer> GetHighestSpenders();
        string GetMostPopularGenre(int customerId);

       

    }

}
