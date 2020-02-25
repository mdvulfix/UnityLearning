//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;
 

public class BehaviorAI_Follow : Behavior, ITick
{
    [GroupBy(Tag.GroupPlayer)] private Group group_players;


    protected override void OnTick(Actor actor)
    {
    
        if (group_players.length == 0) return;
        var player = group_players.From(0);
        var delta = player.selfTransform.position - actor.selfTransform.position;
        var dataMove = actor.Get<DataMove>();
        dataMove.direction = delta.normalized;
   
        if (delta.sqrMagnitude < 12 && !actor.HasTag(Tag.StateAttacking))
        {
     
            actor.AddTag(Tag.StateAttacking);
        }
        else if (delta.sqrMagnitude >= 14 && actor.HasTag(Tag.StateAttacking))
        {
            actor.RemoveTags(Tag.StateAttacking);
        }
    }
}