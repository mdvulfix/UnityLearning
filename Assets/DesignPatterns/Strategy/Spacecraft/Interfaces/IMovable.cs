using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DesignPatterns
{
    
    public interface IMovable
    {
        
        int Speed {get; }
        
        void Move();
        void SetSpeed(int speed);


    }

}
