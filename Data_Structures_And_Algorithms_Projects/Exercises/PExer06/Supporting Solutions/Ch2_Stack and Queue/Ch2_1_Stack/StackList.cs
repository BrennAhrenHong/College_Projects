using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDoublyLinkedList;

namespace Ch2_1_Stack
{
    public class StackList<T> : IStack<T>
    {
        private IDoublyLinkedList<T> _items;


        public StackList()
        {
            _items = new MyGenericDoublyLinkedList<T>();
        }

        //public int Count { get; }

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
            //
            var anotherList = new MyGenericDoublyLinkedList<T>();
            _items = anotherList;
        }

        public bool HasSameContents(IStack<T> other, IComparer<T> comparer)
        {
            if (Count != other.Count)
                return false;
            if (Count == 0 && other.Count == 0)
                return true;
            if (comparer == null)
                comparer = (IComparer<T>) Comparer<T>.Default;

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

        public bool HasEquivalentContents(IStack<T> other, IComparer<T> comparer)
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
                        if ((uint) comparer.Compare(tmp1.Data, tmp2.Data) > 0U)
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

        public IStack<T> CloneTopToBottom()
        {
            StackList<T> clonedList = new StackList<T>();

            var tmp = _items;
            tmp.Reverse();

            foreach (var item in tmp)
            {
                clonedList.Push(item);
            }

            return clonedList;
        }

        public IStack<T> CloneBottomToTop()
        {
            var tmp = _items;

            StackList<T> clonedList = new StackList<T>();

            foreach (var item in tmp)
            {
                clonedList.Push(item);
            }

            return clonedList;
        }

        public void Swap(IStack<T> other)
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
                other.Pop();
            }

            foreach (var item in tmp2)
            {
                other.Push(item);
            }
        }

        public void Flip()
        {
            _items.Reverse();
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException(message: "Stack is empty");
            var nodeData = _items.Head.Data;
            _items.RemoveFromHead();
            return nodeData;
        }

        public void Push(T data)
        {
            _items.AddToHead(data);
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException(message: "Stack is empty");
            var nodeData = _items.Head.Data;
            return nodeData;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }


        //public bool IsEmpty { get; } = _items.Count == 0;


        
    }
}
