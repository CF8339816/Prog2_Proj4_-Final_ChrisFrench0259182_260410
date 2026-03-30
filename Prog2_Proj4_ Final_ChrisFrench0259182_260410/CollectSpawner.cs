using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace prog2_Proj3_beta_ChrisFrench0259182_260324
{
    public class CollectSpawner

    {
       
       

        public CollectSpawner()
        { }

        public static void SetupMapAssets()
        {           
            if (Program.map._currentMapIndex < 3)
            {
                Treasure.DrawGold();
                Captive.DrawPrisoner();
                PowerOrb.DrawPowerOrb();
                //Peons.DrawPeon();   
            }
        }

    }

        
        
}
        
      
    