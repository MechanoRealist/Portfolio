using System;
using System.IO;


class Program
{
    static void Main()
    {
        // alt bliver kommenteret mindst en gang eller vis koden bliver brugt til noget nyt det ser slemt ud til at starte med men lysner sig op efter første forklaring

        Console.Clear();// vinduet bliver tømt

        if (File.Exists(@"DB.txt") == false) // kontrollere om database filen existere og vis ikke udføre koden under
        {
            StreamWriter Exsist = File.CreateText(@"DB.txt"); // laver database filen så der ikke sker fejl senere hen
            Exsist.Close(); // streamwriter Exsist bliver lukket så den ikke forstyrre andre
        }
        string[] linjer = File.ReadAllLines(@"DB.txt"); //et array variable med alle linjer fra databasen. Bruges i flere methoder så smed den i min main for ikke at skulle lave flere af dem

        Console.WriteLine("hvilken function skal du bruge fra denne liste:");// udskriver menu med muligheder til brugeren
        Console.WriteLine("\tS - Søg i Database");
        Console.WriteLine("\tT - Tilføj til Database");
        Console.WriteLine("\tL - Læs Database");
        Console.Write("dit valg:");// udskriver menu med muligheder til brugeren men nu skupper den ikke brugeres svar ned på næste linje
        var input = Console.ReadKey();// læser og gæmmer brugeres tast i variablen input
        switch (input.Key)// et loop der kontrollere hvilken tast der bliver trykket og sender den de rigtige steder hend
        {
            case ConsoleKey.S:// bruger har valgt S fra menuen
                Console.Clear();// vinduet bliver tømt
                Søg(linjer);// programmet fortsætter i søg methoden
                break;// s menu valg slut
            case ConsoleKey.T:
                Console.Clear();
                Skriv();
                break;
            case ConsoleKey.L:
                Console.Clear();
                Læs(linjer);
                break;
            default:// brugeren har tastet noget der ikke var i menuen
                Console.Write("dette var ikke en mulighed prøv igen\ntryk enter og prøv igen");// udskriver fejl medelelse
                Console.ReadLine();// stopper koden så bruger kan læse hvad der står
                Main();
                break;//break var et krav da jeg valgte ikke at bruge { } men programmet burde aldrig nå denne linje
        }

    }

