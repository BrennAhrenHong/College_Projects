using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace DoublyLinkedList.Tests
{
    public class DoublyLinkedListTests
    {
        [Test]
        public void AddToHead_Insert4Nodes_CheckNodeSequence()
        {
            // Arrange
            var sl = new DoublyLinkedList<string>();

            // Act
            sl.AddToHead("D");
            sl.AddToHead("C");
            sl.AddToHead("B");
            sl.AddToHead("A");

            // Assert
            sl.Head.Prev.Should().BeNull();
            sl.Tail.Next.Should().BeNull();

            sl.Head.Next.Data.Should().Be("B");
            sl.Tail.Prev.Data.Should().Be("C");
        }

        [Test]
        public void AddToHead_Insert10Nodes_CheckNodeSequence()
        {
            // Arrange
            var sl = new DoublyLinkedList<int>();

            // Act
            for (int i = 0; i < 10; i++)
            {
                sl.AddToHead(i);
            } // Head should have a data of 9

            // Assert
            var expected = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            var nodeSequence = new List<int>();
            foreach (int i in sl)
            {
                nodeSequence.Add(i);
            }

            nodeSequence.Should().Equal(expected);
        }

        [Test]
        public void RemoveFromHead_EmptyList_ShouldThrowError()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            Action act = () => list.RemoveFromHead();

            act.Should().Throw<Exception>().WithMessage("Cannot remove from head " + "from an empty list.");
        }

        [Test]
        public void RemoveFromHead_List4Nodes_CheckSequence()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddToTail(1);
            list.AddToTail(2);
            list.AddToTail(3);
            list.AddToTail(4);

            // Act
            var removed = list.RemoveFromHead();
            var expected = new List<int> {2, 3, 4};

            var nodes = new List<int>();

            foreach (var i in list)
            {
                nodes.Add(i);
            }

            nodes.Should().Equal(expected);
            removed.Should().Be(1);
        }

        [Test]
        public void RemoveFromTail_EmptyList_ShouldThrowError()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();

            // Act
            Action act = () => list.RemoveFromTail();

            act.Should().Throw<Exception>().WithMessage("Cannot remove from tail " + "from an empty list.");
        }

        [Test]
        public void PersonStuff()
        {
            // Arrange
            var list = new DoublyLinkedList<Person>();
            list.AddToTail(new Person("Brenn", 20));
            //list.AddToTail(2);
            //list.AddToTail(3);
            //list.AddToTail(4);

            // Act
            var removed = list.RemoveFromHead();
            var expected = new List<int> { 2, 3, 4 };

            var nodes = new List<int>();

            nodes.Should().Equal(expected);
        }

        [Test]
        public void TestingCompareIfItWorks()
        {
            // Arrange
            var list = new DoublyLinkedList<Person>();
            var anotherlist = new DoublyLinkedList<Person>();

            list.AddToTail(new Person("Brenn", 21));
            list.AddToTail(new Person("Yoshi", 20));
            list.AddToTail(new Person("Cedrick", 19));
            list.AddToTail(new Person("Mecca", 20));
            list.AddToTail(new Person("Noel", 20));

            anotherlist.AddToTail(new Person("Brenn", 21));
            anotherlist.AddToTail(new Person("Yoshi", 20));
            anotherlist.AddToTail(new Person("Cedrick", 19));
            anotherlist.AddToTail(new Person("Mecca", 20));
            anotherlist.AddToTail(new Person("Noel", 20));

            // Act

            // Assert
            list.Compare(anotherlist).Should().BeTrue();
        }

        [Test]
        public void SearchMethodTesting()
        {
            // Arrange
            var list = new DoublyLinkedList<Person>();
            var anotherlist = new DoublyLinkedList<Person>();

            var z = new Person("Mecca", 20);

            list.AddToTail(new Person("Brenn", 21));
            list.AddToTail(new Person("Yoshi", 20));
            list.AddToTail(new Person("Cedrick", 19));
            list.AddToHead(z);
            //list.AddToHead(new Person("Mecca", 20));
            list.AddToHead(new Person("Noel", 20));

            anotherlist.AddToTail(new Person("Brenn", 21));
            anotherlist.AddToTail(new Person("Yoshi", 20));
            anotherlist.AddToTail(new Person("Cedrick", 19));
            anotherlist.AddToTail(new Person("Mecca", 20));
            anotherlist.AddToTail(new Person("Noel", 20));


            // Act

            // Assert
            var expected = list.Head.Next.Next;
            //list.SearchForPosition(2).Should().Be(expected);
        }
    }
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            if (Name == other.Name && Age == other.Age) return 0;
            else return 1;
        }
    }
}
