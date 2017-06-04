using System;
namespace DataStructures.CustomStack
{
    public class MyStack
    {
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

        public object peek();

        public bool isEmpty()
    }
}
