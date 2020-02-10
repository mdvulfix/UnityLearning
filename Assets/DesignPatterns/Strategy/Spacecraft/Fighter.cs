namespace DesignPatterns
{
    
    public class Fighter : Spacecraft
    {
        
        
        
        #region Constractor
        public Fighter()
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