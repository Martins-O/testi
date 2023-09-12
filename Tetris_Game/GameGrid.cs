using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    internal class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Cols { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Cols = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && c >= 0 && c < Cols;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for(int c = 0; c < Cols; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for(int c = 0; c < Cols; c++)
            {
                if (grid[r,c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Cols; c++)
            {
                grid[r, c] = 0;
            }
        }
         
        private void MoveRowDown(int r, int numRows)
        {
            for(int c = 0; c < Cols; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int Cleared = 0;
            for(int r = Rows; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    Cleared++;
                }
                else if(Cleared > 0)
                {
                    MoveRowDown(r, Cleared);
                }
            }
            return Cleared;
        }
    }
}
