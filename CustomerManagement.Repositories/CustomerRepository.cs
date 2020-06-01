using CustomerManagement.Infrastructures;
using CustomerManagement.Models.Customers;
using CustomerManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private IDataManagement _dataManagement;
        public CustomerRepository()
        {
            _dataManagement = DataManagement.GetInstance();
        }

        public CustomerRepository(IDataManagement dataManagement)
        {
            _dataManagement = dataManagement;
        }
        public bool Delete(int id)
        {
            return _dataManagement.Delete(DataType.Customer, id);
        }

        public IEnumerable<Customer> Get()
        {
            var customers = new List<Customer>();
            var customerRawData = _dataManagement.GetData(DataType.Customer);
            foreach (var customerItem in customerRawData ?? new List<Dictionary<string, string>>())
            {
                var customer = customerItem.ElementAt(0).Value;

                customers.Add(new Customer() { 
                    Id = int.Parse(customerItem.ElementAt(0).Key), 
                    FirstName = customer.SplitGetStringByIndex(0), 
                    LastName = customer.SplitGetStringByIndex(1), 
                    BirthDate = customer.SplitGetDateTimeByIndex(2),
                    Gender = customer.SplitGetStringByIndex(3),
                    Age = customer.SplitGetDateTimeByIndex(2).CalculateAge()
                });
            }
            return customers;
        }

        public Customer GetById(int id)
        {
            Customer customer = null;
            var customerRawData = _dataManagement.GetData(DataType.Customer);
            foreach (var customerItem in customerRawData)
            {
                var customerId = int.Parse(customerItem.ElementAt(0).Key);
                if(customerId == id)
                {
                    var customerData = customerItem.ElementAt(0).Value;

                    customer = new Customer()
                    {
                        Id = int.Parse(customerItem.ElementAt(0).Key),
                        FirstName = customerData.SplitGetStringByIndex(0),
                        LastName = customerData.SplitGetStringByIndex(1),
                        BirthDate = customerData.SplitGetDateTimeByIndex(2),
                        Gender = customerData.SplitGetStringByIndex(3),
                        Age = customerData.SplitGetDateTimeByIndex(2).CalculateAge()
                    };

                    break;
                }
            }
            return customer;
        }

        public bool Insert(Customer entity)
        {
            var result = false;
            if(entity == null)
            {
                return result;
            }

            var customer = new Dictionary<string, string>();
            customer.Add(entity.Id.ToString(), string.Format("{0}:{1}:{2}:{3}:{4}", entity.FirstName, entity.LastName, entity.BirthDate.ToString("yyyy-MM-dd"),entity.Gender, entity.BirthDate.CalculateAge()));
            return _dataManagement.Add(DataType.Customer, customer);
        }
    }
}
