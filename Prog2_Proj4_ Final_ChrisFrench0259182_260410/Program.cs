using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{

    //public class Program
    class Program
    {
        public static void Main(string[] args)
        {
            bool replay = true;

            while (replay)
            {
                GameManager.StartGame();

                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.R)
                {
                    GameManager.isPlaying = true;
                    replay = true;
                    GameManager.Restart();
                    return;
                }
                if (input != ConsoleKey.R)
                {
                    replay = false; 
                }
                Console.Clear();

            }

            //GameManager.StartGame();


        }




       
    }
}


