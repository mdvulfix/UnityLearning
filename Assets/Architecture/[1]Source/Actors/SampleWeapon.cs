using UnityEngine;

namespace Homebrew
{
    [CreateAssetMenu(fileName = "sample_weapon", menuName = "Actors/Samples/SampleWeapon")]
    public class SampleWeapon : Sample
    {
        public GameObject prefab_bullet;

        public void Shoot(int speed, Vector3 position, Quaternion rotation)
        {

            for (var i = 0; i < 1; i++)
            {
                var obj = this.Populate(Pool.Projectiles, prefab_bullet, position, rotation);
           
                var entity = ProcessingEntities.AddEntity();
      
                var dataBullet = new DataBullet();
                dataBullet.speed = speed;
                dataBullet.tr = obj;
                Storage<DataBullet>.Instance.AddVirtual(dataBullet, entity);

               
                
                
            }
            
             
        }
    }
}