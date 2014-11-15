using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace TestMatrix
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroDimentionsTest()
        {
            ActualMatrix matrix = new ActualMatrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeDimentionsTest()
        {
            ActualMatrix matrix = new ActualMatrix(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooBigDimentionsTest()
        {
            ActualMatrix matrix = new ActualMatrix(101);
        }

        [TestMethod]
        public void OneDimentionTest()
        {
            ActualMatrix matrix = new ActualMatrix(1);

            Assert.IsTrue(matrix.ToString() == string.Format("  1\r\n"));
        }

        [TestMethod]
        public void TwoDimentionTest()
        {
            ActualMatrix matrix = new ActualMatrix(2);

            Assert.IsTrue(matrix.ToString() == string.Format("  1  4\r\n  3  2\r\n"));
        }

        [TestMethod]
        public void ThreeDimentionTest()
        {
            ActualMatrix matrix = new ActualMatrix(3);

            Assert.IsTrue(matrix.ToString() == string.Format("  1  7  8\r\n  6  2  9\r\n  5  4  3\r\n"));
        }

        [TestMethod]
        public void SixDimentionTest()
        {
            ActualMatrix matrix = new ActualMatrix(6);

            Assert.IsTrue(matrix.ToString() == string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n",
                                                            "  1 16 17 18 19 20",
                                                            " 15  2 27 28 29 21",
                                                            " 14 31  3 26 30 22",
                                                            " 13 36 32  4 25 23",
                                                            " 12 35 34 33  5 24",
                                                            " 11 10  9  8  7  6"));
        }
    }
}
