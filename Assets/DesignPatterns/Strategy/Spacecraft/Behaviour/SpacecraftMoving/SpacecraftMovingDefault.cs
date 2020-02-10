using UnityEngine;

namespace DesignPatterns
{
    public class SpacecraftMovingDefault : SpacecraftMovingBase, ISpacecraftMovable
    {
        public int Speed {get; private set;}
        
        #region Constructors
        public SpacecraftMovingDefault(ISpacecraft spacecraft, int speed = 100)
        {
            SetSpacecraftInstance(spacecraft);
            this.Speed = speed;
            
        }
        #endregion
        



        public void Move()
        {
            Debug.Log("Moving with speed: " + Speed + " a.u.");
            Spacecraft _sc = spacecraft as Spacecraft;
            _sc.transform.Translate(new Vector3(0, 0, Speed) * Time.deltaTime);

        }
        
    }
}



