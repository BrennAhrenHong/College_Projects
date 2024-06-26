using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace GenericLinkedList.Tests
{
    public class SinglyLinkedListTests
    {
        [Test]
        public void Initialize_EmptyLinkedList_NullHeadAndTail()
        {
            //Arrange
            var sl = new SinglyLinkedList();

            //Act
            
            //Assert
            Assert.Null(sl.Head, null);
            Assert.Null(sl.Tail, null);
        }

        [Test]
        public void AddToHead_Insert1Node_EqualHeadAndTail()
        {
            //Arrange
            var s1 = new SinglyLinkedList();

            //Act
            s1.AddToHead("A");
            s1.AddToTail("B");
            s1.AddToTail("C");

            //Assert
            s1.Head.Should().Be(s1.Tail);
            s1.Head.Data.Should().Be("A");
            s1.Tail.Data.Should().Be("B");
            s1.Tail.Next.Data.Should().Be("C");
        }

        [Test]
        public void GetEnumerator_Insert5Nodes_CheckNodeSequence()
        {
            // Arrange
            var sl = new SinglyLinkedList<int>();

            // Act
            sl.AddToHead(5);
            sl.AddToHead(4);
            sl.AddToHead(3);
            sl.AddToHead(2);
            sl.AddToHead(1);

            // store the correct sequence to check
            var correctSequence = new List<int> { 1, 2, 3, 4, 5 };

            // Assert
            var listToCheck = new List<int>();
            foreach (int i in sl)
            {
                listToCheck.Add(i);
            }

            listToCheck.Should().Equal(correctSequence);
        }

        [Test]
        public void GetEnumerator_Insert5Nodes_CheckIfHeadRemains()
        {
            // Arrange
            var sl = new SinglyLinkedList<int>();

            // Act
            sl.AddToHead(5);
            sl.AddToHead(4);
            sl.AddToHead(3);
            sl.AddToHead(2);
            sl.AddToHead(1);

            // simulate a loop to force call of GetEnumerator
            foreach (int i in sl)
            { }

            // Assert -- check if the Head of the linked list is still the same
            int expected = 1;

            sl.Head.Data.Should().Be(expected);
        }


        [Test]
        public void GetEnumerator_InsertNodes_CheckIfHeadRemains()
        {
            // Arrange
            var sl = new SinglyLinkedList<int>();

            // Act
            sl.AddToHead(5);
            sl.AddToHead(4);
            sl.AddToHead(3);
            sl.AddToHead(2);
            sl.AddToHead(1);

            // simulate a loop to force call
            var correctSequence = new List<int> { 1, 2, 3, 4, 5 };

            //Assert
            var listToCheck = new List<int>();
            foreach (var l in sl)
            {
                listToCheck.Add(l);
            }

        }


        [Test]
        public void Sampler()
        {
            var sl = new SinglyLinkedList<string>();
            sl.AddToHead("5");
            sl.AddToHead("4");
            sl.AddToHead("3");
            sl.AddToHead("2");
            sl.AddToHead("1");

            foreach (var link in sl)
            {
                Console.WriteLine($"Current Item: {link}");
            }
            
        }
    }
}
