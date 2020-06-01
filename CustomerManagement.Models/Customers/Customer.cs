using System;

namespace CustomerManagement.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
