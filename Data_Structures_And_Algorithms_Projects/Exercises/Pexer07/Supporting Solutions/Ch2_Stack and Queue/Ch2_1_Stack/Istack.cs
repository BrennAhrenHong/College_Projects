using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_1_Stack
{
    public interface IStack<T>
    {
        /// <summary>
        /// Push data unto the top of the stack
        /// </summary>
        /// <param name="data"> The data to push. Any type is acceptable.></param>
        void Push(T data);

        /// <summary>
        /// Removes the top of the stack
        /// </summary>
        /// <returns> Returns the data from the top of the stack</returns>
        T Pop();

        /// <summary>
        /// Looks at the data at the top of the stack without removing it.
        /// </summary>
        T Peek();

        bool IsEmpty { get; }

        /// <summary>
        /// Returns the number of items of the stack
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Clears the items of the stack
        /// </summary>
        void Clear();

        /// <summary>
        /// Checks if the items of the stack are equal in order and contents.
        /// </summary>
        bool HasSameContents(IStack<T> other, IComparer<T> comparer);

        /// <summary>
        /// Checks if the items of the stack are equal regardless of order.
        /// </summary>
        bool HasEquivalentContents(IStack<T> other, IComparer<T> comparer);

        /// <summary>
        /// Swaps the position of two items.
        /// </summary>
        void Swap(IStack<T> other);

        /// <summary>
        /// Inverses the stack.
        /// </summary>
        void Flip();

        /// <summary>
        /// Creates a copy of the stack starting from top to bottom.
        /// </summary>
        IStack<T> CloneTopToBottom();

        /// <summary>
        /// Creates a copy of the stack starting from bottom to top.
        /// </summary>
        IStack<T> CloneBottomToTop();

        /// <summary>
        /// Enables foreach.
        /// </summary>
        IEnumerator<T> GetEnumerator();
    }
}
