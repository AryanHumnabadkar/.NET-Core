//using System;
namespace ClassBasics
{
    internal class Program
    {
        static void Main1()
        {
            //Payroll.Employee
            //Payroll.MyNamespace.Class1
            Console.WriteLine("Hello, World!");
            System.Console.WriteLine("h w");

        }
        static void Main()
        {
            //Class1 obj;  //obj is a reference
            //obj = new Class1(); //new Class1() is an object of type Class1

            Class1 obj = new Class1();
            obj.Display();
            obj.Display("aa");

            //int ans;
            //ans = obj.Add(1, 2);
            //Console.WriteLine(ans);

            //positional parameters
            Console.WriteLine(obj.Add(1, 2));
            Console.WriteLine(obj.Add(1, 2, 3));
            //named parameters
            Console.WriteLine(obj.Add(x: 1, y: 2, z: 3));
            Console.WriteLine(obj.Add(z: 3,x: 1, y: 2 ));
            Console.WriteLine(obj.Add(z: 3, x: 1));
            Console.WriteLine(obj.Add(1,z: 3));

        }
    }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display called");
        }
        public void Display(string s)
        {
            Console.WriteLine("Display called" + s);
        }

        //public int Add(int x, int y)
        //{ 
        //    return x + y; 
        //}
        //func overloading
        //public int Add(int x, int y, int z)
        //{
        //    return x + y + z;
        //}

        //default parameters //optional parameters
        //default values - can be only given from r-l

        public int Add(int x, int y=0, int z=0)
        {
            return x + y + z;
        }
        public void DoSomething()
        {
            int i=100; //local variable
            Console.WriteLine(i);
            void DoSomethingElse()  //local function - func defined inside a function
                //implicitly private
                //cannot have an access specifier
                // can only be called from the outer function
            {
                i++; //local function can access the local variables defined in the outer func
                Console.WriteLine(i);
            }

            //TO DO IN LAB - TRY OVERLOADING A LOCAL FUNCTION
            DoSomethingElse();

        }

    }
}
namespace Payroll
{
    public class Employee { }
    public class Department { }
    public class Manager { }
    namespace MyNamespace
    {
        public class Class1 { }
    }
}

namespace CricketTeam
{
    public class Manager { }
}