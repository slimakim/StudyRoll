using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.CustomQueue
{
    public class MyQueue
    {
        /*
            [4 (last)] <= [3] <= [2] <= [1 (first)]

            kinda like the backwards linked list.
        */

        private class QueueNode
        {
            public object data;

            public QueueNode next;

            public QueueNode(object data)
            {
                this.data = data;
            }

            public override string ToString()
            {
                return string.Format("[{0}]", data.ToString());
            }
        }

        private QueueNode first;
        private QueueNode last;

        //add the item to the end of the list.
        public void Add(object data)
        {
            QueueNode node = new QueueNode(data);

            if (last != null)
            {
                last.next = node;
            }

            last = node;

            if (first == null) {
                first = last;
            }
            
        }

        //remove the first item in the list;
        public object Remove()
        {
            if (first == null) throw new Exception("No such element");
            object data = first.data;
            first = first.next;

            if (first == null)
            {
                last = null;
            }

            return data;
        }

        //Return the top node.
        public object Peek()
        {
            if (first == null) throw new Exception("Empty queue");
            return first.data;
        }

        //checks if the queue is empty
        public bool IsEmpty()
        {
            return first == null;
        }

        public void PrintQueue()
        {
            List<string> queue = new List<string>();
            
            while (first != null)
            {
                queue.Add(first.ToString());

                first = first.next;
            }

            string[] queueArray = queue.ToArray();

            Array.Reverse(queueArray);

            Console.WriteLine(string.Join(" <= ", queueArray));

        }
    }
}
