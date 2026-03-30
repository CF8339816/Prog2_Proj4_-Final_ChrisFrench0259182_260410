using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class Character
    {

        public string _name { get; set; }
        public int _x { get; set; }
        public int _y { get; set; }
        public int _attack { get; set; }
        public char _symbol { get; protected set; }
        public int _health { get; set; }

       // public ConsoleColor _color;

        public ConsoleColor _bgColor { get; set; }
        public ConsoleColor _fgColor { get; set; }



        public (int, int) _min_max_x = (1, 55);
        public (int, int) _min_max_y = (1, 24);
        protected Character(string Name, int x, int y, int attack, char symbol, int hp, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) _min_max_x, (int, int) _min_max_y)
        {
            _name = Name;
            _x = x;
            _y = y;
            _attack = attack;
            _symbol = symbol;
            _health = hp;
            //_color = color;
            _bgColor = bgColor;
            _fgColor = fgColor;
            Console.BackgroundColor = _bgColor;
            Console.ForegroundColor = _fgColor;
        }


    }
}
