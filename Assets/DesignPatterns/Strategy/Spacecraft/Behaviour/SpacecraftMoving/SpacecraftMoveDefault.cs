using UnityEngine;

namespace DesignPatterns
{
    public class SpacecraftMoveDefault : ASpacecraftMove, ISpacecraftMove
    {
 
        public void Move(ISpacecraft spacecraft, int speed)
        {
            Debug.Log("Moving with speed: " + speed + " a.u.");
            Spacecraft _sc = spacecraft as Spacecraft;
            _sc.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
 
        }
        
    }
}



