using System.Collections;

namespace Indexers
{
    internal class Program
    {
        static void Main()
        {
            ArrayList o1 = new ArrayList();
            //o1[0] = 100;
            ////o1.this[0] = 100;
            //Console.WriteLine(o1[0]);


            Class1 o = new Class1();
            //o1.Prop1 = 100;  //set

            o[0] = 100;  //set  //o.this[0] = 100
            o[1] = 200;
            o[2] = 300;
//          Console.WriteLine(o.Prop1);  //get
            Console.WriteLine(o[0]); //get
            Console.WriteLine(o[1]);
            Console.WriteLine(o[2]);
        }
        static void Main2()
        {
            
            Class1 o = new Class1();
            o[0] = 100;  //o.this[0] = 100;
            o[1] = 200;
            o[2] = 300;

            Console.WriteLine(o[0]);
            Console.WriteLine(o[1]);
            Console.WriteLine(o[2]);

        }
    }
    public class Class1
    {
        private int prop1;
        public int Prop1
        {
            set 
            { 
                prop1 = value; 
            }
            get 
            { 
                return prop1; 
            }
        }
        int[] arr= new int[3];
        public int this[int index]
        {
            set
            {
                arr[index] = value;
            }
            get
            {
                return arr[index];
            }
        }
    }
}
