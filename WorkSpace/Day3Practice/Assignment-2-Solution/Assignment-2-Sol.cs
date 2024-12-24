using System.Runtime.CompilerServices;

namespace Assignment_2_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee();
            Employee o2 = new Employee();
            Employee o3 = new Employee();

            Console.WriteLine(o1.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);

            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o1.EmpNo);
        }
    }

    public class Employee
    {
        private static int EmpCounter = 0;

        //Fields
        private readonly int empNo;
        private string? name;
        private short deptNo;
        private Decimal basics;
        public int EmpNo
        {
            get
            {
                return empNo;
            }
            
        }
        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null || value == "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Invalid Name");
                }
            }
        }
        public decimal Basic
        {
            get
            {
                return basics;
            }
            set
            {
                if (value > 100 && value < 500)
                {
                    basics = value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Salary");
                }
            }
        }
        public short DeptNo
        {
            get
            {
                return deptNo;
            }
            set
            {
                if (value > 0)
                {
                    deptNo = value;
                }
                else
                {
                    Console.WriteLine("Invalid Dept No");
                }
            }
        }


        //Methods
        public decimal GetNetSalary()
        {
            int NetSalary = ((Convert.ToInt32(this.Basic)) / 10);
            return NetSalary;
        }


        //Constructor 
        public Employee(string Name = "default", decimal Basic = 101, short DeptNo = 1)
        {
            EmpCounter++;
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
            this.empNo = EmpCounter;
        }

    }

}
