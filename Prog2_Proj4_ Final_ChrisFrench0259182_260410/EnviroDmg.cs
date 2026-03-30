using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
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
            if (GameManager.map._mapsCurrent[GameManager.player._y][GameManager.player._x] == '%')// applies lava damage 
            {
                GameManager.player._health = GameManager.player._health - 30;

                if (GameManager.player._health < 0)
                {
                    GameManager.player._health = 0;
                }
                HUD.AnakinMustafar();

                if (GameManager.player._health == 0)
                {
                    GameManager.isPlaying = false;
                }
            }
        }
    }

}
