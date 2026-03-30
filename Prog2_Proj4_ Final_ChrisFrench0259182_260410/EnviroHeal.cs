using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
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

            if (Program.map._mapsCurrent[Program.player._y][Program.player._x] == 'w')// applies spring water healing
            {
                Program.player._health += 20;
                if (Program.player._health > Program.plaMaxHP)
                {
                    Program.player._health = Program.plaMaxHP;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(60, 11);
                Console.WriteLine($"{Program.player._name} Finds cool refreshing sparkling mineral");
                Console.SetCursorPosition(60, 12);
                Console.WriteLine($" water and is healed for 20 pts ");
                Console.SetCursorPosition(60, 12);
                Console.WriteLine($"{Program.player._name} now has {Program.player._health} HP");
            }

        }

    }
}
