using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCodeWithDelegates1
{
    internal class Program
    {
        static void Main1()
        {
            Action oDel = Display;
            Console.WriteLine("before");
            oDel.BeginInvoke(null,null);
            Console.WriteLine("after");

            Console.ReadLine();
        }
        static void Display()
        {
            Thread.Sleep(5000);
            Console.WriteLine("display called");
        }
    }
}

namespace AsyncCodeWithDelegates2
{
    internal class Program
    {
        static void Main2()
        {
            Action<string> oDel = Display;
            Console.WriteLine("before");
            oDel.BeginInvoke("passed value",null, null);
            Console.WriteLine("after");

            Console.ReadLine();
        }
        static void Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("display called" + s);
        }
    }
}

namespace AsyncCodeWithDelegates3
{
    internal class Program
    {
        static void Main3()
        {
            Func<string,string> oDel = Display;
            Console.WriteLine("before");
            oDel.BeginInvoke("passed value", CallbackFunction, null);
            Console.WriteLine("after");

            Console.ReadLine();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}

namespace AsyncCodeWithDelegates4
{
    internal class Program
    {
        static void Main4()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("before");
            IAsyncResult ar1 = oDel.BeginInvoke("passed value", delegate(IAsyncResult ar)
            {
                Console.WriteLine("callback func called");
                string retval = oDel.EndInvoke(ar);
                Console.WriteLine(retval);
            }, null);
            Console.WriteLine("after");

            Console.ReadLine();
        }
      
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}

namespace AsyncCodeWithDelegates5
{
    internal class Program
    {
        static void Main5()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("before");
            //oDel.BeginInvoke("passed value", CallbackFunction, "extra data passed here");
            oDel.BeginInvoke("passed value", CallbackFunction, oDel);
            Console.WriteLine("after");

            Console.ReadLine();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
            //string extra_data = ar.AsyncState.ToString();
            //Console.WriteLine(extra_data);

            Func<string, string> oDel =(Func<string, string>) ar.AsyncState;
            string retval = oDel.EndInvoke(ar); 
            Console.WriteLine(retval);
        
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}

namespace AsyncCodeWithDelegates
{
    internal class Program
    {
        static void Main()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("before");
            IAsyncResult ar1 = oDel.BeginInvoke("passed value", null, null);
            Console.WriteLine("after");

            while (!ar1.IsCompleted) ;

            string retval = oDel.EndInvoke(ar1);
            Console.WriteLine(retval);

            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("display called" + s);
            return s.ToUpper();
        }
    }
}