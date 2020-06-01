using CustomerManagement.Models;
using CustomerManagement.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CustomerManagement.Services.Tests
{
    public class CustomerServiceTests
    {
        CustomerService customerService;

        [Fact]
        public void Should_Be_Instance_When_New_Object()
        {
            customerService = new CustomerService();
            Assert.NotNull(customerService);

            customerService = null;
            Assert.Null(customerService);
        }

        [Fact]
        public void Should_List_Customer_When_Get_All_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(
                new List<Customer>() {
                    new Customer() { Id = 1, FirstName = "Fake Firstname", LastName = "Fake Lastname", BirthDate = DateTime.MinValue, Gender ="Fake Male" }
                }, null);
            customerService = new CustomerService(fakeCustomerRepository);

            var customers = customerService.GetCustomers();

            var customer = customers.FirstOrDefault();
            Assert.NotNull(customers);
            Assert.Equal(1, customers?.Count() ?? 0);
            Assert.Equal("Fake Firstname", customer.FirstName);
            Assert.Equal("Fake Lastname", customer.LastName);
            Assert.Equal(DateTime.MinValue, customer.BirthDate);
            Assert.Equal("Fake Male", customer.Gender);
        }

        [Fact]
        public void Should_Blank_List_Customer_When_No_Data_From_Get_All_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(new List<Customer>(), null);
            customerService = new CustomerService(fakeCustomerRepository);

            var customers = customerService.GetCustomers();

            Assert.NotNull(customers);
            Assert.Equal(0, customers?.Count() ?? 0);
        }

        [Fact]
        public void Should_Customer_When_Get_Customer_By_Id()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(null, new Customer() { Id = 999 });
            customerService = new CustomerService(fakeCustomerRepository);

            var customer = customerService.GetCustomerById(999);

            Assert.NotNull(customer);
            Assert.Equal(999, customer.Id);
        }

        [Fact]
        public void Should_Null_Customer_When_No_Data_From_Get_Customer_By_Id()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(null, null);
            customerService = new CustomerService(fakeCustomerRepository);

            var customer = customerService.GetCustomerById(999);

            Assert.Null(customer);
        }

        [Fact]
        public void Should_False_When_Incorrect_Add_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(null, null);
            customerService = new CustomerService(fakeCustomerRepository);

            var customer = customerService.AddCustomer(null);

            Assert.False(customer);
        }

        [Fact]
        public void Should_True_When_Correct_Add_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(null, null, true);
            customerService = new CustomerService(fakeCustomerRepository);

            var customer = customerService.AddCustomer(null);

            Assert.True(customer);
        }

        [Fact]
        public void Should_False_When_Incorrect_Delete_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(null, null);
            customerService = new CustomerService(fakeCustomerRepository);

            var customer = customerService.DeleteCustomer(999);

            Assert.False(customer);
        }

        [Fact]
        public void Should_True_When_Incorrect_Delete_Customer()
        {
            var fakeCustomerRepository = new FakeCustomerRepository(null, null, true);
            customerService = new CustomerService(fakeCustomerRepository);

            var customer = customerService.DeleteCustomer(999);

            Assert.True(customer);
        }
    }
}
