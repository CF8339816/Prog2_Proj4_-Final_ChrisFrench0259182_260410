using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    internal class EnemyRider : Character
    {
        public EnemyRider(string Name, int x, int y, int attack, char symbol, int hp, ConsoleColor fgColor, ConsoleColor bgColor, (int, int) _min_max_x, (int, int) _min_max_y) 
            : base(Name, x, y, attack, symbol, hp, fgColor, bgColor, (1, 55), (1, 24))
        {
        }


        //public static void MoveTowards(Program.player._x, Program.player._y)
        public static void MoveTowards(EnemyRider enemyRider)
        {
           
            int nextX = enemyRider._x;
            int nextY = enemyRider._y;

             bool inBounds = (nextX >= 1 && nextX <= 55 && nextY >= 1 && nextY <= 24);

            if (enemyRider._x < GameManager.player._x) nextX++;
            else if (enemyRider._x > GameManager.player._x) nextX--;

            if (enemyRider._y < GameManager.player._y) nextY++;
            else if (enemyRider._y > GameManager.player._y) nextY--;

            bool isPathBlockedByEnemy = false;

            foreach (EnemyRider rideOther in GameManager.enemyRiderList)
            {
                if (rideOther != enemyRider && nextX == rideOther._x && nextY == rideOther._y)
                {
                    isPathBlockedByEnemy = true;
                    break;
                }
            }

            char targetTile = GameManager.map._mapsCurrent[nextY][nextX];

            if (inBounds && !isPathBlockedByEnemy && !GameManager.IsTileOccupied(nextX, nextY) && targetTile != '%' && targetTile != '^' && targetTile != 'w' && targetTile != 'M' && (nextX != GameManager.player._x || nextY != GameManager.player._y))
            {
                Console.SetCursorPosition(enemyRider._x, enemyRider._y);
                char oldTile = GameManager.map._mapsCurrent[enemyRider._y][enemyRider._x];
                GameManager.WriteTileWithColor(oldTile);

                enemyRider._x = nextX;
                enemyRider._y = nextY;

                Console.SetCursorPosition(enemyRider._x, enemyRider._y);
                Console.ForegroundColor = enemyRider._fgColor;
                Console.BackgroundColor = enemyRider._bgColor;
                Console.Write(enemyRider._symbol);
                Console.ResetColor();
            }
        }


    }
}
