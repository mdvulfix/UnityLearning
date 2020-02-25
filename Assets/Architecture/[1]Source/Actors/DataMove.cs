//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;

[System.Serializable]
public class DataMove : IData
{
    public Vector2 direction;
    public float speed_actual;
    public float speed_max;
}