    static void Søg(string[] linjer)
    {
        string søger = "";// variabel til tekst (brugerens søge ord)
        int tæller = 1;// varialbel til tekst (linje tæller)
        string linje;
        bool fundet = false;// variabel sandt/falsk (kontrollere om linjen bliver fundet eller ej)

        Console.WriteLine("skriv dit søge kriterie efterfuglt af enter");
        søger = Console.ReadLine();// gæmmer det i søger

        Console.Clear();// vinduet bliver tømt

        StreamReader søg = new StreamReader(@"DB.txt");//læser linjen så den kan sammen lignes med søg senere

        while ((linje = søg.ReadLine()) != null)// starter et loop der køre så længe der stadig er linjer tilbage
        {
            if (linje.Contains(søger))// kontrollere om linje indeholder søge kriteriet og vis ja køre koden under
            {
                Console.WriteLine("Linje nummer {0} indeholder dit søge kriterie {1}", tæller, linjer[tæller - 1]);// udskriver hvilken linje det var og selve linjen
                fundet = true;// ændre fundet til sandt siden vi fandt mindst 1 linje der indeholde søge kriteriet
            }

            tæller++;// pluser 1 til tæller
        }
        if (fundet == false)// vis fundet er sandt køre den koden under
        {
            Console.WriteLine("Ingen linjer inholdte dit søge kriterie\n");
        }
        søg.Close();// lukker søg så den ikke forstyrre senede
        while (true)// starter et uendeligt loop
        {
            Console.WriteLine("vælg en af de følgene muligheder:");
            Console.WriteLine("\tI - Søg igen (nyt Søge kriterie)");
            Console.WriteLine("\tT - Tilbage til menu");
            Console.Write("Dit valg:");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.I:
                    søg.Close();
                    Console.Clear();
                    Søg(linjer);
                    break;
                case ConsoleKey.T:
                    søg.Close();
                    Console.Clear();
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("var ikke en mulighed prøv igen\n");
                    break;
            }
        }

    }

    static void Læs(string[] linjer)
    {
        Console.Clear();// vinduet bliver tømt
        int lin = 1;

        for (int i = 0; i < linjer.Length; i++)// starter et loop der køre lige så længe som der er linjer i database filen
        {
            bool loopContinue = true;
            Console.WriteLine(lin + " " + linjer[i]);// udskriver linje

            if (lin % 15 == 0)// stopper programmet hvær gang tallet rammer noget på 15 tabellen
            {
                while (loopContinue)
                {
                    Console.WriteLine("vælg en af de følgene muligheder:");
                    Console.WriteLine("\tI - Vis næste side (Næste 15)");
                    Console.WriteLine("\tT - Tilbage til menu");
                    Console.WriteLine("\tX - 15 tilbage");
                    Console.Write("Dit valg:");
                    var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.I:
                            Console.Clear();
                            loopContinue = false;
                            break;
                        case ConsoleKey.T:
                            Console.Clear();
                            Main();
                            break;
                        case ConsoleKey.X:
                            loopContinue = false;
                            lin -= 30;
                            i -= 30;
                            if (lin < 0)
                            {
                                lin = 0;
                                i = -1;
                            }
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("var ikke en mulighed prøv igen\n");
                            break;
                    }
                }
            }
            lin++;
        }
        while (true)
        {
            Console.WriteLine("\ndu ramte sidste linje\n");
            Console.WriteLine("\nVælg en af de følgene muligheder:");
            Console.WriteLine("\tI - Vis fra side 1");
            Console.WriteLine("\tT - Tilbage til menu");
            Console.Write("Dit valg:");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.I:
                    Console.Clear();
                    Læs(linjer);
                    break;
                case ConsoleKey.T:
                    Console.Clear();
                    Main();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("var ikke en mulighed prøv igen\n");
                    break;
            }
        }

    }

    static void Skriv()
    {
        string tlf = "124";
        string postnr = "421";
        string navn = "867";
        string adresse = "124";
        string mail = "@@@";
        string by = "nope124";

        tlf = Kontroltlf();// sænder programmet ril kontroltlf methoden og gæmmer svaret fra den i tlf variablen
        Console.Clear();

        Console.Write("skriv dit fulde navn (Fornavn Mellemnavn Efternavn) og tryk Enter:");
        navn = Console.ReadLine();
        Console.Clear();

        Console.Write("Skriv din by (by) og tryk Enter:");
        by = Console.ReadLine();
        Console.Clear();

        Console.Write("skriv din adresse (gade husnummer) og tryk Enter:");
        adresse = Console.ReadLine();
        Console.Clear();

        postnr = KontrolPost();
        Console.Clear();


        Console.Write("Skriv din E-Mail (text@noreply.dk) og tryk Enter:");
        mail = Console.ReadLine();
        Console.Clear();

        string text = tlf + "," + navn + "," + adresse + "," + postnr + "," + by + "," + mail;// sammler alle informationerne brugeren lige har skrevet i en lang comma sepereret linje og gæmmer det i "text" variablen

        StreamWriter sw = new StreamWriter("DB.txt", true);

        sw.WriteLine(text);// udskriver text i database filen på en ny linje
        Console.WriteLine("{0} Tilføjet \n", navn);
        sw.Close();
        while (true)
        {
            Console.WriteLine("vælg en af de følgene muligheder:");
            Console.WriteLine("\tI - Tilføj ny Bruger");
            Console.WriteLine("\tT - Tilbage til menu");
            Console.Write("Dit valg:");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.I:
                    Skriv();
                    break;
                case ConsoleKey.T:
                    Main();
                    break;
                default:
                    Console.WriteLine("\nDet var ikke en mulighed prøv igen");
                    break;
            }
        }
    }

    static string Kontroltlf()
    {
        string tlf;
        Console.Write("Skriv dit telefon nummer (12345678) og tryk Enter:");
        tlf = Console.ReadLine();
        string linje;
        StreamReader search = new StreamReader("db.txt");
        bool tal = long.TryParse(tlf, out long brugesIkke);// ser om tlf kan konverteres til int for at se om det kun er tal der er skrevet ind og vis det gør ændre den variablen til sandt
        if (tal)// kontrollere om tal er sandt
        {
            if (tlf.Length == 8)// kontrollere om længden af nummeret er 8 tal
            {
                while ((linje = search.ReadLine()) != null)// et loop der køre lige så længe som der er linjer i databasen
                {
                    if (linje.Contains(tlf))//  kontrollere om linje indeholder tlf allerade og vis den gør udskriver koden under
                    {
                        while (true)
                        {
                            Console.WriteLine("Dette Telefon nummer existere allerade du har nu følgene muligheder:");// brugeren får menu vist
                            Console.WriteLine("\tI - Prøv igen");
                            Console.WriteLine("\tT - Tilbage til menu");
                            Console.Write("Dit valg:");
                            var input = Console.ReadKey();
                            switch (input.Key)
                            {
                                case ConsoleKey.T:
                                    Console.Clear();
                                    search.Close();
                                    Main();
                                    break;
                                case ConsoleKey.I:
                                    Console.Clear();
                                    search.Close();
                                    Skriv();
                                    break;
                                default:
                                    search.Close();
                                    Console.Clear();
                                    Console.WriteLine("Dit valg Exsisterede ikke ");
                                    break;

                            }
                        }
                    }
                }
                search.Close();
                return tlf;// returnere tlf til hvor methoden blev kaldt
            }
            else
            {
                search.Close();
                Console.WriteLine("Fejl nummer for kort eller for langt");
                Kontroltlf();
            }

            search.Close();
            return tlf;
        }
        else
        {
            Console.WriteLine("et telefon nummer består af tal");
            Kontroltlf();
        }
        search.Close();
        Console.Clear();
        tal = false;
        Kontroltlf();
        return tlf;
    }

    static string KontrolPost()
    {
        string postnummer;

        Console.Write("skriv brugerens postnummer (****) og tryk Enter:");
        postnummer = Console.ReadLine();

        bool succes = long.TryParse(postnummer, out long brugesIkke);
        if (succes)
        {
            if (postnummer.Length == 4)// kontrolere om det er 4 tal der blev skrevet
            {
                return postnummer;
            }
            else
            {
                Console.WriteLine("Fejl der skete en fejl med dit input");
                Console.Write("forsøg igen:");
                KontrolPost();
            }

        }
        else
        {
            Console.WriteLine("et postnummer består af tal prøv igen");
            KontrolPost();
        }
        return (postnummer);
    }
}