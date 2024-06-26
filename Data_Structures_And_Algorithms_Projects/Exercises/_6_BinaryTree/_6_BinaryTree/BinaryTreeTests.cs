using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace _6_BinaryTree
{
    public class BinaryTreeTests
    {
        [Test]
        public void Insert_DefineData_CheckForHierarchy()
        {
            //Arrange
            var bt = new BinaryTree<int>();
            var dataToInsert = new List<int> {10,8,3,5};

            //Act
            foreach (int s in dataToInsert)
            {
                bt.Insert(s);
            }

            //Assert
            var root = bt.Root;
            var leftOfRoot = bt.Root.Left;
            var rightOfRoot = bt.Root.Right;
            var leftOfLevel2 = bt.Root.Left.Left;
            var rightOfLevel2 = bt.Root.Left.Right;
            var leftOfLevel3 = bt.Root.Left.Left;
            var rightOfLevel3 = bt.Root.Left.Left.Right;

            root.Data.Should().Be(10);
            leftOfRoot.Data.Should().Be(8);
            rightOfRoot.Should().BeNull();
            leftOfLevel2.Data.Should().Be(3);
            rightOfLevel2.Should().BeNull();
            leftOfLevel3.Left.Should().BeNull();
            rightOfLevel3.Data.Should().Be(5);
        }
        [Test]
        public void Insert_DefineData_CheckForHierarchyForParent()
        {
            //Arrange
            var bt = new BinaryTree<int>();
            var dataToInsert = new List<int> { 10, 8, 3, 5 };

            //Act
            foreach (int s in dataToInsert)
            {
                bt.Insert(s);
            }
            /* -----------Binary Tree Visual -------------
                    10
                   /
                  8
                 /
                3
                 \
                  5
             
            */

            //Assert
            var root = bt.Root;
            var leftOfRoot = bt.Root.Left;
            var rightOfRoot = bt.Root.Right;
            var leftOfLevel2 = bt.Root.Left.Left;
            var rightOfLevel2 = bt.Root.Left.Right;
            var leftOfLevel3 = bt.Root.Left.Left;
            var rightOfLevel3 = bt.Root.Left.Left.Right;

            //parents
            var parentOfRoot = bt.Root.Parent;
            var parentOfLeftLevel2 = bt.Root.Left.Parent;
            var parentOfRightLevel2 = bt.Root.Right;
            var parentOfLeftLevel3 = bt.Root.Left.Left.Parent;
            var parentOfRightLevel3 = bt.Root.Left.Right;
            var parentOfLeftLevel4 = bt.Root.Left.Left.Left;
            var parentOfRightLevel4 = bt.Root.Left.Left.Right.Parent;

            root.Data.Should().Be(10);
            leftOfRoot.Data.Should().Be(8);
            rightOfRoot.Should().BeNull();
            leftOfLevel2.Data.Should().Be(3);
            rightOfLevel2.Should().BeNull();
            leftOfLevel3.Left.Should().BeNull();
            rightOfLevel3.Data.Should().Be(5);

            parentOfRoot.Should().BeNull();
            parentOfLeftLevel2.Data.Should().Be(10);
            parentOfRightLevel2.Should().BeNull();
            parentOfLeftLevel3.Data.Should().Be(8);
            parentOfRightLevel3.Should().BeNull();
            parentOfLeftLevel4.Should().BeNull();
            parentOfRightLevel4.Data.Should().Be(3);
        }

        [TestCase("10,8,3,5", "10,8,3,5")]
        [TestCase("10,7,5,8,3,4,1", "10,7,5,8,3,1,4")]
        public void BreadthFirst_GivenData_CheckTraversal(string data, string expected)
        {
            // Arrange
            var bt = new BinaryTree<int>();
            var dataToInsert = data.Split(',');
            var expectedData = expected.Split(',');
            var qExpected = new Queue<int>();


            foreach (string s in dataToInsert)
            {
                var x = int.Parse(s);
                bt.Insert(x);
            }

            foreach(string s in expectedData)
            {
                var x = int.Parse(s);
                qExpected.Enqueue(x);
            }
            // Act
            var result = bt.BreadthFirst();

            // Assert
            result.Should().Equal(qExpected);
        }

        [TestCase("Word,Fake,True,Work,Meet,Bryan", "Word,Fake,Work,Bryan,True,Meet")]
        [TestCase("Carrot,Potato,Garlic,Onion,Beef,Tomato", "Carrot,Beef,Potato,Garlic,Tomato,Onion")]
        public void BreadthFirst_GivenDataInString_CheckTraversal(string data, string expected)
        {
            // Arrange
            var bt = new BinaryTree<string>();
            var dataToInsert = data.Split(',');
            var expectedData = expected.Split(',');
            var qExpected = new Queue<string>();

                
            foreach (string s in dataToInsert)
            {
                bt.Insert(s);
            }

            foreach (string s in expectedData)
            {
                qExpected.Enqueue(s);
            }
            // Act
            var result = bt.BreadthFirst();

            // Assert
            result.Should().Equal(qExpected);
        }

        [TestCase("Word,Fake,True,Work,Meet,Bryan", "Word,Fake,Work,Bryan,True,Meet")]
        [TestCase("Carrot,Potato,Garlic,Onion,Beef,Tomato", "Carrot,Beef,Potato,Garlic,Tomato,Onion")]
        public void PreOrder_GivenDataInString_CheckTraversal(string data, string expected)
        {
            // Arrange
            var bt = new BinaryTree<string>();
            var dataToInsert = data.Split(',');
            var expectedData = expected.Split(',');
            var qExpected = new Queue<string>();


            foreach (string s in dataToInsert)
            {
                bt.Insert(s);
            }

            foreach (string s in expectedData)
            {
                qExpected.Enqueue(s);
            }

            // Act
            var result = bt.PreOrder();


            // Assert
            result.Should().Equal(qExpected);
        }
    }
}
