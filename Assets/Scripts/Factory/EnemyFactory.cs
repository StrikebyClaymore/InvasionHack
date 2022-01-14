using System;
using Assets.Scripts.Mobs.Enemies;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "EnemyFactory", order = 51)]
    public class EnemyFactory : GameObjectFactory
    {
        public enum  Enemies { Base, Base2, SimpleCube }
        
        public Enemy Get(Enemies type)
        {
            Enemy instance = null;
            switch (type)
            {
                case Enemies.Base:
                    instance = CreateGameObjectInstance(Get<Enemy>(0));
                    break;
                case Enemies.Base2:
                    instance = CreateGameObjectInstance(Get<Enemy>(1));
                    break;
                case Enemies.SimpleCube:
                    instance = CreateGameObjectInstance(Get<Enemy>(2));
                    break;
                default:
                    throw new ArgumentNullException(nameof(instance));
            }
            
            instance.OriginFactory = this;
            return instance;
        }

        public void Reclaim(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }

        public Enemy Get(int type)
        {
            Enemy instance = CreateGameObjectInstance(Get<Enemy>(type));
            instance.OriginFactory = this;
            return instance;
        }
    }
}
