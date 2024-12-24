namespace EmployeeExample1
{
    internal class Program
    {
        static void Main1()
        {

        }
    }
    public class Employee
    {

        string name; //-> no blank names should be allowed
        int empNo; //-> must be greater than 0
        decimal basic;// -> must be between some range
        short deptNo;// -> must be > 0

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }
        public int EmpNo
        {
            get { return empNo; }
            set
            {
                if (value > 0)
                    empNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public decimal Basic
        {
            get { return basic; }
            set
            {
                if (value < 10000 || value > 100000)
                    Console.WriteLine("Invalid Basic");
                else
                    basic = value;

            }
        }
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public decimal GetNetSalary()
        {
            return Basic * 2;
        }
        public Employee(int EmpNo = 1, string Name = "default", decimal Basic = 10000, short DeptNo = 1)
        {
            this.EmpNo = EmpNo;  //property - set
            //this.empNo = EmpNo; //variable -- do not use this --- validations are not called
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
    }
}


//readonly 1st way
namespace EmployeeExample2
{
    internal class Program
    {
        static void Main()
        {

        }
    }
    public class Employee
    {
        static int lastEmpNo=0;
        string name; //-> no blank names should be allowed
        int empNo; //-> must be greater than 0
        decimal basic;// -> must be between some range
        short deptNo;// -> must be > 0

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }
        public int EmpNo
        {
            get { return empNo; }
            //set
            //{
            //    if (value > 0)
            //        empNo = value;
            //    else
            //        Console.WriteLine("Invalid EmpNo");
            //}
        }
        public decimal Basic
        {
            get { return basic; }
            set
            {
                if (value < 10000 || value > 100000)
                    Console.WriteLine("Invalid Basic");
                else
                    basic = value;

            }
        }
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public decimal GetNetSalary()
        {
            return Basic * 2;
        }
        public Employee(string Name = "default", decimal Basic = 10000, short DeptNo = 1)
        {
            //this.EmpNo = ++lastEmpNo;
            this.empNo= ++lastEmpNo;
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
    }
}


//readonly 2nd way
namespace EmployeeExample3
{
    internal class Program
    {
        static void Main()
        {
            Employee obj = new Employee();
           // obj.EmpNo = 1;

        }
    }
    public class Employee
    {
        static int lastEmpNo = 0;
        string name; //-> no blank names should be allowed
        int empNo; //-> must be greater than 0
        decimal basic;// -> must be between some range
        short deptNo;// -> must be > 0

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }

        //public
        //protected internal
        //protected / internal
        //private protected
        //private

        public int EmpNo
        {
            get { return empNo; }

            //property accessor
            //only one out of get/set can be made less accessible than the property
            //you can only reduce access, not increase it
            private set
            {
                if (value > 0)
                    empNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public decimal Basic
        {
            get { return basic; }
            set
            {
                if (value < 10000 || value > 100000)
                    Console.WriteLine("Invalid Basic");
                else
                    basic = value;

            }
        }
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public decimal GetNetSalary()
        {
            return Basic * 2;
        }
        public Employee(string Name = "default", decimal Basic = 10000, short DeptNo = 1)
        {
            this.EmpNo = ++lastEmpNo;
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
    }
}


//readonly 3rd way
namespace EmployeeExample4
{
    internal class Program
    {
        static void Main()
        {

        }
    }
    public class Employee
    {
        static int lastEmpNo = 0;
        string name; //-> no blank names should be allowed
        //int empNo; //-> must be greater than 0
        decimal basic;// -> must be between some range
        short deptNo;// -> must be > 0

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }

        //readonly auto property
        public int EmpNo
        {
            get;
        }
        public decimal Basic
        {
            get { return basic; }
            set
            {
                if (value < 10000 || value > 100000)
                    Console.WriteLine("Invalid Basic");
                else
                    basic = value;

            }
        }
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Invalid EmpNo");
            }
        }
        public decimal GetNetSalary()
        {
            return Basic * 2;
        }
        public Employee(string Name = "default", decimal Basic = 10000, short DeptNo = 1)
        {
            this.EmpNo = ++lastEmpNo;
            //this line only works in the constructor

            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
        public void X()
        {
           // this.EmpNo = ++lastEmpNo; //error after constructor
        }
    }
}
