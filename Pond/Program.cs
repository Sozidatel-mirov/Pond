using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nowDay = 0;

            List<String> HistoryPonds = new List<String>();

            Diet dietPredator = new Diet(false, true, (float)0.60, (float)0.50); 
            Diet dietOmnivorous = new Diet(true, true, (float)0.70, (float)0.60);
            Diet dietHerbivore = new Diet(true, false, (float)0.0, (float)0.40);

            Pond pond = new Pond(2500, 0, 0, 0, 0, 0, 10000, 1000, 100);

            int quantityCrucian;
            int quantityPike;
            int quantityPerch;

            int commonWeightFishes = 0;

            Console.WriteLine("Сколько карасей вы запустите в первый день?");
            quantityCrucian = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько окуней вы запустите в первый день?");
            quantityPerch = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько щук вы запустите в первый день?");
            quantityPike = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < quantityCrucian; i++)
            {
                Crucian crucian = new Crucian(5, 0, 50, 3, dietHerbivore);
                pond.crucians.Add(crucian);
                commonWeightFishes += 5;
            }
            for (int i = 0; i < quantityPerch; i++)
            {
                pond.perches.Add(new Perch(10, 0, 50, 2, dietOmnivorous));
                commonWeightFishes += 7;
            }
            for (int i = 0; i < quantityPike; i++)
            {
                pond.pikes.Add(new Pike(10, 0, 70, 1, dietPredator));
                commonWeightFishes += 6;
            }
            pond.fishes.AddRange(pond.crucians);
            pond.fishes.AddRange(pond.perches);
            pond.fishes.AddRange(pond.pikes);

            pond.quantityCrucian = pond.crucians.Count();
            pond.quantityPerch = pond.perches.Count();
            pond.quantityPike = pond.pikes.Count();

            pond.quantityFish = pond.quantityCrucian + pond.quantityPerch + pond.quantityPike;
            pond.nowBiomassFish = commonWeightFishes;

            

            Console.WriteLine("Мальков вы запустили, осталось подождать и посмотреть, что с ними будет");
            while(true)
            {
                string day;
                int tryParseToInt;
                Console.WriteLine("\nНапишите день, в который хотели бы их посмотреть или же + для отображения следующего дня");
                day = Console.ReadLine();
                if(day == "+")
                {
                    Day(pond, ref nowDay, HistoryPonds);
                    ShowDay(nowDay, HistoryPonds);
                }
                else if(int.TryParse(day, out tryParseToInt))
                {
                    if(tryParseToInt <= nowDay && tryParseToInt > 0)
                    {
                        ShowDay(tryParseToInt, HistoryPonds);
                    }
                    else if(tryParseToInt < 1)
                    {
                        Console.WriteLine("Вы ввели некорректные данные");
                    }
                    else
                    {
                        for(int i = 0; nowDay < tryParseToInt; )
                        {
                            Day(pond, ref nowDay, HistoryPonds);
                        }
                        ShowDay(nowDay, HistoryPonds);
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                }
            }
           

        }

        private static void Day(Pond pond, ref int nowDay, List<String> ponds)
        {
            
                nowDay++;
                Random randomFishing = new Random();
                Random randomFishingQuantity = new Random();
                if(pond.fishes.Count > 5)
                {
                    for (int i = 0; i < randomFishingQuantity.Next(0, 4); i++)
                    {
                        pond.fishes[randomFishing.Next(0, pond.fishes.Count)].Death(pond);
                    }
                }
                
                if(pond.nowBiomassFish > pond.maxBiomassFish || pond.nowFoodBiomass > pond.maxFoodBiomass)
                {
                    pond.crucians.Clear();
                    pond.perches.Clear();
                    pond.pikes.Clear();
                    pond.fishes.Clear();
                    pond.nowBiomassFish = 0;
                }
                for (int i = 0; i < pond.pikes.Count; i++)
                {
                    pond.pikes[i].Eat(pond);
                    if (nowDay > pond.pikes[i].maxAge)
                    {
                        pond.pikes[i].Death(pond);
                    }
                }
                for (int i = 0; i < pond.perches.Count; i++)
                {
                    pond.perches[i].Eat(pond);
                    if (nowDay > pond.perches[i].maxAge)
                    {
                        pond.perches[i].Death(pond);
                    }
                }
                for (int i = 0; i < pond.crucians.Count; i++)
                {
                    pond.crucians[i].Eat(pond);
                    if (nowDay > pond.crucians[i].maxAge)
                    {
                        pond.crucians[i].Death(pond);
                    }
                }
                pond.quantityCrucian = pond.crucians.Count();
                pond.quantityPerch = pond.perches.Count();
                pond.quantityPike = pond.pikes.Count();

                pond.quantityFish = pond.quantityCrucian + pond.quantityPerch + pond.quantityPike;
                pond.nowFoodBiomass += pond.foodGrowth;

                ponds.Add(pond.ToString());
        }
        private static void ShowDay(int nowDay, List<String> history)
        {
            Console.WriteLine($"День {nowDay}");
            Console.WriteLine(history[nowDay - 1]);
        }
    }
}
