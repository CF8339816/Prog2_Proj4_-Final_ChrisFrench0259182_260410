using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{

    public class Adjustor
    {
        public string _name { get; set; }
       
        public char _symbol { get; protected set; }
        public int _output { get; set; }

        public ConsoleColor _color;

        protected Adjustor(string Name, char symbol, int output, ConsoleColor color)
        {
            _name = Name;
        
            _symbol = symbol;
            _output = output;
            _color = color;
          
        }






    }
}
