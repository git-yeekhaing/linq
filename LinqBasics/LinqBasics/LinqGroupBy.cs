using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class LinqGroupBy
    {
        public static void Example1()
        {
            // method syntax
            var MS = GroupByStudent.GetStudents().GroupBy(s => s.Branch);

            // query syntax
            IEnumerable<IGrouping<string, GroupByStudent>> QS = (from std in GroupByStudent.GetStudents()
                                                                 group std by std.Branch);

            //It will iterate through each groups
            foreach (var group in MS)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
                //Iterate through each student of a group
                foreach (var student in group)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
                }
            }

            Console.WriteLine("============Finish============");
        }

        // Example:In the following example, we get the employees by Gender.
        // But here we first sort the data by Gender in descending order and
        // then sort the student by their name in ascending order.

        public static void Example2()
        {
            // method syntax
            var MS = GroupByStudent.GetStudents().GroupBy(s => s.Gender)
                .OrderByDescending(c => c.Key)
                .Select(std => new
                {
                    Key = std.Key,
                    GroupByStudent = std.OrderBy(x => x.Name)
                });

            // query syntax
            var QS = from std in GroupByStudent.GetStudents()
                     group std by std.Gender into stdGroup
                     orderby stdGroup.Key descending
                     select new
                     {
                         Key = stdGroup.Key,
                         GroupByStudent = stdGroup.OrderBy(x => x.Name)
                     };

            //It will iterate through each groups
            foreach (var group in QS)
            {
                Console.WriteLine(group.Key + " : " + group.GroupByStudent.Count());
                //Iterate through each student of a group
                foreach (var student in group.GroupByStudent)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Branch);
                }
            }

            Console.WriteLine("============Finish=============");
        }
      
        //Example: The following example group the students first by Branch and then by Gender.
        //The student groups first sorted by Branch in descending order and then by Gender in ascending order.
        //Finally, the students in each group are sorted by their names in ascending order. 
        public static void Example3()
        {
            // query method
            var QS = from std in GroupByStudent.GetStudents()
                     group std by new { std.Branch, std.Gender } into stdGrp
                     orderby stdGrp.Key.Branch descending,
                     stdGrp.Key.Gender ascending
                     select new
                     {
                         Branch = stdGrp.Key.Branch,
                         Gender = stdGrp.Key.Gender,
                         Students = stdGrp.OrderBy(x => x.Name)
                     };

            var MS = GroupByStudent.GetStudents()
                    .GroupBy(x => new { x.Branch, x.Gender })
                    .OrderByDescending(g => g.Key.Branch).ThenBy(g => g.Key.Gender)
                    .Select(g => new
                    {
                        Branch = g.Key.Branch,
                        Gender = g.Key.Gender,
                        GroupByStudent = g.OrderBy(x => x.Name)
                    });

            foreach(var grp in QS)
            {
                Console.WriteLine($"Barnch : {grp.Branch} Gender: {grp.Gender} No of Students = {grp.Students.Count()}");

                foreach (var std in grp.Students)
                {
                    Console.WriteLine($"  ID: {std.ID}, Name: {std.Name}, Age: {std.Age} ");
                }
                Console.WriteLine();
            }
        }
    }
}