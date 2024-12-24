namespace Assignment_3_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CEO c1 = new CEO();
            //Console.WriteLine(c1.Name);
            Console.WriteLine("-------------------");
            GenralManager gm1 = new GenralManager();
            Console.WriteLine(gm1.Designtaion);
            Console.WriteLine(gm1.Name);


        }
    }

    public abstract class Employee
    {
        private static int EmpCounter = 0;

        //Fields
        private readonly int empNo;
        private string? name;
        private short deptNo;
        protected decimal basics;

        //Properties
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

        //Abstract Properties
        public abstract decimal Basic
        {
            get; set;
            //get
            //{
            //    return basics;
            //}
            //set
            //{
            //    if (value > 100 && value < 500)
            //    {
            //        basics = value;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Basic Salary");
            //    }
            //}
        } 


        //Methods
        public abstract decimal GetNetSalary();
        //{
        //    int NetSalary = ((Convert.ToInt32(this.Basic)) / 10);
        //    return NetSalary;
        //}


        //Constructor 
        public Employee(string Name = "default", decimal Basic = 101, short DeptNo = 1)
        {
            Console.WriteLine("Employee Constructor");
            EmpCounter++;
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
            this.empNo = EmpCounter;
        }

    }

    public class Manager : Employee
    {
        //Fields
        private string? designation;

        //Property
        public string Designtaion
        {
            get
            {
                return designation;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    designation = value;
                }
                else
                {
                    Console.WriteLine("Invalid Designation");
                }
            }

        }

        //Inherited Property
        public override decimal Basic 
        {
            get
            {
                return basics;
            }
            set
            {
                if (value > 100 && value < 1000)
                {
                    basics = value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Salary For Manager");
                }
            }
        }

        //Inherited Methods
        public override decimal GetNetSalary()
        {
            int MgrBonus = 100;
            int NetSalary = ((((Convert.ToInt32(this.Basic)) + MgrBonus ))/10);
            return NetSalary;
        }

        //Constructor
        public Manager(string designation = "Manager") :base("MGR-Manish",301,2)
        {
            Console.WriteLine("Manager Constructor");
            this.designation = designation;
        }
    }

    public class GenralManager : Manager
    {
        //AutoProperty
        public string? Perks { get; set; }

        //Inherited Property
        public override decimal Basic 
        {
            get
            {
                return basics;
            }
            set
            {
                if (value > 300 && value < 1000)
                {
                    basics = value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Salary For Gernral Manager");
                }
            }
        }

        //Constructor
        public GenralManager(string Perks = "Genral Manager Bonus" ): base("GenralManager")
        {
            Console.WriteLine("Genreal Manager Constructor");
            this.Perks = Perks;
        }
    }

    public class CEO : Employee
    {
        public override decimal Basic 
        {
            get
            {
                return basics;
            }
            set
            {
                if (value > 400 && value < 1000)
                {
                    basics = value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Salary For CEO");
                }
            }
        }

        public sealed override decimal GetNetSalary()
        {
            int CEOBonus = 200;
            int NetSalary = ((((Convert.ToInt32(this.Basic)) + CEOBonus)) / 10);
            return NetSalary;

        }

        //Constructor
        public CEO() : base("CEO-Mukesh", 401, 3) 
        {
            Console.WriteLine("CEO Constructor");
        }
    }

}
