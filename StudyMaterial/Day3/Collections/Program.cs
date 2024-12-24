using System;
using System.Collections;

namespace Collections
{
    internal class Program
    {
        static void Main1()
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(10);
            objArrayList.Add("Vikram");
            objArrayList.Add(10.123);
            objArrayList.Add(true);

            ArrayList objArrayList2 = new ArrayList();
            objArrayList2.Add(888);
            objArrayList2.Add(999);
            objArrayList.AddRange(objArrayList2);

            objArrayList.Insert(0, "new");
            objArrayList.InsertRange(0,objArrayList2);

            objArrayList.Remove("Vikram");//object
            objArrayList.RemoveAt(0);  //index
            //objArrayList.RemoveRange(index, count)
            //objArrayList.RemoveRange(0, 2);

            //objArrayList.Clear(); Remove All
            bool isPresent = objArrayList.Contains("Vikram");
            object[] arr = new object[objArrayList.Count];
            objArrayList.CopyTo(arr);

            object [] arr2 =  objArrayList.ToArray()!;


            //objArrayList[0] = 12344;
            ////objArrayList.this[0] = 12344;
            //Console.WriteLine(objArrayList[0]);
            ////Console.WriteLine(objArrayList.this[0]);


            foreach (object item in objArrayList)
            {
                Console.WriteLine(item);
            }
        }
        static void Main2()
        {
            ArrayList o = new ArrayList();
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");

            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");
            o.Add(10);
            Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");

            o.TrimToSize();
            Console.WriteLine($"after trim.. count is {o.Count}, capacity is {o.Capacity}");
           // o.Add(10);
           // Console.WriteLine($"count is {o.Count}, capacity is {o.Capacity}");

        }
        static void Main()
        {
            Stack s = new Stack();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());

            Queue q  = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());

        }
    }
}
