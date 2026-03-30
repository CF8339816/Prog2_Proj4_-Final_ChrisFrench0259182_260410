using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Prog2_Proj4_Final_ChrisFrench0259182_260410
{
    public class CollectSpawner

    {
       
       

        public CollectSpawner()
        { }

        public static void SetupMapAssets()
        {           
            if (GameManager.map._currentMapIndex < 3)
            {
                Treasure.DrawGold();
                Captive.DrawPrisoner();
                PowerOrb.DrawPowerOrb();
                //Peons.DrawPeon();   
            }
        }

    }

        
        
}
        
      
    