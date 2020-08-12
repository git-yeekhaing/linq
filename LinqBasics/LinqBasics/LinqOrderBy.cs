using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqOrderBy
    {
        public static void Example1()
        {
            List<int> intList = new List<int>() { 10, 45, 35, 29, 100, 69, 58, 50 };

            Console.WriteLine("Before Sorting : ");
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }

            // use method syntax
            var MS = intList.OrderBy(num => num);

            // use query syntax
            var QS = (from num in intList
                      orderby num
                      select num).ToList();

            Console.WriteLine();
            Console.WriteLine("After Sorting : ");
            foreach (var item in QS)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n=========Finish=========");
        }

        public static void ComplexOrderByEg1()
        {
            // use method syntax
            var MS = OrderbyStudent.GetAllStudents().OrderBy(x => x.Branch).ToList();

            // use query syntax
            var QS = (from std in OrderbyStudent.GetAllStudents()
                      orderby std.Branch
                      select std);

            foreach (var student in MS)
            {
                Console.WriteLine(" Branch: " + student.Branch + ", Name :" + student.FirstName + " " + student.LastName);
            }
            Console.WriteLine("\n=========Finish=========");
        }

        public static void ComplexOrderByEg2()
        {
            // method syntax
            var MS = OrderbyStudent.GetAllStudents()
                .Where(std => std.Branch.ToUpper() == "CSE")
                .OrderBy(x => x.FirstName).ToList();

            // query syntax
            var QS = (from std in OrderbyStudent.GetAllStudents()
                      where std.Branch.ToUpper() == "CSE"
                      orderby std.FirstName
                      select std);

            foreach (var student in QS)
            {
                Console.WriteLine(" Branch: " + student.Branch + ", Name :" + student.FirstName + " " + student.LastName);
            }

            Console.WriteLine("\n=========Finish=========");
        }

        public static void LinqThenBy()
        {
            // use method syntax
            var MS = OrderbyStudent.GetAllStudents()
                .OrderBy(x => x.FirstName)
                .ThenBy(y => y.LastName)
                .ToList();

            foreach (var student in MS)
            {
                Console.WriteLine("First Name :" + student.FirstName + ", Last Name : " + student.LastName);
            }

            // use query syntax
            var QS = (from std in OrderbyStudent.GetAllStudents()
                      orderby std.FirstName, std.LastName
                      select std);


            Console.WriteLine("\n=========Finish=========");
        }
    }
}
