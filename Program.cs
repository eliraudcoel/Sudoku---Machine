using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            // Voir un sudoku par un fichier
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

            // On définit un objet de type "Sudoku"
            var sudoku = new Sudoku(input);

            // On démarre la résolution en commencant par 0
            //sudoku.estValide(0);

            // On affiche le Sudoku Finale
            //Console.WriteLine("Sudoku Solution:");
            //sudoku.afficherSudoku();

            int num_colonne = sudoku.compterChiffresColonne();
            Console.WriteLine("Compter colonne :" + num_colonne);

            int num_ligne = sudoku.compterChiffresLigne();
            Console.WriteLine("Compter ligne :" + num_ligne);

            int[] num_region = sudoku.compterChiffresRegion();
            Console.WriteLine("Compter région, ligne :" + num_region[0] + "et colonne :" + num_region[1]);


            // On stoppe le programme
            Console.ReadLine();
        }
    }
}
