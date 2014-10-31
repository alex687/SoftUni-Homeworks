namespace CustomLinkedList.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        public void AddingElementShouldContain()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(6);

            Assert.IsTrue(list.Contains(6), "The list must contain 6.");
        }

        [TestMethod]
        public void AddingNewElementsThreeTimesCountShouldBeThree()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(3, list.Count, "The counter is not 3");
        }

        [TestMethod]
        public void CreatingEmptyListCountShouldBeZero()
        {
            var list = new DynamicList<int>();

            Assert.AreEqual(0, list.Count, "The counter is not null at the init.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "There was no exception when incorrect index was given.")]    
        public void GetElementWithIncorrectIndexShoudThrowArgumentNullException()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            int element = list[2];
        }

        [TestMethod]
        public void GetElementWithIndexShoudReturnElement()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            int element = list[0];

            Assert.AreEqual(2, element, "The return element is not corrent it must be - 2 but was returned " + element);
        }

        [TestMethod]
        public void IndexOfElementShoudReturnCorrenctIndex()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            int index = list.IndexOf(6);

            Assert.AreEqual(1, index, "The returned index is not correct must be 1 instead its " + index);
        }

        [TestMethod]
        public void IndexOfNonExistingElementShoudReturnMinusOne()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            int index = list.IndexOf(7);

            Assert.AreEqual(
                -1, 
                index, 
                "The returned index is not correct must be -1(Not found number) instead its " + index);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "There was no exception when incorrect index was given.")]
        public void RemoveAtIncorrectIndexShoudThrowArgumentNullException()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            list.RemoveAt(2);
        }

        [TestMethod]
        public void RemoveAtIndexShoudReturnRemovedElement()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            int item = list.RemoveAt(0);

            Assert.AreEqual(2, item, "The returned element is not correct must be 2 instead its " + item);
        }

        [TestMethod]
        public void RemovingAnElementShouldReturnIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(6);
            int index = list.Remove(1);

            Assert.AreEqual(0, index, "The returned index is not correct.Must be 0 but was returned " + index);
        }

        [TestMethod]
        public void RemovingAnElementTheCounterShoudBe2()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(6);
            int index = list.Remove(1);

            Assert.AreEqual(2, list.Count, "The counter is not correct.Must be 2 but its " + list.Count);
        }

        [TestMethod]
        public void RemovingAnNonExistingElementSouldReturnMinusOne()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            int index = list.Remove(1);

            Assert.AreEqual(-1, index, "Did not return -1");
        }

        [TestMethod]
        public void RemovingElementSouldRemoveTheElement()
        {
            var list = new DynamicList<int>();
            list.Add(2);
            list.Add(6);
            list.Add(3);
            list.Add(8);
            list.Add(4);

            int index = list.Remove(3);

            bool contains = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == 3)
                {
                    contains = true;
                }
            }

            Assert.IsFalse(contains, "The element was not removed");
        }

        [TestMethod]
        public void ShoudNotContainElement()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);

            Assert.IsFalse(list.Contains(6), "The list must not contain 6.");
        }
    }
}