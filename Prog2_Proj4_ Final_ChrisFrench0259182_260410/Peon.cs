using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
    {
        public class Peon : Character
        {
            
            public string PeonName;
            public int _x_pos;
            public int _y_pos;

          
            public static Random _peonSpawn = new Random();
            public static int _peonCount = 9;
            public static (int, int) _peon_min_max_x = (1, 55);
            public static (int, int) _peon_min_max_y = (1, 24);

            public Peon(string Name, int x, int y, int attack, char symbol, int hp, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) _min_max_x, (int, int) _min_max_y) :
                base(Name, x, y, 2, '6', 3, ConsoleColor.Green, ConsoleColor.Black, (1, 55), (1, 24))
            {
              
                string RandName = RandoGobboNameo();
                PeonName = "Peon " + RandName;

               
                Name = PeonName;

               
                _x_pos = x;
                _y_pos = y;
            }

           
            public string RandoGobboNameo()
            {
                string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lower = "abcdefghijklmnopqrstuvwxyz";
                StringBuilder moniqur = new StringBuilder();

                int length = _peonSpawn.Next(3, 8);
                moniqur.Append(upper[_peonSpawn.Next(upper.Length)]);

                for (int i = 1; i < length; i++)
                {
                    moniqur.Append(lower[_peonSpawn.Next(lower.Length)]);
                }
                return moniqur.ToString();
            }

            public static void DrawPeon()
            {
                if (GameManager.map._currentMapIndex < 3)
                {
                    int currentMap = GameManager.map._currentMapIndex;

            
                    if (!GameManager.MapPeonRegistry.ContainsKey(currentMap))
                    {
                        List<Peon> peonList = new List<Peon>();
                        for (int i = 0; i < _peonCount; i++)
                        {
                            bool valid = false;
                            while (!valid)
                            {
                                int peon_x = _peonSpawn.Next(_peon_min_max_x.Item1, _peon_min_max_x.Item2 + 1);
                                int peon_y = _peonSpawn.Next(_peon_min_max_y.Item1, _peon_min_max_y.Item2 + 1);

                                if (!GameManager.IsTileOccupied(peon_x, peon_y))
                                {

                                peonList.Add(new Peon(" ", peon_x, peon_y, 2, '6', 3, ConsoleColor.Green, ConsoleColor.Black, (1, 55), (1, 24)));
                                    valid = true;
                                }
                            }
                        }
                        GameManager.MapPeonRegistry[currentMap] = peonList;
                    }

            
                    foreach (var p in GameManager.MapPeonRegistry[currentMap])
                    {
                        Console.SetCursorPosition(p._x_pos, p._y_pos);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('6');
                    }
                    Console.ResetColor();
                }
            }

            public static void CheckPeonCollection()
            {
                int currentMap = GameManager.map._currentMapIndex;
                if (!GameManager.MapPeonRegistry.ContainsKey(currentMap)) return;

                var peonList = GameManager.MapPeonRegistry[currentMap];

                for (int i = peonList.Count - 1; i >= 0; i--)
                {
                    
                    if (GameManager.player._x == peonList[i]._x_pos && GameManager.player._y == peonList[i]._y_pos)
                    {
                    string namewa = peonList[i].PeonName;

                        GameManager.player._health -= 2;
                        Buffs.IncreaseXP(5);
                        Treasure._gold += 1;
                        HUD.PeonSmite(namewa);

                        peonList.RemoveAt(i);
                    }
                }
            }

            public static void MovePeonsRandomly()
            {
                int currentMap = GameManager.map._currentMapIndex;
                if (!GameManager.MapPeonRegistry.ContainsKey(currentMap)) return;

                var peonList = GameManager.MapPeonRegistry[currentMap];

                foreach (var p in peonList)
                {
                    int oldX = p._x_pos;
                    int oldY = p._y_pos;

                    int nextX = oldX + _peonSpawn.Next(-1, 2);
                    int nextY = oldY + _peonSpawn.Next(-1, 2);

                    if ((nextX != oldX || nextY != oldY) && !GameManager.IsTileOccupied(nextX, nextY))
                    {
                       
                        Console.SetCursorPosition(oldX, oldY);
                        GameManager.WriteTileWithColor(GameManager.map._mapsCurrent[oldY][oldX]);

                       
                        p._x_pos = nextX;
                        p._y_pos = nextY;

                   
                        Console.SetCursorPosition(p._x_pos, p._y_pos);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write('6');
                        Console.ResetColor();
                    }
                }
            }
        }
    }
  