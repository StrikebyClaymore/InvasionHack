using System;
using UnityEngine;
using Assets.Scripts.Factory;
using Assets.Scripts.Projectiles;

namespace Assets.Scripts.Managers
{
    public class ProjectilesManager : MonoBehaviour
    {
        [SerializeField]
        private ProjectileFactory projectileFactory = default;

        private void Awake()
        {
            projectileFactory.transform = transform;
        }

        public void SpawnProjectile(Vector3 pos, Quaternion rot, ProjectileData data)
        {
            var projectile = projectileFactory.Get(data.type);
            projectile.Spawn(pos, rot, data);
        }
    }
}
