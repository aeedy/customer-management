using CustomerManagement.Infrastructures;
using CustomerManagement.Models;
using CustomerManagement.Models.Customers;
using CustomerManagement.Models.Reports;
using CustomerManagement.Services;
using CustomerManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CustomerManagement.ConsoleApp
{
    class Program
    {
        private static IApplicationService applicationService;
        private static ICustomerService customerService;
        private static IReportService reportService;
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            applicationService = new ApplicationService();
            customerService = new CustomerService();
            reportService = new ReportService(); 

            var application = applicationService.GetApplication();

            Console.WriteLine("Application Name: {0}", application.Name);
            RenderMenu(application.Menus);

            var showMenu = true;
            while (showMenu)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        RenderMenu(application.Menus);
                        showMenu = true;
                        break;
                    case "1":
                        RenderCustomer(customerService.GetCustomers());
                        showMenu = true;
                        break;
                    case "2":
                        RenderAddCustomer();
                        showMenu = true;
                        break;
                    case "3":
                        RenderDeleteCustomer();
                        showMenu = true;
                        break;
                    case "4":
                        RenderReport(reportService.ShowCustomerReport());
                        showMenu = true;
                        break;
                    case "5":
                        Console.WriteLine("Good bye!!!");
                        showMenu = false;
                        break;
                    default:
                        RenderFillMenu();
                        showMenu = true;
                        break;
                }
            }
        }

        static void RenderMenu(List<Menu> menus)
        {
            Console.WriteLine("===== List Menu =====");
            foreach (var item in menus)
            {
                Console.WriteLine("Press {0} : {1}", item.Id, item.Name);
            }
            RenderFillMenu();
        }

        static void RenderCustomer(IEnumerable<Customer> customers)
        {
            Console.WriteLine("================= List Customer=====================");
            Console.WriteLine("Id : Name          : Gender   : Birth Date  : Age");
            Console.WriteLine("====================================================");
            foreach (var item in customers)
            {
                int _age = item.BirthDate.CalculateAge();
                Console.WriteLine("{0} : {1} {2}  : {3}   : {4} : {5}", item.Id, item.FirstName, item.LastName, item.Gender, item.BirthDate.FormatShortDate(), _age);
            }
            RenderFillMenu();
        }

        static void RenderReport(Report report)
        {
            Console.WriteLine("================= Report =====================");
            Console.WriteLine("Id : Name          : Gender   : Birth Date  : Age");
            Console.WriteLine("====================================================");
            foreach (Customer customer in report.Customers)
            {
                int _age = customer.BirthDate.CalculateAge();
                Console.WriteLine("{0} : {1} {2}  : {3}   : {4} : {5}", customer.Id, customer.FirstName, customer.LastName, customer.Gender, customer.BirthDate.FormatShortDate(), customer.Age);
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("Summary \t Total: {0} \t Average Male Age: {1} \t Average Femal Age: {2}", report.AverageDatas.Total, report.AverageDatas.AverageAgeMale, report.AverageDatas.AverageAgeFemale);
            Console.WriteLine("Total Male: {0} \t Total Female: {1}", report.AverageDatas.TotalMale, report.AverageDatas.TotalFemale);

            RenderFillMenu();
        }

        static void RenderAddCustomer()
        {
            try
            {
                var customer = new Customer();
                Console.WriteLine("===== Add new Customer =====");
                Console.Write("Enter Id: ");
                customer.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Firstname: ");
                customer.FirstName = Console.ReadLine();

                Console.Write("Enter Lastname: ");
                customer.LastName = Console.ReadLine();

                Console.Write("Enter Gender ex. Male or Female: ");
                customer.Gender = Console.ReadLine();

                Console.Write("Enter Birthdate ex. 2020-05-31: ");
                var birthdate = Console.ReadLine();
                customer.BirthDate = birthdate.ToString().StringToDateTime();

                customer.Age = customer.BirthDate.CalculateAge();

                if (customerService.AddCustomer(customer))
                {
                    Console.WriteLine("Customer was add.");
                }
                else
                {
                    Console.WriteLine("Customer was not add.");
                }

                RenderFillMenu();
            }
            catch(Exception e)
            {
                Console.WriteLine("Cannot add -incorrect input format.");
                RenderFillMenu();
            }
        }

        static void RenderDeleteCustomer()
        {
            try
            {
                Console.WriteLine("===== Delete Customer =====");
                Console.Write("Enter Id: ");
                var customerId = int.Parse(Console.ReadLine());

                if (customerService.DeleteCustomer(customerId))
                {
                    Console.WriteLine("Customer was delete.");
                }
                else
                {
                    Console.WriteLine("Customer was not delete.");
                }

                RenderFillMenu();
            }
            catch(Exception e)
            {
                Console.WriteLine("Cannot deltete -incorrect input format.");
                RenderFillMenu();
            }
        }

        static void RenderFillMenu()
        {
            Console.Write("Enter your menu: ");
        }
    }
}
