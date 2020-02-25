//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;
using Time = Homebrew.Time;

public class BehaviorMove : Behavior, ITick
{
    protected override void OnTick(Actor actor)
    {
        var data = actor.Get<DataMove>();
        if (data.direction == Vector2.zero)
            data.speed_actual = Mathf.Max(0, data.speed_actual -= Time.DeltaTime * 100);
        else data.speed_actual = Mathf.Min(data.speed_actual += Time.DeltaTime * 15, data.speed_max);

        if (actor.selfTransform == null) return;
        var pos = actor.selfTransform.position;

        var dir_actual = data.direction * data.speed_actual * Time.DeltaTime;
        var y = data.direction.x != 0 && data.direction.y != 0 ? 0.75f : 1;
        dir_actual *= y;

        pos.x += dir_actual.x;
        pos.y += dir_actual.y;

        actor.selfTransform.position = pos;

        if (data.direction.y > 0 && !actor.HasTag(Tag.StateLookUp))
        {
            actor.AddTags(Tag.StateLookUp);
          
        }
        else if (data.direction.y < 0 && actor.HasTag(Tag.StateLookUp))
        {
            actor.RemoveTags(Tag.StateLookUp);
           
        }
    }
}