using System;
using UnityEngine;
using Assets.Scripts.Projectiles;

namespace Assets.Scripts.Factory
{
    [CreateAssetMenu(fileName = "ProjectileFactory", menuName = "ProjectileFactory", order = 51)]
    public class ProjectileFactory : GameObjectFactory
    {
        public enum  Projectiles { Base, Sick, Epic }
        
        public Projectile Get(Projectiles type)
        {
            Projectile instance = null;
            switch (type)
            {
                case Projectiles.Base:
                    instance = CreateGameObjectInstance(Get<Projectile>(0));
                    break;
                default:
                    throw new ArgumentNullException(nameof(instance));
            }
            
            instance.OriginFactory = this;
            return instance;
        }

        public void Reclaim(Projectile projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}
