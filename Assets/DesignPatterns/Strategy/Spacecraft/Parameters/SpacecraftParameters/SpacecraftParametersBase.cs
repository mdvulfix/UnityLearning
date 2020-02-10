namespace DesignPatterns
{
    public abstract class SpacecraftParametersBase
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