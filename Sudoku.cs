using System;

namespace Sudoku
{
    public class Sudoku
    {
        #region Initialization

        /* Constructeur */
        public Sudoku(int[][] sudoku)
        {
            Tableau_Sudoku = sudoku;
        }

        // On veut que le tableau à 2 dimensions ne soit que en lecture
        // On va l'utiliser pour éviter de le mettre en paramètre
        private readonly int[][] Tableau_Sudoku;

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
                    Console.Write("|{0}{1}", Tableau_Sudoku[line][row], row == 8 ? "|" : "");
                }

                Console.Write("\n");
                if ((line + 1) % 3 == 0)
                    Console.WriteLine(" -----------------");
            }
        }

        /* Méthode Absent sur la ligne */
        // on récupère  la valeur à tester et la ligne correspondante
        public bool absentSurLaLigne(int valeur, int ligne)
        {
            // On boucle sur les colonnes de 0 à 9
            for (var colonne = 0; colonne < 9; colonne++)
            {
                // Si la valeur correspond, on retourne false
                if (Tableau_Sudoku[ligne][colonne] == valeur)
                    return false;
            }

            // Sinon on retourne true
            return true;
        }

        /* Méthode Absent sur la colonne */
        // on récupère  la valeur à tester et la colonne correspondante
        public bool absentSurLaColonne(int valeur, int colonne)
        {
            // On boucle sur les lignes de 0 à 9
            for (var ligne = 0; ligne < 9; ligne++)
            {
                // Si la valeur correspond, on retourne false
                if (Tableau_Sudoku[ligne][colonne] == valeur)
                    return false;
            }

            // Sinon on retourne true
            return true;   
        }

        /* Méthode Absent dans la région */
        // on récupère  la valeur à tester, la colonne et la ligne correspondantes
        public bool absentDeLaRegion(int valeur, int ligne, int colonne)
        {
            // On récupère la preière ligne et colonne de la région
            int _ligne = ligne - (ligne % 3);
            int _colonne = colonne - (colonne % 3);
            
            for (ligne = _ligne; ligne < _ligne + 3; ligne++)
            {
                for (colonne = _colonne; colonne < _colonne + 3; colonne++)
                {
                    // Si la valeur correspond, on retourne false
                    if (Tableau_Sudoku[ligne][colonne] == valeur)
                        return false;
                }
            }

            return true;
        }

        /* Méthode pour compter les chiffres dans les lignes */
        public int compterChiffresLigne()
        {
            int cptmax = 0;
            int cpt = 0;
            int i, j;
            int numligne = 0;

            for (i = 0; i < 9; i++)
            {

                for (j = 0; j < 9; j++)
                {
                    //comptage des chiffres != 0
                    if (Tableau_Sudoku[i][j] != 0)
                        cpt++;
                }

                Console.WriteLine("cpt=" + cpt);

                if (cpt > cptmax)
                {
                    //sauvegarde  de la + grande qté de chiffres
                    cptmax = cpt;
                    //sauvegarde du numéro de ligne qui a le + de chiffres
                    numligne = i;
                }

                cpt = 0;
            }

            //retour numéro de ligne qui a le plus de chiffres
            return numligne;

        }

        /* Méthode pour compter les chiffres dans les colonnes */

        public int compterChiffresColonne()
        {
            int cptmax = 0;
            int cpt = 0;
            int i, j;
            int numcol = 0;

            for (i = 0; i < 9; i++)
            {

                for (j = 0; j < 9; j++)
                {
                    //comptage des chiffres != 0
                    if (Tableau_Sudoku[j][i] != 0)
                        cpt++;
                }

                Console.WriteLine("cpt=" + cpt);

                if (cpt > cptmax)
                {
                    cptmax = cpt;
                    //sauvegarde du numéro de colonne qui a le + de chiffres
                    numcol = i;
                }

                cpt = 0;
            }

            //retour numéro de ligne qui a le plus de chiffres
            return numcol;

        }

        /* Méthode pour compter les chiffres dans les régions */
        public int[] compterChiffresRegion()
        {
            int cpt = 0, cptmax = 0;
            int ligne = 0;
            int colonne = 0;
            int[] nb_region = new int[] {0,0};

            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 1 && i < 9)
                {
                    for (ligne = 0; ligne < ligne + 3; ligne++)
                    {
                        for (colonne = 0; colonne < colonne + 3; colonne++)
                        {
                            if (Tableau_Sudoku[ligne][colonne] != 0)
                            {
                                cpt++;
                            }
                        }

                        if (cpt > cptmax)
                        {
                            cptmax = cpt;
                            nb_region[0] = ligne;
                            nb_region[1] = colonne;
                        }

                        cpt = 0;
                    }
                }
            }
            return nb_region;
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
                if (Tableau_Sudoku[ligne][colonne] != 0)
                {
                    position = (position + 1);
                    continue;
                }

                // On boucle sur les nombres possibles
                for (var valeurPossible = 1; valeurPossible <= 9; valeurPossible++)
                {
                    // On teste si la valeur n'est pas présente en ligne en colonne ou dans la région
                    if (!absentSurLaLigne(valeurPossible, ligne) || !absentSurLaColonne(valeurPossible, colonne) || !absentDeLaRegion(valeurPossible, ligne, colonne))
                        continue;

                    // Si c'est bon on remplace la valeur dans le Sudoku
                    Tableau_Sudoku[ligne][colonne] = valeurPossible;

                    // On boucle sur les autre positions
                    if (estValide(position + 1))
                        return true;
                }

                // En faisant "continue" on arrive ici
                // On met à "0" le sudoku à la position donnée
                Tableau_Sudoku[ligne][colonne] = 0;

                // On retourne false à chaque fois pour que la boucle continue
                return false;
            }
        }

        #endregion
    }
}
