using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    internal class rectangle
    {

        public string _name { get; set; }

        public ConsoleColor _bgColor { get; set; }
        public ConsoleColor _fgColor { get; set; }

        public (int, int) _min_max_x { get; set; }
        public (int, int) _min_max_y { get; set; }

        protected rectangle(string Name, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) Rect_min_max_x, (int, int) Rect_min_max_y)
        {
            _name = Name;
            _bgColor = bgColor;
            _fgColor = fgColor;
            _min_max_x = Rect_min_max_x;
            _min_max_y = Rect_min_max_y;
        }

    }
}
