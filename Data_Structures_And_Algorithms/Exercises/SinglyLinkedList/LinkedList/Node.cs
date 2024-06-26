using System.Security.Policy;

namespace LinkedList
{
    public class Node
    {
        public Node(string data, Node next)
        {
            Data = data;
            Next = next;
        }

        public Node(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        public Node Next { get; set; }
    }
}