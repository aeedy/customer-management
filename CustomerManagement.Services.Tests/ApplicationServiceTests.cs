using CustomerManagement.Models;
using System;
using Xunit;

namespace CustomerManagement.Services.Tests
{
    public class ApplicationServiceTests
    {
        ApplicationService appliationService;

        [Fact]
        public void Should_Be_Instance_When_New_Object()
        {
            appliationService = new ApplicationService();
            Assert.NotNull(appliationService);

            appliationService = null;
            Assert.Null(appliationService);
        }

        [Fact]
        public void Should_Application_When_Get_Application()
        {
            var fakeApplicationRepository = new FakeApplicationRepository(null, new Application() { Id = 1, Name = "Fake Application" });
            appliationService = new ApplicationService(fakeApplicationRepository);

            var application = appliationService.GetApplication();

            Assert.Equal(1, application.Id);
            Assert.Equal("Fake Application", application.Name);

        }
    }
}
