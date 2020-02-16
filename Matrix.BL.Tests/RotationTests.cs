using Matrix.Core;
using Matrix.Core.Interfaces;
using NUnit.Framework;

namespace Matrix.BL.Tests
{
    public class RotationTests
    {
        private IRotationService rotationService;
        private int item_1 = 1;
        private int item_2 = 2;
        private int item_3 = 3;
        private int item_4 = 4;

        [SetUp]
        public void Setup()
        {
            rotationService = new RotationService();
        }

        [Test]
        public void IsSquareMatrixWasRotatedInClockWiseDirection()
        {
            int[,] testMatrix =
            {
                {1, 2},
                {3, 4},
            };

            var result = rotationService.ClockwiseMatrixRotation(testMatrix);

            Assert.AreEqual(item_1, result[0,1]);
            Assert.AreEqual(item_2, result[1,1]);
            Assert.AreEqual(item_3, result[0,0]);
            Assert.AreEqual(item_4, result[1,0]);
        }

        [Test]
        public void IsSquareMatrixWasRotatedInAntiClockWiseDirection()
        {
            int[,] testMatrix =
            {
                {1, 2},
                {3, 4},
            };
            var result = rotationService.AnticlockwiseMatrixRotation(testMatrix);

            Assert.AreEqual(item_1, result[1, 0]);
            Assert.AreEqual(item_2, result[0, 0]);
            Assert.AreEqual(item_3, result[1, 1]);
            Assert.AreEqual(item_4, result[0, 1]);
        }
    }
}