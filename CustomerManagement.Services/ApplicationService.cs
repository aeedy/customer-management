using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagement.Repositories.Interfaces;
using CustomerManagement.Services.Interfaces;

namespace CustomerManagement.Services
{
    public class ApplicationService : IApplicationService
    {
        IRepository<Application> _applicationRepository;

        public ApplicationService() {
            _applicationRepository = new ApplicationRepository();
        }

        public ApplicationService(IRepository<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public Application GetApplication()
        {
            return _applicationRepository.GetById(1);
        }
    }
}
