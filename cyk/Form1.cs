using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class btncheck : Form
    {
        public btncheck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
/*
test data
S->AB
S->CB
A->BC
A->y
B->x
C->AS
C->AB
C->y
		
yxyxx	(in language)
	*/
	
            string word = tboxword.Text;
            string[] grammar = Regex.Split(tboxgrammar.Text, "\r\n");
            int width = word.Length;
            int height = word.Length + 1;
            string[,] grammarlist = new String[grammar.Length, 2];
            string[,,] matrix = new String[height, width,grammarlist.GetLength(0)];
            for (int i = 0; i < word.Length; i++)
            {
                matrix[height - 1, i,0] = word.Substring(i, 1);
            }
            for (int i = 0; i < grammar.Length; i++)
            {
                grammarlist[i, 0] = grammar[i].Substring(0, 1);
                grammarlist[i, 1] = grammar[i].Substring(grammar[i].IndexOf("->") + 2);
            }
            for (int j = matrix.GetLength(0)-1; j > 0; j--)    //Zeilen von unten durchgehen
            {
                if (j == height - 1)
                {
                    for (int i = 0; i < matrix.GetLength(1); i++) //Zeichen des Wortes durchgehen
                    {
                        int num = 0;
                        for (int k = 0; k < grammarlist.GetLength(0); k++)    //Grammatik nach Zeichen durchsuchen (lineare Suche)
                        {
                            if (matrix[j, i, 0] == grammarlist[k, 1])   //Non-Terminale in die Matrix schreiben
                            {
                                matrix[j - 1, i, num] = grammarlist[k, 0];
                                num++;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= j; i++)    //Zellen einer Zeile ablaufen
<<<<<<< HEAD
                    {
			//TODO: Ableitungen nach oben suchen
=======
                    {//es soll in zelle matrix[j-1,i,0..] geschrieben werden
                        for (int k = matrix.GetLength(0) - 2; k >= j; k--)    //Spalte von unten nach oben durchsuchen (Senkrechte)
                        {
                            for (int m=0;m<matrix.GetLength(0)-j-1;m++)    //Diagonale von oben nach unten ablaufen (Diagonale)
                            {
                                for (int l = 0; l < matrix.GetLength(2); l++)  //alle Zeichen in der Zelle betrachten (Senkrechte)
                                {
                                    for (int n = 0; n < matrix.GetLength(2); n++)  //alle Zeichen in der Zelle betrachten (Diagonale)
                                    {
                                        if (matrix[k, i, l] != null && matrix[j + m, i + m + 1, n] != null)//TODO: Index der 2. Bedingung wird zu groß
                                        {
                                            for (int g = 0; g < grammarlist.GetLength(0); g++) //Grammatikliste nach der kombi durchsuchen und in feld eintragen
                                            {
                                                if (grammarlist[g, 1] == matrix[k, i, l] + matrix[j + m, i + m + 1, n])
                                                {
                                                    matrix[j - 1, i, 0] = grammarlist[g, 0];
                                                }
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
>>>>>>> continued
                    }
                }
            }
            bool inlanguage = false;
            for (int i = 0; i < matrix.GetLength(2); i++)
            {
                if (matrix[0, 0, i] == "S" && !inlanguage)
                {
                    inlanguage = true;
                }
                
            }
            if(inlanguage)
            {
                MessageBox.Show("The word " + word + " belongs to the language.");
            }
            else
            {
                MessageBox.Show("The word " + word + " does not belong to the language.");
            }
        }
    }
}
