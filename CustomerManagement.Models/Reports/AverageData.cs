using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Models.Reports
{
    public class AverageData
    {
        public int Total { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
        public double AverageAge { get; set; }
        public double AverageAgeMale { get; set; }
        public double AverageAgeFemale { get; set; }
    }
}
