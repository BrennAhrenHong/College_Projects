using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDoublyLinkedList;

namespace Ch2_Queue
{
    public class QueueList<T> : IQueue<T>
    {
        private IDoublyLinkedList<T> _items;
        public QueueList()
        {
            _items = new MyGenericDoublyLinkedList<T>();
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (_items.Count == 0)
                    return true;
                else
                    return false;
            }
        }

        public void Clear()
        {
            var anotherList = new MyGenericDoublyLinkedList<T>();
            _items = anotherList;
        }

        public IQueue<T> CloneLeftToRight()
        {
            QueueList<T> clonedList = new QueueList<T>();

            foreach (var item in _items)
            {
                clonedList.Enqueue(item);
            }

            return clonedList;
        }

        public IQueue<T> CloneRightToLeft()
        {
            var tmp = _items;
            tmp.Reverse();

            QueueList<T> clonedList = new QueueList<T>();

            foreach (var item in tmp)
            {
                clonedList.Enqueue(item);
            }

            return clonedList;
        }

        public T Dequeue()
        {
            var nodeData = _items.Head.Data;
            _items.RemoveFromHead();
            return nodeData;
        }

        public void Enqueue(T data)
        {
            _items.AddToTail(data);
        }

        public void Flip()
        {
            _items.Reverse();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool HasSameContents(IQueue<T> other, IComparer<T> comparer)
        {
            if (Count != other.Count)
                return false;
            if (Count == 0 && other.Count == 0)
                return true;
            if (comparer == null)
                comparer = (IComparer<T>)Comparer<T>.Default;

            var tmpList = new MyGenericDoublyLinkedList<T>();
            foreach (var x in other)
            {
                tmpList.AddToTail(x);
            }

            var tmp1 = _items.Head;
            var tmp2 = tmpList.Head;
            while (tmp1 != _items.Tail)
            {
                if ((uint)comparer.Compare(tmp1.Data, tmp2.Data) > 0U)
                    return false;
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return (uint)comparer.Compare(_items.Tail.Data, tmpList.Tail.Data) <= 0U;
        }

        public bool HasEquivalentContents(IQueue<T> other, IComparer<T> comparer)
        {
            if (Count == 0 && other.Count == 0)
                return true;
            if (comparer == null)
                comparer = (IComparer<T>)Comparer<T>.Default;

            var tmpList = new MyGenericDoublyLinkedList<T>();
            foreach (var x in other)
            {
                tmpList.AddToHead(x);
            }

            var tmp1 = _items.Head;
            var tmp2 = tmpList.Head;
            while (tmp1.Next != null)
            {
                while ((uint)comparer.Compare(tmp1.Data, tmp2.Data) > 0U)
                {
                    if (tmp2.Next == null)
                    {
                        if ((uint)comparer.Compare(tmp1.Data, tmp2.Data) > 0U)
                            return false;
                        break;
                    }
                    tmp2 = tmp2.Next;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmpList.Head;
            }
            while ((uint)comparer.Compare(tmp1.Data, tmp2.Data) > 0U)
            {
                if (tmp2.Next == null)
                {
                    if ((uint)comparer.Compare(tmp1.Data, tmp2.Data) > 0U)
                        return false;
                    break;
                }
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public T Peek()
        {
            return _items.Head.Data;
        }

        public void Swap(IQueue<T> other)
        {
            var tmp = new MyGenericDoublyLinkedList<T>();
            var tmp2 = _items; //Original content of first stack

            foreach (var item in other) //Adding other stacklist to doublylinkedlist
            {
                tmp.AddToTail(item);
            }

            _items = tmp; //Content of second stack overwriting the old.

            while (other.Count > 0)
            {
                other.Dequeue();
            }

            foreach (var item in tmp2)
            {
                other.Enqueue(item);
            }
        }
    }
}
