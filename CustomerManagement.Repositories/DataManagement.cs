using CustomerManagement.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement.Repositories
{
    public enum DataType
    {
        Menu,
        Application,
        Customer
    }

    public class DataManagement : IDataManagement
    {
        private static DataManagement instance;
        private List<Dictionary<string, string>> applicationRawData;
        private List<Dictionary<string, string>> applicationRawMenu;
        private List<Dictionary<string, string>> applicationRawCustomer;

        private DataManagement() { }

        public static DataManagement GetInstance()
        {
            if (instance == null)
            {
                instance = new DataManagement();
                instance.applicationRawData = instance.DataApplication();
                instance.applicationRawMenu = instance.DataMenu();
                instance.applicationRawCustomer = instance.DataCustomer();
            }

            return instance;
        }

        public List<Dictionary<string, string>> GetData(DataType dataType)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            switch (dataType)
            {
                case DataType.Menu:
                    result = applicationRawMenu;
                    break;
                case DataType.Application:
                    result = applicationRawData;
                    break;
                case DataType.Customer:
                    result = applicationRawCustomer;
                    break;
            }
            return result;
        }

        private List<Dictionary<string, string>> DataApplication()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(BuildData("1", "Customer Management Application"));
            return result;
        }

        private List<Dictionary<string, string>> DataMenu()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(BuildData("0", "Help"));
            result.Add(BuildData("1", "List"));
            result.Add(BuildData("2", "Add"));
            result.Add(BuildData("3", "Delete"));
            result.Add(BuildData("4", "Report"));
            result.Add(BuildData("5", "Quit"));
            return result;
        }

        private List<Dictionary<string, string>> DataCustomer()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            result.Add(BuildData("1", "Ngoc :Nguyen :1994-01-11:Male"));
            result.Add(BuildData("2", "Somsak :Bosawa:1975-07-02:Male"));
            result.Add(BuildData("3", "Aliya :Golden:1987-11-04:Female"));
            result.Add(BuildData("4", "Saniya :Holland:1997-04-02:Female"));
            return result;
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

            if (dataType.Equals(DataType.Customer))
            {
                instance.applicationRawCustomer.Add(entity);
                result = true;
            }

            return result;
        }

        public bool Delete(DataType dataType, int id)
        {
            var result = false;
            var isFound = false;
            var index = 0;
            if (dataType.Equals(DataType.Customer))
            {
                foreach (var item in instance.applicationRawCustomer)
                {
                    if(item.ElementAt(0).Key.Equals(id.ToString()))
                    {
                        isFound = true;
                        break;
                    }
                    index++;
                }

                if(isFound)
                {
                    instance.applicationRawCustomer.RemoveAt(index);
                    result = true;
                }
            }

            return result;
        }
    }
}
