using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Collection<PlacesV> Places = new Collection<PlacesV>();
            for (int i = 0; i < 10; i++)
            {
                string Name = "";
                int c = rand.Next(4);
                if (c == 0)
                {
                    Name = RandomNameRegion(rand);
                    Places.Add(new Region(Name, rand.Next(0, 10000000), rand.Next(0, 20)));
                }
                else
                if (c == 1)
                {
                    Name = RandomCity(rand);
                    Places.Add(new City(Name, rand.Next(0, 900000)));
                }
                else
                if (c == 2)
                {
                    Name = RandomMegapolis(rand);
                    Places.Add(new Megapolis(Name, rand.Next(0, 20)));
                }
                else
                {
                    Name = RandomAdres(rand);
                    Places.Add(new Adres(Name));
                }
            } 
            Places.Show();
        }
        private static string RandomAdres(Random rand)
        {
            string[] Streets = new string[] { "улица Павловская", "улица Бахаревская", "улица Гамовская", "улица Запрудская", "улица Ключевая", "улица Красавинская", "улица Липогорская", "улица Набережная" };
            string adres = "";
            adres += Streets[rand.Next(0, Streets.Length)] + " ";
            adres += rand.Next(0, 500);
            return adres;
        }
        private static string RandomCity(Random rand)
        {
            string Name;
            string[] s = new string[] { "Пермь", "Кунгур", "Ижевск", "Боготол", "Саратов", "Чернушка", "Волгоград" };
            int temp = rand.Next(s.Length);
            Name = s[temp];
            return Name;
        }
        private static string RandomMegapolis(Random rand)
        {
            string Name;
            string[] s = new string[] { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеренбург", "Нижнiй новгород", "Казань", "Самара" };
            int temp = rand.Next(s.Length);
            Name = s[temp];
            return Name;
        }

        private static string RandomNameRegion(Random rand)
        {
            string Region;
            string[] s = new string[] { "Магаданская", "Адыгейская", "Башкортостанская", "Алтайская", "Дагестанская", "Татарстанская", "Чувашская" };
            int temp = rand.Next(s.Length);
            Region = s[temp];
            return Region;
        }
    }
}
