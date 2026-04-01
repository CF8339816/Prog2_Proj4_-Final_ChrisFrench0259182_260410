using Prog2_Proj4_Final_ChrisFrench0259182_260410;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
 public class RecTrig : rectangle
    {


        public static bool IsTriggered = false;

        public RecTrig(string Name, int Rect_min_x, int Rect_max_x, int Rect_min_y, int Rect_max_y, bool IsTriggered) : 
            base (Name, Rect_min_x,  Rect_max_x,  Rect_min_y, Rect_max_y, IsTriggered)
        {
            IsTriggered = false;
           
        }

       // public static void ActivateTrigger()
              public  void ActivateTrigger()
        {


            if (GameManager.player._x >= _min_x || GameManager.player._y >= _min_y)
            {
                _isTriggered = true;

            }
            else
            {
                _isTriggered = false;
            }

        }





    }
    
}







