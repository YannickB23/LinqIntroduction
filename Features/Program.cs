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

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;

            //zelfde add als boven, andere syntax:
            /*Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };*/

            Action<int> write = x => Console.WriteLine(x);

            write(square(add(3, 5)));

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Reggie"},
                new Employee {Id = 2, Name = "Chris"},
                new Employee {Id = 5, Name = "LeBron"}
            };

            var sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Rik"},
                new Employee {Id = 4, Name = "Bob"}
            };

            /*foreach (var employee in developers.Where(e => e.Name.Length == 6)
                .OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }*/

            //METHOD SYNTAX -> zelfde foreach als hierboven:
            /*var query = developers.Where(e => e.Name.Length == 6)
                .OrderByDescending(e => e.Name);
            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }*/

            //QUERY SYNTAX -> zelfde foreach als hierboven:
            var query2 = from developer in developers
                         where developer.Name.Length == 6
                         orderby developer.Name descending
                         select developer;
            foreach (var employee in query2)
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
            Console.ReadLine();
        }

        private static bool NameStartsWithR(Employee employee)
        {
            return employee.Name.StartsWith("R");
        }
    }
}
