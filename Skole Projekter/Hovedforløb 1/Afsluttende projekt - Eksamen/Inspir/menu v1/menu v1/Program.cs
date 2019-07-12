using System;
namespace menu_v1
{
    class Program
    {
        public static void Main()
        {
            string eyesbleed = "de concats", tm = "i morgen", notThatCrazyLookinActually = "din CRUD", wut = " en smule wonky.)";
            Console.WriteLine("Hvis vi skal" + " " + tm + " bruge " + notThatCrazyLookinActually + "," + " så skal der styr på " + eyesbleed + ". " + "(Vil bare undgå det her med " + notThatCrazyLookinActually + " da det mildest talt bliver" + wut);
            Console.ReadLine();
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.drawFrame();// en methode der tegner en ramme til menu og opgaver
            Console.WriteLine("programmet kan lukkes fra menu'erne ved at trykke på escape og er ellers er menuen styret af pile taster og enter\ndu har nu følgene valgmuligheder");// udskriver en linje tekst til brugeren
            int valg = KonsolHjælper.Menu(true, "Strings", "variabler", "aritamtik", "variable udtryk",
                "boolske verdier", "if-else statements", "switch cases", "loops", "udvidet kontrolstrukture",
                "methoder og instanser", "returtyper og parametre", "instancevariabler", "nedarvning", "konstructors",
                "arrays", "Gennemløb af arrays");//sender valgmuligheder over til min menu methode i konsolhjælper og bool varaiblen controllere om programmet vil lade brugeren afsluttet programt fra den menu han bliver sendt til
            switch (valg)//en switch case der tager imod den int der bliver returneret fra min menu og sænder brugeren til dne rigtige opgave
            {
                case 1://en case der køre vis brugeren valgte første ting i menu'en
                    Strings.Menu.stringsMenu();// sænder programmet til strings menuen så han/hun kan navigere runt mellem opgaver
                    break;//viser slut punktet af case 1
                case 2://variabler
                    Variabler.Menu.VariablerMenu();
                    break;
                case 3://aritmetik
                    Aritmetiske_udtryk.Opg1.aritmetik();
                    break;
                case 4://variabler i udtryk
                    Variabler_i_udtryk.Menu.variableUdtrykMenu();
                    break;
                case 5://bolske variabler
                    Boolske_variabler.Opg1.opgave1();
                    break;
                case 6://if-else statements
                    if_else_statements.Menu.statementsMenu();
                    break;
                case 7://Switch case
                    Switch_Case.Menu.skiftMenu();
                    break;
                case 8://loops
                    loops.Menu.loopsMenu();
                    break;
                case 9://udvidet kontrolstrukture
                    udvidet_kontrolstruktur.Menu.kontrolMenu();
                    break;
                case 10://methoder og instanser
                    Metoder_og_instanser.Menu.menu();
                    break;
                case 11://returtyper og parametre
                    Returtyper_og_parametre.Menu.menu();
                    break;
                case 12://instancevariabler
                    Instancevariabler.Opg1.opgave1();
                    break;
                case 13://nedarvning
                    Nedarvning.Opg1.nedarvning();
                    break;
                case 14://konstructors
                    Konstruktors.Opg1.opgave1();
                    break;
                case 15://arrays
                    Arrays.Opg1.array();
                    break;
                case 16://Gennemløb af arrays
                    Gennemløb_af_arrays.Opg1.garray();
                    break;
            }
        }
    }
}