//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using System.Collections.Generic;
using UnityEngine;

public class MonoDepthRenderer : MonoBehaviour
{
    public const float default_size = 1;

    public float size = 0.5f;


    private void Update()
    {
        var pos = transform.position;
        pos.z = pos.y - default_size - size;
        transform.position = pos;
    }
}