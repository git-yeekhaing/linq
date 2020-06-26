using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    // Example: We have an integer list and we need to write a LINQ query which will return all the integers which are greater than 5.
    // We are going to create a console application.
    class Program
    {
        static void Main(string[] args)
        {
            LinqQuerySyntax();

            Console.WriteLine("\n==============================");
            LinqMethodSyntax();
            Console.WriteLine("\n==============================");
            LinqMixedSyntax();
            Console.ReadKey();
        }

        private static void LinqQuerySyntax()
        {
            // data source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // linq query using query syntax
            var QuerySyntax = from obj in integerList
                              where obj > 5
                              select obj;

            // Execution
            foreach (var item in QuerySyntax)
            {
                Console.Write(item + " ");
            }
        }
    
        private static void LinqMethodSyntax()
        {
            //Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            //LINQ Query using Method Syntax
            var methodSyntax = integerList.Where(obj => obj > 5).ToList();

            // Execution
            foreach(var item in methodSyntax)
            {
                Console.Write(item + " ");
            }
        }

        private static void LinqMixedSyntax()
        {
            //Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // mixed syntax
            var mixsyntax = (from obj in integerList
                             where obj > 5
                             select obj).Sum();

            //Execution
            Console.Write("Sum Is : " + mixsyntax);
        }
    }
}