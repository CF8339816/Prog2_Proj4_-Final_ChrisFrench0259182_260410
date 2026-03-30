using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class PowerOrb : Collectable
    {
        public static bool _powerOrb = true;
        public static Random _powerOrbSpawn = new Random();
        public static (int, int) _plPosition = (GameManager.player._x, GameManager.player._y);
        //  public static char orbSymbol = '\u2699'; will not diaplay . 
        public static int powerOrb_x_pos;
        public static int powerOrb_y_pos;
        public static (int, int) powerOrb_min_max_x = (8, 46);///
        public static (int, int) powerOrb_min_max_y = (8, 21);///
        public static int peonsDestroyed;
        public static int _XP = 0;
        public static int _poCount = 1;


        public PowerOrb(string Name, int x, int y, int count, char symbol, ConsoleColor color, (int, int) min_max_x, (int, int) min_max_y) : base(Name, x, y, count: 1, symbol: '0' /*orbSymbol*/, ConsoleColor.Cyan, min_max_x, min_max_y)
        {
            Name = "Power Orb";
            powerOrb_x_pos= x;
            powerOrb_y_pos = y;
            count = 1;
        }

        public static void DrawPowerOrb()
        {
            int currentMap = GameManager.map._currentMapIndex;

            if (!GameManager.MapOrbRegistry.ContainsKey(currentMap))// onlly spawns new list if map never visited otherwise holds locations of uncolllected treasures
            {
                List<(int x, int y)> PowerOrb = new List<(int x, int y)>();
                for (int i = 0; i < _poCount; i++)
                {
                    int poSpawnX, poSpawnY;
                    bool valid = false;
                    while (!valid)
                    {
                        poSpawnX = _powerOrbSpawn.Next(powerOrb_min_max_x.Item1, powerOrb_min_max_x.Item2 + 1);
                        poSpawnY = _powerOrbSpawn.Next(powerOrb_min_max_y.Item1, powerOrb_min_max_y.Item2 + 1);

                        if (!GameManager.IsTileOccupied(poSpawnX, poSpawnY))
                        {
                            PowerOrb.Add((poSpawnX, poSpawnY));
                            valid = true;
                        }
                  
                      }
                }
                GameManager.MapOrbRegistry[currentMap] = PowerOrb;
            }

            foreach (var pOrb in GameManager.MapOrbRegistry[currentMap])//Drawing  from the dictionary list for the current map
            {
                Console.SetCursorPosition(pOrb.x, pOrb.y);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write('0');
            }
            Console.ResetColor();
        }
        public static void CheckOrbCollection()
        {
            int currentMap = GameManager.map._currentMapIndex;
            if (!GameManager.MapOrbRegistry.ContainsKey(currentMap)) return;// checks the correct map dictionary for orb location

            var orbs = GameManager.MapOrbRegistry[currentMap];

            for (int i = orbs.Count - 1; i >= 0; i--)
            {

                if (GameManager.player._x == orbs[i].x && GameManager.player._y == orbs[i].y)// checks for player on the Orb
                {

                    if (GameManager.player._x == orbs[i].x && GameManager.player._y == orbs[i].y)
                    {

                        if (GameManager.MapPeonRegistry.ContainsKey(currentMap))// finds the current peon locations on the map
                        {
                            var currentPeons = GameManager.MapPeonRegistry[currentMap];

                          

                            foreach (var peonPos in currentPeons)// cascades tthrough them to clear them
                            {
                                Console.SetCursorPosition(peonPos.x, peonPos.y);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("░");
                                Console.Beep(800, 50);
                                Thread.Sleep(500); //adds a dellay to make itt feel like a wave  not super fast
                                Console.SetCursorPosition(peonPos.x, peonPos.y);
                                GameManager.WriteTileWithColor(GameManager.map._mapsCurrent[peonPos.y][peonPos.x]);// resets the oroignal map tile
                            }
                            int peonsDestroyed = currentPeons.Count;
                            int bonusXP = peonsDestroyed * 10;
                            _XP = bonusXP;
                            currentPeons.Clear();// clears the peons from the map
                            Player.plXP += bonusXP;
                            Buffs.IncreaseXP(bonusXP);  //awards a base xp
                            HUD.Kaboom();
                        }

                        orbs.RemoveAt(i);
                    }

                }
            }
        }
    }
}

