namespace DefaultMethodImplementationInInterfaces1
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.Insert();
            //class has not implemented Select
            //with a def imp of interface, method 1 cant be used
            //o.Select(); //error

            (o as IDbFunctions).Select();  //def imp code will be called

        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        void Select()
        {
            Console.WriteLine("def imp of select");
        }
    }

    public class Class1 : IDbFunctions
    {
        public void Display()
        {
            Console.WriteLine("display from class1");
        }
        public void Delete()
        {
            Console.WriteLine("IDb.Delete from class1");
        }
        public void Insert()
        {
            Console.WriteLine("IDb.Insert from class1");
        }
        public void Update()
        {
            Console.WriteLine("IDb.update from class1");
        }
    }
}

namespace DefaultMethodImplementationInInterfaces2
{
    internal class Program
    {
        static void Main2()
        {
            Class1 o = new Class1();
            o.Insert();
            //class HAS implemented Select
            // method 1 can be used
            o.Select();  //Class1.Select() will be called 

            (o as IDbFunctions).Select();  //Class1.Select() will be called 

        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        void Select()
        {
            Console.WriteLine("def imp of select");
        }
    }

    public class Class1 : IDbFunctions
    {
        public void Display()
        {
            Console.WriteLine("display from class1");
        }
        public void Delete()
        {
            Console.WriteLine("IDb.Delete from class1");
        }
        public void Insert()
        {
            Console.WriteLine("IDb.Insert from class1");
        }
        public void Update()
        {
            Console.WriteLine("IDb.update from class1");
        }
        public void Select()
        {
            Console.WriteLine("IDb.select from class1");
        }
    }
}

namespace DefaultMethodImplementationInInterfaces3
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.Insert();
            //class HAS implemented Select - explicit implementation
            // method 1 CANNOT be used
            //o.Select();  //NOT AVAILABLE

            (o as IDbFunctions).Select();  //Class1.Select() will be called 

        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        void Select()
        {
            Console.WriteLine("def imp of select");
        }
    }

    public class Class1 : IDbFunctions
    {
        public void Display()
        {
            Console.WriteLine("display from class1");
        }
        public void Delete()
        {
            Console.WriteLine("IDb.Delete from class1");
        }
        public void Insert()
        {
            Console.WriteLine("IDb.Insert from class1");
        }
        public void Update()
        {
            Console.WriteLine("IDb.update from class1");
        }
        void IDbFunctions.Select()
        {
            Console.WriteLine("IDb.select from class1");
        }
    }
}