using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    class GameManager

    {
        //  public static LoadMap map = new LoadMap();
        // public static bool isPlaying = true;

        public static string Name;
        public static int MaxNameLLength = 15;
        public static int plaAtkUP = 15;
        public static int plaMaxHP = 50;
        public static Player player = new Player(" ", 3, 3, plaAtkUP, '!', plaMaxHP, ConsoleColor.DarkBlue, ConsoleColor.White, (1, 55), (1, 24));
        public static List<EnemyLeader> enemiesMap1 = new List<EnemyLeader>();
        public static List<EnemyLeader> enemiesMap2 = new List<EnemyLeader>();
        public static List<EnemyLeader> enemiesMap3 = new List<EnemyLeader>();
        public static List<EnemyRider> enemyRiderList = new List<EnemyRider>();
        public static LoadMap map = new LoadMap();
        public static Dictionary<int, List<(int x, int y)>> MapTreasureRegistry = new Dictionary<int, List<(int x, int y)>>();// dictionary set up to track treasure per map to prevent respawn when going back to map after leaving 
        public static Dictionary<int, List<(int x, int y)>> MapCaptiveRegistry = new Dictionary<int, List<(int x, int y)>>();// dictionary set up to track Captives per map to prevent respawn when going back to map after leaving 
        public static Dictionary<int, List<(int x, int y)>> MapOrbRegistry = new Dictionary<int, List<(int x, int y)>>();
        public static Dictionary<int, List<(int x, int y)>> MapPeonRegistry = new Dictionary<int, List<(int x, int y)>>();
        public static bool isPlaying = true;
        public static bool isAlly = false; //sets bool to check for other allies in movement path
        //public GameManager()
        //{


        //}



        public static bool IsTileOccupied(int x, int y)
        {
            // moved the  tile check here  to see if it would stop the treasure and  captive spawns in the lava
            int currentMap = GameManager.map._currentMapIndex;// checks using info from current map
            char targetTile = GameManager.map._mapsCurrent[y][x];
            char[] forbiddenTiles = { '#', 'w', '%', '|', 'M', '-', '+', 'S', '$', '&', '6', 'O', 'H', '@', '!', '*' };
            if (Array.Exists(forbiddenTiles, t => t == targetTile))
            { return true; }
            // Check if player  is there
            if (x == GameManager.player._x && y == GameManager.player._y)
            { return true; }
            // check for enemmies
            if (GameManager.enemiesMap1.Any(enmy => enmy._x == x && enmy._y == y))
            { return true; }
            if (GameManager.enemiesMap2.Any(enmy => enmy._x == x && enmy._y == y))
            { return true; }
            if (GameManager.enemiesMap3.Any(enmy => enmy._x == x && enmy._y == y))
            { return true; }
            if (GameManager.enemyRiderList.Any(enmy => enmy._x == x && enmy._y == y))
            { return true; }
            // Check for gold spawn using current map's dictionary list
            if (GameManager.MapTreasureRegistry.ContainsKey(currentMap))
            {
                if (GameManager.MapTreasureRegistry[currentMap].Any(g => g.x == x && g.y == y))/// checks positions from dictionary for current map
                { return true; }
            }

            if (GameManager.MapOrbRegistry.ContainsKey(currentMap))
            {
                if (GameManager.MapOrbRegistry[currentMap].Any(g => g.x == x && g.y == y))/// checks positions from dictionary for current map
                { return true; }
            }

            if (GameManager.MapPeonRegistry.ContainsKey(currentMap))
            {
                if (GameManager.MapPeonRegistry[currentMap].Any(p => p.x == x && p.y == y))
                { return true; }
            }
            // Check there is already a captive there using current dictionary list for current map
            if (GameManager.MapCaptiveRegistry.ContainsKey(currentMap))
            {
                if (GameManager.MapCaptiveRegistry[currentMap].Any(p => p.x == x && p.y == y))
                { return true; }
            }
            return false;
        }

        public static void StartGame()
        {
            Console.SetCursorPosition(0, 0);
            HUD.alias();
            Console.Clear();
            Console.CursorVisible = false;

            Console.CursorVisible = false;
            map.DrawMap();
            MyEvents.AmbushTriggered();

            enemiesMap1.Clear();
            enemiesMap1.Add(new EnemyLeader("Gobbo", 50, 4, 10, '&', 25, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap1.Add(new EnemyLeader("Slobbo", 20, 23, 8, '&', 20, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap1.Add(new EnemyLeader("Orcus", 15, 13, 12, 'O', 40, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap1.Add(new EnemyLeader("Boss Hobbo", 49, 20, 15, 'H', 80, ConsoleColor.DarkMagenta, ConsoleColor.Green, (1, 55), (1, 24)));

            enemiesMap2.Clear();
            enemiesMap2.Add(new EnemyLeader("Gnolie", 4, 4, 16, 'g', 35, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap2.Add(new EnemyLeader("Gnawlie", 5, 20, 18, 'g', 30, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap2.Add(new EnemyLeader("ZugZug", 31, 12, 12, 'O', 60, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap2.Add(new EnemyLeader("Boss Gobstomper", 45, 22, 15, 'G', 140, ConsoleColor.DarkMagenta, ConsoleColor.Green, (1, 55), (1, 24)));

            enemiesMap3.Clear();
            enemiesMap3.Add(new EnemyLeader("Bammo", 17, 6, 10, 'O', 65, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap3.Add(new EnemyLeader("Slammo", 17, 23, 8, 'O', 60, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap3.Add(new EnemyLeader("Ogrelet", 37, 10, 20, 'Q', 90, ConsoleColor.Magenta, ConsoleColor.DarkGreen, (1, 55), (1, 24)));
            enemiesMap3.Add(new EnemyLeader("Boss Drowkus", 48, 23, 25, 'D', 180, ConsoleColor.DarkMagenta, ConsoleColor.Green, (1, 55), (1, 24)));

            while (isPlaying)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                HUD.Instructions();
                player._name = Name;
                player._attack = plaAtkUP;

                int plX = 0, plY = 0;
                ConsoleKey input = Console.ReadKey(true).Key;
                // move player with W,A,S,D or optional arrow keys 
                if (input == ConsoleKey.LeftArrow) plX = -1;
                if (input == ConsoleKey.A) plX = -1;
                if (input == ConsoleKey.RightArrow) plX = 1;
                if (input == ConsoleKey.D) plX = 1;
                if (input == ConsoleKey.UpArrow) plY = -1;
                if (input == ConsoleKey.W) plY = -1;
                if (input == ConsoleKey.DownArrow) plY = 1;
                if (input == ConsoleKey.S) plY = 1;

                if (input == ConsoleKey.Q) isPlaying = false; //Quit the 'is playing' loop
                if (input == ConsoleKey.R) Restart();//Restarts the game
                HUD.ClearMessage();
                player.Move(plX, plY);
                Treasure.CheckTreasureCollection();
                Captive.CheckCapCollection();
                PowerOrb.CheckOrbCollection();
                Peon.CheckPeonCollection();

                /*>>>>>>*/
                var newSpawn = map.MapChanger(player._x, player._y); //references the map changer function

                if (newSpawn.HasValue) //changes maps if triggers are found
                {
                    // sets player position to new spawn point 
                    player._x = newSpawn.Value.x;
                    player._y = newSpawn.Value.y;

                }
                CollectSpawner.SetupMapAssets();
                Peon.DrawPeon();
                EnviroHeal.SpringWatterHealling();
                EnviroDmg.LavaDamage();
                if (map._mapsCurrent[player._y][player._x] == 'X')
                {
                    isPlaying = false;
                    continue; //skips past rest
                }

                if (GameManager.map._currentMapIndex == 0)
                {
                    for (int i = enemiesMap1.Count - 1; i >= 0; i--)
                    {
                        if (enemiesMap1[i]._health <= 0)
                        {
                            Console.Beep(300, 100);
                            Console.Beep(200, 150);
                            Console.SetCursorPosition(enemiesMap1[i]._x, enemiesMap1[i]._y);
                            WriteTileWithColor(map._mapsCurrent[enemiesMap1[i]._y][enemiesMap1[i]._x]);
                            enemiesMap1.RemoveAt(i);
                        }
                        else
                        { EnemyLeader.MoveEnemy(enemiesMap1[i]); }
                    }
                }
                if (GameManager.map._currentMapIndex == 1)
                {
                    for (int i = enemiesMap2.Count - 1; i >= 0; i--)
                    {
                        if (enemiesMap2[i]._health <= 0)
                        {
                            Console.Beep(300, 100);
                            Console.Beep(200, 150);
                            Console.SetCursorPosition(enemiesMap2[i]._x, enemiesMap2[i]._y);
                            WriteTileWithColor(map._mapsCurrent[enemiesMap2[i]._y][enemiesMap2[i]._x]);
                            enemiesMap2.RemoveAt(i);
                        }
                        else
                        { EnemyLeader.MoveEnemy(enemiesMap2[i]); }
                    }
                }

                if (GameManager.map._currentMapIndex == 2)
                {
                    for (int i = enemiesMap3.Count - 1; i >= 0; i--)
                    {
                        if (enemiesMap3[i]._health <= 0)
                        {
                            Console.Beep(300, 100);
                            Console.Beep(200, 150);
                            Console.SetCursorPosition(enemiesMap3[i]._x, enemiesMap3[i]._y);
                            WriteTileWithColor(map._mapsCurrent[enemiesMap3[i]._y][enemiesMap3[i]._x]);
                            enemiesMap3.RemoveAt(i);
                        }
                        else
                        { EnemyLeader.MoveEnemy(enemiesMap3[i]); }
                    }
                }

                if (GameManager.map._currentMapIndex == 3)
                {
                    for (int i = enemyRiderList.Count - 1; i >= 0; i--)
                    {
                        if (enemyRiderList[i]._health <= 0)
                        {
                            Console.Beep(300, 100);
                            Console.Beep(200, 150);
                            Console.SetCursorPosition(enemyRiderList[i]._x, enemyRiderList[i]._y);
                            WriteTileWithColor(map._mapsCurrent[enemyRiderList[i]._y][enemyRiderList[i]._x]);
                            enemyRiderList.RemoveAt(i);
                        }
                        else
                        { EnemyRider.MoveTowards(enemyRiderList[i]); }
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                DrawEntities();
                Thread.Sleep(50);///
                HUD.plStats();
                

            }

           // 
   
            if ((map._mapsCurrent[player._y][player._x] == 'X') || (player._health == 0))
            {
                if (player._health == 0)
                { HUD.plDied();
                    ConsoleKey input = Console.ReadKey(true).Key;
                   if (input == ConsoleKey.R) Restart(); 
                }
                if (map._mapsCurrent[player._y][player._x] == 'X')
                {
                    isPlaying = false;
                    HUD.plWin();
                    ConsoleKey input = Console.ReadKey(true).Key;
                    if (input == ConsoleKey.R) Restart();

                }
                else
                {
                    HUD.Farewell();
                }
            }
         
        }



        public static void WriteTileWithColor(char tile) //colours the map tiles and writes them to screen
        {
            if (tile == '%')
            { Console.ForegroundColor = ConsoleColor.Red; Console.BackgroundColor = ConsoleColor.DarkRed; }
            else if (tile == 'w')
            { Console.ForegroundColor = ConsoleColor.DarkCyan; Console.BackgroundColor = ConsoleColor.Blue; }
            else if (tile == '#')
            { Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.DarkGray; }
            else if (tile == ',')
            { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.BackgroundColor = ConsoleColor.Yellow; }
            else if (tile == '^')
            { Console.ForegroundColor = ConsoleColor.DarkGreen; Console.BackgroundColor = ConsoleColor.Green; }
            else if (tile == '[')
            { Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.Gray; }
            else if (tile == ']')
            { Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.Gray; }
            else if (tile == 'M')
            { Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.Gray; }
            else if (tile == '{')
            { Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.BackgroundColor = ConsoleColor.Magenta; }
            else if (tile == '}')
            { Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.BackgroundColor = ConsoleColor.Magenta; }
            else if (tile == 'X')
            { Console.ForegroundColor = ConsoleColor.White; Console.BackgroundColor = ConsoleColor.Gray; }
            else if (tile == '.')
            { Console.ForegroundColor = ConsoleColor.Red; Console.BackgroundColor = ConsoleColor.DarkGray; }
            else if (tile == '`')
            { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.BackgroundColor = ConsoleColor.Yellow; }
            else Console.ForegroundColor = ConsoleColor.White;

            Console.Write(tile);
            Console.ResetColor();
        }


        public static void ColorFlash()
        {

            if (GameManager.map._currentMapIndex == 0)
            {
                foreach (var enmy in enemiesMap1)
                {
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.Red;
                    Console.Write(enmy._symbol);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.DarkGreen;
                    Console.Write(enmy._symbol);
                    break;
                }
            }
            if (GameManager.map._currentMapIndex == 1)
            {
                foreach (var enmy in enemiesMap2)
                {
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.Red;
                    Console.Write(enmy._symbol);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.DarkGreen;
                    Console.Write(enmy._symbol);
                    break;
                }
            }

            if (GameManager.map._currentMapIndex == 2)
            {
                foreach (var enmy in enemiesMap3)
                {
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.Red;
                    Console.Write(enmy._symbol);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.DarkGreen;
                    Console.Write(enmy._symbol);
                    break;
                }
            }
            if (GameManager.map._currentMapIndex == 3)
            {
                foreach (var enmy in enemyRiderList)
                {
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.Red;
                    Console.Write(enmy._symbol);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    enmy._fgColor = enmy._fgColor;
                    enmy._bgColor = ConsoleColor.DarkMagenta;
                    Console.Write(enmy._symbol);
                    break;
                }
            }

            Thread.Sleep(500);
            Console.SetCursorPosition(player._x, player._y);
            player._fgColor = player._fgColor;
            player._bgColor = ConsoleColor.DarkYellow;
            Console.Write(player._symbol);
            Thread.Sleep(500);
            Console.SetCursorPosition(player._x, player._y);
            player._fgColor = player._fgColor;
            player._bgColor = ConsoleColor.White;
            Console.Write(player._symbol);
        }

        public static void Restart()
        {

            Console.Clear();
            StartGame();

        }

        /*>>>>>>*/
        public static void DrawEntities()// draws the player and the enemy symbols/ sprites
        {
            if (GameManager.map._currentMapIndex == 0)
            {
                foreach (var enmy in enemiesMap1)
                {
                    if (enmy._health > 0) // Only draw if alive
                    {
                        Console.SetCursorPosition(enmy._x, enmy._y);
                        Console.ForegroundColor = enmy._fgColor;
                        Console.BackgroundColor = enmy._bgColor;
                        Console.Write(enmy._symbol);
                    }
                }
            }

            if (GameManager.map._currentMapIndex == 1)
            {
                foreach (var enmy in enemiesMap2)
                {
                    if (enmy._health > 0) // Only draw if alive
                    {
                        Console.SetCursorPosition(enmy._x, enmy._y);
                        Console.ForegroundColor = enmy._fgColor;
                        Console.BackgroundColor = enmy._bgColor;
                        Console.Write(enmy._symbol);
                    }
                }
            }
            if (GameManager.map._currentMapIndex == 2)
            {
                foreach (var enmy in enemiesMap3)
                {
                    if (enmy._health > 0) // Only draw if alive
                    {
                        Console.SetCursorPosition(enmy._x, enmy._y);
                        Console.ForegroundColor = enmy._fgColor;
                        Console.BackgroundColor = enmy._bgColor;
                        Console.Write(enmy._symbol);
                    }
                }
            }
            if (GameManager.map._currentMapIndex == 3)
            {
               // MyEvents.AmbushMapCheck();
                MyEvents.AmbushTriggered();
            }
            Console.SetCursorPosition(player._x, player._y);
            Console.ForegroundColor = player._fgColor;
            Console.BackgroundColor = player._bgColor;
            Console.Write(player._symbol);
            Console.ResetColor();
            Peon.MovePeonsRandomly();
        } 
    }

}














