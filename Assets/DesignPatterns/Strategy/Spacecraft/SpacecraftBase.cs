using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns
{
    [System.Serializable]
    public abstract class SpacecraftBase : MonoBehaviour
    {

        protected ISpacecraftParameters parameters;
        protected ISpacecraftMovable movingBehaviour;

        //Behaviour
        public void SetMovingBehaviour(ISpacecraftMovable movingBehaviour)
        {
            this.movingBehaviour = movingBehaviour;
        }
 
        public ISpacecraftMovable GetMovingBehaviour()
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



