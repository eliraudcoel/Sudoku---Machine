using System;

namespace Sudoku
{
    public class Sudoku
    {
        #region Initialization

        public Sudoku(int[][] grid)
        {
            Grid = grid;
        }

        private readonly int[][] Grid;

        #endregion

        #region Methods

        /// <summary>
        /// This method is designed to print the grid
        /// is missing from the given line.
        /// </summary>
        public void PrintGrid()
        {
            Console.WriteLine(" -----------------");

            for (var line = 0; line < 9; line++)
            {
                for (var row = 0; row < 9; row++)
                {
                    Console.Write("|{0}{1}", Grid[line][row], row == 8 ? "|" : "");
                }

                Console.Write("\n");
                if ((line + 1) % 3 == 0)
                    Console.WriteLine(" -----------------");
            }

            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// This method is designed to check if the given value
        /// is missing from the given line.
        /// </summary>
        /// <param name="value"> Value to check</param>
        /// <param name="line"> Line to iterate</param>
        public bool isMissingOnLine(int value, int line)
        {
            for (var row = 0; row < 9; row++)
            {
                if (Grid[line][row] == value)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// This method is designed to check if the given value
        /// is missing from the given row.
        /// </summary>
        /// <param name="value"> Value to check</param>
        /// <param name="row"> Row to iterate</param>
        public bool isMissingOnColumn(int value, int row)
        {
            for (var line = 0; line < 9; line++)
            {
                if (Grid[line][row] == value)
                    return false;
            }

            return true;   
        }

        /// <summary>
        /// This method is designed to check if the given value
        /// is missing from the given Block.
        /// </summary>
        /// <param name="value"> Value to check</param>
        /// <param name="line"> Line to iterate</param>
        /// <param name="row"> Row to iterate</param>
        public bool isMissingOnBlock(int value, int line, int row)
        {
            int _line = line - (line % 3), _row = row - (row % 3);
            for (line = _line; line < _line + 3; line++)
            {
                for (row = _row; row < _row + 3; row++)
                {
                    if (Grid[line][row] == value)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method check is the Grid appear to be valid.
        /// </summary>
        /// <param name="position"> Check position</param>
        public bool isValid(int position)
        {
            while (true)
            {
                if (position == (9 * 9))
                    return true;

                int line = (position / 9), row = (position % 9);

                if (Grid[line][row] != 0)
                {
                    position = (position + 1);
                    continue;
                }

                for (var value = 1; value <= 9; value++)
                {
                    if (!isMissingOnLine(value, line) || !isMissingOnColumn(value, row) || !isMissingOnBlock(value, line, row))
                        continue;
                    Grid[line][row] = value;

                    if (isValid(position + 1))
                        return true;
                }

                Grid[line][row] = 0;

                return false;
            }
        }

        #endregion
    }
}
