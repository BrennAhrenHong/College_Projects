using System;
using System.Collections.Generic;
using System.Text;

namespace ILinkedList
{
    public class Node<T>
    {
        public Node(T data, Node<T> next, Node<T> prev)
        {
            Data = data;
            Next = next;
            Prev = prev;
        }

        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
    }
}
