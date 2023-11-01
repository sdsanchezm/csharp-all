using System.Collections;

namespace ExerciseCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack1 = new Stack();
            stack1.Push(11);
            stack1.Push(44);
            stack1.Push(55);
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Pop());
        }
    }

    class Stack
    {
        private ArrayList list;

        public Stack()
        {
            list = new ArrayList();
        }

        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException("Invalid operation occurred.");

            var x1 = 1;
            //var num = obj;
            //Console.WriteLine( obj.GetType );
            list.Add(obj);
            //Console.WriteLine($"push...");
        }

        public object Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("list is empty");
            }

            //var obj1 = new Object();
            var lastItemIndex = list.Count - 1;
            object obj1 = list[lastItemIndex];
            list.RemoveAt(lastItemIndex);
            //Console.WriteLine($"pop... ");
            return obj1;
        }

        public void ClearList()
        {
            list.Clear();
            //Console.WriteLine("cleared...");
        }
    }
}