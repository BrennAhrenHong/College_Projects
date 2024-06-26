using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T data);
        T Dequeue();
        T Peek();
        int Count { get; }
        bool IsEmpty { get; }
        void Clear();
        bool HasSameContents(IQueue<T> other, IComparer<T> comparer);
        bool HasEquivalentContents(IQueue<T> other, IComparer<T> comparer);
        void Swap(IQueue<T> other);
        void Flip();
        IQueue<T> CloneLeftToRight();
        IQueue<T> CloneRightToLeft();

        IEnumerator<T> GetEnumerator();
    }
}
