using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class Collectable
    {
        public string _name { get; set; }
        public int _x { get; set; }
        public int _y { get; set; }
        public int _count { get; set; }
        public char _symbol { get; protected set; }
        //public int _output{ get; set; }

        public ConsoleColor _color;

        public (int, int) _min_max_x = (8, 46);
        public (int, int) _min_max_y = (8, 21);
        protected Collectable(string Name, int x, int y, int count, char symbol,/*int output,*/ ConsoleColor color, (int, int) min_max_x, (int, int) min_max_y)
        {
            _name = Name;
            _x = x;
            _y = y;
            _count = count;
            _symbol = symbol;
          //  _output = output;
            _color = color;
            _min_max_x = min_max_x;
             _min_max_y = min_max_y;    
        }

    }
}
