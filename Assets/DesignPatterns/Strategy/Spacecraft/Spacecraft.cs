﻿using System;
using UnityEngine;

namespace DesignPatterns
{
    [System.Serializable]
    public class Spacecraft : SpacecraftBase, ISpacecraft
    {
        
        
        [SerializeField] int speed;
        #region Constractor
        public Spacecraft()
        {
            parameters = new SpacecraftParametersDefault(this);
            movingBehaviour = new SpacecraftMovingDefault(this, parameters.Speed);

            this.speed = movingBehaviour.Speed;
        }   
        #endregion

        
    }
}