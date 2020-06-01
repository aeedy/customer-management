using CustomerManagement.Models;
using CustomerManagement.Repositories.Interfaces;
using System.Collections.Generic;

namespace CustomerManagement.Services.Tests
{
    public class FakeApplicationRepository : IRepository<Application>
    {
        private IEnumerable<Application> _applications;
        private Application _application;

        public FakeApplicationRepository(IEnumerable<Application> applications, Application applcation)
        {
            _applications = applications;
            _application = applcation;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Application> Get()
        {
            return _applications;
        }

        public Application GetById(int id)
        {
            return _application;
        }

        public bool Insert(Application entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
