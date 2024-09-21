using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// calcul de l'opération en écriture polonaise
        /// </summary>
        /// <param name="LaFormule"></param>
        /// <returns>le résultat</returns>
        static float Polonaise(String[] LaFormule)
        {
            //CODE OK
            try
            {
                if (LaFormule.Length == 1 && (LaFormule[0] != "+" || LaFormule[0] != "-" || LaFormule[0] != "*" || LaFormule[0] != "/"))
                {
                    return float.Parse(LaFormule[0]);
                }
                else
                {
                    //calcul
                    for (int i = LaFormule.Length - 1; i >= 0; i--)
                    {
                        if(LaFormule[0] != "+" && LaFormule[0] != "-" && LaFormule[0] != "*" && LaFormule[0] != "/")
                        {
                            return float.NaN;
                        }                        
                    }
                    for (int i = LaFormule.Length - 1; i >= 0; i--)
                    {
                        if (LaFormule[i] == "+" || LaFormule[i] == "-" || LaFormule[i] == "*" || LaFormule[i] == "/")
                        {
                            float result = 0;
                            //opération
                            float val1 = float.Parse(LaFormule[i + 1]);
                            float val2 = float.Parse(LaFormule[i + 2]);
                            if (LaFormule[i] == "+")
                            {
                                result = val1 + val2;
                            }
                            else if (LaFormule[i] == "-")
                            {
                                result = val1 - val2;
                            }
                            else if (LaFormule[i] == "*")
                            {
                                result = val1 * val2;
                            }
                            else if (LaFormule[i] == "/")
                            {
                                if (val2 != 0)
                                {
                                    result = val1 / val2;
                                }
                                else return float.NaN;
                            }
                            LaFormule[i] = result.ToString();

                            // effacement des deux cases suivantes
                            for (int j = i + 1; j < LaFormule.Length - 1; j++)
                            {
                                LaFormule[j] = LaFormule[j + 1];
                            }
                            for (int j = i + 1; j < LaFormule.Length - 1; j++)
                            {
                                LaFormule[j] = LaFormule[j + 1];
                            }

                            // remplacement des deux dernières cases par " "
                            if (LaFormule[LaFormule.Length - 1] != " " && LaFormule[LaFormule.Length - 2] != " ")
                            {
                                LaFormule[LaFormule.Length - 1] = " ";
                                LaFormule[LaFormule.Length - 2] = " ";
                            }
                        }
                    }
                }
                return float.Parse(LaFormule[0]);
            }
            catch
            {
                return float.NaN;
            }
            //CODE OK
        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                //saisie de la formule
                Console.WriteLine("Entrez une formule polonaise en séparant chaque partie par un espace = ");
                String formuleSaisie = Console.ReadLine();
                string[] LaFormule = formuleSaisie.Split(' ');

                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(LaFormule));
                Console.WriteLine();
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
                Console.WriteLine();
            } while (reponse == 'O');
        }
    }
}
