using System;
namespace menu_v1.loops
{
    class Opg1
    {
        public static void opgave1()
        {
            int tal = 10;// en interger variable med en given værdi
            for (int i = 1; i < 11; i++)//et loop der køre 10 gange
            {
                Console.WriteLine(i + " udskrevet i for loop");// udskriver fra 1-10 alt efter hvor mange gange loopet har kørt
            }
            while (tal >= 0)//et loop der udskriver fra 10-1 alt efter hvor mange gnage loopet har kørt
            {
                Console.WriteLine(tal + " udskrevet i while loop");
                tal--;
            }
            Console.ReadLine();//pauser programmet og afventer brugers input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menuen
        }
    }
}
