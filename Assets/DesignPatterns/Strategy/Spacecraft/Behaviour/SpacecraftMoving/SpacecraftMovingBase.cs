using UnityEngine;

namespace DesignPatterns
{
    public abstract class SpacecraftMovingBase
    {
        protected ISpacecraft spacecraft;

         public void SetSpacecraftInstance(ISpacecraft spacecraft)
        {
            this.spacecraft = spacecraft;
        }

        public ISpacecraft GetSpacecraftInstance()
        {
            return this.spacecraft;
        }




    }
}



