namespace Delegates
{
    //step 1 : create a delegate class matching the signature
    //of the function to be called

    //Object
    //Delegate
    //MulticastDelegate
    //Del1
    public delegate void Del1();
    public delegate int DelAdd(int a, int b);
    internal class Program
    {
        static void Main1()
        {
            //step 2 : declare a delegate reference and make
            //it refer to an object of the delegate class. 
            //Pass function name to be called as a parameter
            Program p1 = new Program();
            Del1 objDel = new Del1(p1.Display);

            //step 3 : call the function indirectly using the delegate reference
            objDel();
        }
        static void Main2()
        {
            Del1 objDel = Display;
            objDel();

            objDel = Show;
            objDel();

        }
        static void Main3()
        {
            Del1 objDel = Display;
            objDel();

            Console.WriteLine();
            objDel += Show;
            objDel();

            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.WriteLine();
            objDel -= Show;
            objDel();

            //Console.WriteLine();
            //objDel -= Display;
            //objDel();
        }
        static void Main4()
        {
            DelAdd objDelAdd = Add;
            Console.WriteLine(objDelAdd(1,2));
            //int ans = objDelAdd(1,2);
            //Console.WriteLine(ans);
        }
        static void Main5()
        {
            Del1 o = Class1.Display;
            o();

            Class1 objClass1 = new Class1();
            Del1 newobj = objClass1.Show;
            newobj();

        }
        static void Main()
        {
            Del1 objDel =(Del1)  Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            objDel();

            Console.WriteLine();
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));
            objDel();
        }
        static void Main7()
        {
            DelAdd objDelAdd = Add;
            objDelAdd += Subtract;
            
            Console.WriteLine(objDelAdd(10, 2));

            //int ans;
            //ans = Add(10, 2);
            //ans = Subtract(10, 2);
            //Console.WriteLine(ans);
        }
        static void Main8()
        {
            Console.WriteLine(CallMathOperation(Add, 1, 2));
            Console.WriteLine(CallMathOperation(Subtract, 3, 1));
            Console.WriteLine(CallMathOperation(Multiply, 1, 2));

        }

        static int Add(int a, int b)
        {
            //Console.WriteLine("add");
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            //Console.WriteLine("subtract");
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
         void Display()
        {
            Console.WriteLine("Display");
        }
        static void Show()
        {
            Console.WriteLine("Show");
        }

        static int CallMathOperation(DelAdd objDelAdd, int a, int b) //objDelAdd = Add
        {

            return objDelAdd(a, b);
        }
    }
    public class Class1
    {
        public static void Display()
        {
            Console.WriteLine("Display");
        }
        public void Show()
        {
            Console.WriteLine("Show");
        }
    }
}
