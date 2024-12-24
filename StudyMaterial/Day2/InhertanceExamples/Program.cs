namespace InheritanceExamples
{
    internal class Program
    {
        static void Main1()
        {
            BaseClass o1 = new BaseClass();

            o1.a = 1;

            DerivedClass o2 = new DerivedClass();
            o2.b = 2;
            o2.a = 3;

        }
    }
    public class BaseClass //:Object
    {
        public int a;
    }
    public class DerivedClass : BaseClass
    {
        public int b;
    }
}


//constructors in inheritance
namespace InheritanceExamples3
{
    class Program
    {
        static void Main()
        {
            DerivedClass o1 = new DerivedClass();
            DerivedClass o2 = new DerivedClass(123, 456);
        }
    }
    public class BaseClass
    {
        public int i;
        public BaseClass()
        {
            Console.WriteLine("base class no param cons");
            i = 10;
        }
        public BaseClass(int i)
        {
            Console.WriteLine("base class int cons");
            this.i = i;
        }
    }
    public class DerivedClass : BaseClass
    {
        public int j;
        public DerivedClass() 
        {
            Console.WriteLine("derived class no param cons");
         
            j = 20;
        }
        public DerivedClass(int i, int j) : base(i)
        {
            Console.WriteLine("derived class int,int cons");
            this.j = j;
        }
    }
}


