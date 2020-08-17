using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class EmployeeData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public static List<EmployeeData> GetAllEmployees()
        {
            return new List<EmployeeData>()
            {
                new EmployeeData { ID = 1, Name = "Preety", AddressId = 1 },
                new EmployeeData { ID = 2, Name = "Priyanka", AddressId = 2 },
                new EmployeeData { ID = 3, Name = "Anurag", AddressId = 3 },
                new EmployeeData { ID = 4, Name = "Pranaya", AddressId = 4 },
                new EmployeeData { ID = 5, Name = "Hina", AddressId = 5 },
                new EmployeeData { ID = 6, Name = "Sambit", AddressId = 6 },
                new EmployeeData { ID = 7, Name = "Happy", AddressId = 7},
                new EmployeeData { ID = 8, Name = "Tarun", AddressId = 8 },
                new EmployeeData { ID = 9, Name = "Santosh", AddressId = 9 },
                new EmployeeData { ID = 10, Name = "Raja", AddressId = 10},
                new EmployeeData { ID = 11, Name = "Sudhanshu", AddressId = 11}
            };
        }
    }

    public class Address
    {
        public int ID { get; set; }
        public string AddressLine { get; set; }
        public static List<Address> GetAllAddresses()
        {
            return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1"},
                new Address { ID = 2, AddressLine = "AddressLine2"},
                new Address { ID = 3, AddressLine = "AddressLine3"},
                new Address { ID = 4, AddressLine = "AddressLine4"},
                new Address { ID = 5, AddressLine = "AddressLine5"},
                new Address { ID = 9, AddressLine = "AddressLine9"},
                new Address { ID = 10, AddressLine = "AddressLine10"},
                new Address { ID = 11, AddressLine = "AddressLine11"},
            };
        }
    }
}

