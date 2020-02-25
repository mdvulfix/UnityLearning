//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

 
using UnityEngine;

public class MonoInput : MonoBehaviour
{
    public MonoCreature monoCreature;

    private void Awake()
    {
        monoCreature = GetComponent<MonoCreature>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        monoCreature.direction = new Vector2(x, y);
    }
}