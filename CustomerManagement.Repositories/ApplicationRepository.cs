using CustomerManagement.Models;
using CustomerManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        private IDataManagement _dataManagement;
        public ApplicationRepository()
        {
            _dataManagement = DataManagement.GetInstance();
        }

        public ApplicationRepository(IDataManagement dataManagement)
        {
            _dataManagement = dataManagement;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Application> Get()
        {
            var applicationData = new List<Application>();
            var applicationRawData = _dataManagement.GetData(DataType.Application);
            var menuRawData = _dataManagement.GetData(DataType.Menu);
            foreach (var appItem in applicationRawData ?? new List<Dictionary<string, string>>())
            {
                var menus = new List<Menu>();
                foreach (var menuItem in menuRawData)
                {
                    menus.Add(new Menu() { Id = int.Parse(menuItem.ElementAt(0).Key), Name = menuItem.ElementAt(0).Value });
                }
                applicationData.Add(new Application() { Id = int.Parse(appItem.ElementAt(0).Key), Name = appItem.ElementAt(0).Value, Menus = menus });
            }

            return applicationData;
        }

        public Application GetById(int id)
        {
            var applicationData = new Application();
            var applicationRawData = _dataManagement.GetData(DataType.Application);
            var menuRawData = _dataManagement.GetData(DataType.Menu);
            foreach (var appItem in applicationRawData)
            {
                var appId = int.Parse(appItem.ElementAt(0).Key);
                if(appId == id)
                {
                    var menus = new List<Menu>();
                    foreach (var menuItem in menuRawData)
                    {
                        menus.Add(new Menu() { Id = int.Parse(menuItem.ElementAt(0).Key), Name = menuItem.ElementAt(0).Value });
                    }
                    applicationData = new Application() { Id = int.Parse(appItem.ElementAt(0).Key), Name = appItem.ElementAt(0).Value, Menus = menus };
                    break;
                }
            }

            return applicationData;
        }

        public bool Insert(Application entity)
        {
            throw new NotImplementedException();
        }
    }
}
