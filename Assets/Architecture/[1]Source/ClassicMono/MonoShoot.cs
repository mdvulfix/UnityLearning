//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018


using UnityEngine;

public class MonoShoot : MonoBehaviour
{
    public GameObject prefab_bullet;

    private SpriteRenderer sr;
    private MonoCreature monoCreature;

    private bool is_facingUp;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        monoCreature = GetComponentInParent<MonoCreature>();
    }

    private void Update()
    {
        if (Camera.main==null) return;
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var rotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, 0, rotation);

        if (!sr.flipY && Mathf.Abs(rotation) > 90 || sr.flipY && Mathf.Abs(rotation) <= 90)
            sr.flipY = !sr.flipY;

        if (monoCreature.face_up && !is_facingUp)
        {
            is_facingUp = true;
            transform.localPosition = new Vector3(0, 0, 0);
            sr.sortingOrder = -2;
        }
        else if (!monoCreature.face_up && is_facingUp)
        {
            is_facingUp = false;
            transform.localPosition = new Vector3(0, -0.1f, -0.01f);
            sr.sortingOrder = 0;
        }


        if (Input.GetMouseButtonDown(0))
        {
            var obj = Instantiate(prefab_bullet,transform.position, transform.rotation);
            obj.GetComponent<MonoBullet>().Setup(40);
        }
    }
}