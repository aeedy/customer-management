using CustomerManagement.Models.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Models.Reports
{
    public class Report
    {
        public List<Customer> Customers { get; set; }
        public AverageData AverageDatas { get; set; }
    }
}
