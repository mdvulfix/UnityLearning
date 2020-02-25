//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using DG.Tweening;
using Homebrew;
using UnityEngine;

[System.Serializable]
public class DataCreature : IData
{
    public SpriteRenderer sr_creature;
    public SpriteRenderer sr_shadow;
    public SpriteRenderer sr_back;
    
    public Tween tw1;
    public Tween tw2;
    public Tween tw3;
    
}