using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo: Voir pour récupérer en entrée un sudoku, on en discutera ensemble mais sinon je pensais à un string que l'on split ensuite
            //todo: Par exemple: 0_6_0_2_0_0_0_0_5
            var input = new[]
            {
                new[] { 0, 6, 0, 2, 0, 0, 0, 0, 5 },
                new[] { 0, 0, 0, 9, 0, 0, 0, 0, 3 },
                new[] { 9, 0, 2, 0, 6, 0, 8, 4, 0 },
                new[] { 0, 0, 4, 0, 0, 9, 0, 5, 6 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 6, 8, 0, 5, 0, 0, 1, 0, 0 },
                new[] { 0, 2, 7, 0, 9, 0, 6, 0, 4 },
                new[] { 1, 0, 0, 0, 0, 2, 0, 0, 0 },
                new[] { 4, 0, 0, 0, 0, 1, 0, 8, 0 }
            };

            //Instanciate Sudoku
            var sudoku = new Sudoku(input);

            //Resolve Sudoku
            sudoku.isValid(0);

            //Print result
            Console.WriteLine("Sudoku Solution:");
            sudoku.PrintGrid();

            //Stop
            Console.ReadLine();
        }
    }
}
