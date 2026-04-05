using prog2_Proj3_beta_ChrisFrench0259182_260324;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{

    public class MyEvents
    {
       public static bool _ambushTriggered = false;
        public static bool isTriggered = false;
  
            public static RecTrig recTrig = new RecTrig("trig", 0, 13,  0, 8, isTriggered);


     
        public static void AmbushTriggered()
        {

       



            if (GameManager.map._currentMapIndex == 3  )
            {     
                
             recTrig.ActivateTrigger();

                //if (GameManager.player._x <= triggerAreas.Trig._max_x || GameManager.player._y <= Trig._max_y)
                //{
                   
                //    if (isTriggered = true )
                //    {
                //        _ambushTriggered = false;
                //    }

                //    {
                //        _ambushTriggered = true;

                //    }
                //}

               
                //else
                //{
                //    _ambushTriggered = false;
                //}

                GameManager.enemyRiderList.Clear();
                GameManager.enemyRiderList.Add(new EnemyRider("Slasher", 44, 5, 10, 'k', 25, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
                GameManager.enemyRiderList.Add(new EnemyRider("Crasher", 3, 12, 8, 'k', 20, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
                GameManager.enemyRiderList.Add(new EnemyRider("Harrier", 13, 3, 12, 'k', 30, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
                GameManager.enemyRiderList.Add(new EnemyRider("PackAlphaNasty", 39, 15, 15, 'K', 200, ConsoleColor.DarkYellow, ConsoleColor.Magenta, (1, 55), (1, 24)));

                //Console.SetCursorPosition(60, 0);
                //Console.WriteLine("here comes a new challenger");
                Console.ReadKey(true);
                Console.Beep(); // Audio cue for the ambush


               
            }


            foreach (var enmyRide in GameManager.enemyRiderList)
            {
                if (enmyRide._health > 0) // Only draw if alive
                {
                    Console.SetCursorPosition(enmyRide._x, enmyRide._y);
                    Console.ForegroundColor = enmyRide._fgColor;
                    Console.BackgroundColor = enmyRide._bgColor;
                    Console.Write(enmyRide._symbol);
                }
            }
            UpdateRiders();
        }


        public static void UpdateRiders()
        {
            // Only move riders if the ambush has started
            if (_ambushTriggered)
            {
                foreach (var enmyRide in GameManager.enemyRiderList)
                {
                    if (enmyRide._health > 0) //verifies enemy alive before move
                    {
                       Console.SetCursorPosition(enmyRide._x, enmyRide._y);
                        Console.ForegroundColor = enmyRide._fgColor;
                        Console.BackgroundColor = enmyRide._bgColor;
                        Console.Write(enmyRide._symbol);
                        
                        EnemyRider.MoveTowards(enmyRide); //  move towards rather than randopm 
                    }
                    
                }
            }
        }
    }
}


