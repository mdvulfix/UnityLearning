using UnityEngine;

namespace DesignPatterns
{
    
    public interface ISpacecraftMove
    {
        
        void Move(ISpacecraft spacecraft, int speed);
        

    }

}
