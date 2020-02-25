namespace DesignPatterns
{
    
    public class Fighter : Spacecraft
    {
        
    
        private void Update() 
        {
            
            movingBehaviour.Move(this, parameters.Speed);



        }

        
    }
}