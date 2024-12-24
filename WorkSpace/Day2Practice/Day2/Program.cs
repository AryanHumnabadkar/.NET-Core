//using ClassLibraryDemo; //Add Reference First
using ProjectReferenceDemo;

namespace Day2Session1
{
    internal class Program
    {
        static void MainForStaticNonStaic(string[] args)
        {
            StaticNonStatic obj = new StaticNonStatic();
            obj.NonStatNum = 12;//set prop called
            //Class1.statNum = 100;//Direct Assignment ( if field pubic )
            StaticNonStatic.StatNum = 200;//set prop called
            StaticNonStatic.AutoPropNum = 300;
        }

        static void MainForInheritance(string[] args)
        {
            PClass pobj = new PClass(1,2);


            CClass Cobj = new CClass();

            Cobj.P1 = pobj.P1;
            Cobj.P2 = pobj.P2;

        }
    }

    public class StaticNonStatic
    {
        //Fields
        private int nonStatNum;

        private static int statNum;

        //Properties
        public int NonStatNum
        {
            get
            {
                return statNum;
            }
            set
            {
                statNum = value;
            }
        }

        public static int StatNum
        {
            get
            {
                return statNum;
            }
            set
            {
                statNum = value;
            }
        }

        //AutoProperty
        public static int AutoPropNum { get;set; }

    }

    //public class PClass
    //{
    //    public int P1 { get; set; }
    //    public int P2 { get; set; }

    //    //public PClass()
    //    //{
    //    //    P1 = 8;
    //    //    P2 = 10;
    //    //}

    //    public PClass(int P1 = 8, int P2 = 10)
    //    {
    //        this.P1 = P1;
    //        this.P2 = P2;
    //    }
    //}

    public class CClass : PClass {

        public int C1 { get; set; }
        public int C2 { get; set; }

        public CClass() : base(100,200)
        {
            this.C1 = 500;
            this.C2 = 400; 
        }

        //Constrctor => Another Form of Setter
        //New Keyword => Actual Object Creation

    }
}

namespace Day2Session2
{
    public class BaseClass
    {
        public void Function1()
        {
            Console.WriteLine("Function 1 of Base");
        }

        public virtual void Function2()
        {
            Console.WriteLine("Function 2 of Base");
        }
    }

    public class DerivedClass : BaseClass
    {
        public void Function1(int x) //Function 1 Overloading
        {
            Console.WriteLine("Overloaded Function 1 of Child Class with Param :"+ x);
        }

        public new void Function1() //Hidden Meachanism
        {
            Console.WriteLine("Hidden Mechanism of Function 1  in child Class");
        }

        public override void Function2() //Function 2 Overriden
        {
            Console.WriteLine("Overriden of Function 2  in child Class");
        }
    }

    public class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("------- Base Class Object-----");
            BaseClass b = new BaseClass();
            b.Function1();
            b.Function2();

            Console.WriteLine("------- Child Class Object-----");
            DerivedClass d = new DerivedClass();
            d.Function1();
            d.Function1(23);
            d.Function2();

            Console.WriteLine("------- B2  Object i.e. Upcasting-----");
            BaseClass b2 = new DerivedClass();
            b2.Function1();


            Console.WriteLine("------- B2  Object i.e. Downcasting-----");
            ((DerivedClass)b2).Function2();
            b2.Function2 ();
        }
    }
}
