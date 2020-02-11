using System;
using UnityEngine;

namespace DesignPatterns
{
    [System.Serializable]
    public class Spacecraft : ASpacecraft, ISpacecraft
    {
        
        [SerializeField] int speed;
        
        #region Constractor
        public Spacecraft()
        {
            this.speed = parameters.Speed;
        }   
        #endregion

        
    }
}