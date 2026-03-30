using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class EnemyLeader : Character
    {
        public EnemyLeader(string Name, int x, int y, int attack, char symbol, int hp, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) _min_max_x, (int, int) _min_max_y) :
            base(Name, x, y, attack, symbol, hp, fgColor, bgColor, (1, 55), (1, 24))
        {
        }

        private static Random enRando = new Random();

        public static void MoveEnemy(EnemyLeader enmy)
        {
          
            int nextX = enmy._x;
            int nextY = enmy._y;
        
            bool isPlayerNear = (enmy._x + 2 >= Program.player._x && enmy._x - 2 <= Program.player._x && enmy._y + 2 >= Program.player._y && enmy._y - 2 <= Program.player._y);
           
            if (isPlayerNear)
            {

                if (enmy._x < Program.player._x) nextX++;
                else if (enmy._x > Program.player._x) nextX--;

                if (enmy._y < Program.player._y) nextY++;
                else if (enmy._y > Program.player._y) nextY--;
            }
            else
            {
                nextX += enRando.Next(-1, 2);
                nextY += enRando.Next(-1, 2);
            }
            bool inBounds = (nextX >= 1 && nextX <= 55 && nextY >= 1 && nextY <= 24);
            bool isPathBlockedByEnemy = false;
            foreach (EnemyLeader other in Program.enemiesMap1)
            {
                if (other != enmy && nextX == other._x && nextY == other._y)
                {
                    isPathBlockedByEnemy = true;
                    break;
                }
            }
            foreach (EnemyLeader other in Program.enemiesMap2)
            {
                if (other != enmy && nextX == other._x && nextY == other._y)
                {
                    isPathBlockedByEnemy = true;
                    break;
                }
            }
            foreach (EnemyLeader other in Program.enemiesMap3)
            {
                if (other != enmy && nextX == other._x && nextY == other._y)
                {
                    isPathBlockedByEnemy = true;
                    break;
                }
            }
         
                char targetTile = Program.map._mapsCurrent[nextY][nextX];
            if (inBounds && !isPathBlockedByEnemy && !Program.IsTileOccupied(nextX, nextY) && targetTile != '*' && targetTile != '!' && targetTile != 'S' && targetTile != '$' && targetTile != '#' && targetTile != 'w' && targetTile != '%' && targetTile != '@' && (nextX != Program.player._x || nextY != Program.player._y))
            {
                Console.SetCursorPosition(enmy._x, enmy._y);
                char oldTile = Program.map._mapsCurrent[enmy._y][enmy._x];
                Program.WriteTileWithColor(oldTile);

                enmy._x = nextX;
                enmy._y = nextY;

                Console.SetCursorPosition(enmy._x, enmy._y);
                Console.ForegroundColor = enmy._fgColor;
                Console.ForegroundColor = enmy._bgColor;
                Console.Write(enmy._symbol);
                Console.ResetColor();
            }
            else
            {
                foreach (EnemyLeader other in Program.enemiesMap1)
                {
                    if (other != enmy && nextX == other._x && nextY == other._y)
                    {
                        Program.isAlly = true;
                        break;
                    }
                }
                foreach (EnemyLeader other in Program.enemiesMap2)
                {
                    if (other != enmy && nextX == other._x && nextY == other._y)
                    {
                        Program.isAlly = true;
                        break;
                    }
                }
                foreach (EnemyLeader other in Program.enemiesMap3)
                {
                    if (other != enmy && nextX == other._x && nextY == other._y)
                    {
                        Program.isAlly = true;
                        break;
                    }
                }
       
                if (inBounds && !Program.IsTileOccupied(nextX, nextY) && targetTile != '*' && targetTile != '!' && targetTile != 'S' && targetTile != '$' && targetTile != '#' && targetTile != 'w' && targetTile != '%' && targetTile != '@')
                {
                    Console.SetCursorPosition(enmy._x, enmy._y);
                    char oldTile = Program.map._mapsCurrent[enmy._y][enmy._x];
                    Program.WriteTileWithColor(oldTile);

                    enmy._x = nextX;
                    enmy._y = nextY;

                    Console.SetCursorPosition(enmy._x, enmy._y);
                    Console.ForegroundColor = enmy._fgColor;
                    Console.ForegroundColor = enmy._bgColor;
                    Console.Write(enmy._symbol);
                    Console.ResetColor();
                }
                else
                {
                    nextX = 0;
                    nextY = 0;

                    Console.SetCursorPosition(enmy._x, enmy._y);
                    Console.ForegroundColor = enmy._fgColor;
                    Console.ForegroundColor = enmy._bgColor;
                    Console.Write(enmy._symbol);
                    Console.ResetColor();

                }
            } 
        }

    }
}
