//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using System.Runtime.InteropServices;
using Homebrew;
using UnityEngine;
using Time = Homebrew.Time;

public class MonoBullet : MonoBehaviour
{
    private float speed;
    private float t;

    public void Setup(float speed)
    {
        this.speed = speed;
        t = UnityEngine.Time.time;
    }


    private void Update()
    {
        if (UnityEngine.Time.time - t > Time.DeltaTime * 5)
        {
            Check();
            t = UnityEngine.Time.time;
        }

        transform.position += transform.right * speed * Time.DeltaTime;
        speed = Mathf.Max(0, speed -= Time.DeltaTime * 150);

        if (speed <= Time.DeltaTime)
        {
            Destroy(gameObject);
        }
    }

    void Check()
    {
        var hits = Physics2D.CircleCastNonAlloc(transform.position, 0.4f, Vector2.zero, ExtGame.hits);
        for (var i = 0; i < hits; i++)
        {
            var hit = ExtGame.hits[i];
            var damageble = hit.collider.GetComponent<MonoDamageble>();
            if (damageble)
            {
                damageble.Kill();
                Destroy(gameObject);
                return;
            }
        }
    }
}