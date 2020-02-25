//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018


using DG.Tweening;
using Homebrew;
using UnityEngine;
using Time = Homebrew.Time;

public class MonoCreature : MonoBehaviour
{
    public SpriteRenderer sr_creature;
    public SpriteRenderer sr_shadow;
    public SpriteRenderer sr_back;

    public Vector2 direction;

    public float speed_actual;
    public float speed_max;


    public bool isAI;
    public Transform target;


    public bool face_up;
    public bool state_dead;

    private bool isAttacking;
    private Tween tw1;
    private Tween tw2;
    private Tween tw3;

    private void Start()
    {
        if (isAI)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }


    private void OnEnable()
    {
//        sr_creature.color = sr_creature.color.SetColorAlpha(0);
//        sr_back.color = sr_back.color.SetColorAlpha(0);
//        sr_shadow.color = sr_shadow.color.SetColorAlpha(0);
//        var color = sr_creature.color;
//        tw1 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
//            .OnUpdate(() => sr_creature.color = color);
//        color = sr_back.color;
//        tw2 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
//            .OnUpdate(() => sr_back.color = color);
//        color = sr_shadow.color;
//        tw3 = DOTween.To(getter: () => color.a, setter: x => color.a = x, endValue: 1.0f, duration: 0.6f)
//            .OnUpdate(() => sr_shadow.color = color);

        if (isAI)
            MonoGameManager.Instance.AddMonster(true);
    }

    private void OnDisable()
    {
      //  tw1.Kill();
      //  tw2.Kill();
       // tw3.Kill();

        if (isAI)
            MonoGameManager.Instance.AddMonster(false);
    }


    private void Update()
    {
        if (state_dead) return;
        HandleAI();
        HandleMove();

        // render_back
        sr_back.enabled = face_up;
    }

    private void HandleAI()
    {
        if (!isAI) return;
        var delta = target.position - transform.position;
        direction = delta.normalized;

        if (!isAttacking && delta.sqrMagnitude < speed_actual * 3)
        {
            isAttacking = true;
            sr_creature.color = new Color(1, 0.25f, 0.25f, 1);
            sr_back.color = sr_creature.color;
            speed_max = 3.5f;
        }
        else if (isAttacking && delta.sqrMagnitude >= speed_actual * 3)
        {
            isAttacking = false;
            sr_creature.color = Color.white;
            sr_back.color = sr_creature.color;
            speed_max = 2.5f;
        }
    }

    private void HandleMove()
    {
        if (direction == Vector2.zero)
            speed_actual = Mathf.Max(0, speed_actual -= Time.DeltaTime * 100);
        else speed_actual = Mathf.Min(speed_actual += Time.DeltaTime * 15, speed_max);


        var pos = transform.position;

        var dir_actual = direction * speed_actual * Time.DeltaTime;
        var y = direction.x != 0 && direction.y != 0 ? 0.75f : 1;
        dir_actual *= y;

        pos.x += dir_actual.x;
        pos.y += dir_actual.y;

        transform.position = pos;

        if (direction.y > 0 && !face_up)
            face_up = true;
        else if (direction.y < 0 && face_up)
            face_up = false;
    }
}