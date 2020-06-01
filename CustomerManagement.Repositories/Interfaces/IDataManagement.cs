using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Repositories.Interfaces
{
    public interface IDataManagement
    {
        List<Dictionary<string, string>> GetData(DataType dataType);

        bool Add(DataType dataType, Dictionary<string, string> entity);

        bool Delete(DataType dataType, int id);
    }
}
