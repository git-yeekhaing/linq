using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class OrderbyStudent
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public static List<OrderbyStudent> GetAllStudents()
        {
            List<OrderbyStudent> listStudents = new List<OrderbyStudent>()
            {
                new OrderbyStudent{ID= 101,FirstName = "Preety",LastName = "Tiwary",Branch = "CSE"},
                new OrderbyStudent{ID= 102,FirstName = "Preety",LastName = "Agrawal",Branch = "ETC"},
                new OrderbyStudent{ID= 103,FirstName = "Priyanka",LastName = "Dewangan",Branch = "ETC"},
                new OrderbyStudent{ID= 104,FirstName = "Hina",LastName = "Sharma",Branch = "ETC"},
                new OrderbyStudent{ID= 105,FirstName = "Anugrag",LastName = "Mohanty",Branch = "CSE"},
                new OrderbyStudent{ID= 106,FirstName = "Anurag",LastName = "Sharma",Branch = "CSE"},
                new OrderbyStudent{ID= 107,FirstName = "Pranaya",LastName = "Kumar",Branch = "CSE"},
                new OrderbyStudent{ID= 108,FirstName = "Manoj",LastName = "Kumar",Branch = "ETC"},
                new OrderbyStudent{ID= 109,FirstName = "Pranaya",LastName = "Rout",Branch = "ETC"},
                new OrderbyStudent{ID= 110,FirstName = "Saurav",LastName = "Rout",Branch = "CSE"}
            };
            return listStudents;
        }
    }
}
