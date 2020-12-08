using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_T;

namespace Project_T_Testing
{
     [TestClass]
    public class UnitTest
    {
        SingleList<int> list = new SingleList<int>();

        [TestMethod]
        public void TestAddFirst()
        {
            //Assign

            //Act
            list.AddFirst(1);
            list.AddFirst(2);

            //Assert
            Assert.AreEqual(2, list[0].Data);
        }

        [TestMethod]
        public void TestCount()
        {
            //Assign
            list.AddFirst(2);
            list.AddFirst(3);

            //Act

            //Assert
            Assert.AreEqual(2, list.Count());
        }

        [TestMethod]
        public void TestAddLast()
        {
            //Assign

            //Act
            list.AddLast(1);
            list.AddLast(2);

            //Assert
            Assert.AreEqual(1, list[0].Data);
        }
        [TestMethod]
        public void TestClear()
        {
            //Assign
            list.AddLast(1);
            list.AddLast(2);

            //Act
            list.Clear();

            //Assert
            Assert.IsNull(list[0]);
            Assert.AreEqual(list.Count(), 0);
        }
        [TestMethod]
        public void TestContains()
        {
            //Assign
            list.AddLast(1);
            list.AddLast(2);

            //Act

            //Assert
            Assert.IsTrue(list.Contains(2));
            Assert.IsFalse(list.Contains(3));
        }
        [TestMethod]
        public void TestFind()
        {
            //Assign
            list.AddFirst(1);
            list.AddFirst(2);
            var node = list.AddFirst(3);

            //Act
            var testFound = list.Find(3);

            //Assert
            Assert.AreEqual(node, testFound);
            Assert.IsNull(list.Find(4));
        }
        [TestMethod]
        public void TestRemoveNode()
        {
            //Assign
            list.AddFirst(1);
            var node = list.AddLast(2);

            //Act
            list.Remove(node);

            //Assert
            Assert.AreEqual(1, list.Count());
        }
        [TestMethod]
        public void TestRemove()
        {
            //Assign
            list.AddFirst(3);
            list.AddFirst(1);
            
            list.AddFirst(2);


            //Act
            list.Remove(3);

            //Assert
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(false, list.Contains(3));

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveArgumentNullException()
        {
            //Assign

            //Act
            list.Remove(null);
            //Assert
        }
        [TestMethod]
        public void TestGetEnumerator()
        {
            //Assign
            list.AddFirst(1);
            list.AddLast(2);

            //Act
            IEnumerator<Node<int>> i = list.GetEnumerator();

            //Assert
            i.MoveNext();
            Assert.AreEqual(i.Current.Data, 1);
            i.MoveNext();
            Assert.AreEqual(i.Current.Data, 2);
        }
        [TestMethod]
        public void TestGet()
        {
            //Assign
            list.AddFirst(1);
            var node = list.AddLast(2);

            //Act
            var testCurrent = list.Get(2);
            list.Clear();
            var testNull = list.Get(1);

            //Assert
            Assert.AreEqual(testCurrent, node);
            Assert.IsNull(testNull);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetArgumentOutOfRangeException()
        {
            //Assign

            //Act
            list.Get(-1);
            //Assert
        }
    }
}
