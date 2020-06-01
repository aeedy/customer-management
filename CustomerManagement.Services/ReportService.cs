using CustomerManagement.Models.Customers;
using CustomerManagement.Models.Reports;
using CustomerManagement.Repositories;
using CustomerManagement.Repositories.Interfaces;
using CustomerManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagement.Services
{
    public class ReportService : IReportService
    {
        IRepository<Customer> _customerRepository;

        public ReportService()
        {
            _customerRepository = new CustomerRepository();
        }

        public ReportService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Report ShowCustomerReport()
        {
            List<Customer> customers = new List<Customer>();
            customers = GetCustomers().ToList();
            List<double> averageAgeGroupByGenders =  GetListCustomerAverageAgeGroupByGender(customers);
            List<int> customerGroupByGenders = GetListCustomerGroupByGender(customers);
            int total = GetTotalCustomer(customers);
            return new Report()
            {
                Customers = customers,
                AverageDatas = new AverageData()
                {
                    AverageAgeMale = averageAgeGroupByGenders[0],
                    AverageAgeFemale = averageAgeGroupByGenders[1],
                    Total = total,
                    TotalMale = customerGroupByGenders[0],
                    TotalFemale = customerGroupByGenders[1]
                }
            };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.Get();
        }

        private List<double> GetListCustomerAverageAgeGroupByGender(List<Customer> customers)
        {
            return customers.GroupBy(c => c.Gender).Select(c => c.Average(k => k.Age)).ToList();
        }

        private List<int> GetListCustomerGroupByGender(List<Customer> customers)
        {
            return customers.GroupBy(c => c.Gender).Select(c => c.Count()).ToList();
        }

        private int GetTotalCustomer(List<Customer> customers)
        {
            return customers.Count;
        }
    }
}
