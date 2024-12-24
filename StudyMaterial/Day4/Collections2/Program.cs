using System.Collections;

namespace Collections2
{
    internal class Program
    {
        static void Main1()
        {
            // Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();
            objDictionary.Add(1, "Vikram");
            objDictionary.Add(2, "Shweta");
            objDictionary.Add(3, "Harsh");
            objDictionary.Add(4, "Ananya");

            objDictionary[5] = "new";
            objDictionary[1] = "updated";

            //objDictionary.Remove(1);
            //objDictionary.RemoveAt(1);

            //bool isPresent = objDictionary.Contains(1); //key
            //bool isPresent = objDictionary.ContainsKey(1); //key
            bool isPresent = objDictionary.ContainsValue("Vikram"); //value

            objDictionary.GetByIndex(0);  //value at index 0
            objDictionary.GetKey(0);
            IList keys = objDictionary.GetKeyList();
            IList values = objDictionary.GetValueList();

            objDictionary.IndexOfKey(1);
            objDictionary.IndexOfValue("Vikram");

            ICollection keys2 = objDictionary.Keys;
            ICollection values2 = objDictionary.Values;

            objDictionary.SetByIndex(1, "changed value"); //index

            foreach (DictionaryEntry item in objDictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
                Console.WriteLine();
            }

        }

        static void Main2()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            List<string> list2 = new List<string>();
            list2.Add("a");
            list2.Add("b");
            list2.Add("c");

            foreach (string item in list2)
            {
            }

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { EmpNo = 1, Name = "Vikram" });
            employees.Add(new Employee { EmpNo = 2, Name = "Harsh" });
            employees.Add(new Employee { EmpNo = 3, Name = "Ananya" });

            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.EmpNo);
                Console.WriteLine(emp.Name);
            }

        }

        static void Main3()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Pop());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            Console.WriteLine(queue.Dequeue());
        }

        static void Main()
        {
            SortedList<int, Employee> sortedlist = new SortedList<int, Employee>();
            sortedlist.Add(1, new Employee { EmpNo = 1, Name = "Vikram" });
            sortedlist.Add(2, new Employee { EmpNo = 2, Name = "Harsh" });
            sortedlist.Add(3, new Employee { EmpNo = 3, Name = "Ananya" });
            //foreach (DictionaryEntry item in objDictionary)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value);
            //    Console.WriteLine();
            //}
            foreach (KeyValuePair<int, Employee> item in sortedlist)
            {
                Console.WriteLine(item.Key);  //empno
                Console.WriteLine(item.Value.Name); //item.Value is of type Employee
            }
        }

    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}
/*
 * TO DO - Read 
https://learn.microsoft.com/en-us/dotnet/standard/collections/commonly-used-collection-types
https://learn.microsoft.com/en-us/dotnet/standard/collections/
https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class

 */