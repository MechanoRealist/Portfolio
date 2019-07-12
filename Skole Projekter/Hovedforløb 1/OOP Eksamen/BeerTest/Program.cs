using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Beer frederikBeer = new Beer();
            frederikBeer.Name = "Frederik's Øl";
            frederikBeer.Type = BeerType.Pilsner;
            frederikBeer.Procent = 0.046F;
            frederikBeer.Volume = 33;
            Beer flemmingBeer = new Beer("Flemming's Øl", BeerType.Lager, 0.087F, 70);
            Console.WriteLine("Her er to øl:");
            Console.WriteLine(frederikBeer.ToString());
            Console.WriteLine(flemmingBeer.ToString());
            Console.WriteLine();
            List<Beer> listOfBeers = new List<Beer>
            {
                new Beer {Name = "En gratis øl", Type = BeerType.Porter, Procent = 0.062F, Volume = 40 },
                new Beer {Name = "En vens øl", Type = BeerType.Münchener, Procent = 0.034F, Volume = 25 },
                new Beer {Name = "Damens øl", Type = BeerType.Lager, Procent = 0.042F, Volume = 33 },
                new Beer {Name = "Bartenderens øl", Type = BeerType.WienerDortmunder, Procent = 0.157F, Volume = 40 },
                new Beer {Name = "Den stærke øl", Type = BeerType.Bock, Procent = 0.403F, Volume = 30 },
                new Beer {Name = "Copy of Den stærke øl", Type = BeerType.Bock, Procent = 0.403F, Volume = 30 }
            };
            Beer nicolaiBeer = new Beer("Nicolai's Øl", BeerType.Pilsner, 0.078F, 33);
            Beer friisBeer = new Beer("Friis Øl", BeerType.Münchener, 0.040F, 35);

            frederikBeer.Add(nicolaiBeer);
            Console.WriteLine("Frederik Add Nicolai");
            Console.WriteLine(frederikBeer.ToString());
            Console.WriteLine();
            Console.WriteLine("GetBeer():");
            Console.WriteLine(listOfBeers[1].ToString());
            Beer.GetBeer(ref listOfBeers, 1);
            Console.WriteLine(listOfBeers[1].ToString());
            Console.WriteLine();

            Console.WriteLine("Mix");
            Beer mixbeer1 = flemmingBeer.Mix(frederikBeer);
            Console.WriteLine(mixbeer1.ToString());
            Beer mixbeer2 = Beer.Mix(nicolaiBeer, frederikBeer);
            Console.WriteLine(mixbeer2.ToString());
            Beer mixbeer3 = flemmingBeer + friisBeer; //Plus operator overload
            Console.WriteLine(mixbeer3.ToString());
            Beer mixbeer4 = frederikBeer + flemmingBeer + friisBeer;
            Console.WriteLine(mixbeer4.ToString());
            Console.WriteLine();

            Console.WriteLine("List sort:");
            listOfBeers.Add(frederikBeer);
            listOfBeers.Add(flemmingBeer);
            listOfBeers.Add(nicolaiBeer);
            listOfBeers.Add(friisBeer);
            Console.WriteLine("Before sort:");
            foreach(Beer beer in listOfBeers)
            {
                Console.WriteLine(beer.ToString());
            }
            Console.WriteLine();
            listOfBeers.Sort();
            Console.WriteLine("Efter sort");
            foreach (Beer beer in listOfBeers)
            {
                Console.WriteLine(beer.ToString());
            }

            Console.ReadKey();
        }
    }
}
