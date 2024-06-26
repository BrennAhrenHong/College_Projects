using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _6_BinaryTree
{
    public class BinaryTree<T>
    {
        public Node<T> Root { get; set; }
        private Queue<T> _resultPreOrder;

        public Queue<T> PreOrder(Node<T> node = null)
        {
            _resultPreOrder = new Queue<T>();
            if (node == null) node = Root;
            return PreOrderHelper(node);
        }
        private Queue<T> PreOrderHelper(Node<T> node = null)
        {
            if (node != null)
            {
                _resultPreOrder.Enqueue(node.Data);
                PreOrderHelper(node.Left);
                PreOrderHelper(node.Right);
            }

            return _resultPreOrder;
        }

        public Queue<T> BreadthFirst(Node<T> node = null)
        {
            if (node == null) node = Root;

            // place nodes here to be returned
            var result = new Queue<T>();

            // store the children of nodes here
            var qTmp = new Queue<Node<T>>();
            qTmp.Enqueue(node);

            while (qTmp.Count > 0)
            {
                node = qTmp.Dequeue();
                result.Enqueue(node.Data);

                if (node.Left != null)
                    qTmp.Enqueue(node.Left);

                if(node.Right != null)
                    qTmp.Enqueue(node.Right);
            }

            return result;
        }

        public void Insert(T data, IComparer<T> comparer = null)
        {
            if(comparer == null) comparer = Comparer<T>.Default;

            Node<T> node = Root;
            Node<T> prev = null;

            while (node != null)
            {
                int result = comparer.Compare(data, node.Data); // 8 & 10 for example, result is -1

                prev = node;
                if (result < 0)
                    node = node.Left;
                else
                    node = node.Right;
            }

            if (Root == null)
            {
                Root = new Node<T>(data);
            }
            else
            {
                if (comparer.Compare(data, prev.Data) < 0)
                {
                    prev.Left = new Node<T>(data);
                    prev.Left.Parent = prev;
                }
                else
                {
                    prev.Right = new Node<T>(data);
                    prev.Right.Parent = prev;
                }
            }
        }
    }
}
