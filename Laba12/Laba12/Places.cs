using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class PlacesV
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public PlacesV()
        {
            Name = "";
        }
        public PlacesV(string name)
        {
            Name = name;
        }
        public virtual void Show()
        {
            Console.WriteLine("Место " + Name);
        }
    }
    class Region : PlacesV //Кол-во мужчин во всех регионах
    {
        int numberMans = 0;
        int numberCities = 0;
        public int NumberCities
        {
            get { return numberCities; }
            set { numberCities = value; }
        }
        public int NumberMans
        {
            get { return numberMans; }
            set
            {
                if (value < 0) Console.WriteLine("Мужчин не может быть меньше 0");
                else numberMans = value;
            }
        }
        public Region() : base()
        {

        }
        public Region(string name) : base(name)
        {

        }
        public Region(string name, int mans) : base(name)
        {
            NumberMans = mans;
        }
        public Region(string name, int mans, int cit) : base(name)
        {
            NumberMans = mans;
            numberCities = cit;
        }
        public override void Show()
        {
            Console.WriteLine(Name + " Область");
        }
    }

    class City : PlacesV // кол-во горожан во всех регионах 
    {
        int citizens = 0;
        public int Citizens
        {
            get { return citizens; }
            set
            {
                if (value < 0) Console.WriteLine("Горожан не может быть меньше 0");
                else citizens = value;
            }
        }
        public City() : base()
        {

        }
        public City(string name) : base(name)
        {
        }
        public City(string name, int Countcitizens) : base(name)
        {
            Citizens = Countcitizens;
        }
        public override void Show()
        {
            Console.WriteLine("Город " + Name);
        }
    }

    class Megapolis : PlacesV
    {
        private int countFabriks;
        public int CounFabriks
        {
            get { return countFabriks; }
            set { countFabriks = value; }
        }
        public Megapolis() : base()
        {

        }
        public Megapolis(string name) : base(name)
        {
        }
        public Megapolis(string name, int t) : base(name)
        {
            countFabriks = t;
        }
        public override void Show()
        {
            Console.WriteLine("Мегаполис " + Name);
        }
    }

    class Adres : PlacesV
    {
        int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public Adres() : base()
        {

        }
        public Adres(string name) : base(name)
        {

        }
        public Adres(string name, int index1) : base(name)
        {
            index = index1;
        }
        public override void Show()
        {
            Console.WriteLine("Адрес: " + Name);
        }
    }
}
