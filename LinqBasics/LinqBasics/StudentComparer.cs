using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class StudentComparer : IEqualityComparer<Student2>
    {
        public bool Equals(Student2 x, Student2 y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (object.ReferenceEquals(x, null) || 
                object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode(Student2 obj)
        {
            if (obj == null) 
            {
                return 0;
            }

            int IDHashCode = obj.ID.GetHashCode();

            int NameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();

            return IDHashCode ^ NameHashCode;
        }

        
    }
    
}
