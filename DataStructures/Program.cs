using System;
using DataStructures.CustomLinkedList;

namespace DataStructures
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Node linkedList = new Node("first node");

            linkedList.AddNode("second node");

            linkedList.AddNode(9);

            linkedList.AddNode(new DateTime(2019,1,6));

            linkedList.AddNode("last node");

            linkedList.PrintNodes();

            Console.WriteLine("----==========----");

            linkedList = LinkedListManager.DeleteNode(linkedList, new DateTime(2019, 1, 6));

            linkedList.PrintNodes();
        }
    }
}
