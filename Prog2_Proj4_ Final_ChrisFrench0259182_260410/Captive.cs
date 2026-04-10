using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Required for File reading


namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class Captive : Collectable
    {
     
        public string CaptiveName;
        public int _x_pos;
        public int _y_pos;

        public static Random _prisonerSpawn = new Random();
        public static int _prisonerCount = 9;
        public static (int, int) _prisoner_min_max_x = (8, 46);
        public static (int, int) _prisoner_min_max_y = (8, 21);
        public static int _freed;

   
        public Captive(string Name, int x, int y, int count, char symbol, ConsoleColor color, (int, int) min_max_x, (int, int) min_max_y) :
            base("Hostage", x, y, count: 9, symbol: 'S', ConsoleColor.White, (8, 46), (8, 21))
        {
            _x_pos = x;
            _y_pos = y;

            
            CaptiveName = GetRandomNameFromFile();
            _name = CaptiveName;
        }

       
        public static string GetRandomNameFromFile()
        {
            string filePath = "names.txt";
            try
            {
                if (File.Exists(filePath))
                {
                    
                    string content = File.ReadAllText(filePath);
                    string[] names = content.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    if (names.Length > 0)
                    {
                        return names[_prisonerSpawn.Next(names.Length)].Trim();
                    }
                }
            }
            catch (Exception ex)
            
            {
                Console.WriteLine($"Error loading {filePath}: {ex.Message}");
            }

            return "Unknown Prisoner"; 
        }

        public static void DrawPrisoner()
        {
            int currentMap = GameManager.map._currentMapIndex;

            if (!GameManager.MapCaptiveRegistry.ContainsKey(currentMap))
            {
                List<Captive> captives = new List<Captive>();
                for (int i = 0; i < _prisonerCount; i++)
                {
                    bool valid = false;
                    while (!valid)
                    {
                        int _x_pos = _prisonerSpawn.Next(_prisoner_min_max_x.Item1, _prisoner_min_max_x.Item2 + 1);
                        int _y_pos = _prisonerSpawn.Next(_prisoner_min_max_y.Item1, _prisoner_min_max_y.Item2 + 1);

                        if (!GameManager.IsTileOccupied(_x_pos, _y_pos))
                        {
                            captives.Add(new Captive("Hostage", _x_pos, _y_pos, count: 8, symbol: 'S', ConsoleColor.White, (8, 46), (8, 21)));
                            valid = true;
                        }
                    }
                }
                GameManager.MapCaptiveRegistry[currentMap] = captives;
            }

            foreach (var cap in GameManager.MapCaptiveRegistry[currentMap])
            {
                Console.SetCursorPosition(cap._x_pos, cap._y_pos);
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
                if (GameManager.player._x == slaves[i]._x_pos && GameManager.player._y == slaves[i]._y_pos)
                {
                    string Heston = slaves[i].CaptiveName;
                    _freed += 1;
                    Buffs.IncreaseXP(5);
                    Buffs.IncreaseMaxHealth(3);
                    Buffs.IncreaseATK(3);
                    Treasure._gold += 2;

                    // Pass the specific name to the HUD!
                    HUD.Moses(Heston);

                    slaves.RemoveAt(i);
                }
            }
        }
    }
}