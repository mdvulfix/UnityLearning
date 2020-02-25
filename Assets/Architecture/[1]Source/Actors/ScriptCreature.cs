//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/25/2018

using DG.Tweening;
using Homebrew;
using UnityEngine;

public class ScriptCreature
{
    public static void HandleAppear(DataCreature data)
    {
         
        data.sr_creature.color = data.sr_creature.color.SetColorAlpha(0);
        data.sr_back.color = data.sr_back.color.SetColorAlpha(0);
        data.sr_shadow.color = data.sr_shadow.color.SetColorAlpha(0);
        var color = data.sr_creature.color;
        data.tw1 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
            .OnUpdate(() => data.sr_creature.color = color);
        color = data.sr_back.color;
        data.tw2 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
            .OnUpdate(() => data.sr_back.color = color);
        color = data.sr_shadow.color;
        data.tw3 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 0.5f, duration: 0.6f)
            .OnUpdate(() => data.sr_shadow.color = color);
    }

    public static void HandleAppearWithGun(DataCreature data, DataWeapon dataW)
    {
        dataW.sr_muzzle.color = dataW.sr_muzzle.color.SetColorAlpha(0);
        data.sr_creature.color = data.sr_creature.color.SetColorAlpha(0);
        data.sr_back.color = data.sr_back.color.SetColorAlpha(0);
        data.sr_shadow.color = data.sr_shadow.color.SetColorAlpha(0);

        var color = data.sr_creature.color;
        data.tw1 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
            .OnUpdate(() => data.sr_creature.color = color);
        color = data.sr_back.color;
        data.tw2 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
            .OnUpdate(() => data.sr_back.color = color);
        color = data.sr_shadow.color;
        data.tw3 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 0.5f, duration: 0.6f)
            .OnUpdate(() => data.sr_shadow.color = color);
        data.tw3 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 0.5f, duration: 0.6f)
            .OnUpdate(() => data.sr_shadow.color = color);

        color = dataW.sr_muzzle.color;
        DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1f, duration: 0.6f)
            .OnUpdate(() => dataW.sr_muzzle.color = color);
    }
}