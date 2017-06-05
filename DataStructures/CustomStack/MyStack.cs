using System;
namespace DataStructures.CustomStack
{
    public class MyStack
    {
        /*
            [  5  ]
            [  4  ]
            [  3  ]
            [  2  ]
            [  1  ]
        */
        private StackNode top;

        public MyStack()
        {
        }

        private class StackNode
        {
            public object data;
            public StackNode next;

            public StackNode(object data)
            {
                this.data = data;
            }
        }

        public object pop()
        {
            if (top == null) throw new Exception("Stack is empty");

            object item = top.data;

            top = top.next;

            return item;

        }

        public void push(object item)
        {
            StackNode topStackNode = new StackNode(item);

            topStackNode.next = top;

            top = topStackNode;
        }

        public object peek()
        {
            if (top == null) throw new Exception("The stack is empty");

            return top.data;

        }

        public bool isEmpty()
        {
            return top == null;
        }

        public void PrintStack()
        {
            StackNode node = top;

            if (node == null)
            {
                Console.WriteLine("The stack is empty");
                return;
            }

            while (node != null)
            {
                Console.WriteLine(string.Format("==\t\t{0}t\t==", node.data));
                node = node.next;
            }
        }
    }
}
