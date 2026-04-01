using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class rectangle
    {

        public string _name { get; set; }

        //public ConsoleColor _bgColor { get; set; }
        //public ConsoleColor _fgColor { get; set; }
        public static bool _isTriggered { get; set; }
        public int _min_x { get; set; }
        public int _min_y { get; set; }
        public int _max_x { get; set; }
        public int _max_y { get; set; }
        protected rectangle(string Name, /*ConsoleColor fgColor, ConsoleColor bgColor,*/ int Rect_min_x, int Rect_max_x, int Rect_min_y, int Rect_max_y, bool IsTriggered)
        {
            _name = Name;
            //_bgColor = bgColor;
            //_fgColor = fgColor;
            _min_x = Rect_min_x;
            _min_y = Rect_min_y;
            _max_x = Rect_max_x;
            _max_y = Rect_max_y;
            _isTriggered = IsTriggered;


    }

}
}
