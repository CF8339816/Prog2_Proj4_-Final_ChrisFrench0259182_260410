using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class Peon : Character
    {

        public static bool _newPeon = true;
        public static Random _peonSpawn = new Random();
        public static int _peonCount = 9;
        public static int _peon_x_pos;
        public static int _peon_y_pos;
        public static (int, int) _peon_min_max_x = (1, 55);
        public static (int, int) _peon_min_max_y = (1, 24);
        public static int _defeated;
       // public static Random _rando = new Random();
 

        public Peon(string Name, int x, int y, int attack, char symbol, int hp, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) _min_max_x, (int, int) _min_max_y) : 
            base("Peon", x, y, 2, '6', 3, fgColor: ConsoleColor.Green, bgColor: ConsoleColor.Black, (1, 55), (1, 24))
        {
            Name = "hostage";
            _peonCount = 9;
            _peon_x_pos = x;
            _peon_y_pos = y;
          

        }


                       
        public static void DrawPeon()
        {
            if (Program.map._currentMapIndex < 3) {
                int currentMap = Program.map._currentMapIndex;

                if (!Program.MapPeonRegistry.ContainsKey(currentMap))// onlly spawns new list if map never visited otherwise holds locations of uncolllected captives
                {
                    List<(int x, int y)> Peon = new List<(int x, int y)>();
                    for (int i = 0; i < _peonCount; i++)
                    {
                        int peonSpawnX, peonSpawnY;
                        bool valid = false;
                        while (!valid)
                        {
                            peonSpawnX = _peonSpawn.Next(_peon_min_max_x.Item1, _peon_min_max_x.Item2 + 1);///
                            peonSpawnY = _peonSpawn.Next(_peon_min_max_y.Item1, _peon_min_max_y.Item2 + 1);///

                            if (!Program.IsTileOccupied(peonSpawnX, peonSpawnY))
                            {
                                Peon.Add((peonSpawnX, peonSpawnY));
                                valid = true;
                            }
                        }
                    }
                    Program.MapPeonRegistry[currentMap] = Peon;
                }

                foreach (var peons in Program.MapPeonRegistry[currentMap])// checks the dictionary to draw from fro the currerent map
                {
                    Console.SetCursorPosition(peons.x, peons.y);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('6');
                }
                Console.ResetColor();
            }
        }
        public static void CheckPeonCollection()
        {
            int currentMap = Program.map._currentMapIndex;
            if (!Program.MapPeonRegistry.ContainsKey(currentMap)) return;

            var peon = Program.MapPeonRegistry[currentMap];

            for (int i = peon.Count - 1; i >= 0; i--)
            {
                if (Program.player._x == peon[i].x && Program.player._y == peon[i].y)
                {
                    Program.player._health -= 2;
                    Buffs.IncreaseXP(5);

                    Treasure._gold += 1;
                    HUD.PeonSmite();

                    peon.RemoveAt(i);// remove Captives from map list
                }
            }
        }

        public static void MovePeonsRandomly()
        {
            int currentMap = Program.map._currentMapIndex;
            if (!Program.MapPeonRegistry.ContainsKey(currentMap)) return;

            var peonList = Program.MapPeonRegistry[currentMap];

            for (int i = 0; i < peonList.Count; i++)
            {
                
                int oldX = peonList[i].x;// gets current x
                int oldY = peonList[i].y;//gets current y

               
                int nextX = oldX + _peonSpawn.Next(-1, 2);
                int nextY = oldY + _peonSpawn.Next(-1, 2);

                
                if ((nextX != oldX || nextY != oldY) && !Program.IsTileOccupied(nextX, nextY))//checks if the taget tile is free and availabl to write to
                {
                    
                    Console.SetCursorPosition(oldX, oldY);// clears old location
                    Program.WriteTileWithColor(Program.map._mapsCurrent[oldY][oldX]);

                   
                    peonList[i] = (nextX, nextY); // adds new location to the dictionary 

                  
                    Console.SetCursorPosition(nextX, nextY); //0draws at new location
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write('6');
                    Console.ResetColor();
                }
            }
        }    
    }
}
