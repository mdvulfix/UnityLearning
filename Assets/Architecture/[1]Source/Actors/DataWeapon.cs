//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;

[System.Serializable]
public class DataWeapon : IData
{
    public Transform tr_muzzle;
    public SpriteRenderer sr_muzzle;
    public SampleWeapon sample_weapon;
}