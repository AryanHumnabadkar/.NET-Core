namespace EventHandling1
{
    //internal class Program
    //{
    //    static void Main()
    //    {
    //        Class1 objClass1 = new Class1();
    //        objClass1.InvalidP1 += objClass1_InvalidP1;
    //        objClass1.P1 = 1000;

    //    }
    //    static void objClass1_InvalidP1()
    //    {
    //        Console.WriteLine("event handled here");
    //    }
    //}

    internal class Program
    {
        static void Main2()
        {
            Class1 objClass1 = new Class1();
            //one event multiple handlers
            objClass1.InvalidP1 += ObjClass1_InvalidP1;
            objClass1.InvalidP1 += handler2;


            objClass1.P1 = 123;
            Class1 objClass2 = new Class1();
            //same handler for different events
            objClass2.InvalidP1 += ObjClass1_InvalidP1;
            objClass2.P1 = 123;


        }

        private static void ObjClass1_InvalidP1()
        {
            Console.WriteLine("event handled");
        }
        private static void handler2()
        {
            Console.WriteLine("event handled here also");
        }
    }


    //step1 : create a delegate class that matches
    //the signature of the event handler
    public delegate void InvalidP1EventHandler();
    public class Class1
    {
        //step2 : declare the event. event is a delegate reference
        public event InvalidP1EventHandler InvalidP1;
        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3 - raise the event
                    if(InvalidP1 != null)
                        InvalidP1();
                }
            }
        }
    }
}
namespace EventHandling2
{
   
    internal class Program
    {
        static void Main()
        {
            Class1 objClass1 = new Class1();
            objClass1.InvalidP1 += ObjClass1_InvalidP1;
            objClass1.P1 = 1233;
        }

        private static void ObjClass1_InvalidP1(int InvalidValue)
        {
            Console.WriteLine("invalid p1- " + InvalidValue);
        }
    }


    //step1 : create a delegate class that matches
    //the signature of the event handler
    public delegate void InvalidP1EventHandler(int InvalidValue);
    public class Class1
    {
        //step2 : declare the event. event is a delegate reference
        public event InvalidP1EventHandler InvalidP1;
        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3 - raise the event
                    if (InvalidP1 != null)
                        InvalidP1(value);
                }
            }
        }
    }
}