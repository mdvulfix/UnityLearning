//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;

public class StarterGame : Starter
{
    protected override void Setup()
    {   
        Toolbox.Add<ProcessingDepthRender>();
        Toolbox.Add<ProcessingBullets>();
        Toolbox.Add<ProcessingGame>();
    }
}