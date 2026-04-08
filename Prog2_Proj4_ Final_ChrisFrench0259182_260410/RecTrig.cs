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
     

       

        public RecTrig(string Name, int Rect_min_x, int Rect_max_x, int Rect_min_y, int Rect_max_y, bool IsTriggered) : 
            base ("trig", 1,  13, 1, 8, false)
        {
           
        }

       // public static void ActivateTrigger()
              public  void ActivateTrigger()
        {


            if (GameManager.player._x > _max_x || GameManager.player._y > _max_y)
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







