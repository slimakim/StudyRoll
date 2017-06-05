using System;
using DataStructures.CustomLinkedList;
using DataStructures.CustomQueue;
using DataStructures.CustomStack;

namespace DataStructures
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ExecQueue();
        }

        public static void ExecLinkedList()
        {
			Node linkedList = new Node("first node");

			linkedList.AddNode("second node");

			linkedList.AddNode(9);

			linkedList.AddNode(new DateTime(2019, 1, 6));

			linkedList.AddNode("last node");

			linkedList.PrintNodes();

			Console.WriteLine("----==========----");

			linkedList = LinkedListManager.DeleteNode(linkedList, new DateTime(2019, 1, 6));

			linkedList.PrintNodes();
        }

        public static void  ExecStack()
        {
            MyStack myStack = new MyStack();

            myStack.PrintStack();

            Console.WriteLine(myStack.isEmpty());

            myStack.push("exec print");

            myStack.push("alloc 11 bytes");

            myStack.push(91);

            myStack.PrintStack();

            myStack.peek();

            Console.WriteLine(myStack.isEmpty());

            myStack.pop();

            myStack.PrintStack();
        }

        public static void ExecQueue()
        {
            MyQueue myQueue = new MyQueue();

            myQueue.IsEmpty();

            myQueue.PrintQueue();

            myQueue.Add(7);

            myQueue.Add("Tina");

            myQueue.Add("11 bytes");

            myQueue.Add(91);

            myQueue.Remove();

            myQueue.PrintQueue();
        }
    }
}
