using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class LoadMap
    {

        private string[] _filePaths = { "map1.txt", "map2.txt", "map3.txt", "map4.txt" };// creates a string of filep[atths to call tto for creatting the string of strings in all maps
        private string[][] _allMaps = new string[4][]; // stores maps in a string of strings so they can be inddexed to move forward and back through them
        public string[] _mapsCurrent; // initiattes ourt usage string for current to draw map from the all maps string
        public int _currentMapIndex = 0; //initiates and sets the default map to display first 

        public LoadMap()
        {
            MapLoader();
            // Initialize _mapsCurrent to the first map in the array
            if (_allMaps[0] != null)
            {
                _mapsCurrent = _allMaps[0];
            }
        }

        public void MapLoader()
        {
            for (int i = 0; i < _filePaths.Length; i++)
            {
                try
                {
                    _allMaps[i] = File.ReadAllLines(_filePaths[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading {_filePaths[i]}: {ex.Message}"); // srror loading messages 
                    
                    _allMaps[i] = new string[] 
                    
                    {
                    "+~~~~~~~~~~~~~~~~ Return to NEVERWHERE ~~~~~~~~~~~~~~~~~+" +
                    "|-------------------------------------------------------|" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                        404                            |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                Your Castle is around                  |" +
                    "|                    another Princess                   |" +
                    "|                          ...                          |" +
                    "|              You had best look elsewhere              |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "|                      A__|./__A                        |" +
                    "|                      ( o Y o )                        |" +
                    "|                      @| ()() |@                       |" +
                    "|                      ;|++++++|;                       |" +
                    "|                        |_@@_|                         |" +
                    "|                                                       |" +
                    "|                                                       |" +
                    "+-------------------------------------------------------+" };// dummy output if map file is broken

                }
            }


        }
        public (int x, int y)? MapChanger(int x, int y) //sets the map changer to look for the specified tiles to get the x,y ints
        {
            char tile = _mapsCurrent[y][x];

          
            if (tile == '@' && _currentMapIndex < _allMaps.Length - 1)// checks for forward portall in player movement
            {
                _currentMapIndex++;
                _mapsCurrent = _allMaps[_currentMapIndex];
                DrawMap();
                return FindTile('*'); // Spawn at the backward entrance of next map
            }
            
            else if (tile == '*' && _currentMapIndex > 0)// Step on * to Go Backward
            {
                _currentMapIndex--;
                _mapsCurrent = _allMaps[_currentMapIndex];
                DrawMap();
                return FindTile('@'); // Spawn at the forward exit of previous map
            }

            return null; // No map change

           
        }
      
        public (int x, int y) FindTile(char target)
        {
            for (int y = 0; y < _mapsCurrent.Length; y++)
            {
                for (int x = 0; x < _mapsCurrent[y].Length; x++)
                {
                    if (_mapsCurrent[y][x] == target) return (x, y);
                }
            }
            return (3, 3); // Fallback spawn incase find tile breaks
        }

        public void DrawMap()
        {
            Console.Clear();
            for (int y = 0; y < _mapsCurrent.Length; y++)
            {
                foreach (char tile in _mapsCurrent[y])
                {
                    SetTileColor(tile);
                    Console.Write(tile);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void DrawTileAt(int x, int y)// redrawsorigional  map when tile isvacated by  player or enemy.
        {
            if (y < 0 || y >= _mapsCurrent.Length || x < 0 || x >= _mapsCurrent[y].Length) return;

            char tile = _mapsCurrent[y][x];
            Console.SetCursorPosition(x, y);
            SetTileColor(tile);
            Console.Write(tile);
            Console.ResetColor();
        }
        public void SetTileColor(char tile)// sets the tile colors for the map
        {
            switch (tile)
            {
                case '#': Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.DarkGray; break;
                case '%': Console.ForegroundColor = ConsoleColor.Red; Console.BackgroundColor = ConsoleColor.DarkRed; break;
                case 'G': Console.ForegroundColor = ConsoleColor.Cyan; Console.BackgroundColor = ConsoleColor.Black; break; 
                case '@': Console.ForegroundColor = ConsoleColor.DarkBlue; Console.BackgroundColor = ConsoleColor.Cyan; break; 
                case '*': Console.ForegroundColor = ConsoleColor.DarkBlue; Console.BackgroundColor = ConsoleColor.Cyan; break; 
                case '|': Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Black; break;
                case '-': Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Black; break; 
                case '+': Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Black; break;
                case '~': Console.ForegroundColor = ConsoleColor.DarkYellow; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'R': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'e': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 't': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'u': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'r': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'n': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break;
                case 'o': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'N': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'V': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break; 
                case 'W': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break;
                case 'H': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break;
                case 'E': Console.ForegroundColor = ConsoleColor.Magenta; Console.BackgroundColor = ConsoleColor.Black; break;
                case 'w': Console.ForegroundColor = ConsoleColor.DarkCyan; Console.BackgroundColor = ConsoleColor.Blue; break; 
                case '^': Console.ForegroundColor = ConsoleColor.DarkGreen; Console.BackgroundColor = ConsoleColor.Green; break; 
                case ',': Console.ForegroundColor = ConsoleColor.DarkYellow; Console.BackgroundColor = ConsoleColor.Yellow; break; 
                case 'M': Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.Gray; break; 
                case '.': Console.ForegroundColor = ConsoleColor.Red; Console.BackgroundColor = ConsoleColor.DarkGray; break;
                case '{': Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.BackgroundColor = ConsoleColor.Magenta; break;
                case '}': Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.BackgroundColor = ConsoleColor.Magenta; break;
                case '[': Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.Gray; break;
                case ']': Console.ForegroundColor = ConsoleColor.DarkGray; Console.BackgroundColor = ConsoleColor.Gray; break;
                case 'X': Console.ForegroundColor = ConsoleColor.White; Console.BackgroundColor = ConsoleColor.Gray; break;
                case '`': Console.ForegroundColor = ConsoleColor.DarkYellow; Console.BackgroundColor = ConsoleColor.Yellow; break;
                default: Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Black; break;
            }
        }
        public bool CanMoveTo(int tarMapX, int tarMapY)
        {
            // Safety check if map failed to load
            if (_mapsCurrent == null) return false;
            // Boundary Check
            if (tarMapY >= 0 && tarMapY < _mapsCurrent.Length && tarMapX >= 0 && tarMapX < _mapsCurrent[tarMapY].Length)
            {
                char tarTile = _mapsCurrent[tarMapY][tarMapX];

                switch (tarTile)
                {
                    case '#':
                        break;
                    case '|':
                        break;
                    case '-':
                        break;
                    case '+':
                        break;
                    case '{':
                        break;
                    case '}':
                        break;
                    case '[':
                        break;
                    case ']':
                        break;
                    case 'M':
                        break;
                    case '^':
                        break;
                    case '!': 
                        break;
                    case '&':
                        break;
                    case 'H':
                        break;
                    case 'O':
                        return false; // Walls and borders  player  and enemy are blocked

                    default:
                        return true; // Spaces and Lava are walkable
                }
            }
            return false;
        }
    }
}