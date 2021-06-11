using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operators_in_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //join
            //inner join
            // Inner join is used to return only the matched records or elements
            // from the collections based on the specified conditions.

            //create object of department
            List<Department> dep = new List<Department>()
        {
            new Department(){dname = "chemistry"  ,did = 1},
          new Department(){dname = "physics"  ,did = 2},
            new Department(){dname = "maths"  ,did = 3},
              new Department(){dname = "english"  ,did = 4},
        };



            //create object of Employee
            List<Employee> emp = new List<Employee>()
        {
            new Employee(){ename = "Ravi"  ,eid = 1},
          new Employee(){ename = "Pawan"  ,eid = 2},
          new Employee(){ename = "ankit"  ,eid = 3},
          new Employee(){ename = "samay"  ,eid = 4},
        };

            //using query to fetch info from employee name with his department
            var res1 = from d in dep
                        join e in emp on d.did equals e.eid
                        select new
                        {
                            Employeename = e.ename,
                            Departmentname = d.dname
                        };
            //access using foreach loop
            foreach (var i in res1)
            {
                Console.WriteLine(i.Employeename + i.Departmentname);
            }
            Console.ReadLine();
            /*output = Ravichemistry
Pawanphysics
ankitmaths
samayenglish
*/

            //-------------------------------------------
            //Left outer join
            //query
            var res2 = from e in emp
                       join d in dep on e.eid equals d.did into x
                       from y in x.DefaultIfEmpty()
                       select new
                       {
                           Employeename = e.ename,
                           Departmentname = y== null ? "no department available":y.dname
                       };
            //access using foreach loop
            foreach (var i in res2)
            {
                Console.WriteLine(i.Employeename + i.Departmentname);
            }
            Console.ReadLine();

            /*output =Ravichemistry
Pawanphysics
ankitmaths
samayenglish */

            //-------------------------------
            //cross join
            // Cross join will produce the Cartesian product of the collections of items
            // There is no need for any condition to join the collection.

            //applying query
            var res3 = from e in emp
                       from d in dep
                       select new
                       {
                           Employeename = e.ename,
                           Departmentname = d.dname
                       };
            //access using foreach loop
            foreach (var i in res1)
            {
                Console.WriteLine(i.Employeename + i.Departmentname);
            }
            Console.ReadLine();
            /*output =Ravichemistry
Pawanphysics
ankitmaths
samayenglish */


            //-------------------------------------------
            //Group join
            //a Join clause with an 'into' expression is called a Group join. 
            var res4 = from d in dep
                       join e in emp on d.did equals e.eid into x
                       select new
                       {
                           Departmentname = d.dname,
                           Employees = from y in  x orderby y.ename select x
                       };
            int total = 0;
            foreach(var z in res4)
            {
                total++;
                Console.WriteLine("{0}", z.Departmentname);
            }
            Console.ReadLine();
            /*output = chemistry
physics
maths
english
*/
        }

    }
    class Employee
    {
        public int eid { get; set; }
        public string ename { get; set; }

    }
    class Department
    {
        public int did { get; set; }
        public string dname { get; set; }

    }
}
   