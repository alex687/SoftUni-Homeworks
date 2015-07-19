namespace ArrayBasedStackTests
{
    using System;

    using ArrayBasedStack;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PushingElementShouldContainElement()
        {
            var stack = new ArrayStack<int>();

            stack.Push(6);

            Assert.IsTrue(stack.Peek() == 6, "The stack must contain 6.");
            Assert.IsTrue(stack.Count == 1, "The stack count must be 1.");
        }


        [TestMethod]
        public void PopElementShouldNotContainElement()
        {
            var stack = new ArrayStack<int>();

            stack.Push(6);
            stack.Pop();

            Assert.IsTrue(stack.Count == 0, "The stack count must be 0.");
        }

        [TestMethod]
        public void Push100ElementsShouldContainElements()
        {
            var stack = new ArrayStack<int>();

            for (int i = 0; i < 500; i++)
            {
                stack.Push(i);
            }

            Assert.IsTrue(stack.Count == 500, "The stack count must be 500.");
        }


        [TestMethod]
        public void Pop100ElementsShouldNotContainElements()
        {
            var stack = new ArrayStack<int>();

            for (int i = 0; i < 500; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 500; i++)
            {
                stack.Pop();
            }

            Assert.IsTrue(stack.Count == 0, "The stack count must be 0.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There was no exception when pop from empty stack.")]
        public void PopFromEmptyStackShotuldThrowException()
        {
            var stack = new ArrayStack<int>();

            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There was no exception when peek from empty stack.")]
        public void PeekFromEmptyStackShotuldThrowException()
        {
            var stack = new ArrayStack<int>();

            stack.Peek();
        }

        [TestMethod]
        public void PushElementFromStackWithCapacity1ShouldContainElement()
        {
            var stack = new ArrayStack<int>(1);

            stack.Push(6);

            Assert.IsTrue(stack.Peek() == 6, "The stack must contain 6.");
            Assert.IsTrue(stack.Count == 1, "The stack count must be 1.");
        }

        [TestMethod]
        public void PopElementFromStackWithCapacity1ShouldNotContainElement()
        {
            var stack = new ArrayStack<int>(1);

            stack.Push(6);
            stack.Pop();

            Assert.IsTrue(stack.Count == 0, "The stack count must be 0.");
        }

        [TestMethod]
        public void ConvertStackToArray()
        {
            var stack = new ArrayStack<int>();
            var exprectedArray = new int[] { 3, 4, 5, 6 };

            stack.Push(6);
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            var array = stack.ToArray();

            CollectionAssert.AreEqual(exprectedArray, array, "The array was wrong");
        }

        [TestMethod]
        public void ConvertEmptyStackToArray()
        {
            var stack = new ArrayStack<DateTime>();
            var exprectedArray = new DateTime[0];

            var array = stack.ToArray();
            CollectionAssert.AreEqual(exprectedArray, array, "The array was wrong");
        }
    }
}
