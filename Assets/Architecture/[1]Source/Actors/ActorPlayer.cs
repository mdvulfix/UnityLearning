//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;

public class ActorPlayer : Actor
{
    [FoldoutGroup("Setup")] public DataDepth dataDepth;
    [FoldoutGroup("Setup")] public DataMove dataMove;
    [FoldoutGroup("Setup")] public DataCreature dataCreature;
    [FoldoutGroup("Setup")] public DataWeapon dataWeapon;
    [FoldoutGroup("Setup")] public TagNode[] tagsToAdd;

    protected override void Setup()
    {
        BindTags();

        Add(dataMove);
        Add(dataCreature);
        Add(dataWeapon);
        Add(dataDepth);

        BindComposiiton()
            .TagsExclude(Tag.StateKiiled)
            .Add<BehaviorInput>()
            .Add<BehaviorMove>()
            .Add<BehaviorShoot>();


        BindComposiiton()
            .TagsInclude(Tag.StateLookUp)
            .Add(HandleDecorateBack);

        this.AddTags(tagsToAdd);
    }


    protected override void HandleEnable()
    {
        ScriptCreature.HandleAppearWithGun(dataCreature, dataWeapon);
    }

    private void HandleDecorateBack(bool is_on)
    {
        dataCreature.sr_back.enabled = is_on;


        if (is_on)
        {
            dataWeapon.tr_muzzle.localPosition = new Vector3(0, 0, 0);
            dataWeapon.sr_muzzle.sortingOrder = -2;
        }
        else
        {
            dataWeapon.tr_muzzle.localPosition = new Vector3(0, -0.1f, -0.01f);
            dataWeapon.sr_muzzle.sortingOrder = 0;
        }
    }
}