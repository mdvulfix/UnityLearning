//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using UnityEngine;
using TMPro;

public class MonoGameManager : MonoBehaviour
{

    public static MonoGameManager Instance;
    
    public GameObject prefab_mob;
    public GameObject obj_player;
    public TextMeshProUGUI leib;
    public TextMeshProUGUI leib_enemies;

    private float t;
    private int stage = 0;
    private int amount = 1;

    private int score = 0;
    private int monsters = 0;
    private void Start()
    {
        Instance = this;
        t = Time.time;
        obj_player.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (Time.time - t > Time.deltaTime * 1000)
        {
            for (var i = 0; i < amount; i++)
            {
                var pos = Random.insideUnitCircle * 5;
                Instantiate(prefab_mob, pos, Quaternion.identity);
            }


            t = UnityEngine.Time.time;
            stage++;

            if (stage % 10 == 0)
                amount++;
        }
    }

    public void AddMonster(bool add)
    {
        if (add) monsters++;
        else monsters--;
        leib_enemies.text = "enemies: " + monsters;
    }
    
    public void UpdateScore()
    {
        score++;
        leib.text = score.ToString();
    }
}

 