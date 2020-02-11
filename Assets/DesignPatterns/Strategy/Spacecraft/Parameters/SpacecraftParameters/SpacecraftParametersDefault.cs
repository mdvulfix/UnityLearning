using UnityEngine;

namespace DesignPatterns
{

    public class SpacecraftParametersDefault : ASpacecraftParameters, ISpacecraftParameters
    {
        
        public int Speed {get; protected set;} // Скорость
        public int Strength {get; protected set;} // Прочность
        
        #region Constructors

        public SpacecraftParametersDefault()
        {
            this.Speed = 10;
            this.Strength = 100;
        }
        #endregion

        

    }
}