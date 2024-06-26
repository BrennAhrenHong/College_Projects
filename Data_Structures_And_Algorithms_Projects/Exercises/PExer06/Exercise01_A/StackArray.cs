using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ch2_1_Stack;

namespace Exercise01_A
{
    public class StackArray<T> : IStack<T>
    {


        private T[] _items;

        private int availableIndex;

        private int max;

        public int Count
        {
            get
            {
                return availableIndex + 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (availableIndex + 1 == 0)
                    return true;
                else
                    return false;
            }
        }

        public StackArray(int size)
        {
            _items = new T[size];
            max = size;
            availableIndex = -1;
        }

        public StackArray()
        {
            _items = new T[20];
            max = 20;
            availableIndex = -1;
        }

        public void Clear()
        {
            //var anotherList = new MyGenericDoublyLinkedList<T>();
            _items = Array.Empty<T>();
        }

        public void Flip()
        {
            _items.Reverse();
        }

        public bool HasEquivalentContents(IStack<T> other, IComparer<T> comparer)
        {
            if (Count == 0 && other.Count == 0)
                return true;
            if (comparer == null)
                comparer = (IComparer<T>)Comparer<T>.Default;

            var otherArray = new T[50];

            int counter = 0;
            foreach (var x in other)
            {
                otherArray[counter] = x;
                counter++;
            }

            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < other.Count; j++)
                {
                    if (otherArray[i].Equals(_items[j]))
                    {
                        break;
                    }

                    if (j == other.Count - 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool HasSameContents(IStack<T> other, IComparer<T> comparer)
        {
            if (Count != other.Count)
                return false;
            if (Count == 0 && other.Count == 0)
                return true;
            if (comparer == null)
                comparer = (IComparer<T>)Comparer<T>.Default;

            var otherArray = new T[50];

            int counter = 0;
            foreach (var x in other)
            {
                otherArray[counter] = x;
                counter++;
            }

            for (int i = 0; i < Count; i++)
            {
                if (!otherArray[i].Equals(_items[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public IStack<T> CloneTopToBottom()
        {
            StackArray<T> clonedArray = new StackArray<T>();

            foreach (var item in _items)
            {
                clonedArray.Push(item);
            }

            return clonedArray;
        }

        public IStack<T> CloneBottomToTop()
        {
            var tmp = _items;
            tmp.Reverse();

            StackArray<T> clonedArray = new StackArray<T>();

            foreach (var item in tmp)
            {
                clonedArray.Push(item);
            }

            return clonedArray;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException(message: "Stack is empty");

            return _items[availableIndex - 1];
        }

        public void Push(T data)
        {
            if(availableIndex != max)
                _items[++availableIndex] = data;
            else
                throw new InvalidOperationException("Maximum size reached");
        }

        public void Swap(IStack<T> other)
        {
            var tmp = _items;

            var otherArray = new T[other.Count];
            int counter = 0;
            foreach (var item in other)
            {
                otherArray[counter] = item;
                counter++;
            }

            _items = otherArray;

            otherArray = tmp;
            foreach (var item in otherArray)
            {
                other.Push(item);
            } 

        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var a in _items)
            {
                yield return a;
            }
        }

        public T Peek()
        {
            return _items[availableIndex];
        }
    }
}
