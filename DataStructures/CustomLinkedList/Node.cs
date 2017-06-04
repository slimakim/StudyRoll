using System;
namespace DataStructures.CustomLinkedList
{
    public class Node
    {
        public Node next = null;

        public object data;

        public Node(object data)
        {
            this.data = data;
        }

        public void AddNode(object data)
        {
            Node end = new Node(data);
            Node current = this;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = end;
        }


        public void PrintNodes()
        {
            Node current = this;
            while (current.next !=null)
            {
                Console.WriteLine(string.Format("This data {0}; next data: {1}", current.data, current.next.data));
                current = current.next;
            }
        }
    }
}
