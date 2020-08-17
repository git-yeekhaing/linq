using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
   public class GroupJoinModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public static List<GroupJoinModel> GetAllEmployees()
        {
            return new List<GroupJoinModel>()
            {
                new GroupJoinModel { ID = 1, Name = "Preety", DepartmentId = 10},
                new GroupJoinModel { ID = 2, Name = "Priyanka", DepartmentId =20},
                new GroupJoinModel { ID = 3, Name = "Anurag", DepartmentId = 30},
                new GroupJoinModel { ID = 4, Name = "Pranaya", DepartmentId = 30},
                new GroupJoinModel { ID = 5, Name = "Hina", DepartmentId = 20},
                new GroupJoinModel { ID = 6, Name = "Sambit", DepartmentId = 10},
                new GroupJoinModel { ID = 7, Name = "Happy", DepartmentId = 10},
                new GroupJoinModel { ID = 8, Name = "Tarun", DepartmentId = 0},
                new GroupJoinModel { ID = 9, Name = "Santosh", DepartmentId = 10},
                new GroupJoinModel { ID = 10, Name = "Raja", DepartmentId = 20},
                new GroupJoinModel { ID = 11, Name = "Ramesh", DepartmentId = 30}
            };
        }
    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<Department> GetAllDepartments()
        {
            return new List<Department>()
                {
                    new Department { ID = 10, Name = "IT"},
                    new Department { ID = 20, Name = "HR"},
                    new Department { ID = 30, Name = "Sales"},
                };
        }
    }
}