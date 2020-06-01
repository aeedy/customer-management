using CustomerManagement.Models.Customers;
using CustomerManagement.Models.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<Customer> GetCustomers();
        Report ShowCustomerReport();
    }
}
