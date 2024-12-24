namespace OverloadingHidingOverriding
{
    internal class Program
    {
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
            o.Display1();
            o.Display1("aa");

            o.Display2();
            o.Display3();
        }
        static void Main()
        {
            BaseClass o;
            o = new BaseClass();
            o.Display2();  //non virtual func - early bound /compile time binding
            o.Display3();  //virtual func - late bound /run time binding

            Console.WriteLine(  );
            o = new DerivedClass();
            o.Display2();  //non virtual func - early bound /compile time binding
            o.Display3();  //virtual func - late bound /run time binding


            Console.WriteLine();
            o = new SubDerivedClass();
            o.Display2();  //non virtual func - early bound /compile time binding
            o.Display3();  //virtual func - late bound /run time binding

            Console.WriteLine();
            o = new SubSubDerivedClass();
            o.Display2();  //non virtual func - early bound /compile time binding
            o.Display3();  //virtual func - late bound /run time binding

        }
    }
    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("base display1");
        }
        public void Display2()
        {
            Console.WriteLine("base display2");
        }
        public virtual void Display3()
        {
            Console.WriteLine("base display3");
        }
    }
    public class DerivedClass : BaseClass
    {
        //overloading
        public void Display1(string s)
        {
            Console.WriteLine("derived display1");
        }
        public new void Display2()
        {
            Console.WriteLine("derived display2");
        }

        public override void Display3()
        {
            Console.WriteLine("derived display3");
        }
    }
    public class SubDerivedClass : DerivedClass
    {
        public sealed override void Display3()
        {
            Console.WriteLine("subderived display3");
        }
    }
    public class SubSubDerivedClass : SubDerivedClass
    {
        public new void Display3()
        {
            Console.WriteLine("subsubderived display3");
        }
    }
}
/*
 Employee
   CalcNetSalary()

Manager : Employee


Manager m = new Manager();
m.CalcNetSalary();

1. Derived class can overload the base class method
same func name, diff signature
Manager : Employee
   CalcNetSalary(.....)

Manager m = new Manager();
m.CalcNetSalary();   --- Employee(base)
m.CalcNetSalary(......);  ---- Manager(derived)
both are available

2. Derived class can hide the base class method
same func name, same signature
Manager : Employee
   CalcNetSalary()

Manager m = new Manager();
m.CalcNetSalary();   --- Manager(derived)
only derived class method is available

ANY method can be hidden

3. Derived class can override the base class method
same func name, same signature
Manager : Employee
   override CalcNetSalary()

Manager m = new Manager();
m.CalcNetSalary();   --- Manager(derived)
only derived class method is available

ONLY a virtual method can be overridden



 */