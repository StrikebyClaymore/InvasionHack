using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.RangeCube
{
    public class RangeCubeAttack : EnemyAttack
    {
        [SerializeField]
        private Transform aim;
        [SerializeField]
        private ProjectileData projectileData;

        private void Update()
        {
            if (Target is null)
                return;
            if (Vector3.Distance(transform.position, Target.transform.position) <= attackDistance)
            {
                Attack();
            }
        }
        
        protected override void Attack()
        {
            if (AttackIsCooldown)
                return;
            transform.LookAt(Target.transform.position);
            GameManager.ProjectilesManager.SpawnProjectile(aim.position, transform.rotation, projectileData);
            AttackIsCooldown = true;
            CoolldownTimer.Enabled = true; 
        }
    }
}
