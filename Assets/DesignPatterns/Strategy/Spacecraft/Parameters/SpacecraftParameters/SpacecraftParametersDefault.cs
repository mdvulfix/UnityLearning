using UnityEngine;

namespace DesignPatterns
{

    public class SpacecraftParametersDefault : SpacecraftParametersBase, ISpacecraftParameters
    {
        
        public int Speed {get; protected set;} // Скорость
        public int Strength {get; protected set;} // Прочность
        
        #region Constructors

        public SpacecraftParametersDefault(ISpacecraft spacecraft, int speed = 50 , int strength = 100)
        {
            this.Speed = speed;
            this.Strength = strength;
            SetSpacecraftInstance(spacecraft);

        }
        #endregion

        

    }
}