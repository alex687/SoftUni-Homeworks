namespace LinkedQueueTests
{
    using System;

    using LinkedQueue;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void EnqueueingElementShouldContainElement()
        {
            var stack = new LinkedQueue<int>();

            stack.Enqueue(6);

            Assert.IsTrue(stack.Peek() == 6, "The stack must contain 6.");
            Assert.IsTrue(stack.Count == 1, "The stack count must be 1.");
        }


        [TestMethod]
        public void DequeueElementShouldNotContainElement()
        {
            var stack = new LinkedQueue<int>();

            stack.Enqueue(6);
            stack.Dequeue();

            Assert.IsTrue(stack.Count == 0, "The stack count must be 0.");
        }

        [TestMethod]
        public void Enqueue100ElementsShouldContainElements()
        {
            var stack = new LinkedQueue<int>();

            for (int i = 0; i < 500; i++)
            {
                stack.Enqueue(i);
            }

            Assert.IsTrue(stack.Count == 500, "The stack count must be 500.");
        }


        [TestMethod]
        public void Dequeue100ElementsShouldNotContainElements()
        {
            var stack = new LinkedQueue<int>();

            for (int i = 0; i < 500; i++)
            {
                stack.Enqueue(i);
            }

            for (int i = 0; i < 500; i++)
            {
                stack.Dequeue();
            }

            Assert.IsTrue(stack.Count == 0, "The stack count must be 0.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There was no exception when Dequeue from empty stack.")]
        public void DequeueFromEmptyStackShotuldThrowException()
        {
            var stack = new LinkedQueue<int>();

            stack.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There was no exception when peek from empty stack.")]
        public void PeekFromEmptyStackShotuldThrowException()
        {
            var stack = new LinkedQueue<int>();

            stack.Peek();
        }
    }
}
