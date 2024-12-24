namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee(1,"Amol", 123465, 10);
            Employee o2 = new Employee(2,"Amol", 123465);
            Employee o3 = new Employee(3,"Amol");
            Employee o4 = new Employee(4);
            Employee o5 = new Employee();

            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.WriteLine(o3);
            Console.WriteLine(o4);
            Console.WriteLine(o5);

        }
    }

    public class Employee
    {
        //Fields
        private int empNo;
        private string? name;
        private short deptNo;
        private Decimal basics;
        public int EmpNo {
            get
            {
                return empNo;
            }
            set
            {
                if (value > 0)
                {
                    empNo = value;
                }
                else
                {
                    Console.WriteLine("Invalid Emp Number");
                }
            } 
        }
        public string Name
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
                if (value > 100 &&  value < 500)
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
            int NetSalary = ((Convert.ToInt32(this.Basic))/10);
            return NetSalary;
        }

        //Constructor 
        public Employee(int EmpNo = 1, string Name = "default", decimal Basic = 101, short DeptNo = 1 )
        {
            this.EmpNo = EmpNo;
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }

    }

}
