using System;

namespace GridSystem
{
    public class Grid<T>
    {
        private readonly T[,] _gridArray;
        
        public int Width => _gridArray.GetLength(0);

        public int Height => _gridArray.GetLength(1);

        public Grid(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Grid dimensions must be greater than zero.");
            }
            
            _gridArray = new T[width, height];
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public T GetValue(int x, int y)
        {
            if (!IsInBounds(x, y))
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of grid bounds.");
            }
            return _gridArray[x, y];
        }

        public void SetValue(int x, int y, T value)
        {
            if (!IsInBounds(x, y))
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of grid bounds.");
            }
            _gridArray[x, y] = value;
        }

        public void ClearGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _gridArray[x, y] = default;
                }
            }
        }

        public T[,] GetGridArray()
        {
            return _gridArray;
        }
    }
}
