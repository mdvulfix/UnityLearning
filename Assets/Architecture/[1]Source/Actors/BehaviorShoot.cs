//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;

public class BehaviorShoot : Behavior, ITick
{
    protected override void OnTick(Actor actor)
    {
        var data = actor.Get<DataWeapon>();
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - actor.selfTransform.position;
        var rotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        data.tr_muzzle.localEulerAngles = new Vector3(0, 0, rotation);

        if (!data.sr_muzzle.flipY && Mathf.Abs(rotation) > 90 || data.sr_muzzle.flipY && Mathf.Abs(rotation) <= 90)
            data.sr_muzzle.flipY = !data.sr_muzzle.flipY;


        if (Input.GetMouseButtonDown(0))
        {
            data.sample_weapon.Shoot(40, data.tr_muzzle.position, data.tr_muzzle.rotation);
        }
    }
}