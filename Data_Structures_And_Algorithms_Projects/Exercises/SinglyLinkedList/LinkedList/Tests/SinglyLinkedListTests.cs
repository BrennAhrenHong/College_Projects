using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace LinkedList.Tests
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
            //s1.Head.Should().Be(s1.Tail.Data);
            s1.Head.Data.Should().Be("A");
            s1.Tail.Data.Should().Be("C");
        }

        [Test]
        public void AddToHead_Insert4Nodes_CheckNodeSequence()
        {
            //Arrange
            var s1 = new SinglyLinkedList();

            //Act
            s1.AddToHead("A");
            s1.AddToHead("B");
            s1.AddToHead("C");

            //Assert
            //s1.Head.Should().Be(s1.Tail);
            s1.Head.Data.Should().Be("C");
            s1.Head.Next.Data.Should().Be("B");
            s1.Head.Next.Next.Data.Should().Be("A");
        }

        [Test]
        public void SwapHeadAndTail()
        {
            // Arrange
            var s1 = new SinglyLinkedList();

            // Act
            s1.AddToHead("A");
            s1.AddToHead("B");
            s1.AddToHead("C");
            s1.SwapHeadAndTail();

            // Assert
            s1.Head.Data.Should().Be("C");
            s1.Tail.Data.Should().Be("A");

            //foreach (var s in s1)
            //{
            //    Console.WriteLine(s);
            //}
        }
    }
}
