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
        
        /* Méthode d'affichage du sudoku */
        public void afficherSudoku()
        {
            // les "--" permettent de spérer les lignes 
            Console.WriteLine(" -----------------");

            for (var line = 0; line < 9; line++)
            {
                for (var row = 0; row < 9; row++)
                {
                    // les "|" permettent de séparer les valeurs et de former les colonnes
                    Console.Write("|{0}{1}", Grid[line][row], row == 8 ? "|" : "");
                }

                Console.Write("\n");
                if ((line + 1) % 3 == 0)
                    Console.WriteLine(" -----------------");
            }
        }

        /* Méthode Absent sur la ligne */
        // on récupère  la valeur à tester et la ligne correspondante
        public bool absentLigne(int valeur, int ligne)
        {
            // On boucle sur les colonnes de 0 à 9
            for (var colonne = 0; colonne < 9; colonne++)
            {
                // Si la valeur correspond, on retourne false
                if (Grid[ligne][colonne] == valeur)
                    return false;
            }

            // Sinon on retourne true
            return true;
        }

        /* Méthode Absent sur la colonne */
        // on récupère  la valeur à tester et la colonne correspondante
        public bool absentColonne(int valeur, int colonne)
        {
            // On boucle sur les lignes de 0 à 9
            for (var ligne = 0; ligne < 9; ligne++)
            {
                // Si la valeur correspond, on retourne false
                if (Grid[ligne][colonne] == valeur)
                    return false;
            }

            // Sinon on retourne true
            return true;   
        }

        /* Méthode Absent dans la région */
        // on récupère  la valeur à tester, la colonne et la ligne correspondantes
        public bool absentRegion(int valeur, int ligne, int colonne)
        {
            int _ligne = ligne - (ligne % 3), _colonne = colonne - (colonne % 3);
            for (ligne = _ligne; ligne < _ligne + 3; ligne++)
            {
                for (colonne = _colonne; colonne < _colonne + 3; colonne++)
                {
                    if (Grid[ligne][colonne] == valeur)
                        return false;
                }
            }

            return true;
        }
        
        /* Méthode vérifiant la validité de la valeur à la position donnée */
        // On récupère la position 
        public bool estValide(int position)
        {
            // Boucle qui effectue le programme jusqu'à ce qu'on ai "true"
            while (true)
            {
                // Si la position est la dernière valeur du Sudoku alors on arrête la boucle
                if (position == (9 * 9))
                    return true;

                // On récupère la ligne et la colonne par rapport à la position que l'on a en paramètre
                int ligne = (position / 9);
                int colonne = (position % 9);

                // Si à la position donnée on a autre chose que 0 on continue
                if (Grid[ligne][colonne] != 0)
                {
                    position = (position + 1);
                    continue;
                }

                // On boucle sur les nombres possibles
                for (var valeurPossible = 1; valeurPossible <= 9; valeurPossible++)
                {
                    // On teste si la valeur n'est pas présente en ligne en colonne ou dans la région
                    if (!absentLigne(valeurPossible, ligne) || !absentColonne(valeurPossible, colonne) || !absentRegion(valeurPossible, ligne, colonne))
                        continue;

                    // Si c'est bon on remplace la valeur dans le Sudoku
                    Grid[ligne][colonne] = valeurPossible;

                    // On boucle sur les autre positions
                    if (estValide(position + 1))
                        return true;
                }

                // En faisant "continue" on arrive ici
                // On met à "0" le sudoku à la position donnée
                Grid[ligne][colonne] = 0;

                // On retourne false à chaque fois pour que la boucle continue
                return false;
            }
        }

        #endregion
    }
}
