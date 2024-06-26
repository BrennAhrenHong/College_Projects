using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch2_Queue;

namespace Exercise01_B
{
    public class QueueArray<T> : IQueue<T>
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

        public QueueArray(int size)
        {
            _items = new T[size];
            max = size;
            availableIndex = -1;
        }

        public QueueArray()
        {
            _items = new T[20];
            max = 20;
            availableIndex = -1;
        }

        public void Clear()
        {
            _items = Array.Empty<T>();
        }

        public IQueue<T> CloneLeftToRight()
        {
            QueueArray<T> clonedArray = new QueueArray<T>();

            foreach (var item in _items)
            {
                clonedArray.Enqueue(item);
            }

            return clonedArray;
        }

        public IQueue<T> CloneRightToLeft()
        {
            var tmp = _items;
            tmp.Reverse();

            QueueArray<T> clonedArray = new QueueArray<T>();

            foreach (var item in tmp)
            {
                clonedArray.Enqueue(item);
            }

            return clonedArray;
        }

        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException(message: "Stack is empty");

            var tmp = new T[Count];

            tmp = _items;
            availableIndex--;
            for (int i = 0; i < availableIndex; i++)
            {
                _items[i] = tmp[i + 1];
            }
            

            return tmp[0];
        }

        public void Enqueue(T data)
        {
            if (availableIndex != max)
                _items[++availableIndex] = data;
            else
                throw new InvalidOperationException("Maximum size reached");
        }

        public void Flip()
        {
            _items.Reverse();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var a in _items)
            {
                yield return a;
            }
        }

        public bool HasEquivalentContents(IQueue<T> other, IComparer<T> comparer)
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

        public bool HasSameContents(IQueue<T> other, IComparer<T> comparer)
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

        public T Peek()
        {
            return _items[0];
        }

        public void Swap(IQueue<T> other)
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
                other.Enqueue(item);
            }
        }
    }
}