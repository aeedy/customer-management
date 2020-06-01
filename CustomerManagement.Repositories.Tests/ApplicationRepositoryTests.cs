using System;
using System.Linq;
using Xunit;

namespace CustomerManagement.Repositories.Tests
{
    public class ApplicationRepositoryTests
    {
        ApplicationRepository appliationRepository;

        [Fact]
        public void Should_Be_Instance_When_New_Object()
        {
            appliationRepository = new ApplicationRepository();
            Assert.NotNull(appliationRepository);

            appliationRepository = null;
            Assert.Null(appliationRepository);
        }

        [Fact]
        public void Should_Application_When_Get_Application_By_Id()
        {
            appliationRepository = new ApplicationRepository(new FakeDataManagement());
            var application = appliationRepository.GetById(1);

            Assert.Equal("Fake Customer Management Application", application.Name);
            Assert.Equal(5, application.Menus.Count);
            Assert.True(application?.Menus?.Any(x => x.Name.Equals("Fake Delete")) ?? false);
        }

        [Fact]
        public void Should_List_Application_When_Get_All_Application()
        {
            appliationRepository = new ApplicationRepository(new FakeDataManagement());
            var applications = appliationRepository.Get();
            var application = applications.FirstOrDefault();

            Assert.NotNull(applications);
            Assert.Equal("Fake Customer Management Application", application.Name);
            Assert.Equal(5, application.Menus.Count);
            Assert.True(application?.Menus?.Any(x => x.Name.Equals("Fake Delete")) ?? false);
        }

        [Fact]
        public void Should_Blank_List_Application_When_No_Data_From_Get_All_Application()
        {
            appliationRepository = new ApplicationRepository(new FakeDataManagement() { isSkipLoadData = true });
            var applications = appliationRepository.Get();

            Assert.NotNull(applications);
            Assert.Equal(0, applications?.Count() ?? 0);
        }

        [Fact]
        public void Should_NotImplementedException_When_Delete()
        {
            appliationRepository = new ApplicationRepository();
            Assert.Throws<NotImplementedException>(() => appliationRepository.Delete(999));
        }

        [Fact]
        public void Should_NotImplementedException_When_Add()
        {
            appliationRepository = new ApplicationRepository();
            Assert.Throws<NotImplementedException>(() => appliationRepository.Insert(null));
        }
    }
}
