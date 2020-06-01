using CustomerManagement.Models.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Services.Interfaces
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetCustomers();
        public Customer GetCustomerById(int id);
        public bool AddCustomer(Customer customer);
        public bool DeleteCustomer(int id);
    }
}
