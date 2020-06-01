using CustomerManagement.Models.Customers;
using CustomerManagement.Repositories;
using CustomerManagement.Repositories.Interfaces;
using CustomerManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Services
{
    public class CustomerService : ICustomerService
    {
        IRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.Delete(id);
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.Insert(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.Get();
        }
    }
}
