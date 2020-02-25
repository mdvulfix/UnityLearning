//   Project : Actors-Example
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/24/2018

using Homebrew;
using TMPro;
using UnityEngine;
using Time = UnityEngine.Time;

public class ProcessingGame : ProcessingBase, ITick, IReceive<SignalScore>
{
    [Bind(From.Toolbox)] private FactoryMonsters factory;
    [Bind(From.Toolbox)] private DataGameSession dataGameSession;

    private float t;
    private int stage;
    private int amount = 1;

    private TextMeshProUGUI label_score;
    private TextMeshProUGUI label_enemies;

    [GroupBy(Tag.GroupEnemy)] private Group group_enemies;


    public ProcessingGame()
    {
        label_score = GameObject.Find("[CANVAS]/label_score").GetComponent<TextMeshProUGUI>();
        label_enemies = GameObject.Find("[CANVAS]/label_enemies").GetComponent<TextMeshProUGUI>();

        group_enemies.OnAdded += OnAdd;
        group_enemies.OnRemoved += OnRemove;
    }


    void OnAdd(int index)
    {
        label_enemies.text = "enemies: " + group_enemies.length;
    }

    void OnRemove(int index)
    {
        label_enemies.text = "enemies: " + group_enemies.length;
    }


    public void Tick()
    {
        if (!(Time.time - t > Time.deltaTime * 500)) return;

        for (var i = 0; i < amount; i++)
        {
            var pos = Random.insideUnitCircle * 5;
            var obj = factory.SpawnMonster();
            obj.position = pos;
        }


        t = Time.time;
        stage++;

        if (stage % 10 == 0)
            amount++;
    }

    public void HandleSignal(SignalScore arg)
    {
        dataGameSession.score++;
        label_score.text = dataGameSession.score.ToString();
    }
}