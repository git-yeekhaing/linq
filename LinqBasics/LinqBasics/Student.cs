using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class Student2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<Student2> GetStudents()
        {
            List<Student2> students = new List<Student2>()
            {
                new Student2 {ID = 101, Name = "Preety" },
                new Student2 {ID = 102, Name = "Sambit" },
                new Student2 {ID = 103, Name = "Hina"},
                new Student2 {ID = 104, Name = "Anurag"},
                new Student2 {ID = 102, Name = "Sambit"},
                new Student2 {ID = 103, Name = "Hina"},
                new Student2 {ID = 101, Name = "Preety" },
            };
            return students;
        }

        public override int GetHashCode()
        {
            int IDHashCode = this.ID.GetHashCode();

            int NameHashCode = this.Name == null ? 0 : this.Name.GetHashCode();

            return IDHashCode ^ NameHashCode;
        }

        public override bool Equals(object obj)
        {
            return this.ID == ((Student2)obj).ID &&
                this.Name == ((Student2)obj).Name;
        }
    }
}
