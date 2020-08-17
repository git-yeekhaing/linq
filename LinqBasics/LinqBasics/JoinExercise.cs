using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class JoinExercise
    {
        public static void Exercise1()
        {
            // method syntax
            var MS = EmployeeData.GetAllEmployees()
                .Join(Address.GetAllAddresses(),
                 emp => emp.AddressId,
                 addr => addr.ID,
                 (emp, addr) => new
                 {
                     EmployeeName = emp.Name,
                     AddressLine = addr.AddressLine
                 }).ToList();

            foreach (var employee in MS)
            {
                Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
            }

            Console.WriteLine("====================");
        }

        public static void Exercise2()
        {
            var QS = (from emp in EmployeeData.GetAllEmployees()
                      join
                      addr in Address.GetAllAddresses()
                      on emp.AddressId equals addr.ID
                      select new
                      {
                          EmployeeName = emp.Name,
                          AddressLine = addr.AddressLine
                      }).ToList();

            foreach (var emp in QS)
            {
                Console.WriteLine($"Name :{emp.EmployeeName}, Address : {emp.AddressLine}");
            }

            Console.WriteLine("====================");
        }

        public static void Exercise3()
        {
            var MS = Department.GetAllDepartments()
                .GroupJoin(
                  GroupJoinModel.GetAllEmployees(),
                  dept => dept.ID,
                  emp => emp.DepartmentId,
                  (dept, emp) => new {dept, emp});

            foreach (var item in MS)
            {
                Console.WriteLine("Department :" + item.dept.Name);
                //Inner Foreach loop for each employee of a department
                foreach (var employee in item.emp)
                {
                    Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
                }
            }

            Console.WriteLine("====================");
        }

        public static void Exercise4()
        {
            var QS = from dept in Department.GetAllDepartments()
                     join emp in GroupJoinModel.GetAllEmployees()
                     on dept.ID equals emp.DepartmentId
                     into EmpGrp
                     select new { dept, EmpGrp };

            foreach (var item in QS)
            {
                Console.WriteLine("Department :" + item.dept.Name);

                foreach (var emp in item.EmpGrp)
                {
                    Console.WriteLine(" EmployeeID : " + emp.ID + 
                        " , Name : " + emp.Name);
                }
            }

            Console.WriteLine("====================");
        }

        public static void Exercise5()
        {
            var QS = from emp in EmployeeData.GetAllEmployees()
                     join add in Address.GetAllAddresses()
                     on emp.AddressId equals add.ID
                     into EmpAddrGrp
                     from address in EmpAddrGrp.DefaultIfEmpty()
                     select new { emp, address };

        }
    }
}
