using System;
using System.Collections.Generic;
using System.Text;

namespace ILinkedList
{
    public class GenericDoublyLinkedList<T> : ILinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; private set; }

        public void AddToHead(T data)
        {
            var tmp = new Node<T>(data); // #1

            if (Head == null)
            {
                Head = Tail = tmp;
            }
            else
            {
                Head.Prev = tmp; // #2
                tmp.Next = Head; // #3
                Head = tmp;
            }

            Count++;
        }

        public void AddToTail(T data)
        {
            var tmp = new Node<T>(data); // #1

            if (Head == null) Head = Tail = tmp;
            else
            {
                Tail.Next = tmp;
                tmp.Prev = Tail;
                Tail = tmp;
            }

            Count++;
        }

        public T RemoveFromHead()
        {
            if (Head == null)
                throw new Exception("Cannot remove head " +
                                    "from an empty linked list.");

            var headData = Head.Data; // #1a
            if (Head == Tail) // #1
            {

                Head = Tail = null; // #1b
            }
            else // #2
            {
                Head = Head.Next;
                //Head.Prev.Next = null; // optional step
                Head.Prev = null;
            }

            Count--;
            return headData;

            //----------------------------
            // #1 List only has one node
            // #1a get a copy of the head data to return
            // #2 List has one or more nodes
        }

        public T RemoveFromTail()
        {
            if (Head == null)
                throw new Exception("Cannot remove head " +
                                    "from an empty linked list.");
            var tailData = Tail.Data;
            if (Head == Tail) // #1
            {
                Head = Tail = null; // #1b
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next.Prev = null;
                Tail.Next = null;
            }

            Count--;
            return tailData;
        }

        public bool DeleteFromPosition(int position)
        {
            bool result = false;


            Count--; // should execute if position is deleted
            return result;
        }

        public bool Search(T data)
        {
            var tmp = Head;
            while (tmp != null)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, data) == 0)
                    return true;
                tmp = tmp.Next;
            }

            return false;
        }

        public Node<T> SearchForPosition(int position)
        {
            if (position > Count || position < 1) throw new IndexOutOfRangeException("Input out of bounds");
            if (position == 1)
            {
                return Head;
            }

            if (position == Count - 1)
            {
                return Tail;
            }

            var tmp = Head;
            var posCount = 1;
            while (tmp != Tail)
            {
                tmp = tmp.Next;
                posCount++;
                if (posCount == position)
                {
                    return tmp;
                }
            }

            return null;
        }

        public void SwapHeadAndTail()
        {
            var headData = RemoveFromHead();
            var tailData = RemoveFromTail();

            AddToHead(tailData);
            AddToTail(headData);
        }

        public bool Compare(ILinkedList<T> other)
        {
            var tmp = Head;
            var otherHead = other.Head;
            while (tmp != null)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, otherHead.Data) != 0)
                    return false;

                otherHead = otherHead.Next;
                tmp = tmp.Next;
            }

            return true;
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
    }
}
