namespace Lambdas
{
    internal class Program
    {
        static void Main1()
        {
            Func<int, int> o1 = GetDouble;
            Console.WriteLine(o1(10));

            Func<int, int> o2 = delegate(int a)
            {
                return a * 2;
            };
            Console.WriteLine(o2(10));

            Func<int, int> o3 = (a) => a * 2;
            Func<int, int> o4 = a => a * 2;
            Console.WriteLine(o3(10));
            Console.WriteLine(o4(10));


        }
        static void Main()
        {
            Func<string> o1 = () => DateTime.Now.ToLongTimeString();
            Console.WriteLine(o1());

            Func<int,int,int> o2 = (x,y) => x + y;
            Console.WriteLine(o2(10,5));

            Func<int,bool> o3 = x => x % 2 == 0;
            Console.WriteLine(o3(10));

            Func<int, bool> o5 = x =>
            {
                if (x % 2 == 0)
                    return true;
                else
                    return false;
            };

           Predicate<int> o4 = x => x % 2 == 0;
            Console.WriteLine(o4(10));

            Predicate<Employee> o7 = obj => obj.Basic > 10000;
            Employee oEmp = new Employee { EmpNo = 1, Basic = 12000 };
            Console.WriteLine(o7(oEmp));

        }
        static int GetDouble(int a)
        {
            return a * 2;
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}
