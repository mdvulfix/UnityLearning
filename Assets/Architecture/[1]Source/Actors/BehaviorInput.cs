//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;

public class BehaviorInput : Behavior, ITick
{
    protected override void OnTick(Actor actor)
    {
        var data = actor.Get<DataMove>();
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        data.direction = new Vector2(x, y);
    }
}