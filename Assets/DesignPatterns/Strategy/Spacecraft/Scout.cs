namespace DesignPatterns
{
    
    public class Scout : Spacecraft
    {
        
        public Scout()
        {
            parameters = new ScoutParameters();

        }


        private void Update() 
        {
            
            movingBehaviour.Move(this, parameters.Speed);



        }

        
    }
}