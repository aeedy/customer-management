using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CustomerManagement.Infrastructures
{ 
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
