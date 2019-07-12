using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIS_Guest_Register
{
    class Program
    {
        //Variabler som hører til classen er globale og kan så bruges i alle metoderne.
        static string databasePath, configPath;
        static string[] loadedDatabase; //Et array til at holde databasen i hukommelse.
        //To konstanter som bruges i Console.SetCursorPosition og betegner positionen til højre for "Telefon nr" i MenuUI().
        const int inputPosLeft = 28;
        const int inputPosTop = 4;
        //Hvis Main slutter lukker programmet.
        static void Main(string[] args)
        {
            Console.Title = "CMIS Guest Register"; //Sætter titlen på console.
            //Sætter en hvid baggrund med sort tekst på.
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            //Fjerner scrollbarren da console bufferen ikke er større end vinduets højde.
            Console.BufferHeight = 30;
            //Finder mappen hvor programmet blev eksekveret og pejer på konfigurationsfilen config.ini.
            configPath = Environment.CurrentDirectory + @"\config.ini";
            //Bruger metoden File.ReadAllLines(string path) til at læse første linje af config.ini. Den bør indeholde stien til database filen.
            databasePath = File.ReadAllLines(configPath)[0]; //[0] er den første felt i et array og er derfor den første linje i config.ini.
            char menuChoice; //Start af menu systemet. Valg foretages når man trykker på en af de givne taster.
            bool run = true;
            loadedDatabase = File.ReadAllLines(databasePath); //Databasen bliver indlæst før menuen kommer op.
            while (run) //Så længe run er true slutter Main ikke.
            {
                do
                {
                    MenuUI();
                    menuChoice = EvaluateKey(Console.ReadKey()); //Menuen reagerer når man trykker på de rigtige taster.
                    menuChoice = char.ToUpper(menuChoice); //Sørger for at menuChoice altid er stort bogstav.
                } while (menuChoice != 'O' && menuChoice != 'F' && menuChoice != 'V' && menuChoice != 'Q'); //do-while loop så længe menuChoice ikke er nogen af svarene.
                
                switch (menuChoice) //Switch case med metoder holder menu systemet samlet.
                {
                    case 'O':
                        bool again = false;
                        do //Looper så længe der skal indtastes flere personer.
                        {
                            MenuUI();
                            again = EnterData();
                        } while (again);
                        loadedDatabase = File.ReadAllLines(databasePath); //Indlæser databasen efter der er blevet tilføjet nye linjer.
                        break;
                    case 'F':
                        SearchDatabase();
                        break;
                    case 'V':
                        BrowseDatabase();
                        break;
                    case 'Q':
                        run = false;
                        break;
                }
            }
        }

        static bool EnterData() //Dette er metoden for at indtaste data i databasen.
        {
            string infoInput;
            int phoneNumber;
            Console.SetCursorPosition(inputPosLeft, inputPosTop); //Sætter markøren til højre for "Telefon nr" i MenuUI().
            phoneNumber = InputPhoneNumber(); //Tager input for telefonnummer og tjekker det er korrekt.
            if (phoneNumber < 0) //En negativ tilbagemelding betyder at noget ikke er korrekt.
            {
                return true; //Afslutter metoden og vender tilbage.
            }
            Console.SetCursorPosition(inputPosLeft + 11, inputPosTop);
            if (FindEntry(false, phoneNumber) < 0) //Ser om telefonnummeret allerede er i databasen.
            {
                Console.Write("Ikke OK! Findes allerede");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.Write("OK! Kan oprettes");
            }
            infoInput = phoneNumber.ToString(); //Oplysningerne concatenates (sammenkædes/sammenklistres) som strings delimited (adskilte) med kommaer.
            Console.SetCursorPosition(inputPosLeft, inputPosTop + 1); //Sætter markøren til næste linje.
            infoInput = infoInput + "," + Console.ReadLine();
            Console.SetCursorPosition(inputPosLeft, inputPosTop + 2);
            infoInput = infoInput + "," + Console.ReadLine();
            Console.SetCursorPosition(inputPosLeft, inputPosTop + 3);
            infoInput = infoInput + "," + Console.ReadLine();
            Console.SetCursorPosition(inputPosLeft, inputPosTop + 4);
            infoInput = infoInput + "," + Console.ReadLine();
            Console.SetCursorPosition(inputPosLeft, inputPosTop + 5);
            infoInput = infoInput + "," + Console.ReadLine();
            //Console.WriteLine(infoInput); //Debug output.
            Console.SetCursorPosition(0, inputPosTop + 8);
            Console.WriteLine("\tOplysninger gemmes .....");
            WriteDatabase(infoInput, databasePath); //Skriver den indtastede string ind i databasen.
            Console.Write("\tSuccess. Skal der oprettes flere personer? (Y/N):");
            return YesNo();
        }

        static void SearchDatabase() //Søger efter et telefonnummer i databasen og viser oplysningen hvis den findes
        {
            int index, phoneNumber;
            SearchUI();
            phoneNumber = InputPhoneNumber();
            index = FindEntry(true, phoneNumber); 
            Console.WriteLine();
            if (index < 0) //Negativ tilbagemelding betyder at der ikke blev fundet noget.
            {
                Console.WriteLine("\tKan ikke finde en person med telefonnummer {0}", phoneNumber);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\tFandt personen du ledte efter:");
                Console.WriteLine("\t {0}", loadedDatabase[index]);
                Console.WriteLine();
            }
            Console.Write("\tTryk på en vilkårlig tast for at fortsætte: ");
            Console.ReadKey();
        }

        static void BrowseDatabase() //Viser oplysningerne i databasen 15 linjer ad gangen.
        {
            BrowseUI();
            int count = 0;
            foreach (string line in loadedDatabase) //Looper igennem alle 
            {
                Console.WriteLine("\t{0}", line);
                count++; //Hver gang en linje er skrevet i console lægges der en til tælleren
                if ( count >= 15 )
                {
                    Console.WriteLine();
                    Console.Write("\tTryk på en vilkårlig tast for at fortsætte: ");
                    count = 0; //Nulstil tæller
                    Console.ReadKey();
                    BrowseUI();
                }
            }
            Console.SetCursorPosition(0, 25);
            Console.Write("\tIkke mere at vise - Tryk på en vilkårlig tast for at fortsætte: ");
            Console.ReadKey();
        }


        static int InputPhoneNumber() //Tager et input for et telefonnummer med fejldetektering og fejlmeddelelse.
        {
            string s;
            int n = -1, cl = Console.CursorLeft, ct = Console.CursorTop;
            Exception e = new Exception(); //En fejlalarm som kan aktiveres i koden.
            bool repeat = true;
            while (repeat)
            {
                s = Console.ReadLine();
                try
                {
                    if (s.Substring(0, 1) != "0") //Tjekker at telefonnummer ikke starter med et nul.
                    {
                        if (s.Length == 8) //Tjekker at telefonnummer er 8 tegn lang.
                        {
                            n = Convert.ToInt32(s); //Tjekker at telefonnummer er et tal.
                            repeat = false;
                        }
                        else throw e;
                    }
                    else throw e;
                }
                catch
                {
                    string error = "Ikke OK! Tjek telefonnummer";
                    int offset = cl + s.Length + 3;
                    if (offset + error.Length > Console.WindowWidth) //Tjekker at fejlindtastningen ikke går ud over enden af console.
                    {
                        n = -1;
                        return n;
                    }
                    Console.SetCursorPosition(offset, ct);
                    Console.Write(error);
                    Console.ReadKey();
                    Console.SetCursorPosition(cl, ct); Console.Write(new string(' ', Console.WindowWidth - cl)); //Skriver med blank til enden af linjen for at slette tidligere indtastning og fejlmeddelelse.
                    Console.SetCursorPosition(cl, ct);
                }
            }
            return n;
        }
        
        static void WriteDatabase(string s, string path) //Skriver en string til databasen.
        {
            using (StreamWriter file = new StreamWriter(path, true)) /*StreamWriter åbner filen ved stien path
                og er sat (true) til at lægge til på enden af filen så den ikke overskriver tidligere data.
                Ved at bruge using sikrer man at filen bliver lukket igen når programmet er færdig med den.*/
            {
                file.WriteLine(s);
            }
        }

        static int FindEntry(bool good, int phoneNumber) /*Leder igennem den indlæste database efter et telefonnummer og vender tilbage med et index nummer.
            Variablen good bestemer om det er godt hvis den finder et telefonnummer.*/
        {
            int i = 0;
            string search = phoneNumber.ToString(); //Laver int om til string for nemmere sammenligning.
            foreach (string line in loadedDatabase) //Kører igennem den indlæste database.
            {
                if (line != string.Empty) //Tjekker om linjen er tom.
                {
                    if (line.Substring(0, 8) == search) //Sammenligner de første 8 tegn i linjen med søgnigen.
                    {
                        if (good) //Hvis det er godt at nummeret blev fundet.
                        {
                            return i;
                        }
                        return -1; //Hvis det ikke er godt at nummeret blev fundet
                    }
                }
                i++;
            }
            if (good) //Hvis det ikke er godt at nummeret ikke blev fundet.
            {
                return -1;
            }
            return i; //Hvis det er godt at nummeret ikke blev fundet.

        }
        
        static char EvaluateKey(ConsoleKeyInfo k) //Tager en ReadKey og giver tilbage dens tilsvarende char.
        {
            Console.WriteLine();
            return k.KeyChar;
        }

        static bool YesNo() //Dette er et svar på et Ja/Nej spørgsmål.
        {
            bool q = false;
            int cl = Console.CursorLeft, ct = Console.CursorTop; //Får nuværende markør position.
            char ans;
            do //Menu system for Y/N
            {
                Console.SetCursorPosition(cl, ct);
                ans = EvaluateKey(Console.ReadKey());
                ans = char.ToUpper(ans);
            } while (ans != 'Y' && ans != 'N');

            switch (ans)
            {
                case 'Y':
                    q = true;
                    break;
                case 'N':
                    q = false;
                    break;
            }
            return q; // Ja giver true og Nej giver false.
        }

        static void MenuUI()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t<<<   Carsten Mørch Information Systems - Gæste-registrering v 1.0   >>>");
            Console.WriteLine();
            Console.WriteLine(); // "\t" betyder et tryk på TAB.
            Console.WriteLine("\tTelefon nr\t:");
            Console.WriteLine("\tNavn\t\t:");
            Console.WriteLine("\tAdresse\t\t:");
            Console.WriteLine("\tPostnr\t\t:");
            Console.WriteLine("\tBy\t\t:");
            Console.WriteLine("\tEmail\t\t:");
            Console.SetCursorPosition(0, Console.CursorTop + 9);
            Console.WriteLine("\t[O] Opret  [F] Find  [V] Vis alle    [Q] Afslut :");
            Console.WriteLine();
            Console.Write("\t Vælg funktion :");
        }
        static void SearchUI()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t<<<   Carsten Mørch Information Systems - Gæste-registrering v 1.0   >>>");
            Console.WriteLine();
            Console.WriteLine("\tSøg i databasen efter en person");
            Console.WriteLine();
            Console.Write("\t Indtast et telefonnummer: ");
        }

        static void BrowseUI()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t<<<   Carsten Mørch Information Systems - Gæste-registrering v 1.0   >>>");
            Console.WriteLine();
            Console.WriteLine("\t Der er i alt {0} linier i databasen", loadedDatabase.Length);
            Console.WriteLine("\t Indhold af databasen:");
            Console.WriteLine();
        }
    }
}
