using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkedList
{
    public class Node<T>
    {
        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }

        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }


        public void AddToHead(T data)
        {
            var tmp = new Node<T>(data);
            tmp.Next = Head;

            if (Head == null)
                Head = Tail = tmp;
            else
                Head = tmp;
        }

        public void PrintList()
        {
            var tmp = Head;
            while (tmp != null)
            {
                Console.WriteLine(tmp.Data);
                tmp = tmp.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = Head;
            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }

        public void AddToTail(T data)
        {
            var tmp = new Node<T>(data);
            if (Tail == null)
                Head = Tail = tmp;
            else
            {
                Tail.Next = tmp;
                Tail = tmp;
            }

            Count++;
        }
    }
}
