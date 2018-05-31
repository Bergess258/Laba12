using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //CheckingDictComm(rand);
            List<PlacesV> steb = new List<PlacesV>();
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(50);
                steb.Add(PlacesV.RandAdd(rand));
            }
            //BaseTo
            //List<Person>
            //List<String>
            //Dictionary<Person> < Student >
            //Dictionary<string> < Student >
            //int count = 0;
            //ForEach(Places, Negativecount,ref count);
        }

        private static void CheckingDictComm(Random rand)
        {
            DictionaryCommon<PlacesV,PlacesV> Places = new DictionaryCommon<PlacesV, PlacesV>();
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(50);
                Places.Add(PlacesV.RandAdd(rand), PlacesV.RandAdd(rand));
            }
            Places.Sort();
            Places.Show();
        }
        private static void RandomPlaces(Random rand, List<PlacesV> Places)
        {
            for (int i = 0; i < 10; i++)
            {
                string Name = "";
                int c = rand.Next(4);
                if (c == 0)
                {
                    Region temp;
                    do
                    {
                        Name = RandomNameRegion(rand);
                        temp = new Region(Name, rand.Next(0, 10000000), rand.Next(0, 20));
                    } while (Places.Contains(temp));
                    Places.Add(temp);
                }
                else
                if (c == 1)
                {
                    City temp;
                    do
                    {
                        Name = RandomCity(rand);
                        temp = new City(Name, rand.Next(0, 900000));
                    } while (Places.Contains(temp));
                    Places.Add(temp);
                }
                else
                if (c == 2)
                {
                    Megapolis temp;
                    do
                    {
                        Name = RandomMegapolis(rand);
                        temp = new Megapolis(Name, rand.Next(0, 20));
                    } while (Places.Contains(temp));
                    Places.Add(temp);
                }
                else
                {
                    Adres temp;
                    do
                    {
                        Name = RandomAdres(rand);
                        temp = new Adres(Name);
                    } while (Places.Contains(temp));
                    Places.Add(temp);
                }
            }
        }

        //public static void ForEach(ICollection<PlacesV> collection, Handler handler,ref int result)
        //{
        //    foreach(PlacesV x in collection)
        //    {
        //        handler(x, ref result);
        //    }
        //}
        //public static void Negativecount(PlacesV x, ref int y)//даунизми)
        //{
        //    if (x.ToString().Length < 0) y++;
        //}
        //public static void Positivecount(int x, ref int y)
        //{
        //    if (x > 0) y++;
        //}
        //public static void Max(int x, ref int max)
        //{
        //    if (x > max) max = x;
        //}
        //public static void Min(int x, ref int min)
        //{
        //    if (x < min) min = x;
        //}
        //public delegate void Handler(PlacesV x, ref int y);
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
