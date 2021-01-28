using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Features.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            #region opsomming in console met foreach
            /*
            Employee[] developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Reggie"},
                new Employee {Id = 2, Name = "Chris"}
            };

            List<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Rick"}
            };
            
            foreach (var person in developers)
            {
                Console.WriteLine($"{person.Id} - {person.Name}");
            }

            foreach (var person in sales)
            {
                Console.WriteLine($"{person.Id} - {person.Name}");
            }
            */
            #endregion

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Reggie"},
                new Employee {Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Rik"}
            };

            foreach (var employee in developers.Where(e => e.Name.StartsWith("R")))
            {
                Console.WriteLine(employee.Name);
            }

            /*Console.WriteLine(developers.Count());
            //hard way foreach => behind the scenes => outcomment using System.Linq
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
            */
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("R");
        }
    }
}
