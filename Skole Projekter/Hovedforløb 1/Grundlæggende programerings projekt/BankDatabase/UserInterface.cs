using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDatabase
{
    class UserInterface
    {
        static List<Kunde> listeAfKunder;
        static List<Konto> listeAfKonti;
        static List<Transaktion> listeAfTransaktioner;
        #region Start
        public static char Start() //Menu input for hovedmenu
        {
            Checkfilter menuChoices = pressedKey => pressedKey != 'A' && pressedKey != 'S' && pressedKey != 'Q';
            DrawStart();
            return EvaluateInput(menuChoices);
        }

        private static void DrawStart() //Grafik for hovedmenu
        {
            Console.Clear();
            string banner = "----Netbank----"; //Titlen
            int left = Console.WindowWidth / 2 - banner.Length / 2; //sætter Titlen i midten
            Console.SetCursorPosition(left, 0);
            Console.WriteLine(banner);
            Console.WriteLine("\t\tVelkommen!");
            Console.WriteLine("\tTryk A for Kunde ");
            Console.WriteLine("\tTryk S for Konti");
            Console.WriteLine("\tTryk Q for afslutte");
            Console.WriteLine();
            Console.SetCursorPosition(8, Console.CursorTop);
        }
        #endregion

        #region Kunde
        public static void KundeMenu() //Kundemenu valg som fører videre til andre metoder
        {
            Checkfilter menuChoices = pressedKey => pressedKey != 'A' && pressedKey != 'S' && pressedKey != 'D' && pressedKey != 'F' && pressedKey != 'Q';

            bool inMenu = true;
            while (inMenu)
            {
                listeAfKunder = Kunde.GetKunderList();
                listeAfKonti = Konto.GetKontiList();
                DrawKunde();
                switch (EvaluateInput(menuChoices))
                {
                    case 'A':
                        CreateKunde();
                        break;
                    case 'S':
                        DeleteKunde();
                        break;
                    case 'D':
                        SearchKunde();
                        break;
                    case 'F':
                        Kontooversigt();
                        break;
                    case 'Q':
                        inMenu = false;
                        break;
                }
            }

        }

        public static void DrawKunde() //GUI Kundemenu
        {
            Console.Clear();
            Console.WriteLine("\t\tKunde Menu");
            Console.WriteLine();
            Console.WriteLine("\tOpret tryk A ");
            Console.WriteLine("\tSlet tryk S ");
            Console.WriteLine("\tVis kundeoversigt tryk D ");
            Console.WriteLine("\tKundens konti tryk F ");
            Console.WriteLine("\tGå tilbage tryk Q ");

            //GUI for kunde 
        }

        private static void CreateKunde() //metode for opret ny kunde + GUI
        {
            Kunde nyKunde = new Kunde();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tOpret konto"); //tab et skridt til venstre
            Console.Write("\tFornavn: ");
            nyKunde.Fornavn = Console.ReadLine();
            Console.Write("\tEfternavn: ");
            nyKunde.Efternavn = Console.ReadLine();
            Console.Write("\tOrganisation (kan lades være tom): ");
            nyKunde.Organisation = Console.ReadLine();
            nyKunde.Oprettelsesdato = DateTime.Now;
            if (nyKunde.CreateKunde() == 1)
            {
                Console.WriteLine("Kunden blev succesfuldt oprættet");
            }
            else
            {
                Console.WriteLine("Noget gik galt i oprættelsen");
            }
            Console.ReadKey();
        }

        private static void SearchKunde() //metode for kundeoversigt fra databasen
        {
            Console.Clear();
            //viser kundens profil information
            //metode kald til valg
            listeAfKunder = Kunde.GetKunderList();
            listeAfKunder.OrderBy(k => k.Efternavn).ToList();
            Kunde.PrintList(listeAfKunder);

            Console.ReadKey();
        }
        private static void DeleteKunde() //UI for slet en kunde
        {

            Checkfilter yesNo = pressedKey => pressedKey != 'Y' && pressedKey != 'N';
            int kundeNr;
            Console.Clear();
            Console.WriteLine();
            Console.Write("\t\tIndtast kundeummer: ");
            kundeNr = Convert.ToInt32(Console.ReadLine());
            Kunde denneKunde = listeAfKunder.Find(k => k.Kundenummer == kundeNr);
            Console.WriteLine("Er du sikker du vil slette denne kunde? (Y/N): ");
            if (EvaluateInput(yesNo) == 'Y')
            {
                denneKunde.RemoveKunde();
            }


        }
        public static void Kontooversigt() //UI for se konti oversigt på en kunde
        {
            int kundenr;
            Console.Clear();
            Console.WriteLine();
            Console.Write("\t\tIndtast Kundenummer: ");
            kundenr = Convert.ToInt32(Console.ReadLine());
            List<Konto> kundeNU = listeAfKonti.Where(t => t.Kundenummer == kundenr).ToList();
            Console.WriteLine();
            Konto.PrintList(kundeNU);
            Console.WriteLine();
            Console.ReadKey();
        }
        #endregion

        #region Konto

        public static void KontoMenu() //Menuen for Konto
        {
            
            Checkfilter menuChoices = pressedKey => pressedKey != 'A' && pressedKey != 'S' && pressedKey != 'D' && pressedKey != 'F' && pressedKey != 'G' && pressedKey != 'Q';
            bool inMenu = true;
            while (inMenu)
            {
                listeAfKonti = Konto.GetKontiList(); //Loading af lister
                listeAfTransaktioner = Transaktion.GetTransaktionerList();
                DrawKonto();
                switch (EvaluateInput(menuChoices)) //Switch til Metoder
                {
                    case 'A':
                        OpretKonto();
                        break;
                    case 'S':
                        SletKonto();
                        break;
                    case 'D':
                        VisSaldo();
                        break;
                    case 'F':
                        IndsætHæv();
                        break;
                    case 'G':
                        VisTransaktioner();
                        break;
                    case 'Q':
                        inMenu = false;
                        break;
                }
            }
        }
        private static void DrawKonto() //Grafik til KontoMenu
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tKonto");
            Console.WriteLine("\t\tOpret en konto (A)");
            Console.WriteLine();
            Console.WriteLine("\t\tSlet en konto (S)");
            Console.WriteLine();
            Console.WriteLine("\t\tVis saldo på en konto (D)");
            Console.WriteLine();
            Console.WriteLine("\t\tIndsæt eller hæv penge (F)");
            Console.WriteLine();
            Console.WriteLine("\t\tVis transaktioner på en konto (G)");
            Console.WriteLine();
            Console.WriteLine("\t\tGå tilbage (Q)");
            Console.WriteLine();
            Console.Write("\t\t\tVælg med tast: ");

        }
        private static void OpretKonto()
        {
            Console.Clear();
            Konto nyKonto = new Konto();
            Console.WriteLine();
            Console.Write("\t\tIndtast kundenummer: ");
            nyKonto.Kundenummer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("\t\tIndtast saldo i kr.: ");
            nyKonto.Saldo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("\tTilgængelige kontotyper: [Firma, 6,4%]:(1) [Familie, 5,8%]:(2) [Enkeltperson, 5,4%:(3) [Ung, 3,1%]:(4) [NGO, 6,1%]:(5)");
            Console.Write("\t\tIndtast nummer for kontotype (1-5): ");
            switch(Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    nyKonto.Kontotype = "Firma";
                    break;
                case 2:
                    nyKonto.Kontotype = "Familie";
                    break;
                case 3:
                    nyKonto.Kontotype = "Enkeltperson";
                    break;
                case 4:
                    nyKonto.Kontotype = "Ung";
                    break;
                case 5:
                    nyKonto.Kontotype = "NGO";
                    break;
            }
            nyKonto.Opretelsesdato = DateTime.Now;
            if(nyKonto.CreateKonto() == 1)
            {
                Console.WriteLine("Kontoen blev succesfuldt oprættet");
            }
            else
            {
                Console.WriteLine("Noget gik galt i oprættelsen");
            }
            Console.ReadKey();
        }
        private static void SletKonto()
        {
            Checkfilter yesNo = pressedKey => pressedKey != 'Y' && pressedKey != 'N';
            int kontoNr;
            Console.Clear();
            Console.WriteLine();
            Console.Write("\t\tIndtast kontonummer: ");
            kontoNr = Convert.ToInt32(Console.ReadLine());
            Konto denneKonto = listeAfKonti.Find(k => k.Kontonummer == kontoNr);
            Console.WriteLine("Er du sikker du vil slette denne konto? (Y/N): ");
            if(EvaluateInput(yesNo) == 'Y')
            {
                denneKonto.RemoveKonto();
            }
            
        }
        private static void VisSaldo()
        {
            int saldoKroner;
            Console.Clear();
            Console.WriteLine();
            Console.Write("\t\tIndtast kontonummer: ");
            saldoKroner = DatabaseAction.GetSaldo(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine("\tSaldo er {0} kr.", saldoKroner);
            Console.ReadKey();
        }
        private static void IndsætHæv()
        {
            int kontoNr, beløb;
            Konto denneKonto;
            Transaktion nyTransaktion = new Transaktion();
            Console.Clear();
            Console.WriteLine();
            Console.Write("\t\tIndtast kontonummer: ");
            kontoNr = Convert.ToInt32(Console.ReadLine());
            denneKonto = listeAfKonti.Find(k => k.Kontonummer == kontoNr);
            nyTransaktion.Kontonummer = denneKonto.Kontonummer;
            Console.WriteLine();
            Console.WriteLine("Positive tal sætter penge ind. Negative tal hæver.");
            Console.Write("\t\tIndtast beløb i kr.: ");
            beløb = Convert.ToInt32(Console.ReadLine());
            nyTransaktion.Saldo = denneKonto.Saldo + beløb;
            nyTransaktion.Beløb = beløb;
            nyTransaktion.Dato = DateTime.Now;
            if (nyTransaktion.CreateTransaktion() == 2)
            {
                Console.WriteLine("Transaktionen blev udført");
            }
            else
            {
                Console.WriteLine("Noget gik galt i transaktionen");
            }
            Console.ReadKey();

        }
        private static void VisTransaktioner()
        {
            int kontoNr;
            Console.Clear();
            Console.WriteLine();
            Console.Write("\t\tIndtast kontonummer: ");
            kontoNr = Convert.ToInt32(Console.ReadLine());
            List<Transaktion> kontoTransaktioner = listeAfTransaktioner.Where(t => t.Kontonummer == kontoNr).ToList(); //Skaber en ny liste
            Console.WriteLine();
            Transaktion.PrintList(kontoTransaktioner);
            Console.WriteLine();
            Console.ReadKey();
            
        }
        
        #endregion

        #region Other methods
        delegate bool Checkfilter(char button);

        /// <summary>
        /// Tager en bool delegate af typen Checkfilter(char c);. Det er et filter for at bestemme tilladte taster for Console.Readkey input.
        /// <para></para>
        /// Eksempel: Checkfilter menuChoices = pressedKey => pressedKey != 'A' &amp;&amp; pressedKey != 'S' &amp;&amp; pressedKey != 'Q';
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        //Checkfilter menuChoices = pressedKey => pressedKey != 'A' && pressedKey != 'S' && pressedKey != 'Q';
        private static char EvaluateInput(Checkfilter filter)
        {
            char button;
            int inputLeft = Console.CursorLeft, inputTop = Console.CursorTop;
            do
            {
                Console.SetCursorPosition(inputLeft, inputTop);
                button = Console.ReadKey().KeyChar;
                button = char.ToUpper(button);
            } while (filter(button));
            return button;
        }
        #endregion
    }
}
