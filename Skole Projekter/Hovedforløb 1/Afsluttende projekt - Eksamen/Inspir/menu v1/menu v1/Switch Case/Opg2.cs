using System;

namespace menu_v1.Switch_Case
{
    class Opg2
    {
        public static void opgave2()
        {
            int Isbjørn = 47;// en integer variable med den givne værdi 47
            int Champangebrus = 45;
            int Sunrise = 153;
            int mojito = 10;
            int brandbil = 34;
            int filur = 999;
            Console.WriteLine("hvilken drink kunne du tænke dig\nIsbjørn\t\t =\t{0}\nChampagnebrus\t =\t{1}\nTequila Sunrise\t =\t{2}\nMojito\t\t =\t{3}\nBrandbil\t =\t{4}\nFilur\t\t =\t{5}", Isbjørn,Champangebrus,Sunrise,mojito,brandbil,filur);// udskriver vær drink på en linje for sig selv med prisne sat pænt under hinanden
            string svar = Console.ReadLine();// gæmmer brugerens svar

            switch (svar)//wn switch case der kontrollere hvad brugeren's svar var og om det var en mulighed
            {
                case "Isbjørn":// vis brugerens svar var Isbjørn ville switch casen udføre linjen under
                    Console.WriteLine("Du har valgt en {0} og det bliver {1}kr.", svar, Isbjørn);
                    break;
                case "Champangnebrus":
                    Console.WriteLine("Du har valgt en {0} og det bliver {1}kr.", svar, Champangebrus);
                    break;
                case "Tequila":
                    Console.WriteLine("Du har valgt en {0} og det bliver {1}kr.", svar, Sunrise);
                    break;
                case "mojito":
                    Console.WriteLine("Du har valgt en {0} og det bliver {1}kr.", svar, mojito);
                    break;
                case "brandbil":
                    Console.WriteLine("Du har valgt en {0} og det bliver {1}kr.", svar, brandbil);
                    break;
                case "filur":
                    Console.WriteLine("Du har valgt en {0} og det bliver {1}kr.", svar, filur);
                    break;
                default:
                    break;
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.skiftMenu();// sender bruger tilbage til opgave menu
        }
    }
}
