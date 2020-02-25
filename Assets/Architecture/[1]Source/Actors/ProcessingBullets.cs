//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using UnityEngine;
using Time = Homebrew.Time;

public class ProcessingBullets : ProcessingBase, ITick
{
    private Group<DataBullet> group_bullets;

    private float t;


    public void Tick()
    {
        var condition_check = false;
        if (UnityEngine.Time.time - t > Time.DeltaTime * 5)
        {
            condition_check = true;
            t = UnityEngine.Time.time;
        }

        for (var i = 0; i < group_bullets.length; i++)
        {
            var bullet = group_bullets.component[i];

            bullet.tr.position += bullet.tr.right * bullet.speed * Time.DeltaTime;
            bullet.speed = Mathf.Max(0, bullet.speed -= Time.DeltaTime * 150);

            if (bullet.speed == 0)
                HandleDestroyBullet(bullet, i);
            else
            if (condition_check)
                HandleCheck(bullet, i);
        }
    }

    void HandleCheck(DataBullet bullet, int index)
    {
        var hits = Physics2D.CircleCastNonAlloc(bullet.tr.position, 0.4f, Vector2.zero, ExtGame.hits);
        for (var i = 0; i < hits; i++)
        {
            var hit = ExtGame.hits[i];
            var actor = hit.GetActor();
            if (actor == null || !actor.HasTag(Tag.GroupEnemy)) continue;
            if (actor.HasTag(Tag.StateKiiled)) continue;


            actor.AddTag(Tag.StateKiiled);
            HandleDestroyBullet(bullet, index);
            return;
        }
    }

    void HandleDestroyBullet(DataBullet bullet, int index)
    {
        if (bullet.killed) return;
        bullet.killed = true;
        var entity = group_bullets.entities[index];
        ProcessingGoPool.Default.Despawn(Pool.Projectiles,bullet.tr.gameObject);
        ProcessingEntities.Remove<DataBullet>(entity);
        ProcessingEntities.KillEntity(entity);
    }
}