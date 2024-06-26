using System;
using System.Collections.Generic;
using System.Text;

namespace _2_StackAndQueue
{
    class Stack<T>
    {
        private DoublyLinkedList<T> _nodes;

        public Stack()
        {
            _nodes = new DoublyLinkedList<T>();
        }

        public void Push(T element)
        {
            _nodes.AddToHead(element);
        }

        public T Pop()
        {
            // throw an error if linked list is empty
            if (_nodes.Size <= 0) throw new Exception("Unable to Pop from an empty stack.");

            return _nodes.RemoveFromHead();
        }

        public T Peek()
        {
            // throw an error if linked list is empty
            if (_nodes.Size <= 0) throw new Exception("Unable to Pop from an empty stack.");

            return _nodes.Head.Data;
        }

        public bool IsEmpty => _nodes.Size == 0;

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var node in _nodes)
            {
                sb.Append(node + ",");
            }
            return sb.ToString();
        }
    }
}
