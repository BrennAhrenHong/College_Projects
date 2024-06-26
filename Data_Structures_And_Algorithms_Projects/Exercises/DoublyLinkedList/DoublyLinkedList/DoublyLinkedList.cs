using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        //TODO
        //AddToTail(); Check
        //RemoveFromHead(); Check
        //RemoveFromTail(); Check
        //bool DeleteFromPosition(int position) Check
        //bool Search (T data) Check
        //Node SearchForPosition(int position)
        //SwapHeadAndTail()
        //Compare(DoublyLinkedList other);
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }
        public void AddToHead(T data)
        {
            var tmp = new Node<T>(data); // #1

            if (Head == null)
            {
                Head = Tail = tmp;
            }
            else
            {
                Head.Prev = tmp;             // #2
                tmp.Next = Head;             // #3
                Head = tmp;
            }

            Count++;
        }

        public void AddToTail(T data)
        {
            var tmp = new Node<T>(data);

            if (Head == null)
                Head = Tail = tmp;
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
            if(Head == null) throw new Exception("Cannot remove from head " + "from an empty list.");

            if (Head == Tail) //#1
            {
                var headData = Head.Data;
                Head = Tail = null;
                Count--;

                return headData;
            }
            else
            {
                var headData = Head.Data;
                Head = Head.Next;
                Head.Prev.Next = null;
                Head.Prev = null;
                Count--;

                return headData;
            }

            // --------------------------------
            // #1 List only has one node
            // #1a get a copy of the head data
        }

        public T RemoveFromTail()
        {
            if (Head == null) throw new Exception("Cannot remove from tail " + "from an empty list.");
            
            var tailData = Tail.Data;
            if (Tail == Head) //#1
            {
                Tail = Head = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Prev.Next = null;
                Tail.Next = null;
            }
            Count--;
            return tailData;

            // --------------------------------
            // #1 List only has one node
            // #1a get a copy of the head data
        }

        public bool DeleteFromPosition(int position)
        {
            if (position > Count || position < 1)
                return false;
            if (position == 1)
            {
                RemoveFromHead();
                Count--;
                return true;
            }
            if (position == Count - 1)
            {
                RemoveFromTail();
                Count--;
                return true;
            }

            var tmp = Head;
            var posCount = 0;
            while (tmp != Tail)
            {
                tmp = tmp.Next;
                posCount++;
                if (posCount == position)
                {
                    tmp.Prev.Next = tmp.Next;
                    tmp.Next.Prev = tmp.Prev;
                    tmp.Prev = null;
                    tmp.Next = null;
                    Count--;

                    return true;
                }
            }

            return false;
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
            if (Count < 2)
                return;
            var tmp = Head;
            var tmp2 = Tail;
            
            RemoveFromHead();
            RemoveFromTail();

            AddToHead(tmp2.Data);
            AddToTail(tmp.Data);
        }

        public bool Compare(DoublyLinkedList<T> other)
        {
            if (Count != other.Count)
                return false;

            if (Count == 0 && other.Count == 0)
                return true;

            var  thisList = Head;
            var otherList = other.Head;

            while (thisList != null)
            {
                if (Comparer<T>.Default.Compare(thisList.Data, otherList.Data) == 1)
                    return false;
                thisList = thisList.Next;
                otherList = otherList.Next;
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
