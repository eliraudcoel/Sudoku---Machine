using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuHumain
    {
        /* Constructeur */
        public SudokuHumain(int[][] grid)
        {
            Grid = grid;
        }

        // On veut que le tableau à 2 dimensions ne soit que en lecture
        // On va l'utiliser pour éviter de le mettre en paramètre
        private readonly int[][] Grid;

        /* Méthode d'affichage du sudoku */
        public void afficherSudoku()
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

        /*************************************************************************************************************/
        //pour déterminer l'absence d'une valeur sur une ligne
        public bool absentSurLaLigne(int valeur, int ligne)
        {
            //parcours le long de la ligne
            for (int col = 0; col < 9; col++)
            {
                //vérification de la présence de la valeur
                if (Grid[ligne][col] == valeur)
                    return false;
            }

            //retour true si valeur absente de la ligne
            return true;
        }

        /*************************************************************************************************************/
        //pour déterminer l'absence d'une valeur sur une colonne
        public bool absentSurLaColonne(int valeur, int col)
        {
            //parcours le long de la colonne
            for (int ligne = 0; ligne < 9; ligne++)
            {
                //vérification de la présence de la valeur
                if (Grid[ligne][col] == valeur)
                    return false;
            }
            //retour true si valeur absente de la colonne
            return true;
        }

        /*************************************************************************************************************/
        //pour déterminer l'absence d'une valeur sur une ligne
        public bool absentSurRegion(int valeur, int ligne, int col)
        {
            //détermination de la région relative à la case donnée par ligne et col
            int _ligne = ligne - (ligne % 3), _col = col - (col % 3);

            //parcours de la région en ligne
            for (ligne = _ligne; ligne < _ligne + 3; ligne++)
            {
                //parcours de la région en colonne
                for (col = _col; col < _col + 3; col++)
                {
                    //vérification de présence de la valeur
                    if (Grid[ligne][col] == valeur)
                        return false;
                }
            }

            //retour vrai si valeur absente de la région
            return true;
        }

        /*************************************************************************************************************/
        //pour compter le nombre de cases remplies initialement dans la grille
        public int compterNbCasesRemplies()
        {
            int nbCasesRemplies = 0;
            int i, j;

            //parcours de la grille
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    //si une case contient une valeur
                    if (Grid[i][j] != 0)
                        //incrémentation de nbCasesRemplies
                        nbCasesRemplies++;
                }
            }
            //renvoi du nb de cases remplies dans la grille
            return nbCasesRemplies;
        }

        /*************************************************************************************************************/
        //méthode de résolution sur une ligne
        public void resolutionSurLigne(ref int nbCasesRemplies)
        {

            int ligne, col, valeur;
            int ligneRetenue = 0, colRetenue = 0;
            int nbCasesCandidates = 0;

            //parcours ligne par ligne
            for (ligne = 0; ligne < 9; ligne++)
            {

                //test de chaque valeur pour savoir si ça peut entrer dans une case de la ligne
                for (valeur = 1; valeur <= 9; valeur++)
                {
                    //parcours colonne par colonne
                    for (col = 0; col < 9; col++)
                    {
                        //si la case contient déjà qqch, on l'ignore
                        if (Grid[ligne][col] != 0)
                            continue;

                        //si la valeur peut potentiellement entrer dans une case
                        if (absentSurLaColonne(valeur, col) && absentSurLaLigne(valeur, ligne) && absentSurRegion(valeur, ligne, col))
                        {
                            //on incrémente le nb de cases dans laquelle la valeur peut s'y insérer
                            nbCasesCandidates++;

                            //on sauvegarde la dernière case où la valeur peut entrer
                            ligneRetenue = ligne;
                            colRetenue = col;
                        }

                    }//fin for(col)

                    //puis s'il n'y a qu'une seule valeur possible sur la ligne
                    if (nbCasesCandidates == 1)
                    {
                        //on affecte la valeur dans cette case
                        Grid[ligneRetenue][colRetenue] = valeur;

                        //incrémentation du nb de cases remplies
                        nbCasesRemplies++;

                    }

                    //on réinitialise le nb de cases possibles avant de reboucler
                    nbCasesCandidates = 0;

                }//fin for(valeur)

            }//fin for(ligne)

        }//fin de resolutionSurLigne

        /*************************************************************************************************************/
        //résolution sur une colonne
        public void resolutionSurColonne(ref int nbCasesRemplies)
        {

            int ligne, col, valeur;
            int ligneRetenue = 0, colRetenue = 0;
            int nbCasesCandidates = 0;

            //parcours ligne par ligne
            for (col = 0; col < 9; col++)
            {

                //test de chaque valeur pour savoir si ça peut entrer dans une case de la ligne
                for (valeur = 1; valeur <= 9; valeur++)
                {
                    //parcours colonne par colonne
                    for (ligne = 0; ligne < 9; ligne++)
                    {
                        //si la case contient déjà qqch, on l'ignore
                        if (Grid[ligne][col] != 0)
                            continue;

                        //si la valeur peut potentiellement entrer dans une case
                        if (absentSurLaColonne(valeur, col) && absentSurLaLigne(valeur, ligne) && absentSurRegion(valeur, ligne, col))
                        {
                            //on incrémente le nb de cases dans laquelle la valeur peut s'y insérer
                            nbCasesCandidates++;

                            //on sauvegarde la dernière case où la valeur peut entrer
                            ligneRetenue = ligne;
                            colRetenue = col;
                        }

                    }//fin for(ligne)

                    //s'il n'y a qu'une seule valeur possible sur la ligne
                    if (nbCasesCandidates == 1)
                    {
                        //on affecte la valeur dans cette case
                        Grid[ligneRetenue][colRetenue] = valeur;

                        //incrémentation du nb de cases remplies
                        nbCasesRemplies = nbCasesRemplies + 1;

                    }

                    //on réinitialise le nb de cases possibles avant de reboucler
                    nbCasesCandidates = 0;

                }//fin for(valeur)

            }//fin for(col)

        }//fin de resolutionSurColonne

        /*************************************************************************************************************/
        //résolution sur une seule et unique région
        public void resolutionSurUneRegion(ref int nbCasesRemplies, int ligne, int col, int valeur)
        {

            int ligneRetenue = 0, colRetenue = 0, nbCasesCandidates = 0;
            int i, j;

            //parcours de la région
            for (i = ligne; i < ligne + 3; i++)
            {

                for (j = col; j < col + 3; j++)
                {

                    //si la case contient déjà qqch, on l'ignore
                    if (Grid[i][j] != 0)
                        continue;

                    //si la valeur peut potentiellement entrer dans une case
                    if (absentSurLaColonne(valeur, j) && absentSurLaLigne(valeur, i) && absentSurRegion(valeur, i, j))
                    {
                        //on incrémente le nb de cases dans laquelle la valeur peut s'y insérer
                        nbCasesCandidates++;

                        //on sauvegarde la dernière case où la valeur peut entrer
                        ligneRetenue = i;
                        colRetenue = j;
                    }

                }//fin for(col)


            }//fin for(ligne)

            //s'il n'y a qu'une seule valeur possible sur la région
            if (nbCasesCandidates == 1)
            {

                //on affecte la valeur dans cette case
                Grid[ligneRetenue][colRetenue] = valeur;

                //incrémentation du nb de cases remplies
                nbCasesRemplies++;

            }

        }//fin fonction resolutionSurUneRegion()

        /*************************************************************************************************************/
        public void resolutionSurToutesRegions(ref int nbCasesRemplies)
        {
            int valeur, ligne = 0, col = 0;

            //double boucle for pour parcourir chaque région
            for (ligne = 0; ligne < ligne + 3 && ligne < 9; ligne += 3)
            {
                for (col = 0; col < col + 3 && col < 9; col += 3)
                {
                    //test de toutes les valeurs
                    for (valeur = 1; valeur <= 9; valeur++)
                    {
                        //appel à la fonction auxiliaire qui vérifie sur une région si la valeur courante peut s'y insérer
                        //incrémentation de nbCasesRemplies si des cases sont remplies
                        resolutionSurUneRegion(ref nbCasesRemplies, ligne, col, valeur);

                    }//fin for(valeur)

                }//fin for (col)

            }//fin for (ligne)

        }//fin méthode resolutionSurToutesRegions

        /*************************************************************************************************************/
        //méthode de résolution principale
        public void resolution()
        {
            //position donne la position dans la grille
            int nbCasesRemplies = 0, cptboucle = 0;

            //compter le nombre de cases remplies
            nbCasesRemplies = compterNbCasesRemplies();

            //tant que toutes les cases ne sont pas remplies
            //et tant que le nb de tours de boucle n'a pas atteint 10 000
            while (nbCasesRemplies < 81 && cptboucle < 10000)
            {
                //incrémentation du cpt de boucle
                cptboucle++;

                //résolution du sudoku
                //et incrémentation de nbCasesRemplies par les méthodes ci-dessous
                resolutionSurToutesRegions(ref nbCasesRemplies);
                resolutionSurLigne(ref nbCasesRemplies);
                resolutionSurColonne(ref nbCasesRemplies);
            }

        }//fin du programme "resolution"
    }
}
