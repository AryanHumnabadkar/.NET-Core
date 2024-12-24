namespace FuncActionPredicate
{
    internal class Program
    {
        static void Main1()
        {
            Action o1 = Display;
            o1();
            o1 = Show;
            o1();
            Action<string> o2 = Display;
            o2("passed value");

            Action<string,int> o3 = Display;
            o3("a", 1);
        }
        static void Main2()
        {
            Func<string> o1 = GetTime;
            Console.WriteLine(o1());
            Func<int,int> o2 = GetDouble;
            Console.WriteLine(o2(10));
            Func<int, int, int> o3 = Add;
            Console.WriteLine(o3(10,20))    ;

            Func<int,bool> o4 = IsEven;
            Console.WriteLine(o4(10));

            Predicate<int> o5 = IsEven;
            Console.WriteLine(o5(10));

            Employee oEmp = new Employee { EmpNo = 1, Basic = 12000 };
            Func<Employee, bool> o6 = IsBasicGreaterThan10000;
            Console.WriteLine(o6(oEmp));

            Predicate<Employee> o7 = IsBasicGreaterThan10000;
            Console.WriteLine(o7(oEmp));

        }

        static void Display()
        {
            Console.WriteLine("Display");
        }
        static void Show()
        {
            Console.WriteLine("Show");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display" +s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display" + s + i);
        }
        static int GetDouble(int a)
        {
            return a * 2;
        }
        static string GetTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static bool IsBasicGreaterThan10000(Employee obj)
        {
            if (obj.Basic > 10000)
                return true;
            else
                return false;
        }
        static bool IsEven(int a)
        {
            return (a % 2 == 0);
        //    if (a % 2 == 0)
        //        return true;
        //    else
        //        return false;
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string? Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}
