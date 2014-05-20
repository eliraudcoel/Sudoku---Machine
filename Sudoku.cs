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
            for (var colonne = 0; colonne < 9; colonne++)
            {
                if (Grid[ligne][colonne] == valeur)
                    return false;
            }

            return true;
        }

        /* Méthode Absent sur la colonne */
        // on récupère  la valeur à tester et la colonne correspondante
        public bool absentColonne(int valeur, int colonne)
        {
            for (var ligne = 0; ligne < 9; ligne++)
            {
                if (Grid[ligne][colonne] == valeur)
                    return false;
            }

            return true;   
        }

        /* Méthode Absent dans la région */
        // on récupère  la valeur à tester, la colonne et la ligne correspondantes
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
                    if (!absentLigne(value, line) || !absentColonne(value, row) || !isMissingOnBlock(value, line, row))
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
