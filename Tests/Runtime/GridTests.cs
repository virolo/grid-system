using System;
using NUnit.Framework;

namespace GridSystem.Tests.Runtime
{
    public class GridTests
    {
        private Grid<int> _grid;

        [SetUp]
        public void Setup()
        {
            _grid = new Grid<int>(5, 5);
        }

        [TestCase(-1, 5)]
        [TestCase(5, -1)]
        [TestCase(0, 0)]
        public void Grid_Creation_WithNegativeDimensions_ShouldThrowException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => new Grid<int>(width, height));
        }

        [Test]
        public void Grid_InitialDimensions_AreCorrect()
        {
            Assert.AreEqual(5, _grid.Width);
            Assert.AreEqual(5, _grid.Height);
        }

        [TestCase(0, 0)]
        [TestCase(0, 4)]
        [TestCase(4, 0)]
        [TestCase(4, 4)]
        public void Grid_IsInBounds_ReturnsCorrectly(int x, int y)
        {
            Assert.IsTrue(_grid.IsInBounds(x, y));
        }
    
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(5, 0)]
        [TestCase(0, 5)]
        public void Grid_IsInBounds_ReturnsWrongly(int x, int y)
        {
            Assert.IsFalse(_grid.IsInBounds(x, y));
        }

        [Test]
        public void Grid_SetValueAndGetValue_AreCorrect()
        {
            _grid.SetValue(0, 0, 10);
            _grid.SetValue(4, 4, 20);

            Assert.AreEqual(10, _grid.GetValue(0, 0));
            Assert.AreEqual(20, _grid.GetValue(4, 4));
        }

        [TestCase(-1, 0, 5)]
        [TestCase(0, -1, 5)]
        [TestCase(5, 0, 5)]
        [TestCase(0, 5, 5)]
        public void Grid_SetValue_OutOfBounds_ShouldThrowException(int x, int y, int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _grid.SetValue(x, y, value));
        }

        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(5, 0)]
        [TestCase(0, 5)]
        public void Grid_GetValue_OutOfBounds_ShouldThrowException(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _grid.GetValue(x, y));
        }

        [Test]
        public void Grid_ClearGrid_ResetsAllValuesToDefault()
        {
            _grid.SetValue(0, 0, 10);
            _grid.SetValue(4, 4, 20);
            _grid.ClearGrid();

            Assert.AreEqual(0, _grid.GetValue(0, 0));
            Assert.AreEqual(0, _grid.GetValue(4, 4));
        }

        [Test]
        public void Grid_GetGridArray_ReturnsCorrectArray()
        {
            _grid.SetValue(0, 0, 10);
            _grid.SetValue(4, 4, 20);

            int[,] array = _grid.GetGridArray();

            Assert.AreEqual(10, array[0, 0]);
            Assert.AreEqual(20, array[4, 4]);
            Assert.AreEqual(0, array[2, 2]); // Default value check
        }
    }
}