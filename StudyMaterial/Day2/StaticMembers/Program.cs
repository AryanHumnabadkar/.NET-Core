namespace StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o1;
            o1= new Class1();
            o1.i = 1;
            Class1.s_Display();
            o1.Display();
            Class1 o2 = new Class1();
            o2.i = 2;
            Class1.s_i = 3;
            Class1.s_Prop1 = 1;
        }
    }
    public class Class1
    {
        public int i;

        //only a single copy for the entire class (shared data)
        public static int s_i;
        public void Display()
        {
            Console.WriteLine("dis");
            Console.WriteLine(i);
            Console.WriteLine(s_i);
        }
        //static methods can be called directly from the class without creating an object of the class
        public static void s_Display()
        {
            Console.WriteLine("static dis");
            //from a static member you can only access static members directly.
            //to access a non static member you need to have an object reference
            //Console.WriteLine(i);  //error
            Console.WriteLine(s_i);

        }
        //why property - validations
        //why static variable - single copy

        //why static property - single copy with validations
        private int prop1;
        public int Prop1
        {
            set
            {
                if (value > 100)
                    Console.WriteLine("invalid value");
                else
                    prop1 = value;
            }
            get
            {
                return prop1;
            }
        }
        private static int s_prop1;
        public static int s_Prop1
        {
            set
            {
                if (value > 100)
                    Console.WriteLine("invalid value");
                else
                    s_prop1 = value;
            }
            get
            {
                return s_prop1;
            }
        }
        //why constructor - to initialise data
        //why static constructor - to initialise Static data

        //implicitly private - cannot have an access specifier
        //parameterless
        //cannot be overloaded
        //when is the static constructor called? - when class is loaded
        //when is the class loaded? - 1st object created OR
        //static member accessed for the 1st time

        static Class1()
        {
            Console.WriteLine("static cons");
            s_i = 200;
        }
        public Class1()
        {
            Console.WriteLine("cons");
        }
    }

}
//TO DO
//static class
//can only have static members
//cannot be instantiated
//cannot be a base class