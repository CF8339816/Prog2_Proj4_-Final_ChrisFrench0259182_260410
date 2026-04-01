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
        public static List<RecTrig> TriggerAreas = new List<RecTrig>();
          


        public static void AmbushTriggered(RecTrig recTrig)
        {

            TriggerAreas.Add(new RecTrig(" ", 13, 55, 1, 24, isTriggered));
            TriggerAreas.Add(new RecTrig(" ", 1, 55, 8, 24, isTriggered));

            foreach (var Trig in TriggerAreas)
            {
                recTrig.ActivateTrigger();

            }

            if (GameManager.map._currentMapIndex == 3  )
            {

                if (GameManager.player._x >= triggerAreas.Trig._min_x || GameManager.player._y >= Trig._min_y)
                {
                    //if (trigger1.IsTriggered = true || trigger2._isTriggered = true) ;
                    if (trigger1.IsTriggered = true || trigger2._isTriggered = true)
                    {
                        _ambushTriggered = false;
                    }

                    {
                        _ambushTriggered = true;

                    }
                }

                //if (GameManager.player._x >= trigger1._min_x || GameManager.player._y >= trigger2._min_y)
                //{
                //    //if (trigger1.IsTriggered = true || trigger2._isTriggered = true) ;
                //    if (trigger1.IsTriggered = true || trigger2._isTriggered = true)
                //    {
                //        _ambushTriggered = false;
                //    }

                //    {
                //        _ambushTriggered = true;

                //    }
                //}
                else
                {
                    _ambushTriggered = false;
                }

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


        //public static void AmbushMapCheck()
        //{

        //    if (GameManager.map._currentMapIndex == 3 && !_ambushTriggered) //sets this to run on map 3 only  and only if not alreacdy active
        //    {
        //        if ((GameManager.map._mapsCurrent[GameManager.player._y][GameManager.player._x] == '`'))// defines trigger location for event to begin
        //        {
        //            _ambushTriggered = true;

        //            GameManager.enemyRiderList.Clear();
        //            GameManager.enemyRiderList.Add(new EnemyRider("Slasher",        44,  5, 10, 'k', 25, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
        //            GameManager.enemyRiderList.Add(new EnemyRider("Crasher",         3, 12,  8, 'k', 20, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
        //            GameManager.enemyRiderList.Add(new EnemyRider("Harrier",        13,  3, 12, 'k', 30, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
        //            GameManager.enemyRiderList.Add(new EnemyRider("PackAlphaNasty", 39, 15, 15, 'K', 200, ConsoleColor.DarkYellow, ConsoleColor.Magenta, (1, 55), (1, 24)));

        //            //Console.SetCursorPosition(60, 0);
        //            //Console.WriteLine("here comes a new challenger");
        //            Console.ReadKey(true);
        //            Console.Beep(); // Audio cue for the ambush

        //        }
        //    }
        //    foreach (var enmyRide in GameManager.enemyRiderList)
        //    {
        //        if (enmyRide._health > 0) // Only draw if alive
        //        {
        //            Console.SetCursorPosition(enmyRide._x, enmyRide._y);
        //            Console.ForegroundColor = enmyRide._fgColor;
        //            Console.BackgroundColor = enmyRide._bgColor;
        //            Console.Write(enmyRide._symbol);
        //        }
        //    }
        //    UpdateRiders();
        //}

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


