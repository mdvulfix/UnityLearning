namespace DesignPatterns
{
    
    public class Scout : Spacecraft
    {
        
        
        
        #region Constractor
        public Scout()
        {
            parameters = new SpacecraftParametersDefault(this);
            movingBehaviour = new SpacecraftMovingDefault(this, parameters.Speed);
        }   
        #endregion

        private void Update() 
        {
            
            movingBehaviour.Move();



        }

        
    }
}