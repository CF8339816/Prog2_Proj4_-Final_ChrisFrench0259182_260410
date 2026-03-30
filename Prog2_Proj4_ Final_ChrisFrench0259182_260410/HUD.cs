using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class HUD
    {

            
            public static void alias()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("What is your character's name");
            Console.ForegroundColor = ConsoleColor.Blue;
            GameManager.Name = Console.ReadLine();
            while (true)
            {
                if (GameManager.Name.Length <= GameManager.MaxNameLLength) break;

                Console.WriteLine($"Error: Input is too long! please limit to 15 characters({GameManager.Name.Length}/{GameManager.MaxNameLLength})");
                alias();
            }

            Console.ResetColor();
        }

        #region old combat hud
        /// <summary>
        /// combat hud worked until i go t the multiple maps working then i couldn't get it to ref the specific enemies being foughr only and alwatys tyhe last in the list. 
        /// had to move it back into the combat method to display correctly  this is what i was trying and could not get it to work 
        //public static void combat()
        //{
        //    if (Program.map._currentMapIndex == 0)
        //    {
        //        foreach (var enmy in Program.enemiesMap1)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.SetCursorPosition(60, 14);
        //            Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 15);
        //            Console.WriteLine($" {enmy._name} has {enmy._health} health...");
        //            Console.ForegroundColor = ConsoleColor.DarkRed;
        //            Console.SetCursorPosition(60, 17);
        //            Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 18);
        //            Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
        //        }
        //    }
        //    if (Program.map._currentMapIndex == 1)
        //    {
        //        foreach (var enmy in Program.enemiesMap2)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.SetCursorPosition(60, 14);
        //            Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 15);
        //            Console.WriteLine($" {enmy._name} has {enmy._health} health...");
        //            Console.ForegroundColor = ConsoleColor.DarkRed;
        //            Console.SetCursorPosition(60, 17);
        //            Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 18);
        //            Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
        //        }
        //    }
        //    if (Program.map._currentMapIndex == 2)
        //    {
        //        foreach (var enmy in Program.enemiesMap3)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.SetCursorPosition(60, 14);
        //            Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 15);
        //            Console.WriteLine($" {enmy._name} has {enmy._health} health...");
        //            Console.ForegroundColor = ConsoleColor.DarkRed;
        //            Console.SetCursorPosition(60, 17);
        //            Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 18);
        //            Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
        //        }
        //    }
        //    if (Program.map._currentMapIndex == 3)
        //    {
        //        foreach (var enmy in Program.enemyRiderList)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.SetCursorPosition(60, 14);
        //            Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 15);
        //            Console.WriteLine($" {enmy._name} has {enmy._health} health...");
        //            Console.ForegroundColor = ConsoleColor.DarkRed;
        //            Console.SetCursorPosition(60, 17);
        //            Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
        //            Console.SetCursorPosition(60, 18);
        //            Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
        //        }
        //    }
        //}
        /// </summary>
        #endregion 
        public static void PeonSmite()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(60, 12);
            Console.WriteLine($" the clueless peon looks up at you and takes {GameManager.player._attack} points");
            Console.SetCursorPosition(60, 13);
            Console.WriteLine($" of combat damage");
            Console.SetCursorPosition(60, 14);
            Console.WriteLine($" you have turned this poor peon into gooo how much health ");
            Console.SetCursorPosition(60, 15);
            Console.WriteLine($"do you think it has?");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(60, 17);
            Console.WriteLine($" {GameManager.player._name} takes 2 points of combat damage, ");
            Console.SetCursorPosition(60, 18);
            Console.WriteLine($" '...tis but a scratch' {GameManager.player._name} has {GameManager.player._health} health...");
        }

        public static void Instructions()
        {
            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press any Key to start... Use W,A,S,D  or arrow keys to move around the map...Press 'Q' to exit...\n" +
                "Fight enemies by manouvering to them or try to avoid them... Get to your castle [XXX].\n" +
                " Lava '%' will damage you, Water 'w' will heal you, '@' and '*' will port you forward and back through the maps");
            Console.ResetColor();
        }
        public static void plStats()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(58, 1);
            Console.WriteLine($"Name:{GameManager.player._name} Health:{GameManager.player._health}/{GameManager.plaMaxHP} attack:{GameManager.plaAtkUP} Xp:{Player.plXP} Level:{Player.plLevel}");
            Console.SetCursorPosition(58, 2);
            Console.WriteLine($"Gold:{Treasure._gold} Captives Freed:{Captive._freed}");
            Console.ResetColor();
        }
        public static void plDied()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(60, 22);// outputs player death and end of game prompts to exit
            Console.WriteLine($" {GameManager.player._name} has {GameManager.player._health} health, {GameManager.player._name} has died ");
            Console.SetCursorPosition(60, 23); 
            Console.WriteLine($"with {Treasure._gold} gold on them and freed {Captive._freed} captives who were sadly ");
            Console.SetCursorPosition(60, 24);
            Console.WriteLine("recaptured, and very mean things were done to them.");
            Console.ReadKey(true);
            Console.ResetColor();
        }

        public static void plWin()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(58, 22);// outputs player death and end of game prompts to exit
            Console.WriteLine($"{GameManager.player._name} has reached the goal with {GameManager.player._health} health, ");
            Console.SetCursorPosition(58, 23);
            Console.WriteLine($"{GameManager.player._name} is safe with {Treasure._gold} golds and freed {Captive._freed} captives.");
            Console.SetCursorPosition(58, 24);
            Console.WriteLine($"{GameManager.player._name}'s legend will be told till the ends of time.");
            Console.ReadKey(true);
            Console.ResetColor();
        }

        public static void Kaboom()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(58, 5);
            Console.WriteLine($"{GameManager.player._name} loots the Holy Fraculator! A.K.A. The Peon");
            Console.SetCursorPosition(58, 6);       
            Console.WriteLine($"Mulcher 6000. Fine print on 1 side says 'Face Towards Peon'.");    
            Console.SetCursorPosition(58, 7);
            Console.WriteLine($"A wave of energy pulses out and kills all low level peons");
            Console.SetCursorPosition(58, 8);
            Console.WriteLine($"on this stage {GameManager.player._name} gets {PowerOrb._XP} XP...woooo!");
            Console.ResetColor();



        }
        public static void Farewell()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
           
           
            Console.SetCursorPosition(60, 25);
            Console.WriteLine("We hope you come back soon... Please press any key to exit");
            Console.ReadKey(true);
            Console.WriteLine("\n\n\n\n\n\n");
            Console.ResetColor();

        }

        public static void Looter()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(60, 5);
            Console.WriteLine($" {GameManager.player._name} loots {Treasure.loot} amounts of golds! ");
            Console.SetCursorPosition(60, 6);
            Console.WriteLine($"{GameManager.player._name} now has {Treasure.goldie} gold...woooo!");

            Console.ResetColor();



        }

        public static void Moses()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(60, 4);
            Console.WriteLine($"{GameManager.player._name} has freed a captive... Good Job! They thank");
                Console.SetCursorPosition(60, 5);
            Console.WriteLine($"you with a small power up an a couple of gold they hid.");

            Console.ResetColor();
        }

        public static void AnakinMustafar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(60, 8);
            Console.WriteLine($" {GameManager.player._name} takes 30 points of lava damage");
            Console.SetCursorPosition(60, 9);
            Console.WriteLine($" {GameManager.player._name} now has {GameManager.player._health} HP");
            Console.ResetColor();
        }


        public static void ClearMessage()
        {
            Console.SetCursorPosition(58, 4);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 5);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 6);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 7);
            Console.Write(new string(' ', 60)); 
            Console.SetCursorPosition(58, 8);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 9);
            Console.Write(new string(' ', 60)); 
            Console.SetCursorPosition(58, 10);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 11);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 12);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 13);   
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 14);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 15);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 16);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 17);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 18);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 19);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 20);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(58, 21);
            Console.Write(new string(' ', 60));
       



        }

    }
}
