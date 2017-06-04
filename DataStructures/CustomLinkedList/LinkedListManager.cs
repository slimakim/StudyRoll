using System;
namespace DataStructures.CustomLinkedList
{
    public static class LinkedListManager
    {
        public static Node DeleteNode(Node head, object data)
        {
            Node n = head;
            
            if (head.data == data)
            {
                return head.next;
            }

            while (n.next != null)
            {
                if (n.next.data.Equals(data))
                {
                    n.next = n.next.next;
                    return head;
                }
                n = n.next;
            }

            return head;
        }
    }
}
