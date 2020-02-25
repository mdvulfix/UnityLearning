using UnityEngine;

namespace Homebrew
{
    [CreateAssetMenu(fileName = "factory_monsters", menuName = "Actors/Factories/FactoryMonsters")]
    public class FactoryMonsters : Factory
    {
        public GameObject prefab_monster;


        public Transform SpawnMonster()
        {
            return this.Populate(Pool.Entities, prefab_monster);
        }
    }
}