using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class Treasure : Collectable
    {
        public static bool _goldTreasure = true;
        public static Random _goldPileSpawn = new Random();
        public static Random _goldCount = new Random();
        public static (int, int) _plPosition = (GameManager.player._x, GameManager.player._y);
        //public static (int, int) goldLoc = (treasure_x_pos, treasure_y_pos);
        public static int treasure_x_pos;
        public static int treasure_y_pos;
        public static (int, int) treasure_min_max_x = (8, 46);///
        public static (int, int) treasure_min_max_y = (8, 21);///
        public static Random _lootRando = new Random();
        public static int loot;
        public static int _gold;
        public static int goldie;
        public static int _gpCount;
        //public static List<(int x, int y)> activeGoldPiles = new List<(int x, int y)>();///

        public Treasure(string Name, int x, int y, int count, char symbol,  ConsoleColor color, (int, int) min_max_x, (int, int) min_max_y) : base(Name, x, y, count: _gpCount, symbol: '$', ConsoleColor.Yellow, min_max_x, min_max_y)
        {
            


            Name = "gold";
            treasure_x_pos = x;
            treasure_y_pos = y;
            count = _gpCount;
        }
        public static void DrawGold()
        {
            int currentMap = GameManager.map._currentMapIndex;
                     
            if (!GameManager.MapTreasureRegistry.ContainsKey(currentMap))// onlly spawns new list if map never visited otherwise holds locations of uncolllected treasures
            {
                _gpCount = _goldCount.Next(6, 12);
                List<(int x, int y)> goldPiles = new List<(int x, int y)>();
                for (int i = 0; i < _gpCount; i++)
                {
                    int tSpawnX, tSpawnY;
                    bool valid = false;
                    while (!valid)
                    {
                        tSpawnX = _goldPileSpawn.Next(treasure_min_max_x.Item1, treasure_min_max_x.Item2 + 1);
                        tSpawnY = _goldPileSpawn.Next(treasure_min_max_y.Item1, treasure_min_max_y.Item2 + 1);

                        if (!GameManager.IsTileOccupied(tSpawnX, tSpawnY))
                        {
                           goldPiles.Add((tSpawnX, tSpawnY));
                            valid = true;
                        }
                    }
                }
                GameManager.MapTreasureRegistry[currentMap] = goldPiles;
            }

            foreach (var golds in GameManager.MapTreasureRegistry[currentMap])//Drawing  from the dictionary list for the current map
            {
                Console.SetCursorPosition(golds.x, golds.y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("$");
            }
            Console.ResetColor();
        }
        public static void CheckTreasureCollection()
        {
            int currentMap = GameManager.map._currentMapIndex;
            if (!GameManager.MapTreasureRegistry.ContainsKey(currentMap)) return;

            var piles = GameManager.MapTreasureRegistry[currentMap];

            for (int i = piles.Count - 1; i >= 0; i--)
            {
                if (GameManager.player._x == piles[i].x && GameManager.player._y == piles[i].y)
                {
                   
                    loot= _lootRando.Next(15, 35);
                    _gold += loot;
                    goldie = _gold; 
                   // _gold += _lootRando.Next(15, 35);
                    HUD.Looter();

                    piles.RemoveAt(i);// Remove collected treasure from map list
                }
            }
        } 
    }
}

    


