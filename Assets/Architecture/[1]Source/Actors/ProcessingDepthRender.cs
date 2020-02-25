//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;

public class ProcessingDepthRender : ProcessingBase, ITick
{
    private Group<DataDepth> group_depth;

    public void Tick()
    {
        for (var i = 0; i < group_depth.length; i++)
        {
            var index = group_depth.entities[i];
            var actor = this.GetEntity(index);

            var pos = actor.selfTransform.position;
            pos.z = pos.y - DataDepth.size_default - group_depth.component[i].size;
            actor.selfTransform.position = pos;
        }
    }
}