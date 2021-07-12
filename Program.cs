using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iddle_tavern_simulator_personal
{
    class Program
    {
        static double harmas = 0;
        static double negyes = 66;
        static double otos = 90.8;
        static double hatos = 98.8;
        static double hetes = 99.8;
        static int gem = 0;
        static int mennyiseg = 0;
        static int elkoltottGem = 0;
        static int questek = 0;

        static int gems = 50;
        static int arenaTicket = 10; // 1db
        static int basicScroll = 10; // 1db
        static int wishingCoin = 30; // 1db
        static int gold = 150; // 1m
        static int spirit = 158; // 700k
        static int promotionStone = 34; // 250 db
        static int heroShard3 = 90; //30 shard
        static int heroShard4 = 240; // 60 shard
        static int heroicScroll = 125; // 1 db
        static int prophetBlessing = 300; // 100 db
        static int superWC = 250; // 1 db
        static int PO = 450; // 1 db
        static int heroShard5 = 600; // 30 db
        //3as quest
        static int[] rewards3 = { gems, arenaTicket, basicScroll * 3, wishingCoin, gold,
        spirit, promotionStone, heroShard3, heroShard4};
        //4es quest
        static int[] rewards4 = { gems * 2, arenaTicket * 2, basicScroll * 6, heroicScroll,
            wishingCoin * 2, gold * 2,spirit * 2, promotionStone * 2, heroShard3 * 2, heroShard4 * 2};
        //5ös quest
        static int[] rewards5 = { gems * 3, arenaTicket * 3, heroicScroll * 2,
            wishingCoin * 3,superWC, gold * 4,spirit * 4, promotionStone * 4, heroShard3 * 3, heroShard4 * 3};
        //6-os quest
        static int[] rewards6 = { gems * 6, prophetBlessing, heroicScroll * 3,
            superWC * 2,PO , gold * 8,spirit * 8, promotionStone * 6, heroShard4 * 6, heroShard5};
        
        static int[] rewards7 = { gems * 12, prophetBlessing * 2, heroicScroll * 4,
            superWC * 4,PO * 2, heroShard4 * 12, heroShard5 * 2};
        static void Main(string[] args)
        {
            // 1 million quest
            statisztika();
            Console.ReadKey();
        }

        public static void statisztika()
        {
            int i = 0;
            var profit = 0;
            var gemecske = 0;
            var minuszgem = 0;
            for (i = 0; i < 1000; i++)
            {
                eldontes();
                profit += (gem - elkoltottGem);
                gemecske += gem;
                minuszgem += elkoltottGem;
                gem = 0;
                elkoltottGem = 0;
            }

            Console.WriteLine("nyert gem: " + gemecske / i);
            Console.WriteLine("elköltött gem: " + minuszgem / i);
            Console.WriteLine("profit: " + profit / i);
            Console.WriteLine("questek száma: " + questek + " db");
        }


        public static void eldontes()
        {
            double eredmeny;
            double minimum = 0;
            double maximum = 100;

            mennyiseg = 1000;
            Random rndharom = new Random();

            for (int i = 0; i < mennyiseg; i++)
            {
                eredmeny = rndharom.NextDouble() * (maximum - minimum) + minimum;
                var random4 = rndharom.Next(rewards4.Length);
                var random5 = rndharom.Next(rewards5.Length);
                var random6 = rndharom.Next(rewards6.Length);
                var random7 = rndharom.Next(rewards7.Length);
                if (eredmeny < negyes)
                {
                    while (eredmeny < negyes)
                    {
                        eredmeny = rndharom.NextDouble() * (maximum - minimum) + minimum;
                        elkoltottGem += 20;

                    }
                    /*var random3 = rndharom.Next(rewards3.Length);
                    gem += rewards3[random3];
                    Console.WriteLine("3-as quest");*/
                }

                if (eredmeny < otos)
                {
                    if (rewards4[random4] < 70)
                    {
                        i--;
                        elkoltottGem += 20;
                        continue;
                    }
                    gem += rewards4[random4];
                    //Console.WriteLine("4-os quest");
                    questek++;
                }
                else if (eredmeny < hatos)
                {
                    if (rewards5[random5] < 140)
                    {
                        i--;
                        elkoltottGem += 20;
                        continue;
                    }
                    gem += rewards5[random5];
                    //Console.WriteLine("5-ös quest");
                    questek++;
                }
                else if (eredmeny < hetes)
                {
                    if (rewards6[random6] < 210)
                    {
                        i--;
                        elkoltottGem += 20;
                        continue;
                    }
                    gem += rewards6[random6];
                    //Console.WriteLine("6-es quest");
                    questek++;
                }
                else
                {
                    gem += rewards7[random7];
                    //Console.WriteLine("7-es quest");
                    questek++;
                }
            }
        }
    }
}
