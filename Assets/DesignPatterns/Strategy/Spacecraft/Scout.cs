using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns
{
    
    public class Scout : Spacecraft
    {
        
        #region Constractor
        public Scout()
        {
            movingBehaviour = new MovingStandart();
        }   
        #endregion

        
    }
}