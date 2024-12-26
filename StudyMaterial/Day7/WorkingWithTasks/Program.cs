namespace WorkingWithTasks0
{
    internal class Program
    {
        static void Main1()
        {
            //Task t1 = new Task(new Action(Func1));
            Task t1 = new Task(Func1);
            Task t2 = new Task(Func2);
            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();
            //Console.ReadLine();
        }
        static void Func1()
        {
            Console.WriteLine("f1 called");
        }
        static void Func2()
        {
            Console.WriteLine("f2 called");
        }
    }
}
//calling a method with void return type using taskobj.Start
namespace Example1
{
    class Program
    {
        static void Main1()
        {

            Task t1 = new Task(Func1);

            //Action objAction1 = Func1;
            //Task t1 = new Task(objAction1);

            //Task t3 = new Task(new Action(Func1));

            Action objAction2 = Func2;
            Task t2 = new Task(objAction2);

            t1.Start();
            t2.Start();

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}


//calling a method with void return type using Task.Run and Task.Factory.StartNew
namespace Example2
{
    class Program
    {
        static void Main2()
        {
            Task t1 = Task.Run(Func1);
            Task t2 = Task.Factory.StartNew(Func2);

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type and parameters 
namespace Example3
{
    class Program
    {
        static void Main1()
        {
            Task t1 = new Task(new Action<object>(Func1), "passed value");
            t1.Start();


            Task t2 = Task.Factory.StartNew(Func2, "passed value");


            //Task.Run - cannot be used with parameters. 
            //use anonymous methods instead to access variables declared in calling code

            string s = "ccc";

            Task.Run(delegate () { Console.WriteLine(s); });
            Task.Run(() => { Console.WriteLine(s); });



            Console.ReadLine();
        }
        static void Func1(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called {0}{1}", i, obj.ToString());
            }
        }
        static void Func2(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
        }
    }
}

//calling methods with return type 
namespace Example4
{
    class Program
    {
        static void Main()
        {
            //Task<int> t1 = new Task<int>(new Func<int>(Func1));
            Task<int> t1 = new Task<int>(Func1);
            t1.Start();

            Task<int> t2 = new Task<int>(Func2, "passed value");

            Task<int> t3 = Task.Factory.StartNew<int>(Func1);
            Task<int> t4 = Task.Factory.StartNew<int>(Func2, "aaa");

            Task<int> t5 = Task.Run<int>(Func1);

            //do other code here

            //if(!t1.IsCompleted)
            //    t1.Wait();
            Console.WriteLine(t1.Result);  //waiting call
            Console.WriteLine(t2.Result);  //waiting call


            Console.ReadLine();
        }
        static int Func1()
        {
            int i;
            for (i = 0; i < 100000; i++)
            {
                Console.WriteLine("first Func called {0}", i);
            }
            return i;
        }
        static int Func2(object obj)
        {
            int i;
            for (i = 0; i < 20; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
            return i;
        }
    }
}


