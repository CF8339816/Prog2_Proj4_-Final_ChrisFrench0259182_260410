using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class Captive : Collectable
    {
   
        public static bool _newPrisoner = true;
        public static Random _prisonerSpawn = new Random();
        public static int _prisonerCount=6;
        public static int _prisoner_x_pos;
        public static int _prisoner_y_pos;
        public static (int, int) _prisoner_min_max_x = (8, 46);
        public static (int, int) _prisoner_min_max_y = (8, 21);
        public static int _freed;
       
        //public static List<(int x, int y)> _prisonerLocations = new List<(int, int)>();

        public Captive(string Name, int x, int y, int count, char symbol, ConsoleColor color, (int, int) min_max_x, (int, int) min_max_y) : base(Name, x, y, count: 8, symbol: 'S', ConsoleColor.White, min_max_x, min_max_y)
        {
            Name = "hostage";
            _prisonerCount = count;
            _prisoner_x_pos = x;
            _prisoner_y_pos = y;
            _prisoner_min_max_x = min_max_x;///
            _prisoner_min_max_y = min_max_y;///
        }

        public static void DrawPrisoner()
        {
            int currentMap = GameManager.map._currentMapIndex;

            if (!GameManager.MapCaptiveRegistry.ContainsKey(currentMap))// onlly spawns new list if map never visited otherwise holds locations of uncolllected captives
            {
                List<(int x, int y)> captives = new List<(int x, int y)>();
                for (int i = 0; i < _prisonerCount; i++)
                {
                    int capSpawnX, capSpawnY;
                    bool valid = false;
                    while (!valid)
                    {
                        capSpawnX = _prisonerSpawn.Next(_prisoner_min_max_x.Item1, _prisoner_min_max_x.Item2 + 1);///
                        capSpawnY = _prisonerSpawn.Next(_prisoner_min_max_y.Item1, _prisoner_min_max_y.Item2 + 1);///

                        if (!GameManager.IsTileOccupied(capSpawnX, capSpawnY))
                        {
                            captives.Add((capSpawnX, capSpawnY));
                            valid = true;
                        }
                    }
                }
                GameManager.MapCaptiveRegistry[currentMap] = captives;
            }
                        
            foreach (var slaves in GameManager.MapCaptiveRegistry[currentMap])// checks the dictionary to draw from fro the currerent map
            {
                Console.SetCursorPosition(slaves.x, slaves.y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("S");
            }
            Console.ResetColor();
        }
        public static void CheckCapCollection()
        {
            int currentMap = GameManager.map._currentMapIndex;
            if (!GameManager.MapCaptiveRegistry.ContainsKey(currentMap)) return;

            var slaves = GameManager.MapCaptiveRegistry[currentMap];

            for (int i = slaves.Count - 1; i >= 0; i--)
            {
                if (GameManager.player._x == slaves[i].x && GameManager.player._y == slaves[i].y)
                {
                    _freed +=1;
                    Buffs.IncreaseXP(5);
                    Buffs.IncreaseATK(0);
                    Buffs.IncreaseMaxHealth(0);
                    Treasure._gold += 2;
                    HUD.Moses();

                    slaves.RemoveAt(i);// remove Captives from map list
                }
            }
        }
    }
}
