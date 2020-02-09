using UnityEngine;

namespace DesignPatterns
{
    public class MovingStandart : IMovable
    {
        public int Speed {get; private set;}
        
        #region Constructors
        public MovingStandart()
        {
            Speed = 100;
        }
        public MovingStandart(int speed)
        {
            SetSpeed(speed);
        }
        #endregion
        
        public void Move()
        {
            Debug.Log("Moving with speed: " + Speed + " a.u.");

        }
        
        public void SetSpeed(int speed)
        {
            Speed = speed;

        }


    }
}



