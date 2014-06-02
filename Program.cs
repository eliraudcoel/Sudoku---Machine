using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            // Différente définition des grilles de Sudoku
            //facile - grille défaut
            var grille_defaut = new[]
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
            var grille_facile = new[]
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

            //moyen
            var grille_moyen = new[]
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

            //démoniaque
            var grille_demoniaque = new[]
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

            //difficile - irréalisable version humain
            var grille_difficile = new[]
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
            };

            // Affichage du titre de l'application
            Console.WriteLine("********************************************");
            Console.WriteLine("************** SUDOKU SOLVER ***************");
            Console.WriteLine("********************************************");

            String choix = "";
           
            // On boucle sur l'application jusqu'à ce que la personne quitte => tape "q" dans l'interface
            do
            {
                // On demande à l'utilisateur quel force il souhaite
                Console.WriteLine("Quelle force de Sudoku voulez-vous?");
                Console.WriteLine("Taper 1 - Facile");
                Console.WriteLine("Taper 2 - Moyen");
                Console.WriteLine("Taper 3 - Difficile");
                Console.WriteLine("Taper 4 - Démoniaque");
                // On récupère ici la force choisie
                String force_choisie = Console.ReadLine();

                int[][] grille_finale = new int[9][];

                // Ici on teste la valeur entrée par l'utilisateur
                switch (force_choisie)
                {
                    case "1":
                        grille_finale = grille_facile;
                        break;
                    case "2":
                        grille_finale = grille_moyen;
                        break;
                    case "3":
                        grille_finale = grille_difficile;
                        break;
                    case "4":
                        grille_finale = grille_demoniaque;
                        break;
                        // Si il a taper un autre type de lettre on met la grille défault de type facile
                    default:
                        grille_finale = grille_defaut;
                        break;
                }

                // Ici, l'utilisateur choisit le type de résolution
                Console.WriteLine("Quelle solution voulez-vous?");
                Console.WriteLine("Taper 1 - Par solution humaine");
                Console.WriteLine("Taper 2 - Par solution machine");
                String solution_choisie = Console.ReadLine();

                // Cas si il choisit la résolution de type humaine
                if (solution_choisie == "1") 
                {
                    // On définit un objet de type "Sudoku"
                    var sudokuHumain = new SudokuHumain(grille_finale);
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

                // Cas si il choisit la résolution de type machine
                if (solution_choisie == "2")
                {
                    // On définit un objet de type "Sudoku"
                    var sudokuMachine = new SudokuMachine(grille_finale);
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

                // L'utiliateur peut soit quitter soit continuer
                Console.WriteLine("Taper c - Continuer SudokuSolver");
                Console.WriteLine("Taper q - Quitter SudokuSolver");
                choix = Console.ReadLine();

            } while (choix == "c" || choix == "C");
        }
    }
}