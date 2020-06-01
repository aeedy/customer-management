using CustomerManagement.Models.Customers;
using System;
using System.Linq;
using Xunit;

namespace CustomerManagement.Repositories.Tests
{
    public class CustomerRepositoryTests
    {
        CustomerRepository customerRepository;

        [Fact]
        public void Should_Be_Instance_When_New_Object()
        {
            customerRepository = new CustomerRepository();
            Assert.NotNull(customerRepository);

            customerRepository = null;
            Assert.Null(customerRepository);
        }

        [Fact]
        public void Should_List_Customer_When_Get_All_Customer()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement());
            var customers = customerRepository.Get();

            Assert.NotNull(customers);
            Assert.Equal(2, customers.Count());
        }

        [Fact]
        public void Should_Blank_List_Customer_When_No_Data_From_Get_All_Customer()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement() { isSkipLoadData = true });
            var customers = customerRepository.Get();

            Assert.NotNull(customers);
            Assert.Equal(0, customers?.Count() ?? 0);
        }

        [Fact]
        public void Should_Customer_When_Get_Customer_By_Id()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement());
            var customer = customerRepository.GetById(1);

            Assert.NotNull(customer);
            Assert.Equal("FakeA", customer.FirstName);
            Assert.Equal("FakeB", customer.LastName);
            Assert.Equal(new DateTime(2010, 01, 01), customer.BirthDate);
            Assert.Equal("Male", customer.Gender);
        }

        [Fact]
        public void Should_Null_Customer_When_Incorrect_Id_To_Get_Customer_By_Id()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement());
            var customer = customerRepository.GetById(999);

            Assert.Null(customer);
        }

        [Fact]
        public void Should_True_When_Correct_Insert_Customer()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement());
            var customer = customerRepository.Insert(new Customer() { Id = 999, FirstName = "TEST", LastName = "TEST", BirthDate = DateTime.Now, Gender = "Male" });

            Assert.True(customer);
        }

        [Fact]
        public void Should_False_When_Incorrect_Insert_Customer()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement());
            var customer = customerRepository.Insert(null);

            Assert.False(customer);
        }

        [Fact]
        public void Should_True_When_Correct_Delete_Customer()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement() { forceResult = true });
            var customer = customerRepository.Delete(1);

            Assert.True(customer);
        }

        [Fact]
        public void Should_False_When_Correct_Delete_Customer()
        {
            customerRepository = new CustomerRepository(new FakeDataManagement() { forceResult = false });
            var customer = customerRepository.Delete(1);

            Assert.False(customer);
        }
    }
}
