using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            //facile
            
                        var input = new[]
                        {
                            new[]{6,0,0, 0,0,0, 4,0,8},
                            new[]{0,4,7, 0,5,8, 3,0,2},
                            new[]{9,3,0, 7,0,2, 0,0,0},

                            new[]{0,9,0, 0,0,1, 7,0,4},
                            new[]{0,7,0, 0,0,0, 0,2,0},
                            new[]{4,0,2, 9,0,0, 0,8,0},

                            new[]{0,0,0, 1,0,7, 0,3,5},
                            new[]{7,0,3, 4,9,0, 2,1,0},
                            new[]{5,0,9, 0,0,0, 0,0,7}
                         };
            

            //facile
            /*
                        var input = new[]
                        {
                            new[]{0,6,0, 0,0,0, 0,0,2},
                            new[]{3,9,0, 1,2,0, 7,8,6},
                            new[]{0,0,7, 8,0,0, 0,0,0},

                            new[]{8,3,0, 0,0,2, 5,0,9},
                            new[]{1,0,0, 6,0,3, 0,0,8},
                            new[]{7,0,9, 5,0,0, 0,6,4},

                            new[]{0,0,0, 0,0,5, 4,0,0},
                            new[]{6,7,2, 0,4,1, 0,9,5},
                            new[]{5,0,0, 0,0,0, 0,3,0}
                         };
            */

            //démoniaque
            /*
                        var input = new[]
                        {
                            new[]{0,1,2, 4,5,0, 3,0,0},
                            new[]{0,0,0, 2,7,0, 0,0,4},
                            new[]{4,0,0, 1,0,0, 0,0,7},

                            new[]{0,0,0, 0,0,0, 5,9,3},
                            new[]{2,7,0, 0,0,0, 0,8,6},
                            new[]{9,3,6, 0,0,0, 0,0,0},

                            new[]{3,0,0, 0,0,2, 0,0,5},
                            new[]{5,0,0, 0,6,1, 0,0,0},
                            new[]{0,0,7, 0,9,5, 8,4,0}
                         };
            */

            //moyen
            /*
                        var input = new[]
                        {
                            new[]{3,0,0, 0,0,0, 0,2,0},
                            new[]{5,7,0, 0,4,0, 6,0,9},
                            new[]{1,0,0, 0,2,9, 5,0,0},

                            new[]{0,0,0, 3,6,4, 0,8,0},
                            new[]{0,0,0, 0,0,0, 0,0,0},
                            new[]{0,3,0, 2,9,5, 0,0,0},

                            new[]{0,0,3, 4,5,0, 0,0,6},
                            new[]{9,0,4, 0,8,0, 0,7,3},
                            new[]{0,8,0, 0,0,0, 0,0,1}
                         };
            */

            //difficile - irréalisable version humain
            /*
            var input = new[]
            {
                new[]{0,0,0, 0,2,3, 8,0,0},
                new[]{0,0,0, 0,0,0, 0,0,0},
                new[]{9,2,0, 0,0,0, 0,3,1},

                new[]{7,0,0, 0,9,0, 2,6,0},
                new[]{0,0,5, 0,8,0, 9,0,0},
                new[]{0,9,1, 0,6,0, 0,0,4},

                new[]{3,1,0, 0,0,0, 0,4,9},
                new[]{0,0,0, 0,0,0, 0,0,0},
                new[]{0,0,2, 8,5,0, 0,0,0}
             };*/

            Console.WriteLine("Quelle solution voulez-vous?");
            Console.WriteLine("1. Par solution humaine");
            Console.WriteLine("2. Par solution machine");
            String solution_choisie = Console.ReadLine();

            if (solution_choisie == "1") 
            {
                // On définit un objet de type "Sudoku"
                var sudokuHumain = new SudokuHumain(input);
                sudokuHumain.afficherSudoku();

                DateTime start = DateTime.Now;

                // On démarre la résolution en commencant par 0
                sudokuHumain.resolution();

                DateTime end = DateTime.Now;

                TimeSpan tps_total = end - start;

                // On affiche le Sudoku Finale
                Console.WriteLine("Temps d'exécution : " + tps_total.Seconds + "s " + tps_total.Milliseconds + "ms");
                Console.WriteLine("Sudoku Solution Humain :");
                sudokuHumain.afficherSudoku();  
            }

            if (solution_choisie == "2")
            {

                // On définit un objet de type "Sudoku"
                var sudokuMachine = new SudokuMachine(input);
                sudokuMachine.afficherSudoku();

                DateTime start = DateTime.Now;
                
                // On démarre la résolution en commencant par 0
                sudokuMachine.estValide(0);

                DateTime end = DateTime.Now;

                TimeSpan tps_total = end - start;

                // On affiche le Sudoku Finale
                Console.WriteLine("Temps d'exécution : "+ tps_total.Seconds + "s " + tps_total.Milliseconds +"ms");
                Console.WriteLine("Sudoku Solution Machine :");
                sudokuMachine.afficherSudoku();                
            }

            // On stoppe le programme
            Console.ReadLine();
        }
    }
}