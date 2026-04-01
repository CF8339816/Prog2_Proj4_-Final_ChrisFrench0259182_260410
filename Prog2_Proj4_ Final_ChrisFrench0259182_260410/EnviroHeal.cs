 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class EnviroHeal : Adjustor
    {

        public static int _healing;

        public EnviroHeal(string Name, char symbol, int output, ConsoleColor color) : base(Name, symbol: 'w', output: _healing, ConsoleColor.DarkCyan)
        {

            Name = "Spring Water";



        }

        public static void SpringWatterHealling()
        {

            if (GameManager.map._mapsCurrent[GameManager.player._y][GameManager.player._x] == 'w')// applies spring water healing
            {
                GameManager.player._health += 20;
                if (GameManager.player._health > GameManager.plaMaxHP)
                {
                    GameManager.player._health = GameManager.plaMaxHP;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(60, 11);
                Console.WriteLine($"{GameManager.player._name} Finds cool refreshing sparkling mineral");
                Console.SetCursorPosition(60, 12);
                Console.WriteLine($" water and is healed for 20 pts ");
                Console.SetCursorPosition(60, 12);
                Console.WriteLine($"{GameManager.player._name} now has {GameManager.player._health} HP");
            }

        }

    }
}
