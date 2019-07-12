using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTest
{
    enum BeerType
    {
        Lager, Pilsner, Münchener, WienerDortmunder, Bock, Doppelbock, Porter, Mix
    }
    class Beer : IComparable<Beer>
    {
        //Fields and properties
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private BeerType type;
        public BeerType Type
        {
            get { return type; }
            set { type = value; }
        }
        private float procent;
        public float Procent
        {
            get { return procent; }
            set { procent = value; }
        }
        private int volume;
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        //Constructors
        public Beer()
        {
            name = "NoName";
            type = BeerType.Mix;
            procent = 0.0F;
            volume = 0;
        }
        public Beer(string _name="NoName", BeerType _type=BeerType.Mix, float _procent=0.0F, int _volume=0)
        {
            name = _name;
            type = _type;
            procent = _procent;
            volume = _volume;
        }

        //Methods
        public override string ToString()
        {
            return string.Format("Name: {0}, Type: {1}, Procent: {2:0.0%}, Volume: {3}cl, Genstade: {4}", name, type, procent, volume, GetUnits());
        }
        
        public float GetUnits()
        {
            return volume * procent * 100.0F / 150.0F;
        }

        public void Add(Beer sourceBeer)
        {
            if(type != sourceBeer.Type)
            {
                type = BeerType.Mix;
            }
            name = string.Format("{0} & {1}", name, sourceBeer.Name);
            procent = (volume * procent + sourceBeer.Volume * sourceBeer.Procent) / (volume + sourceBeer.Volume);
            volume += sourceBeer.Volume;
        }

        public Beer Mix(Beer sourceBeer)
        {
            Beer mixBeer = new Beer(Name, Type, Procent, Volume);
            mixBeer.Add(sourceBeer);
            return mixBeer;
        }

        public static Beer Mix(Beer firstBeer, Beer secondBeer)
        {
            return firstBeer.Mix(secondBeer);
        }

        public static void GetBeer(ref List<Beer> list , int index)
        {
            list[index].Procent += 0.046F;
        }

        public int CompareTo(Beer other)
        {
            int compareResultat;
            compareResultat = GetUnits().CompareTo(other.GetUnits());
            if (compareResultat == 0)
            {
                compareResultat = volume.CompareTo(other.Volume);
            }
            if (compareResultat == 0)
            {
                compareResultat = name.CompareTo(other.Name);
            }
            return compareResultat;
        }
        public static Beer operator+ (Beer firstBeer, Beer secondBeer)
        {
            return firstBeer.Mix(secondBeer);
        }
    }
}
