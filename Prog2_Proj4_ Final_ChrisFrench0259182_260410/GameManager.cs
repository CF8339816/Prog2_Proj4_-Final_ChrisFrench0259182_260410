using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    class GameManager
    {

      //  public static LoadMap map = new LoadMap();

       // public static bool isPlaying = true;
        public GameManager()

        {

        }
        //public static void PlayGame()
        //{

            //while (isPlaying)
            //{
            //    Program.player._name = Program.Name;
            //    Program.player._attack = Program.plaAtkUP;



            //    int plX = 0, plY = 0;
            //    ConsoleKey input = Console.ReadKey(true).Key;
            //    // move player with W,A,S,D or optional arrow keys 
            //    if (input == ConsoleKey.LeftArrow) plX = -1;
            //    if (input == ConsoleKey.A) plX = -1;
            //    if (input == ConsoleKey.RightArrow) plX = 1;
            //    if (input == ConsoleKey.D) plX = 1;
            //    if (input == ConsoleKey.UpArrow) plY = -1;
            //    if (input == ConsoleKey.W) plY = -1;
            //    if (input == ConsoleKey.DownArrow) plY = 1;
            //    if (input == ConsoleKey.S) plY = 1;

            //    if (input == ConsoleKey.Q) isPlaying = false; //Quit the 'is playing' loop

            //    Program.player.Move(plX, plY);


            //    if (map._mapsCurrent[Program.player._y][Program.player._x] == 'X')
            //    {
            //        isPlaying = false;
            //        continue; //skips past rest
            //    }
            //    for (int i = Program.enemies.Count - 1; i >= 0; i--)
            //    {
            //        if (Program.enemies[i]._health <= 0)
            //        {
            //            Console.Beep(300, 100);
            //            Console.Beep(200, 150);
            //            Console.SetCursorPosition(Program.enemies[i]._x, Program.enemies[i]._y);
            //            Program.WriteTileWithColor(map._mapsCurrent[Program.enemies[i]._y][Program.enemies[i]._x]);
            //            Program.enemies.RemoveAt(i);

            //        }
            //        Enemy.MoveEnemy(Program.enemies[i]);
            //    }

            //    Program.DrawEntities();


            //    HUD.plStats();

            // }

        //}

    }

}
