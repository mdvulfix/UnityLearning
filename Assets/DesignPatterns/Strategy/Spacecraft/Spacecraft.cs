using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns
{
    public abstract class Spacecraft
    {

        protected IMovable movingBehaviour;
        
        #region Constructors
        public Spacecraft()
        {
            movingBehaviour = new MovingStandart();
        }
        #endregion
        
        public void Move()
        {
            movingBehaviour.Move();

        }

        public IMovable GetMovingBehaviour()
        {
            return movingBehaviour;
        }

    }

}



