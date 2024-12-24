using System.Xml;

namespace Constructors
{
    internal class Program
    {
        static void Main()
        {
            Class1 o1 = new Class1();
            Console.WriteLine(o1.i);


            Class1 o2 = new Class1(123);
            Console.WriteLine(o2.i);
        }
    }
    public class Class1
    {

        public int i;
        public Class1()
        {
            Console.WriteLine("no param cons called");
            i = 10;
        }
        public Class1(int i)
        {
            Console.WriteLine("int cons called");
            this.i = i; //this a reference to the current object
        }

    }
}
