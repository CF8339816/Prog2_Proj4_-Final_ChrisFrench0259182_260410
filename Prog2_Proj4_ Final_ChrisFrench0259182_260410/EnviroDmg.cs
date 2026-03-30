using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{ 
    public class EnviroDmg : Adjustor
    {

        public static int _lavaDmg;
      
        public EnviroDmg(string Name, char symbol, int output, ConsoleColor color) : base(Name, symbol: '%', output: _lavaDmg, ConsoleColor.Red)
        {

            Name = "Lava";   



        }


        public static void LavaDamage()
        {
            if (Program.map._mapsCurrent[Program.player._y][Program.player._x] == '%')// applies lava damage 
            {
                Program.player._health = Program.player._health - 30;

                if (Program.player._health < 0)
                {
                    Program.player._health = 0;
                }
                HUD.AnakinMustafar();

                if (Program.player._health == 0)
                {
                    Program.isPlaying = false;
                }
            }
        }
    }

}
