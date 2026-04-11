
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
        public static bool isTriggered = false;

        public static void CheckForAmbush()
        {

            if (GameManager.map._currentMapIndex == 3 && !isTriggered) //sets this to run on map 3 only  and only if not alreacdy active
            {
                AmbushTriggered();
            }
        }




             public static void AmbushTriggered()
              { 
                
                if ((GameManager.map._mapsCurrent[GameManager.player._y][GameManager.player._x] == '`'))// defines trigger location for event to begin
                {
                    isTriggered = true;

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
            if (isTriggered)
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


///  will need to figure out the issue witht he rectangle trigger when I have more time and have not been awake for 36 + hours

//    public class MyEvents
//    {
//       //public static bool _ambushTriggered = false;
//        public static bool isTriggered = false;

//            public static RecTrig recTrig = new RecTrig("trig", 0, 13,  0, 8, false);

//        public static void CheckForAmbush()
//        {
//            if (GameManager.map._currentMapIndex == 3 && !isTriggered)
//                //if (GameManager.map._currentMapIndex == 3 && !_ambushTriggered)
//            {
//                if (GameManager.player._x <= recTrig._max_x && GameManager.player._y <= recTrig._max_y)
//                {
//                    //_ambushTriggered = false;
//                    isTriggered= false;
//                }
//            }
//            else
//            {
//                //_ambushTriggered = true;
//                //isTriggered= false;
//                AmbushTriggered();
//            }

//        //AmbushTriggered();
//        }
//        public static void AmbushTriggered()
//        {
//            //if (isTriggered)
//            //{
//            //    return;
//            //}

//            if (GameManager.map._currentMapIndex == 3)
//            {

//                //recTrig.ActivateTrigger();

//                GameManager.enemyRiderList.Clear();
//                GameManager.enemyRiderList.Add(new EnemyRider("Slasher", 44, 5, 10, 'k', 25, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
//                GameManager.enemyRiderList.Add(new EnemyRider("Crasher", 3, 12, 8, 'k', 20, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
//                GameManager.enemyRiderList.Add(new EnemyRider("Harrier", 13, 3, 12, 'k', 30, ConsoleColor.Yellow, ConsoleColor.DarkMagenta, (1, 55), (1, 24)));
//                GameManager.enemyRiderList.Add(new EnemyRider("PackAlphaNasty", 39, 15, 15, 'K', 200, ConsoleColor.DarkYellow, ConsoleColor.Magenta, (1, 55), (1, 24)));

//               // Console.ReadKey(true);
//                Console.Beep(); // Audio cue for the ambush

//                //isTriggered = true;

//            }
//            foreach (var enmyRide in GameManager.enemyRiderList)
//            {
//                if (enmyRide._health > 0) // Only draw if alive
//                {
//                    Console.SetCursorPosition(enmyRide._x, enmyRide._y);
//                    Console.ForegroundColor = enmyRide._fgColor;
//                    Console.BackgroundColor = enmyRide._bgColor;
//                    Console.Write(enmyRide._symbol);
//                   // Console.ResetColor();
//                }
//            }
//          //  UpdateRiders();
//        }

//        public static void UpdateRiders()
//        {
//            // Only move riders if the ambush has started
//            if (GameManager.map._currentMapIndex == 3 && isTriggered)
//                //if (_ambushTriggered)
//            {
//                foreach (var enmyRide in GameManager.enemyRiderList)
//                {
//                    if (enmyRide._health > 0) //verifies enemy alive before move
//                    {
//                       Console.SetCursorPosition(enmyRide._x, enmyRide._y);
//                        Console.ForegroundColor = enmyRide._fgColor;
//                        Console.BackgroundColor = enmyRide._bgColor;
//                        Console.Write(enmyRide._symbol);

//                        EnemyRider.MoveTowards(enmyRide); //  move towards rather than randopm 
//                    }

//                }
//            }
//        }
//    }
//}


