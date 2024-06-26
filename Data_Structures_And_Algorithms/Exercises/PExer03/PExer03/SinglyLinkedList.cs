using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;

namespace PExer03
{
    public class SinglyLinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Count { get; private set; }

        public IEnumerator GetEnumerator()
        {
            if (Head == null) yield break;

            var tmp = Head;
            while (tmp != Tail)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
            yield return Tail.Data;

        }

        public void AddToHead(string data)
        {
            var tmp = new Node(data);
            tmp.Next = Head;
            if (Head == null)
            {
                Head = Tail = tmp;
            }
            else
                Head = tmp;

            Count++;

            #region OldCode

            //var x = new Node(data);
            //Count++;
            //if (Head == null)
            //{
            //    Head = x;
            //    Tail = x;
            //    return;
            //}

            //var tmp = Head;
            //Head = x;
            //Head.Next = tmp;

            #endregion

        }

        public void AddToTail(string data)
        {
            var tmp = new Node(data);
            if (Tail == null)
                Head = Tail = tmp;
            else
            {
                Tail.Next = tmp;
                Tail = tmp;
            }

            Count++;
        }

        public void RemoveFromHead()
        {
            var tmp = Head;
            Head = tmp.Next;
        }

        public void RemoveFromTail()
        {
            var tmp = Head;

            while (tmp.Next != Tail) 
                tmp = tmp.Next;

            Tail = tmp;
        }

        public bool DeleteFromPosition(int position)
        {
            var prev = Head;
            var pos1 = 0;
            var tmp = Head;

            if (position - 1 == Count)
            {
                RemoveFromTail();
                return true;
            }
            else if (position == 1)
            {
                RemoveFromHead();
                return true;
            }

            if (position - 1 < Count)
            {
                while (tmp != Tail)
                {
                    if (pos1 == position - 1)
                        prev.Next = tmp.Next;

                    tmp = tmp.Next;
                    if (pos1 > 0)
                        prev = prev.Next;
                    pos1++;
                }

                Count--;

                return true;
            }
            return false;
        }

        public bool Search(string data)
        {
            var tmp = Head;

            if (Head.Data == data)
                return true;
            else if (Tail.Data == data)
                return true;

            while (tmp.Next != Tail)
            {
                if (tmp.Data == data)
                    return true;

                tmp = tmp.Next;
            }

            return false;
        }


        public Node SearchForPosition(int position)
        {
            var prev = Head;
            var pos1 = 0;
            var tmp = Head;

            if (position - 1 == Count)
                return Tail;
            else if (position == 1)
                return Tail;


            if (position - 1 < Count)
            {
                while (tmp != Tail)
                {
                    if (pos1 == position - 1)
                        return tmp;

                    tmp = tmp.Next;
                }
            }
            return null;
        }

        public void SwapHeadAndTail()
        {
            var headData = Head.Data;
            var tailData = Tail.Data;

            RemoveFromHead();
            RemoveFromTail();

            AddToTail(headData);
            AddToHead(tailData);
        }

        public bool Compare(SinglyLinkedList other)
        {
            if (Count != other.Count)
                return false;

            var tmp1 = Head;
            var tmp2 = other.Head;

            while (tmp1 != null && tmp2 != null)
            {
                if (tmp1 != tmp2)
                    return false;


                tmp2 = tmp2.Next;
                tmp1 = tmp1.Next;
            }
            return false;
        }
    }
}