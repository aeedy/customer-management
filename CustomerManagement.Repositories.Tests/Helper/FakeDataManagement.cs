using CustomerManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Repositories.Tests
{
    public class FakeDataManagement : IDataManagement
    {
        public bool isSkipLoadData{ get; set; }
        public bool forceResult { get; set; }

        public List<Dictionary<string, string>> GetData(DataType dataType)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            switch (dataType)
            {
                case DataType.Menu:
                    result = DataMenu();
                    break;
                case DataType.Application:
                    result = DataApplication();
                    break;
                case DataType.Customer:
                    result = DataCustomer();
                    break;
            }
            return result;
        }

        private List<Dictionary<string, string>> DataApplication()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(BuildData("1", "Fake Customer Management Application"));
            return isSkipLoadData ? null : result;
        }

        private List<Dictionary<string, string>> DataMenu()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(BuildData("1", "Fake List"));
            result.Add(BuildData("2", "Fake Add"));
            result.Add(BuildData("3", "Fake Delete"));
            result.Add(BuildData("4", "Fake Report"));
            result.Add(BuildData("5", "Fake Quit"));
            return isSkipLoadData ? null : result;
        }

        private List<Dictionary<string, string>> DataCustomer()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(BuildData("1", "FakeA:FakeB:2010-01-01:Male"));
            result.Add(BuildData("2", "FakeC:FakeD:2009-01-01:Female"));
            return isSkipLoadData ? null : result;
        }

        private Dictionary<string, string> BuildData(string id, string name)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(id, name);
            return data;
        }

        public bool Add(DataType dataType, Dictionary<string, string> entity)
        {
            var result = false;
            if (entity == null)
            {
                return result;
            }

            if(dataType.Equals(DataType.Customer))
            {
                result = true;
            }
            return result;
        }

        public bool Delete(DataType dataType, int id)
        {
            return forceResult;
        }
    }
}
