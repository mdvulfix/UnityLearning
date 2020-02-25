using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns
{
    [System.Serializable]
    public abstract class ASpacecraft : MonoBehaviour
    {

        protected ISpacecraftParameters parameters;
        protected ISpacecraftMove movingBehaviour;

        public ASpacecraft()
        {
            parameters = new SpacecraftParametersDefault();
            movingBehaviour = new SpacecraftMoveDefault();
        }



        //Behaviour
        public void SetMovingBehaviour(ISpacecraftMove movingBehaviour)
        {
            this.movingBehaviour = movingBehaviour;
        }
 
        public ISpacecraftMove GetMovingBehaviour()
        {
            return this.movingBehaviour;
        }
        
        
        //Parameters
        public void SetParameters(ISpacecraftParameters parameters)
        {
            this.parameters = parameters;
        }
  
        public ISpacecraftParameters GetParameters()
        {
            return this.parameters;
        }






    }

}



