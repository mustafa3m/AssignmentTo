using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentTo;  // For CustomerRepository and ICustomerRepository
using AssignmentTo.Models;  // For Customer model


namespace AssignmentTo.Models
{
    // Customer model class
    public class Customer
    {
        // Properties
        public int CustomerId { get; set; }// Property for the CustomerId
        public string FirstName { get; set; }// Property for the FirstName
        public string LastName { get; set; }// Property for the LastName
        public string Country { get; set; }// Property for the Country
        public string PostalCode { get; set; }// Property for the PostalCode
        public string Phone { get; set; }// Property for the Phone
        public string Email { get; set; }// Property for the Email
    }

}
