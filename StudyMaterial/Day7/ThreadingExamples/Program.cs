namespace ThreadingExamples1
{
    internal class Program
    {
        static void Func1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("First : " + i);
                //Thread.Sleep(1000);
            }

        }
        static void Func2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Second : " + i);
                //Thread.Sleep(1000);
            }
        }

        static void Main0(string[] args) //ForeGround Thread Example : Main is Over Still waiting to complete t1 & t2
        {
            Thread t1 = new Thread(new ThreadStart(Func1)); 
            Thread t2 = new Thread(Func2);
            t1.Start();
            t2.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main : " + i);
            }
            Console.WriteLine("--------Main is Over------");
        }
        static void Main1(string[] args) //BackGround Thread Example : Once Main is Over Program Terminates Irrepective of Weather the t1 & t2 completed.
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            t1.IsBackground = true;
            t2.IsBackground = true;

            t1.Start();
            t2.Start();

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Main : " + i);
            }
            Console.WriteLine("--------Main is Over------");
        }
        static void Main2(string[] args) //Join Method Example : Main is waiting till t1 ends its operationa and join.
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            t1.Start();
            t2.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
            t1.Join();  //waiting call.
                        //main thread waits for t1 to finish execution
                        //and then continues with the next line
            Console.WriteLine("Code to be run after Func1 is over");
        }
        static void Main3() //ThreadState Example : Cannot restart alredy running thread.
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Start();
            if (t1.ThreadState != ThreadState.Running)
            t1.Start();


        //Deprecated Methods of Thread Class : 
            //t1.Abort();
            //t1.Suspend();
            //t1.Resume();

            t2.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
                Thread.Sleep(1000);
            }
        }

        static void Main4()//ThreadPriority Example : Just a Suggestion Not A Guarantee.
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;


            t1.Start();
            t2.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }
        static void Main5() //AutoResetEvent Signaling Mechanism Example 
        {
            AutoResetEvent wh = new AutoResetEvent(true);//Intial State => Signaled
            Thread t1 = new Thread(delegate () // Why Anonymous ? => To access the wh inside main locally. else need to decalre it globally inside class.
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("f1:" + i);
                    if (i % 50 == 0)
                    {
                        //instead of Suspend, use this
                        Console.WriteLine("waiting");
                        wh.WaitOne();
                    }
                }
            });

            t1.Start();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 1....");
            wh.Set();// -> Non - SIgnaled 
            //Now wh -> signled

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 2....");
            wh.Set();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 3....");
            wh.Set();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 4....");
            wh.Set();
        }

    }
}
//Parametrised Thread Start
namespace ThreadingExamples2
{
    internal class Progrm
    {
        static void Func1(object o)
        {
            Console.WriteLine("func1" + o);
        }
        static void Func2(object o)
        {
            Console.WriteLine("func2" + o);
        }
        static void Func3(object o)
        {
            List<int> list = (List<int>)o;
            Console.WriteLine("func3" + list[0]);

        }
        static void Main()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            t1.Start(10);

            Thread t2 = new Thread(Func2);
            t2.Start("abc");

            Console.WriteLine("Main : ");

            //to do -- pass more than one value to the func
            //collection/array
            //class/struct
            //anon method/lambda/local func
            //ValueTuple

            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            Thread t3= new Thread(Func3);
            t3.Start(list);
        }

    }
}
//ThreadPool
namespace ThreadingExamples3
{
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First Thread " + i);
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second Thread " + i);
            }
        }
        static void Main1()
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1));
            //ThreadPool.QueueUserWorkItem(PoolFunc1);

            //ThreadPool.QueueUserWorkItem(PoolFunc2, "aaa");

            //for (int i = 0; i < 1; i++)
            //{
            //    Console.WriteLine("Main Thread " + i.ToString());
            //}

            int workerthreads, iothreads;

            //ThreadPool.GetMinThreads(out workerthreads, out iothreads);
            //ThreadPool.GetMaxThreads(out workerthreads, out iothreads);
            //ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);
            //ThreadPool.SetMinThreads()
            //ThreadPool.SetMaxThreads
            //ThreadPool.GetMinThreads()
            //Console.WriteLine(workerthreads);
            //Console.WriteLine(iothreads);

            Console.ReadLine();
        }
    }
}
//synchronization
namespace ThreadingExamples4
{
    class MainClass
    {
        static object lockObject = new object();
        static int i = 0;
        static void FuncLock()
        {
            Thread.Sleep(1);
            lock (lockObject) //Monitor.Enter(lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                //--------------------------
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;


                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                //--------------------------
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;


                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
        }

        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            //{

            //Thread.Sleep(3000);
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            i++;
            Console.WriteLine("Second Monitor " + i.ToString());
            // }
            Monitor.Exit(lockObject);

        }

        static void FuncInterlocked()
        {

            Interlocked.Add(ref i, 10);   //i+=10
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Increment(ref i); //++i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Decrement(ref i); //--i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Exchange(ref i, 100); //i = 100;
            Console.WriteLine("Third Interlocked " + i.ToString());
        }

        static void Main1()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            //Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            // t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }

    }
}
