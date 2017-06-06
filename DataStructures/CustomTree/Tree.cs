using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.CustomTree
{
    class Tree
    {
        public Node root;

        public void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Visit(node);
                InOrderTraversal(node.right);
            }
        }

        public void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Visit(node);
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }
        }

        public void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.left);
                PostOrderTraversal(node.right);
                Visit(node);
            }
        }
    }
}
