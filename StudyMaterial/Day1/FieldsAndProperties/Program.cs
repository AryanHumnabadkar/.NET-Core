namespace FieldsAndProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();

            //o1.Seti(1000);
            //Console.WriteLine(o1.Geti());


            o1.P1 = 1000;  //set
            Console.WriteLine(o1.P1);  //get

            o1.P2 = "aaa";
            o1.P3 = "aaa";

        }

    }

    public class Class1
    {
        public int j;
        //field -- class level variable
        private int i;


        public void Seti(int VALUE)
        { 
            if(VALUE <=100)    
                i = VALUE;
            else
                Console.WriteLine("invalid value");
        }
        public int Geti()
        {
            return i;
        }


        private int p1; //variable
        //why property? - validations
        public int P1        //property
        {
            set 
            {
                if(value <=100)
                    p1 = value;
                else
                    Console.WriteLine("invalid value");
            }
            get
            {
                return p1;
            }
        }


        private string p2;
        public string P2
        {
            set 
            { 
                p2 = value; 
            }
            get 
            { 
                return p2;
            }
        }


        //to do - create a readonly property - no set
        //to do - create a writeonly property - no get
        public string P3;

        //automatic property /auto property
        //no validations
        //compile generates the private variable
        //compile generates set, get

        public string P4 { set; get; }
    }
}
