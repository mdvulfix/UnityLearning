//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using System.Collections;
using Homebrew;
using UnityEngine;

public class MonoDamageble : MonoBehaviour
{
    public void Kill()
    {
        if (GetComponent<MonoCreature>().state_dead) return;
        StartCoroutine(_Kill());
    }

    IEnumerator _Kill()
    {
        MonoGameManager.Instance.UpdateScore();
        GetComponent<MonoCreature>().state_dead = true;
        GetComponent<Animator>().Play("anim_creature_death");
        yield return new WaitForSeconds(0.48f);
        Destroy(gameObject);
    }
}