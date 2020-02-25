//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using DG.Tweening;
using Homebrew;
using UnityEngine;

public class ActorCreature : Actor, IPoolable
{
    [FoldoutGroup("Setup")] public DataDepth dataDepth;
    [FoldoutGroup("Setup")] public DataMove dataMove;
    [FoldoutGroup("Setup")] public DataCreature dataCreature;
    [FoldoutGroup("Setup")] public TagNode[] tagsToAdd;


    protected override void Setup()
    {
        BindTags();

        Add(dataMove);
        Add(dataCreature);
        Add(dataDepth);

        BindComposiiton()
            .TagsExclude(Tag.StateKiiled)
            .Add<BehaviorMove>()
            .Add<BehaviorAI_Follow>();

        BindComposiiton()
            .TagsInclude(Tag.StateLookUp)
            .Add(HandleDecorateBack);


        BindComposiiton()
            .TagsInclude(Tag.StateKiiled)
            .Add(HandleKill);


        BindComposiiton()
            .TagsInclude(Tag.StateAttacking)
            .Add(HandleRage);

        this.AddTags(tagsToAdd);
    }


    private void HandleDecorateBack(bool is_on)
    {
        dataCreature.sr_back.enabled = is_on;
    }

    private void HandleKill(bool is_on)
    {
        if (!is_on) return;

        dataCreature.sr_back.enabled = false;
        GetComponent<Animator>().Play("anim_creature_death");
        Timer.Add(0.48f, () => { HandleDestroy(); });
        SignalScore signal;
        ProcessingSignals.Send(signal);
    }

    private void HandleRage(bool is_on)
    {
        if (is_on)
        {
            dataCreature.sr_creature.color = new Color(1, 0.25f, 0.25f, 1);
            dataCreature.sr_back.color = dataCreature.sr_creature.color;
            dataMove.speed_max = 3.5f;
        }
        else
        {
            dataCreature.sr_creature.color = Color.white;
            dataCreature.sr_back.color = dataCreature.sr_creature.color;
            dataMove.speed_max = 2.5f;
        }
    }

    /// <summary>
    /// condition spawned = false when obj despawned
    /// condition spawned = true when obj created from pool
    /// </summary>
    /// <param name="condition_spawned"></param>
    public void Spawn(bool condition_spawned)
    {
        if (condition_spawned)
        {
            this.AddTags(tagsToAdd);
        }
    }
}