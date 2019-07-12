using System;

namespace menu_v1.if_else_statements
{
    class Opg6
    {
        public static void opgave6()
        {
            double fradrag = 0;// en double variable med en given værdi
            Console.WriteLine("hvor mange km køre du vær dag?");
            int km = Convert.ToInt32(Console.ReadLine());
            if (km < 24)
            {
                Console.WriteLine("du får ikke noget fradrag");
            }
            else if (km > 24 && km < 120)
            {
                fradrag = 1.93;
                Console.WriteLine("du får {0:n2} pr. km. som svare til {1:n3}", fradrag, (km - 24) * fradrag);
            }
            else if (km > 120)
            {
                Console.WriteLine("du får {0:n2} pr. km. som svare til {1:n3}", fradrag, 96 * fradrag + (km - 120) * 0.97);
            }
            Console.ReadLine();
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();
        }
    }
}
