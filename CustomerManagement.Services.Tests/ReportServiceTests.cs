using CustomerManagement.Infrastructures;
using CustomerManagement.Models.Customers;
using CustomerManagement.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomerManagement.Services.Tests
{
    public class ReportServiceTests
    {
        ReportService reportService;

        [Fact]
        public void Should_Be_Instance_When_New_Object()
        {
            reportService = new ReportService();
            Assert.NotNull(reportService);

            reportService = null;
            Assert.Null(reportService);
        }

        [Fact]
        public void Should_Be_Calculate_Age_When_Get_All_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(
               new List<Customer>() {
                    new Customer() 
                    { 
                        Id = 1, FirstName = "Fake Firstname1", LastName = "Fake Lastname1", BirthDate = new DateTime(1994,01,11), Gender ="Fake Male", Age = new DateTime(1994,01,11).CalculateAge()
                    },
                     new Customer()
                    {
                        Id = 2, FirstName = "Fake Firstname2", LastName = "Fake Lastname2", BirthDate = new DateTime(1975,07,02), Gender ="Fake Male",Age = new DateTime(1975,07,02).CalculateAge()
                    },
                      new Customer()
                    {
                        Id = 3, FirstName = "Fake Firstname3", LastName = "Fake Lastname3", BirthDate = new DateTime(1987,11,04), Gender ="Fake Female", Age = new DateTime(1987,11,04).CalculateAge()
                    },
                       new Customer()
                    {
                        Id = 4, FirstName = "Fake Firstname4", LastName = "Fake Lastname4", BirthDate = new DateTime(1997,04,02), Gender ="Fake Female", Age = new DateTime(1997,04,02).CalculateAge()
                    }

               }, null);

            reportService = new ReportService(fakeCustomerRepository);
            var customers = reportService.GetCustomers().ToList();
            Assert.NotNull(customers);
            Assert.Equal(4, customers.Count());
            Assert.Equal(3, customers[2].Id);
            Assert.Equal("Fake Firstname3", customers[2].FirstName);
            Assert.Equal("1987-11-04", customers[2].BirthDate.FormatShortDate());
            Assert.Equal("Fake Female", customers[2].Gender);
            Assert.Equal(32, customers[2].Age);
        }

        [Fact]
        public void Should_Be_Show_Report_When_Get_All_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(
               new List<Customer>() {
                    new Customer()
                    {
                        Id = 1, FirstName = "Fake Firstname1", LastName = "Fake Lastname1", BirthDate = new DateTime(1994,01,11), Gender ="Fake Male", Age = new DateTime(1994,01,11).CalculateAge()
                    },
                     new Customer()
                    {
                        Id = 2, FirstName = "Fake Firstname2", LastName = "Fake Lastname2", BirthDate = new DateTime(1975,07,02), Gender ="Fake Male",Age = new DateTime(1975,07,02).CalculateAge()
                    },
                      new Customer()
                    {
                        Id = 3, FirstName = "Fake Firstname3", LastName = "Fake Lastname3", BirthDate = new DateTime(1987,11,04), Gender ="Fake Female", Age = new DateTime(1987,11,04).CalculateAge()
                    },
                       new Customer()
                    {
                        Id = 4, FirstName = "Fake Firstname4", LastName = "Fake Lastname4", BirthDate = new DateTime(1997,04,02), Gender ="Fake Female", Age = new DateTime(1997,04,02).CalculateAge()
                    }

               }, null);

            reportService = new ReportService(fakeCustomerRepository);
            Report report = reportService.ShowCustomerReport();
            Assert.NotNull(report);
            Assert.Equal(4, report.Customers.Count());
            Assert.Equal(35, report.AverageDatas.AverageAgeMale);
            Assert.Equal(27.5, report.AverageDatas.AverageAgeFemale);
            Assert.Equal(4, report.AverageDatas.Total);
            Assert.Equal(2, report.AverageDatas.TotalMale);
            Assert.Equal(2, report.AverageDatas.TotalFemale);
        }

    }
}
