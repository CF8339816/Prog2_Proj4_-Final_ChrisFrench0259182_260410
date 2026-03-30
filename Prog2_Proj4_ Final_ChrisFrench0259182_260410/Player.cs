using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class Player : Character
    {
        //public static int plMaxHP = 50;
        public static int plXP = 0;
        public static int plLevel = 0;
        public Player(string Name, int x, int y, int attack, char symbol, int hp, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) _min_max_x, (int, int) _min_max_y) :
            base(Name, x, y, attack: Program.plaAtkUP, symbol: '!', hp: Program.plaMaxHP, fgColor: ConsoleColor.DarkBlue, bgColor: ConsoleColor.Blue, (1, 55), (1, 24))
        {
        }

        public void Move(int X, int Y)
        {

            int nextX = _x + X;
            int nextY = _y + Y;
        
            bool inBounds = (nextX >= 1 && nextX <= 55 && nextY >= 1 && nextY <= 24);
            bool hitEnemy = false;
          // bool isNextStepEnemy = true; ////  
          
            if (Program.map._currentMapIndex == 0)
              foreach (var enmy in Program.enemiesMap1)  // back in programs possible rename check enemy colisions
              {
                                


                    if (nextX == enmy._x && nextY == enmy._y)
                    {
                        //isNextStepEnemy = true;////

                        Console.Beep(800, 50);
                        //Console.SetCursorPosition(nextX, nextY);///
                        Program.ColorFlash();
                        Console.ResetColor();///
                        enmy._health -= _attack;
                        _health -= enmy._attack;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(60, 14);
                        Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
                        Console.SetCursorPosition(60, 15);
                        Console.WriteLine($" {enmy._name} has {enmy._health} health...");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(60, 17);
                        Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
                        Console.SetCursorPosition(60, 18);
                        Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
                        //HUD.combat();

                        if (_health <= 0 || enmy._health <= 0)
                        {
                            if (_health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                _health = 0;
                                Console.SetCursorPosition(60, 20);
                                Console.WriteLine($" {_name} has {_health} health, {_name} has died");
                                Program.isPlaying = false;
                                break;//
                            }
                            if (enmy._health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                enmy._health = 0;
                                plXP += 15;
                                Buffs.IncreaseXP(0);
                                Treasure._gold += 5;
                                Console.SetCursorPosition(60, 21);
                                Console.WriteLine($" {enmy._name} has {enmy._health} health, {enmy._name} has died");
                                Program.isPlaying = true;
                                Console.SetCursorPosition(nextX, nextY);///
                            }
                        }
                        break;///
                    }
              }

            if (Program.map._currentMapIndex == 1)
                foreach (var enmy in Program.enemiesMap2)  // back in programs   possible rename check enemy colisions
                {
                    if (nextX == enmy._x && nextY == enmy._y)
                    {
                        Console.Beep(800, 50);
                        //Console.SetCursorPosition(nextX, nextY);///
                        Program.ColorFlash();
                        Console.ResetColor();///
                        enmy._health -= _attack;
                        _health -= enmy._attack;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(60, 14);
                        Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
                        Console.SetCursorPosition(60, 15);
                        Console.WriteLine($" {enmy._name} has {enmy._health} health...");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(60, 17);
                        Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
                        Console.SetCursorPosition(60, 18);
                        Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
                        //HUD.combat();

                        if (_health <= 0 || enmy._health <= 0)
                        {
                            if (_health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                _health = 0;
                                Console.SetCursorPosition(60, 20);
                                Console.WriteLine($" {_name} has {_health} health, {_name} has died");
                                Program.isPlaying = false;
                                break;//
                            }
                            if (enmy._health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                enmy._health = 0;
                                plXP += 15;
                                Buffs.IncreaseXP(0);
                                Treasure._gold += 5;
                                Console.SetCursorPosition(60, 21);
                                Console.WriteLine($" {enmy._name} has {enmy._health} health, {enmy._name} has died");
                                Program.isPlaying = true;
                                Console.SetCursorPosition(nextX, nextY);///
                            }
                        }
                        break;///
                    }
                }

            if (Program.map._currentMapIndex == 2)
                foreach (var enmy in Program.enemiesMap3)  // back in programs   possible rename check enemy colisions
                {
                    if (nextX == enmy._x && nextY == enmy._y)
                    {
                        Console.Beep(800, 50);
                        //Console.SetCursorPosition(nextX, nextY);///
                        Program.ColorFlash();
                        Console.ResetColor();///
                        enmy._health -= _attack;
                        _health -= enmy._attack;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(60, 14);
                        Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
                        Console.SetCursorPosition(60, 15);
                        Console.WriteLine($" {enmy._name} has {enmy._health} health...");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(60, 17);
                        Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
                        Console.SetCursorPosition(60, 18);
                        Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
                        //HUD.combat();

                        if (_health <= 0 || enmy._health <= 0)
                        {
                            if (_health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                _health = 0;
                                Console.SetCursorPosition(60, 20);
                                Console.WriteLine($" {_name} has {_health} health, {_name} has died");
                                Program.isPlaying = false;
                                break;//
                            }
                            if (enmy._health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                enmy._health = 0;
                                plXP += 15;
                                Buffs.IncreaseXP(0);
                                Treasure._gold += 5;
                                Console.SetCursorPosition(60, 21);
                                Console.WriteLine($" {enmy._name} has {enmy._health} health, {enmy._name} has died");
                                Program.isPlaying = true;
                                Console.SetCursorPosition(nextX, nextY);///
                            }
                        }
                        break;///
                    }
                }
            if (Program.map._currentMapIndex == 3)
                foreach (var enmy in Program.enemyRiderList)  // back in programs   possible rename check enemy colisions
                {
                    if (nextX == enmy._x && nextY == enmy._y)
                    {
                        Console.Beep(800, 50);
                        //Console.SetCursorPosition(nextX, nextY);///
                        Program.ColorFlash();
                        Console.ResetColor();///
                        enmy._health -= _attack;
                        _health -= enmy._attack;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(60, 14);
                        Console.WriteLine($" {enmy._name} takes {Program.player._attack} points of combat damage");
                        Console.SetCursorPosition(60, 15);
                        Console.WriteLine($" {enmy._name} has {enmy._health} health...");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(60, 17);
                        Console.WriteLine($" {Program.player._name} takes {enmy._attack} points of combat damage");
                        Console.SetCursorPosition(60, 18);
                        Console.WriteLine($" {Program.player._name} has {Program.player._health} health...");
                        //HUD.combat();

                        if (_health <= 0 || enmy._health <= 0)
                        {
                            if (_health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                _health = 0;
                                Console.SetCursorPosition(60, 20);
                                Console.WriteLine($" {_name} has {_health} health, {_name} has died");
                                Program.isPlaying = false;
                                break;//
                            }
                            if (enmy._health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                enmy._health = 0;
                                plXP += 15;
                                Buffs.IncreaseXP(0);
                                Treasure._gold += 5;
                                Console.SetCursorPosition(60, 21);
                                Console.WriteLine($" {enmy._name} has {enmy._health} health, {enmy._name} has died");
                                Program.isPlaying = true;
                                Console.SetCursorPosition(nextX, nextY);///
                            }
                        }
                        break;///
                    }
                }

            if (!hitEnemy && Program.map.CanMoveTo(nextX, nextY))
            {
                Console.SetCursorPosition(_x, _y);
                char oldTile = Program.map._mapsCurrent[_y][_x];
                Program.WriteTileWithColor(oldTile);

                _x = nextX;// allowed to move here 
                _y = nextY;

            }

        }

    }

}




