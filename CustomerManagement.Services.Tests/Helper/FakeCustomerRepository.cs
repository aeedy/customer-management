using CustomerManagement.Models.Customers;
using CustomerManagement.Repositories.Interfaces;
using System.Collections.Generic;

namespace CustomerManagement.Services.Tests
{
    public class FakeCustomerRepository : IRepository<Customer>
    {
        private IEnumerable<Customer> _customers;
        private Customer _customer;
        private bool _result;

        public FakeCustomerRepository(IEnumerable<Customer> customers, Customer customer, bool result = false)
        {
            _customers = customers;
            _customer = customer;
            _result = result;
        }
        public bool Delete(int id)
        {
            return _result;
        }

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public Customer GetById(int id)
        {
            return _customer;
        }

        public bool Insert(Customer entity)
        {
            return _result;
        }
    }
}
