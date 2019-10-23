using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LifeTask;

namespace LifeTaskTests
{
    [TestFixture]
    class Program_Test
    {
        [Test]
        public void CheckSquare()
        {
            int[,] matrix = new int[5, 5] { { 1, 1, 0, 0, 0 }, { 1, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            LifeAlgoritm LA = new LifeAlgoritm(matrix);
            Assert.AreEqual(matrix, LA.Matrix);
        }

        [Test]
        public void CheckThreeElementsLine()
        {
            int[,] startMatrix = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            LifeAlgoritm LA = new LifeAlgoritm(startMatrix);
            int[,] finishMatrix = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 1, 1, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            Assert.AreEqual(finishMatrix, LA.Matrix);
        }

        [Test]
        public void CheckRhombus()
        {
            int[,] matrix = new int[5, 5] { { 0, 1, 0, 0, 0 }, { 1, 0, 1, 0, 0 }, { 1, 0, 1, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            LifeAlgoritm LA = new LifeAlgoritm(matrix);
            Assert.AreEqual(matrix, LA.Matrix);
        }

        [Test]
        public void CheckSomeField()
        {
            int[,] startMatrix = new int[5, 5] { { 1, 1, 0, 0, 0 }, { 0, 1, 0, 1, 1 }, { 1, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 1, 0, 0, 1 } };
            LifeAlgoritm LA = new LifeAlgoritm(startMatrix);
            int[,] finishMatrix = new int[5, 5] { { 1, 1, 1, 0, 0 }, { 0, 1, 1, 0, 0 }, { 0, 1, 1, 1, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            Assert.AreEqual(finishMatrix, LA.Matrix);
        }
    }
}
